#Boa:Frame:frmDBConfig

import wx
import frmODMToolsMain
from odmservices.service_manager import ServiceManager

def create(parent, service_manager, is_main):
    return frmDBConfig(parent, service_manager, is_main = is_main)

[wxID_FRMDBCONFIG, wxID_FRMDBCONFIGBOXCONNECTION, wxID_FRMDBCONFIGBTNCANCEL, 
 wxID_FRMDBCONFIGBTNSAVE, wxID_FRMDBCONFIGBTNTEST, wxID_FRMDBCONFIGCOMBOBOX1, 
 wxID_FRMDBCONFIGLBLDBNAME, wxID_FRMDBCONFIGLBLDBTYPE, 
 wxID_FRMDBCONFIGLBLPASS, wxID_FRMDBCONFIGLBLSERVER, wxID_FRMDBCONFIGLBLUSER, 
 wxID_FRMDBCONFIGPNLCONNECTION, wxID_FRMDBCONFIGPNLMAIN, 
 wxID_FRMDBCONFIGTXTDBNAME, wxID_FRMDBCONFIGTXTPASS, 
 wxID_FRMDBCONFIGTXTSERVER, wxID_FRMDBCONFIGTXTUSER, wxID_FRAME1BOXCONNECTION, 
 wxID_FRAME1LBLUSER, wxID_FRAME1TXTPASS, wxID_FRMDBCONFIGTXTDBNAME, 
 wxID_FRAME1LBLDBNAME, wxID_FRAME1TXTSERVER, wxID_FRMDBCONFIGLBLSERVER,
] = [wx.NewId() for _init_ctrls in range(24)]

