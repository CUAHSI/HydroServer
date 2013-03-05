#Boa:Frame:frmCreateVariable

import wx

def create(parent):
    return frmCreateVariable(parent)

[wxID_FRMCREATEVARIABLE, wxID_FRMCREATEVARIABLEBOXDEFINED, 
 wxID_FRMCREATEVARIABLEBOXPTOSELECT, wxID_FRMCREATEVARIABLEBTNCANCEL, 
 wxID_FRMCREATEVARIABLEBTNCREATE, wxID_FRMCREATEVARIABLECBSPECIATION, 
 wxID_FRMCREATEVARIABLECBVARNAME, wxID_FRMCREATEVARIABLECBVARUNITS, 
 wxID_FRMCREATEVARIABLELBLDATATYPE, wxID_FRMCREATEVARIABLELBLGENCAT, 
 wxID_FRMCREATEVARIABLELBLISREGULAR, wxID_FRMCREATEVARIABLELBLNODV, 
 wxID_FRMCREATEVARIABLELBLSAMPLEM, wxID_FRMCREATEVARIABLELBLSPECIATION, 
 wxID_FRMCREATEVARIABLELBLTSUNITS, wxID_FRMCREATEVARIABLELBLTSVALUE, 
 wxID_FRMCREATEVARIABLELBLVALUETYPE, wxID_FRMCREATEVARIABLELBLVARCODE, 
 wxID_FRMCREATEVARIABLELBLVARNAME, wxID_FRMCREATEVARIABLELBLVARUNITS, 
 wxID_FRMCREATEVARIABLEPANEL1, wxID_FRMCREATEVARIABLEPNLDEFINDED, 
 wxID_FRMCREATEVARIABLEPNLFILLER, wxID_FRMCREATEVARIABLEPNLPTOSELECT, 
 wxID_FRMCREATEVARIABLESTATICBOX3, wxID_FRMCREATEVARIABLETXTDATATYPE, 
 wxID_FRMCREATEVARIABLETXTGENCAT, wxID_FRMCREATEVARIABLETXTISREGULAR, 
 wxID_FRMCREATEVARIABLETXTNODV, wxID_FRMCREATEVARIABLETXTSAMPLEM, 
 wxID_FRMCREATEVARIABLETXTTSUNITS, wxID_FRMCREATEVARIABLETXTTSVALUE, 
 wxID_FRMCREATEVARIABLETXTVALUETYPE, wxID_FRMCREATEVARIABLETXTVARCODE, 
] = [wx.NewId() for _init_ctrls in range(34)]

