#Boa:Frame:ODMTools

import wx
import wx.grid
import wx.lib.agw.ribbon as RB
import wx.aui
# import wx.aui

try:
    from agw import aui
except ImportError: # if it's not there locally, try the wxPython lib.
    import wx.lib.agw.aui as aui



import wx.richtext
import wx.stc
import datetime
import wx.lib.agw.aui as aui
from wx.lib.agw.aui import aui_switcherdialog as ASD
from wx.lib.pubsub import Publisher
import wx.py.crust
from numpy import arange, sin, cos, exp, pi
import frmDBConfiguration

from odmservices import ServiceManager
from odmservices import EditService
from pnlScript import pnlScript
import pnlSeriesSelector
import pnlPlot
import mnuRibbon
import pnlDataTable


# import sys
# sys.path.append('C:\DEV\ODM\HydroServer\ODM_Tools Python')


def create(parent):
    return frmODMToolsMain(parent)
[wxID_ODMTOOLS, wxID_ODMTOOLSCHECKLISTBOX2, wxID_ODMTOOLSCOMBOBOX1,
 wxID_ODMTOOLSCOMBOBOX2, wxID_ODMTOOLSCOMBOBOX4, wxID_ODMTOOLSCOMBOBOX5,
 wxID_ODMTOOLSGRID1, wxID_ODMTOOLSPANEL1, wxID_ODMTOOLSPANEL2,
 wxID_ODMTOOLSTOOLBAR1,  wxID_PNLSELECTOR,  wxID_TXTPYTHONSCRIPT,
 wxID_TXTPYTHONCONSOLE,
] = [wx.NewId() for _init_ctrls in range(13)]



class frmODMToolsMain(wx.Frame):

    def __init__(self, parent):
        self.service_manager = ServiceManager()
        self.edit_service = None
        if self.service_manager.get_current_connection() == None:
            # Create a DB form which will set a connection for the service manager
            db_config = frmDBConfiguration.frmDBConfig(None, self.service_manager, False)
            db_config.ShowModal()

        self.createService()
        self._init_ctrls(parent)
        self.Refresh()

#############Entire Form Sizers##########
    def _init_sizers(self):
        # generated method, don't edit
        self.s = wx.BoxSizer(wx.VERTICAL)

        self._init_s_Items(self.s)

        self.SetSizer(self.s)

    def _init_s_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self._ribbon, 0, wx.EXPAND)
        parent.AddWindow(self.pnlDocking, 85, flag=wx.ALL | wx.EXPAND)


###################### Form ################
    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Frame.__init__(self, id=wxID_ODMTOOLS, name=u'ODMTools', parent=prnt,
              pos=wx.Point(150, 150), size=wx.Size(1190, 812),
              style=wx.DEFAULT_FRAME_STYLE, title=u'ODM Tools')
        self.SetFont(wx.Font(9, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'Tahoma'))
        # Publisher().subscribe(self.addPlot, ("add.NewPlot"))
        # Publisher().subscribe(self.addEdit, ("edit.NewPlot"))
        Publisher().subscribe(self.onDocking, ("adjust.Docking"))

        Publisher().subscribe(self.onDocking, ("adjust.Docking"))
        Publisher().subscribe(self.onPlotSelection, ("select.Plot"))
        Publisher().subscribe(self.onExecuteScript, ("execute.script"))


        Publisher().subscribe(self.onExecuteScript, ("execute.script"))
        Publisher().subscribe(self.onChangeDBConn, ("change.dbConfig"))
        Publisher().subscribe(self.onSetScriptTitle, ("script.title"))
        Publisher().subscribe(self.OnClose, ("onClose"))


############### Ribbon ###################
        self._ribbon = mnuRibbon.mnuRibbon(parent=self, id=wx.ID_ANY, name ='ribbon')


################ Docking Tools##############
        self.pnlDocking = wx.Panel(id=wxID_ODMTOOLSPANEL1, name='pnlDocking',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
              style=wx.TAB_TRAVERSAL)




