#Boa:Dialog:frmLinearDrift

import wx

def create(parent):
    return frmLinearDrift(parent)

[wxID_FRMLINEARDRIFT, wxID_FRMLINEARDRIFTBTNCANCEL, wxID_FRMLINEARDRIFTBTNOK, 
 wxID_FRMLINEARDRIFTLBLFNLGAP, wxID_FRMLINEARDRIFTTXTFINALGAPVALUE, 
] = [wx.NewId() for _init_ctrls in range(5)]

class frmLinearDrift(wx.Dialog):
    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Dialog.__init__(self, id=wxID_FRMLINEARDRIFT, name=u'frmLinearDrift',
              parent=prnt, pos=wx.Point(653, 334), size=wx.Size(400, 117),
              style=wx.DEFAULT_DIALOG_STYLE, title=u'Linear Drift Correction ')
        self.SetClientSize(wx.Size(384, 79))

        self.lblFnlGap = wx.StaticText(id=wxID_FRMLINEARDRIFTLBLFNLGAP,
              label=u'Final Gap Value:', name=u'lblFnlGap', parent=self,
              pos=wx.Point(16, 16), size=wx.Size(78, 13), style=0)

        self.txtFinalGapValue = wx.TextCtrl(id=wxID_FRMLINEARDRIFTTXTFINALGAPVALUE,
              name=u'txtFinalGapValue', parent=self, pos=wx.Point(96, 16),
              size=wx.Size(272, 21), style=0, value=u'')

        self.btnOK = wx.Button(id=wxID_FRMLINEARDRIFTBTNOK, label=u'OK',
              name=u'btnOK', parent=self, pos=wx.Point(208, 48),
              size=wx.Size(75, 23), style=0)
        self.btnOK.Bind(wx.EVT_BUTTON, self.OnBtnOKButton,
              id=wxID_FRMLINEARDRIFTBTNOK)

        self.btnCancel = wx.Button(id=wxID_FRMLINEARDRIFTBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self, pos=wx.Point(288,
              48), size=wx.Size(75, 23), style=0)
        self.btnCancel.Bind(wx.EVT_BUTTON, self.OnBtnCancelButton,
              id=wxID_FRMLINEARDRIFTBTNCANCEL)

    def __init__(self, parent):
        self._init_ctrls(parent)

    def OnBtnOKButton(self, event):
        event.Skip()
        self.Close()
        self.Destroy()

    def OnBtnCancelButton(self, event):
        event.Skip()
        self.Close()
        self.Destroy()



if __name__ == '__main__':
    app = wx.PySimpleApp()
    dlg = create(None)
    try:
        dlg.ShowModal()
    finally:
        dlg.Destroy()
    app.MainLoop()