class frmDBConfig(wx.Dialog):
    def _init_coll_boxSizer3_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.lblDbType, 25, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.comboBox1, 75, border=5, flag=wx.GROW | wx.ALL)

    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddSizer(self.boxSizer3, 17, border=5, flag=wx.GROW | wx.ALL)
        parent.AddWindow(self.pnlConnection, 66, border=5,
              flag=wx.GROW | wx.ALL)
        parent.AddSizer(self.boxSizer2, 17, border=5, flag=wx.ALL | wx.GROW)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.btnTest, 33, border=5, flag=wx.GROW | wx.ALL)
        parent.AddWindow(self.btnSave, 33, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.btnCancel, 33, border=5, flag=wx.GROW | wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self.boxSizer3 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)
        self._init_coll_boxSizer3_Items(self.boxSizer3)

        self.pnlMain.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Dialog.__init__(self, id=wxID_FRMDBCONFIG, name=u'frmDBConfig',
              parent=prnt, pos=wx.Point(685, 312), size=wx.Size(473, 308),
              style=wx.DEFAULT_DIALOG_STYLE, title=u'Database Configuration')
        self.SetClientSize(wx.Size(457, 270))

        self.pnlMain = wx.Panel(id=wxID_FRMDBCONFIGPNLMAIN, name=u'pnlMain',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(457, 270),
              style=wx.TAB_TRAVERSAL)

        self.lblDbType = wx.StaticText(id=wxID_FRMDBCONFIGLBLDBTYPE,
              label=u'Connection Type:', name=u'lblDbType', parent=self.pnlMain,
              pos=wx.Point(10, 10), size=wx.Size(101, 25), style=0)

        self.comboBox1 = wx.ComboBox(choices=["Microsoft Sql Server", "MySQL"], id=wxID_FRMDBCONFIGCOMBOBOX1,
              name='comboBox1', parent=self.pnlMain, pos=wx.Point(121, 10),
              size=wx.Size(326, 21), style=0,
              value=u'Microsoft SQL Server')
        # self.comboBox1.SetLabel(u'Microsoft SQL Server')

        self.btnTest = wx.Button(id=wxID_FRMDBCONFIGBTNTEST,
              label=u'Test Connection', name=u'btnTest', parent=self.pnlMain,
              pos=wx.Point(10, 233), size=wx.Size(139, 27), style=0)

        self.btnSave = wx.Button(id=wxID_FRMDBCONFIGBTNSAVE,
              label=u'Save Connection', name=u'btnSave', parent=self.pnlMain,
              pos=wx.Point(159, 233), size=wx.Size(139, 27), style=0)

        self.btnCancel = wx.Button(id=wxID_FRMDBCONFIGBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self.pnlMain,
              pos=wx.Point(308, 233), size=wx.Size(139, 27), style=0)

        self.pnlConnection = wx.Panel(id=wxID_FRMDBCONFIGPNLCONNECTION,
              name=u'pnlConnection', parent=self.pnlMain, pos=wx.Point(5, 50),
              size=wx.Size(447, 168), style=wx.TAB_TRAVERSAL)

        self.boxConnection = wx.StaticBox(id=wxID_FRAME1BOXCONNECTION,
              label=u'Microsoft SQL Server', name=u'boxConnection',
              parent=self.pnlConnection, pos=wx.Point(8, 8), size=wx.Size(432,
              152), style=0)

        # ----------------------------

        self.lblServer = wx.StaticText(id=wxID_FRMDBCONFIGLBLSERVER,
              label=u'Server Address:', name=u'lblServer',
              parent=self.pnlConnection, pos=wx.Point(64, 40), size=wx.Size(79,
              16), style=0)

        self.txtServer = wx.TextCtrl(id=wxID_FRAME1TXTSERVER, name=u'txtServer',
              parent=self.pnlConnection, pos=wx.Point(160, 32),
              size=wx.Size(248, 21), style=0, value=u'')

        self.lblDBName = wx.StaticText(id=wxID_FRAME1LBLDBNAME,
              label=u'Database Name:', name=u'lblDBName',
              parent=self.pnlConnection, pos=wx.Point(64, 72), size=wx.Size(81,
              13), style=0)

        self.txtDBName = wx.TextCtrl(id=wxID_FRMDBCONFIGTXTDBNAME,
              name=u'txtDBName', parent=self.pnlConnection, pos=wx.Point(160,
              64), size=wx.Size(248, 21), style=0, value=u'')

        self.lblUser = wx.StaticText(id=wxID_FRAME1LBLUSER,
              label=u'Server User ID:', name=u'lblUser',
              parent=self.pnlConnection, pos=wx.Point(64, 104), size=wx.Size(76,
              13), style=0)

        self.txtUser = wx.TextCtrl(id=wxID_FRMDBCONFIGTXTUSER, name=u'txtUser',
              parent=self.pnlConnection, pos=wx.Point(160, 96),
              size=wx.Size(248, 21), style=0, value=u'')
        self._init_sizers()
        
        self.lblPass = wx.StaticText(id=wxID_FRMDBCONFIGLBLPASS,
              label=u'Server Password:', name=u'lblPass',
              parent=self.pnlConnection, pos=wx.Point(56, 136), size=wx.Size(86,
              13), style=0)        

        self.txtPass = wx.TextCtrl(id=wxID_FRAME1TXTPASS, name=u'txtPass',
              parent=self.pnlConnection, pos=wx.Point(160, 128),
              size=wx.Size(248, 21), style=wx.PASSWORD, value=u'')

        self.BindActions()


    def __init__(self, parent, service_manager, is_main=False):
        self.service_manager = service_manager
        self.is_main = is_main
        self._init_ctrls(parent)

    def BindActions(self):
        self.btnSave.Bind(wx.EVT_BUTTON, self.OnBtnSave,
          id=wxID_FRMDBCONFIGBTNSAVE)

        self.btnCancel.Bind(wx.EVT_BUTTON, self.OnBtnCancel,
          id=wxID_FRMDBCONFIGBTNCANCEL)

        self.btnTest.Bind(wx.EVT_BUTTON, self.OnBtnTest,
          id=wxID_FRMDBCONFIGBTNTEST)

    def OnBtnTest(self, event):
      conn_dict = self._GetFieldValues()
      message = ""
      if self.service_manager.test_connection(conn_dict):
        message = "This connection is valid"
      else:
        message = "This connection is invalid"

      wx.MessageBox(message, 'Test Connection', wx.OK)
              
    def OnBtnSave(self, event):
      conn_dict = self._GetFieldValues()

      self.service_manager.add_connection(conn_dict)

      self.Close()
      self.Destroy()

    def OnBtnCancel(self, e):
      self.Close()
      self.Destroy()

    # Returns a dictionary of the database values entered in the form
    def _GetFieldValues(self):
      conn_dict = {}

      if self.comboBox1.GetValue() == 'Microsoft SQL Server':
        conn_dict['engine'] = 'mssql'
      if self.comboBox1.GetValue() == 'MySQL':
        conn_dict['engine'] = 'mysql'

      conn_dict['user']     = self.txtUser.GetValue()
      conn_dict['password'] = self.txtPass.GetValue()
      conn_dict['address']  = self.txtServer.GetValue()
      conn_dict['db']       = self.txtDBName.GetValue()

      print conn_dict
      return conn_dict