################ Series Selection Panel ##################
        self.pnlSelector = pnlSeriesSelector.pnlSeriesSelector(id=wxID_PNLSELECTOR, name=u'pnlSelector',
               parent=self.pnlDocking, pos=wx.Point(0, 0), size=wx.Size(770, 388),
               style=wx.TAB_TRAVERSAL, dbservice= self.sc)


####################grid##################
        self.dataTable = pnlDataTable.pnlDataTable(id=wxID_ODMTOOLSGRID1, name='dataTable',
              parent=self.pnlDocking, pos=wx.Point(64, 160), size=wx.Size(376, 280),
              style=0)


############# Graph ###############
        self.pnlPlot= pnlPlot.pnlPlot(id=wxID_ODMTOOLSPANEL1, name='pnlPlot',
              parent=self.pnlDocking, pos=wx.Point(0, 0), size=wx.Size(605, 458),
               style=wx.TAB_TRAVERSAL)


############# Script & Console ###############

        self.txtPythonConsole = wx.py.crust.CrustFrame(id=wxID_TXTPYTHONCONSOLE,
                name=u'txtPython', parent=self, rootObject=pnlDataTable, pos=wx.Point(72, 24),
                size=wx.Size(500,800), style=0)
##        self.txtPythonConsole= wx.richtext.RichTextCtrl(id=wxID_TXTPYTHONCONSOLE,
##              parent=self, pos=wx.Point(72, 24), size=wx.Size(500,800),
##              style=wx.richtext.RE_MULTILINE, value='')

        self.txtPythonScript = pnlScript(id=wxID_TXTPYTHONSCRIPT,
              name=u'txtPython', parent=self, pos=wx.Point(72, 24),
              size=wx.Size(200,200))


        # print self.txtPythonConsole.fileMenu.MenuItems
        # for menu in self.txtPythonConsole.fileMenu.MenuItems:
        #     print menu.Label, menu.Kind
        # print self.txtPythonConsole.fileMenu.MenuItems[11].IsEnabled()
        # self.txtPythonConsole.fileMenu.MenuItems[11].Enable=False
        # print self.txtPythonConsole.fileMenu.MenuItems[11].IsEnabled()


