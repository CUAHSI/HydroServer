#Boa:FramePanel:pnlDataTable

import wx
import wx.grid
from wx.lib.anchors import LayoutAnchors

[wxID_PNLDATATABLE, wxID_PNLDATATABLEDATAGRID, 
] = [wx.NewId() for _init_ctrls in range(2)]

class pnlDataTable(wx.Panel):
    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.dataGrid, 100, border=0, flag=wx.GROW | wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)

        self.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Panel.__init__(self, id=wxID_PNLDATATABLE, name=u'pnlDataTable',
              parent=prnt, pos=wx.Point(653, 296), size=wx.Size(677, 449),
              style=wx.TAB_TRAVERSAL)
        self.SetClientSize(wx.Size(661, 411))

        self.dataGrid = wx.grid.Grid(id=wxID_PNLDATATABLEDATAGRID,
              name=u'dataGrid', parent=self, pos=wx.Point(0, 0),
              size=wx.Size(661, 411), style=wx.HSCROLL | wx.VSCROLL)
        self.dataGrid.SetAutoLayout(False)
        self.dataGrid.SetToolTipString(u'DataValues table')
        self.dataGrid.SetLabel(u'DataValues')
        self.dataGrid.EnableGridLines(True)
        self.dataGrid.EnableEditing(False)

        self._init_sizers()

    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)
