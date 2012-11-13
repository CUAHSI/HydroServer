#Boa:Frame:frmChangeValue

import wx

def create(parent):
    return frmChangeValue(parent)

[wxID_FRMCHANGEVALUE, wxID_FRMCHANGEVALUEBTNAPPLY, 
 wxID_FRMCHANGEVALUEBTNCANCEL, wxID_FRMCHANGEVALUECBVALUE, 
 wxID_FRMCHANGEVALUEPANEL1, wxID_FRMCHANGEVALUETXTVALUE, 
] = [wx.NewId() for _init_ctrls in range(6)]

class frmChangeValue(wx.Frame):
    def _init_coll_gridSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.cbValue, 50, border=5, flag=wx.ALL)
        parent.AddWindow(self.txtValue, 50, border=5, flag=wx.ALL)
        parent.AddWindow(self.btnApply, 50, border=5, flag=wx.ALL)
        parent.AddWindow(self.btnCancel, 50, border=5, flag=wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.gridSizer1 = wx.GridSizer(cols=2, hgap=0, rows=2, vgap=0)

        self._init_coll_gridSizer1_Items(self.gridSizer1)

        self.panel1.SetSizer(self.gridSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Frame.__init__(self, id=wxID_FRMCHANGEVALUE, name=u'frmChangeValue',
              parent=prnt, pos=wx.Point(732, 489), size=wx.Size(248, 109),
              style=wx.STAY_ON_TOP | wx.DEFAULT_FRAME_STYLE,
              title=u'Change Value')
        self.SetClientSize(wx.Size(232, 71))
        self.SetMinSize(wx.Size(248, 109))
        self.SetMaxSize(wx.Size(248, 109))

        self.panel1 = wx.Panel(id=wxID_FRMCHANGEVALUEPANEL1, name='panel1',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(232, 71),
              style=wx.TAB_TRAVERSAL)
        self.panel1.SetLabel(u'panel1')

        self.cbValue = wx.ComboBox(choices=[], id=wxID_FRMCHANGEVALUECBVALUE,
              name=u'cbValue', parent=self.panel1, pos=wx.Point(5, 5),
              size=wx.Size(104, 21), style=0, value=u'Add')
        self.cbValue.SetLabel(u'Add')

        self.txtValue = wx.TextCtrl(id=wxID_FRMCHANGEVALUETXTVALUE,
              name=u'txtValue', parent=self.panel1, pos=wx.Point(121, 5),
              size=wx.Size(100, 21), style=50, value=u'')

        self.btnApply = wx.Button(id=wxID_FRMCHANGEVALUEBTNAPPLY,
              label=u'Apply', name=u'btnApply', parent=self.panel1,
              pos=wx.Point(5, 40), size=wx.Size(104, 23), style=0)

        self.btnCancel = wx.Button(id=wxID_FRMCHANGEVALUEBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self.panel1,
              pos=wx.Point(121, 40), size=wx.Size(99, 23), style=0)

        self._init_sizers()

    def __init__(self, parent):
        self._init_ctrls(parent)


if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()