############ Docking ###################

        self._mgr = aui.AuiManager()
        self._mgr.SetManagedWindow(self.pnlDocking)
        self._mgr.AddPane(self.dataTable, aui.AuiPaneInfo().Right().Name("Table").
                Show(show=False).Caption('Table View').MinSize(wx.Size( 200, 200)))
        # DestroyOnClose(b=False)
        self._mgr.AddPane(self.pnlSelector, aui.AuiPaneInfo().Bottom().Name("Selector").
                Layer(0).Caption('Series Selector').MinSize(wx.Size(100, 200)) )
        self._mgr.AddPane(self.txtPythonScript,  aui.AuiPaneInfo().Caption('Script').
                Name("Script").Show(show=False).Layer(0).Float().MinSize(wx.Size(200,200)))
        # self._mgr.CreateFloatingFrame(self.txtPythonScript,  aui.AuiPaneInfo().Caption('Script').
        #         Name("Script").MinSize(wx.Size(500,800)))
        self._mgr.AddPane(self.txtPythonConsole,  aui.AuiPaneInfo().Caption('Python Console').
                Name("Console").Layer(1).Show(show=False).Float())
        # self.txtPythonConsole.ToggleTools()

        self._mgr.AddPane(self.pnlPlot,  aui.AuiPaneInfo().CenterPane().Name("Plot").Caption("Plot"))

        self.loadDockingSettings()

        self._mgr.Update()

        self.Bind(wx.EVT_CLOSE, self.OnClose)

        self._init_sizers()
        self._ribbon.Realize()




    def onDocking(self, Value):

        panedet=self._mgr.GetPane(self.pnlPlot)
        if Value.data == "Table":
            panedet=self._mgr.GetPane(self.dataTable)
        elif Value.data == "Selector":
            panedet=self._mgr.GetPane(self.pnlSelector)
        elif Value.data == "Script":
            panedet=self._mgr.GetPane(self.txtPythonScript)
        elif Value.data == "Console":

        # self.txtPythonConsole = wx.py.crust.CrustFrame(id=wxID_TXTPYTHONCONSOLE, 
        #     name=u'txtPython', parent=self,  pos=wx.Point(72, 24),
        #     size=wx.Size(500,800), style=0) 
        # self._mgr.AddPane(self.txtPythonConsole,  aui.AuiPaneInfo().Caption('Python Console').
        #     Name("Console").Layer(1).Show(show=False).Float())

            panedet=self._mgr.GetPane(self.txtPythonConsole)
        # print self.txtPythonConsole.fileMenu.MenuItems[11].IsEnabled()

        # self._mgr.SetFont(wx.Font(9, wx.SWISS, wx.NORMAL, wx.NORMAL,
        #       False, u'Tahoma'))
        if panedet.IsShown():
            panedet.Show(show=False)
        else:
            panedet.Show(show=True)
        self._mgr.Update()

        # for p in self._mgr.GetAllPanes():
        #     print p.caption
        # print "\n"


    def onPlotSelection(self, value):
        self.pnlPlot.selectPlot(value)


    def addPlot(self, cursor, series):
    #     self.dataTable.Init(Values.data[0])
        # self.pnlPlot.addPlot(Values.data)

        self.pnlPlot.addPlot(cursor, series)

        self._ribbon.enableButtons(self.pnlPlot.getActivePlotID() )



    def onSetScriptTitle(self, title):
        scriptPane = self._mgr.GetPane(self.txtPythonScript)
        scriptPane.Caption(title.data)
        if scriptPane.IsFloating():
            # print "script is floating"
            scriptPane.Restore()
        self._mgr.Update()


    def addEdit(self, cursor, series):
        # Publisher().sendMessage(("edit.EnableButtons"), True)
        # self.pnlPlot.addEditPlot(Values.data)
        # self.dataTable.Init(Values.data[0])
        # self.edit_service = self.service_manager.get_edit_service(Values.data[1].id, Values.data[0])
        
        print cursor, series
        self.pnlPlot.addEditPlot(cursor, series)
        self.dataTable.Init(cursor)
        self.edit_service = self.service_manager.get_edit_service(series.id, cursor)
        self._ribbon.toggleEditButtons(True)
        
        # TODO
        # create edit service, send in Values.data[0]
   
    def stopEdit(self):
        
        self.pnlPlot.stopEdit()
        self.dataTable.stopEdit()
        self.edit_service = None
        self.pnlSelector.stopEdit()
        self._ribbon.toggleEditButtons(False)
        


    def getEditService(self):
        return self.edit_service
    

    def onChangeDBConn(self, event):
        db_config = frmDBConfiguration.frmDBConfig(None, self.service_manager, False)
        db_config.ShowModal()
        #clear editseries
        #clear all plots
        #clear table


    def createService(self):
        self.sc = self.service_manager.get_series_service()

    def GetDBService(self):
        return self.service_manager


    def toggleConsoleTools(self):
        self.txtPythonConsole.ToggleTools()


    def onExecuteScript(self, value):
        # print "testing file execution with test.py"
        for i in ('red', 'blue', 'green', 'magenta', 'gold', 'cyan', 'brown', 'lime','purple', 'navy'):
            self.txtPythonScript('This is a test\n', i)


    def loadDockingSettings(self):
     #test if there is a perspective to load
        try:
            f= open('ODMTools.config', 'r')
            self._mgr.LoadPerspective(f.read(), True)
        except:
            print "error loading docking data"

    def OnClose(self, event):
        # deinitialize the frame manager
        self.pnlPlot.Close()
        try:
            f= open('ODMTools.config', 'w')
            f.write(self._mgr.SavePerspective())
        except:
            print "error saving docking data"
        self._mgr.UnInit()
        # delete the frame
        self.Destroy()


if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()