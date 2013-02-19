import wx
import wx.stc as stc
import os

from highlightSTC import highlightSTC

ID_NEW=101
ID_OPEN=102
ID_SAVE=103
ID_EXECUTE_BUTTON=300

class pnlScript(wx.Frame):
    def __init__(self, parent, id=wx.ID_ANY, name="", pos=(0,0), size=(200, 200)):
        super(pnlScript, self).__init__(parent, id, name=name, pos=pos, size=size, style=0)
        self.console = parent.txtPythonConsole
        self.control = highlightSTC(self)
        # self.control = stc.StyledTextCtrl(self, 1, style=wx.TE_MULTILINE)

        # Set up menu
        filemenu = wx.Menu()
        # use ID_ for future easy reference -- much better than "48", "404", etc.
        # The & character indicates the shortcut key
        filemenu.Append(ID_NEW, "&New", "New file")
        filemenu.Append(ID_OPEN, "&Open", " Open file")
        filemenu.AppendSeparator()        
        filemenu.Append(ID_SAVE, "&Save", " Save file")

        # create the menubar
        menuBar = wx.MenuBar()
        menuBar.Append(filemenu, "&File")
        self.SetMenuBar(menuBar)

        wx.EVT_MENU(self, ID_NEW, self.OnNew)
        wx.EVT_MENU(self, ID_OPEN, self.OnOpen)
        wx.EVT_MENU(self, ID_SAVE, self.OnSave)

        # Set up execute button
        self.sizer2 = wx.BoxSizer(wx.HORIZONTAL)
        self.executeButton = wx.Button(self, ID_EXECUTE_BUTTON, "&Execute")
        self.executeButton.Bind(wx.EVT_BUTTON, self.OnExecute)
        self.sizer2.Add(self.executeButton, 25, wx.ALIGN_LEFT)

        self.sizer = wx.BoxSizer(wx.VERTICAL)        
        self.sizer.Add(self.sizer2, 0, wx.EXPAND)
        self.sizer.Add(self.control, 1, wx.EXPAND)

        self.SetSizer(self.sizer)
        self.SetAutoLayout(1)
        self.sizer.Fit(self)

        self.dirname = ''

    def OnNew(self, e):
        if self.control.GetText() != '':
            self.OnSave(e)

        self.filename = ''
        self.control.SetText('')
        self.SetTitle("Editing a new file")

    def OnOpen(self, e):
        dlg = wx.FileDialog(self, "Choose a file", self.dirname, "", "*.*", wx.OPEN)
        if dlg.ShowModal() == wx.ID_OK:
            self.filename = dlg.GetFilename()
            self.dirname = dlg.GetDirectory()

            # Open the file and set its contents into the edit window
            filehandle = open(os.path.join(self.dirname, self.filename), 'r')
            self.control.SetText(filehandle.read())
            self.control.EmptyUndoBuffer()
            filehandle.close()

            self.SetTitle("Editing: %s" % self.filename)

        dlg.Destroy()

    def OnSave(self, e):
        dlg = wx.FileDialog(self, "Choose a file", self.dirname, "", "*.*", wx.SAVE | wx.OVERWRITE_PROMPT)
        if dlg.ShowModal() == wx.ID_OK:
            saved_text = self.control.GetText()

            self.filename = dlg.GetFilename()
            self.dirname = dlg.GetDirectory()
            filehandle = open(os.path.join(self.dirname, self.filename), 'w')
            filehandle.write(saved_text)
            filehandle.close()

            self.SetTitle("Editing: %s" % self.filename)

        dlg.Destroy()

    def OnExecute(self, e):
        self.OnSave(e)
        filename = os.path.join(self.dirname, self.filename)
        self.console.shell.runfile(filename)


    def getStyle(self, c='black'):
        """
        Returns a style for a given color if one exists. If no style
        exists for the color, make a new style.

        If we run out of styles (only 32 allowed here) we go to the top
        of the list and reuse previous styles.
        """
        free = self._free
        if c and isinstance(c, (str, unicode)):
            c = c.lower()
        else:
            c = 'black'

        try:    
            style = self._styles.index(c)
            return style

        except ValueError:
            style = free
            self._styles[style] = c
            self.StyleSetForeground(style, wx.NamedColour(c))

            free += 1
            if free > 31:
                free = 0
            self._free = free
            return style

    def write(self, text, c=None):
        """
        Add the text to the end of the control using color c which
        should be suitable for feeding directly to wx.NamedColour.

        'text' should be a unicode string or contain only ascii data.
        """
        style = self.getStyle(c)
        lenText = len(text.encode('utf8'))
        end = self.GetLength()
        self.AddText(text)
        self.StartStyling(end, 31)
        self.SetStyling(lenText, style)
        self.EnsureCaretVisible()


    __call__ = write