class frmCreateVariable(wx.Frame):
    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.pnlPtoSelect, 35, border=2, flag=wx.GROW | wx.ALL)
        parent.AddWindow(self.pnldefinded, 55, border=2, flag=wx.GROW | wx.ALL)
        parent.AddSizer(self.boxSizer2, 10, border=0, flag=wx.ALL | wx.GROW)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.pnlFiller, 60, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.btnCreate, 20, border=5, flag=wx.ALL)
        parent.AddWindow(self.btnCancel, 20, border=5, flag=wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)

        self.panel1.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Frame.__init__(self, id=wxID_FRMCREATEVARIABLE,
              name=u'frmCreateVariable', parent=prnt, pos=wx.Point(564, 287),
              size=wx.Size(547, 417),
              style=wx.STAY_ON_TOP | wx.DEFAULT_FRAME_STYLE,
              title=u'Create Variable')
        self.SetClientSize(wx.Size(531, 379))
        self.SetMinSize(wx.Size(547, 417))
        self.SetMaxSize(wx.Size(547, 417))

        self.panel1 = wx.Panel(id=wxID_FRMCREATEVARIABLEPANEL1, name='panel1',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(531, 379),
              style=wx.TAB_TRAVERSAL)

        self.pnlPtoSelect = wx.Panel(id=wxID_FRMCREATEVARIABLEPNLPTOSELECT,
              name=u'pnlPtoSelect', parent=self.panel1, pos=wx.Point(2, 2),
              size=wx.Size(527, 128), style=wx.TAB_TRAVERSAL)

        self.pnldefinded = wx.Panel(id=wxID_FRMCREATEVARIABLEPNLDEFINDED,
              name=u'pnldefinded', parent=self.panel1, pos=wx.Point(2, 134),
              size=wx.Size(527, 205), style=wx.TAB_TRAVERSAL)
        self.pnldefinded.SetLabel(u'panel3')

        self.btnCreate = wx.Button(id=wxID_FRMCREATEVARIABLEBTNCREATE,
              label=u'Create', name=u'btnCreate', parent=self.panel1,
              pos=wx.Point(323, 346), size=wx.Size(96, 23), style=0)

        self.btnCancel = wx.Button(id=wxID_FRMCREATEVARIABLEBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self.panel1,
              pos=wx.Point(429, 346), size=wx.Size(97, 23), style=0)

        self.pnlFiller = wx.Panel(id=wxID_FRMCREATEVARIABLEPNLFILLER,
              name=u'pnlFiller', parent=self.panel1, pos=wx.Point(5, 346),
              size=wx.Size(308, 28), style=wx.TAB_TRAVERSAL)

        self.boxPtoSelect = wx.StaticBox(id=wxID_FRMCREATEVARIABLEBOXPTOSELECT,
              label=u'Parameters to Select', name=u'boxPtoSelect',
              parent=self.pnlPtoSelect, pos=wx.Point(8, 8), size=wx.Size(528,
              128), style=0)

        self.boxDefined = wx.StaticBox(id=wxID_FRMCREATEVARIABLEBOXDEFINED,
              label=u'Defined Parameters', name=u'boxDefined',
              parent=self.pnldefinded, pos=wx.Point(8, 8), size=wx.Size(528,
              208), style=0)

        self.lblVarCode = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLVARCODE,
              label=u'Variable Code:', name=u'lblVarCode',
              parent=self.pnlPtoSelect, pos=wx.Point(24, 40), size=wx.Size(71,
              13), style=0)

        self.lblVarName = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLVARNAME,
              label=u'Variable Name:', name=u'lblVarName',
              parent=self.pnlPtoSelect, pos=wx.Point(24, 72), size=wx.Size(73,
              13), style=0)

        self.lblVarUnits = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLVARUNITS,
              label=u'Variable Units:', name=u'lblVarUnits',
              parent=self.pnlPtoSelect, pos=wx.Point(24, 104), size=wx.Size(70,
              13), style=0)

        self.staticBox3 = wx.StaticBox(id=wxID_FRMCREATEVARIABLESTATICBOX3,
              label=u'Time Support', name='staticBox3', parent=self.pnldefinded,
              pos=wx.Point(32, 32), size=wx.Size(488, 48), style=0)

        self.lblTSValue = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLTSVALUE,
              label=u'Value:', name=u'lblTSValue', parent=self.pnldefinded,
              pos=wx.Point(56, 56), size=wx.Size(31, 13), style=0)

        self.lblTSUnits = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLTSUNITS,
              label=u'Units:', name=u'lblTSUnits', parent=self.pnldefinded,
              pos=wx.Point(264, 56), size=wx.Size(29, 13), style=0)

        self.lblValueType = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLVALUETYPE,
              label=u'Value Type:', name=u'lblValueType',
              parent=self.pnldefinded, pos=wx.Point(40, 104), size=wx.Size(58,
              13), style=0)

        self.lblGenCat = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLGENCAT,
              label=u'General Category:', name=u'lblGenCat',
              parent=self.pnldefinded, pos=wx.Point(40, 136), size=wx.Size(90,
              13), style=0)

        self.lblSampleM = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLSAMPLEM,
              label=u'Sample Medium:', name=u'lblSampleM',
              parent=self.pnldefinded, pos=wx.Point(40, 168), size=wx.Size(78,
              13), style=0)

        self.lblSpeciation = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLSPECIATION,
              label=u'Speciation:', name=u'lblSpeciation',
              parent=self.pnlPtoSelect, pos=wx.Point(296, 104), size=wx.Size(54,
              13), style=0)

        self.lblDataType = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLDATATYPE,
              label=u'Data Type:', name=u'lblDataType', parent=self.pnldefinded,
              pos=wx.Point(280, 104), size=wx.Size(55, 13), style=0)

        self.lblNoDV = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLNODV,
              label=u'NoData Value:', name=u'lblNoDV', parent=self.pnldefinded,
              pos=wx.Point(344, 136), size=wx.Size(70, 16), style=0)

        self.lblIsRegular = wx.StaticText(id=wxID_FRMCREATEVARIABLELBLISREGULAR,
              label=u'Is Regular:', name=u'lblIsRegular',
              parent=self.pnldefinded, pos=wx.Point(360, 168), size=wx.Size(54,
              13), style=0)

        self.txtVarCode = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTVARCODE,
              name=u'txtVarCode', parent=self.pnlPtoSelect, pos=wx.Point(104,
              32), size=wx.Size(416, 21), style=0, value=u'')

        self.cbVarName = wx.ComboBox(choices=[],
              id=wxID_FRMCREATEVARIABLECBVARNAME, name=u'cbVarName',
              parent=self.pnlPtoSelect, pos=wx.Point(104, 64), size=wx.Size(416,
              21), style=0, value='')

        self.cbVarUnits = wx.ComboBox(choices=[],
              id=wxID_FRMCREATEVARIABLECBVARUNITS, name=u'cbVarUnits',
              parent=self.pnlPtoSelect, pos=wx.Point(104, 96), size=wx.Size(176,
              21), style=0, value='')

        self.cbSpeciation = wx.ComboBox(choices=[],
              id=wxID_FRMCREATEVARIABLECBSPECIATION, name=u'cbSpeciation',
              parent=self.pnlPtoSelect, pos=wx.Point(360, 96), size=wx.Size(160,
              21), style=0, value='')

        self.txtTSValue = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTTSVALUE,
              name=u'txtTSValue', parent=self.pnldefinded, pos=wx.Point(96, 48),
              size=wx.Size(152, 21), style=0, value='')

        self.txtTSUnits = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTTSUNITS,
              name=u'txtTSUnits', parent=self.pnldefinded, pos=wx.Point(296,
              48), size=wx.Size(200, 21), style=0, value='')

        self.txtValueType = wx.ComboBox(choices=[],
              id=wxID_FRMCREATEVARIABLETXTVALUETYPE, name=u'txtValueType',
              parent=self.pnldefinded, pos=wx.Point(104, 96), size=wx.Size(168,
              21), style=0, value='')

        self.txtDataType = wx.ComboBox(choices=[],
              id=wxID_FRMCREATEVARIABLETXTDATATYPE, name=u'txtDataType',
              parent=self.pnldefinded, pos=wx.Point(336, 96), size=wx.Size(184,
              21), style=0, value='')

        self.txtGenCat = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTGENCAT,
              name=u'txtGenCat', parent=self.pnldefinded, pos=wx.Point(136,
              128), size=wx.Size(200, 21), style=0, value='')

        self.txtSampleM = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTSAMPLEM,
              name=u'txtSampleM', parent=self.pnldefinded, pos=wx.Point(120,
              160), size=wx.Size(216, 21), style=0, value='')

        self.txtNoDV = wx.TextCtrl(id=wxID_FRMCREATEVARIABLETXTNODV,
              name=u'txtNoDV', parent=self.pnldefinded, pos=wx.Point(416, 128),
              size=wx.Size(104, 21), style=0, value='')

        self.txtIsRegular = wx.ComboBox(choices=['True', 'False'],
              id=wxID_FRMCREATEVARIABLETXTISREGULAR, name=u'txtIsRegular',
              parent=self.pnldefinded, pos=wx.Point(416, 160), size=wx.Size(104,
              21), style=0, value='')

        self._init_sizers()

    def __init__(self, parent):
        self._init_ctrls(parent)



if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()
