#Boa:Frame:frmDataFilter

import wx

def create(parent):
    return frmDataFilter(parent)

[wxID_FRMDATAFILTER, wxID_FRMDATAFILTERBTNAPPLY, wxID_FRMDATAFILTERBTNCANCEL, 
 wxID_FRMDATAFILTERBTNCLEAR, wxID_FRMDATAFILTERBTNOK, 
 wxID_FRMDATAFILTERCBGAPTIME, wxID_FRMDATAFILTERDBAFTER, 
 wxID_FRMDATAFILTERDPBEFORE, wxID_FRMDATAFILTERLBLDATEAFTER, 
 wxID_FRMDATAFILTERLBLDATEBEFORE, wxID_FRMDATAFILTERLBLGAPSTIME, 
 wxID_FRMDATAFILTERLBLGAPVALUE, wxID_FRMDATAFILTERLBLTHRESHVALGT, 
 wxID_FRMDATAFILTERLBLTHRESHVALLT, wxID_FRMDATAFILTERPANEL1, 
 wxID_FRMDATAFILTERRBDATAGAPS, wxID_FRMDATAFILTERRBDATE, 
 wxID_FRMDATAFILTERRBTHRESHOLD, wxID_FRMDATAFILTERRBVCHANGETHRESH, 
 wxID_FRMDATAFILTERSBDATE, wxID_FRMDATAFILTERSBGAPS, 
 wxID_FRMDATAFILTERSBTHRESHOLD, wxID_FRMDATAFILTERTXTGAPSVAL, 
 wxID_FRMDATAFILTERTXTTHRESHVALGT, wxID_FRMDATAFILTERTXTTHRESVALLT, 
 wxID_FRMDATAFILTERTXTVCHANGETHRESH, 
] = [wx.NewId() for _init_ctrls in range(26)]

