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

from odmservices.service_manager import ServiceManager
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
        Publisher().subscribe(self.addPlot, ("add.NewPlot")) 
        Publisher().subscribe(self.onDocking, ("adjust.Docking")) 

        Publisher().subscribe(self.onDocking, ("adjust.Docking"))
        Publisher().subscribe(self.onPlotSelection, ("select.Plot")) 
        Publisher().subscribe(self.onExecuteScript, ("execute.script")) 


        Publisher().subscribe(self.onExecuteScript, ("execute.script"))
        Publisher().subscribe(self.onChangeDBConn, ("change.dbConfig"))
        Publisher().subscribe(self.OnClose, ("onClose"))


############### Ribbon ###################
        self._ribbon = mnuRibbon.mnuRibbon(parent=self, id=wx.ID_ANY, name ='ribbon')
              

################ Docking Tools##############
        self.pnlDocking = wx.Panel(id=wxID_ODMTOOLSPANEL1, name='pnlDocking',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
              style=wx.TAB_TRAVERSAL)
              
        
        self.txtPythonScript = wx.stc.StyledTextCtrl(id=wxID_TXTPYTHONSCRIPT,
              name=u'txtPython', parent=self, pos=wx.Point(72, 24),
              size=wx.Size(368, 168), style=0)
        
        self.txtPythonConsole = wx.py.crust.CrustFrame(id=wxID_TXTPYTHONCONSOLE, 
                name=u'txtPython', parent=self, pos=wx.Point(72, 24),
                size=wx.Size(500,800), style=0)           
        
        
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


############ Docking ###################
       
        self._mgr = aui.AuiManager()
        self._mgr.SetManagedWindow(self.pnlDocking)
        self._mgr.AddPane(self.dataTable, aui.AuiPaneInfo().Right().Name("Table").
                Show(show=False).Caption('Table View').MinSize(wx.Size( 400, 400)))
        # DestroyOnClose(b=False)
        self._mgr.AddPane(self.pnlSelector, aui.AuiPaneInfo().Bottom().Name("Selector").
                Layer(0).Caption('Series Selector').MinSize(wx.Size(100, 200)) )   
        self._mgr.AddPane(self.txtPythonScript,  aui.AuiPaneInfo().Bottom().Caption('Script').
                Name("Script").Show(show=False).Layer(1))
        self._mgr.AddPane(self.txtPythonConsole,  aui.AuiPaneInfo().Bottom().Caption('Python Console').
                Name("Console").Layer(1).Show(show=False).Float())        
        self._mgr.AddPane(self.pnlPlot,  aui.AuiPaneInfo().CenterPane().Name("Plot"))


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
            panedet=self._mgr.GetPane(self.txtPythonConsole)
        
        # self._mgr.SetFont(wx.Font(9, wx.SWISS, wx.NORMAL, wx.NORMAL,
        #       False, u'Tahoma'))
        if panedet.IsShown():          
            panedet.Show(show=False)
            self._mgr.Update()
        else:         
            panedet.Show(show=True)
        self._mgr.Update()
        self.Bind(wx.EVT_CLOSE, self.OnClose)


    def onPlotSelection(self, value):         
        self.pnlPlot.selectPlot(value)


    def addPlot(self, Values):
        self.dataTable.Init(Values.data[0])
        self.pnlPlot.addPlot(Values.data)        
        self._ribbon.enableButtons(self.pnlPlot.getActivePlotID() )
       



    def __init__(self, parent):
        self.service_manager = ServiceManager()
        if self.service_manager.get_current_connection() == None:
            # Create a DB form which will set a connection for the service manager
            db_config = frmDBConfiguration.frmDBConfig(None, self.service_manager, False)
            db_config.ShowModal()

        self.createService()
        self._init_ctrls(parent)
        self.Refresh()


    def addEdit(self, Values): 
         self.dataTable.Init(Values.data[0])
    
   
    def onChangeDBConn(self, event):
        db_config = frmDBConfiguration.frmDBConfig(None, self.service_manager, False)
        db_config.ShowModal()


    def createService(self):
        self.sc = self.service_manager.get_series_service()
   
    
    
    def onExecuteScript(self, value):
        print "testing file execution with test.py"
        print "testing script logging"
        for i in ('red', 'blue', 'green', 'magenta'):
            self.txtPythonScript('This is a test\n', i)
        pass
    

        
            
    def OnClose(self, event):
        # deinitialize the frame manager
        self._mgr.UnInit()
        # delete the frame
        self.Destroy()





if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()