class frmDataFilter(wx.Frame):
    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Frame.__init__(self, id=wxID_FRMDATAFILTER, name=u'frmDataFilter',
              parent=prnt, pos=wx.Point(599, 384), size=wx.Size(313, 384),
              style=wx.DEFAULT_FRAME_STYLE, title=u'Data Filter')
        self.SetClientSize(wx.Size(297, 346))

        self.panel1 = wx.Panel(id=wxID_FRMDATAFILTERPANEL1, name='panel1',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(297, 346),
              style=wx.TAB_TRAVERSAL)
              
        self.sbThreshold = wx.StaticBox(id=wxID_FRMDATAFILTERSBTHRESHOLD,
              label=u'Value Threshold', name=u'sbThreshold', parent=self.panel1,
              pos=wx.Point(16, 8), size=wx.Size(272, 72), style=0)

        self.sbGaps = wx.StaticBox(id=wxID_FRMDATAFILTERSBGAPS,
              label=u'Data Gaps', name=u'sbGaps', parent=self.panel1,
              pos=wx.Point(16, 88), size=wx.Size(272, 72), style=0)

        self.sbDate = wx.StaticBox(id=wxID_FRMDATAFILTERSBDATE, label=u'Date',
              name=u'sbDate', parent=self.panel1, pos=wx.Point(16, 168),
              size=wx.Size(264, 112), style=0)
              
              
        self.rbThreshold = wx.RadioButton(id=wxID_FRMDATAFILTERRBTHRESHOLD,
              label=u'', name=u'rbThreshold', parent=self.panel1,
              pos=wx.Point(8, 8), size=wx.Size(16, 13), style=0)
        self.rbThreshold.SetValue(True)

        self.rbDataGaps = wx.RadioButton(id=wxID_FRMDATAFILTERRBDATAGAPS,
              label=u'', name=u'rbDataGaps', parent=self.panel1, pos=wx.Point(8,
              88), size=wx.Size(16, 13), style=0)

        self.rbDate = wx.RadioButton(id=wxID_FRMDATAFILTERRBDATE, label=u'',
              name=u'rbDate', parent=self.panel1, pos=wx.Point(8, 168),
              size=wx.Size(16, 13), style=0)

        self.rbVChangeThresh = wx.RadioButton(id=wxID_FRMDATAFILTERRBVCHANGETHRESH,
              label=u'Value Change Threshold >=', name=u'rbVChangeThresh',
              parent=self.panel1, pos=wx.Point(8, 288), size=wx.Size(152, 13),
              style=0)

        self.lblThreshValGT = wx.StaticText(id=wxID_FRMDATAFILTERLBLTHRESHVALGT,
              label=u'Value >', name=u'lblThreshValGT', parent=self.panel1,
              pos=wx.Point(24, 32), size=wx.Size(38, 13), style=0)

        self.lblThreshValLT = wx.StaticText(id=wxID_FRMDATAFILTERLBLTHRESHVALLT,
              label=u'Value<', name=u'lblThreshValLT', parent=self.panel1,
              pos=wx.Point(24, 56), size=wx.Size(35, 13), style=0)

        self.txtThreshValGT = wx.TextCtrl(id=wxID_FRMDATAFILTERTXTTHRESHVALGT,
              name=u'txtThreshValGT', parent=self.panel1, pos=wx.Point(72, 24),
              size=wx.Size(200, 21), style=0, value='')

        self.txtThresValLT = wx.TextCtrl(id=wxID_FRMDATAFILTERTXTTHRESVALLT,
              name=u'txtThresValLT', parent=self.panel1, pos=wx.Point(72, 48),
              size=wx.Size(200, 21), style=0, value='')

        self.lblGapValue = wx.StaticText(id=wxID_FRMDATAFILTERLBLGAPVALUE,
              label=u'Value:', name=u'lblGapValue', parent=self.panel1,
              pos=wx.Point(32, 112), size=wx.Size(31, 13), style=0)

        self.lblGapsTime = wx.StaticText(id=wxID_FRMDATAFILTERLBLGAPSTIME,
              label=u'Time Period:', name=u'lblGapsTime', parent=self.panel1,
              pos=wx.Point(32, 136), size=wx.Size(60, 13), style=0)

        self.txtGapsVal = wx.TextCtrl(id=wxID_FRMDATAFILTERTXTGAPSVAL,
              name=u'txtGapsVal', parent=self.panel1, pos=wx.Point(80, 104),
              size=wx.Size(192, 21), style=0, value='')

        self.cbGapTime = wx.ComboBox(choices=[], id=wxID_FRMDATAFILTERCBGAPTIME,
              name=u'cbGapTime', parent=self.panel1, pos=wx.Point(96, 128),
              size=wx.Size(176, 21), style=0, value='')

        self.lblDateBefore = wx.StaticText(id=wxID_FRMDATAFILTERLBLDATEBEFORE,
              label=u'Before:', name=u'lblDateBefore', parent=self.panel1,
              pos=wx.Point(24, 184), size=wx.Size(37, 13), style=0)

        self.lblDateAfter = wx.StaticText(id=wxID_FRMDATAFILTERLBLDATEAFTER,
              label=u'After:', name=u'lblDateAfter', parent=self.panel1,
              pos=wx.Point(24, 232), size=wx.Size(30, 13), style=0)

        self.dpBefore = wx.DatePickerCtrl(id=wxID_FRMDATAFILTERDPBEFORE,
              name=u'dpBefore', parent=self.panel1, pos=wx.Point(24, 200),
              size=wx.Size(248, 21), style=wx.DP_DROPDOWN | wx.DP_SHOWCENTURY)

        self.dbAfter = wx.DatePickerCtrl(id=wxID_FRMDATAFILTERDBAFTER,
              name=u'dbAfter', parent=self.panel1, pos=wx.Point(24, 248),
              size=wx.Size(248, 21), style=wx.DP_DROPDOWN | wx.DP_SHOWCENTURY)

        self.txtVChangeThresh = wx.TextCtrl(id=wxID_FRMDATAFILTERTXTVCHANGETHRESH,
              name=u'', parent=self.panel1, pos=wx.Point(168, 280),
              size=wx.Size(100, 21), style=0, value='')

        self.btnClear = wx.Button(id=wxID_FRMDATAFILTERBTNCLEAR,
              label=u'Clear Filter', name=u'btnClear', parent=self.panel1,
              pos=wx.Point(8, 312), size=wx.Size(64, 23), style=0)

        self.btnOK = wx.Button(id=wxID_FRMDATAFILTERBTNOK, label=u'OK',
              name=u'btnOK', parent=self.panel1, pos=wx.Point(128, 312),
              size=wx.Size(48, 23), style=0)

        self.btnCancel = wx.Button(id=wxID_FRMDATAFILTERBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self.panel1,
              pos=wx.Point(184, 312), size=wx.Size(48, 23), style=0)

        self.btnApply = wx.Button(id=wxID_FRMDATAFILTERBTNAPPLY, label=u'Apply',
              name=u'btnApply', parent=self.panel1, pos=wx.Point(240, 312),
              size=wx.Size(48, 23), style=0)

    def __init__(self, parent):
        self._init_ctrls(parent)
