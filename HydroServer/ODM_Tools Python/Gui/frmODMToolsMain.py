#Boa:Frame:ODMTools

import wx
import wx.grid
import wx.lib.agw.ribbon as RB
import wx.aui
import wx.richtext
import wx.stc
import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import \
    FigureCanvasWxAgg as FigCanvas, \
    NavigationToolbar2WxAgg as NavigationToolbar

import wx.lib.plot
import datetime

# import sys
# sys.path.append('C:\DEV\ODM\HydroServer\ODM_Tools Python')

from odmservices.series_service import SeriesService
import pnlSeriesSelector
import mnuRibbon


    


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
              
              
              
############### Ribbon ###################
        self._ribbon = mnuRibbon.mnuRibbon(parent=self, id=wx.ID_ANY, name ='ribbon')

              
################ Docking Tools##############
        self.pnlDocking = wx.Panel(id=wxID_ODMTOOLSPANEL1, name='pnlDocking',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
              style=wx.TAB_TRAVERSAL)
              
        self.grid1 = wx.grid.Grid(id=wxID_ODMTOOLSGRID1, name='grid1',
              parent=self.pnlDocking, pos=wx.Point(64, 160), size=wx.Size(376, 280),
              style=0)
        self.txtPythonScript = wx.stc.StyledTextCtrl(id=wxID_TXTPYTHONSCRIPT,
              name=u'txtPython', parent=self, pos=wx.Point(72, 24),
              size=wx.Size(368, 168), style=0)
              
        self.txtPythonConsole = wx.stc.StyledTextCtrl(id=wxID_TXTPYTHONCONSOLE,
              name=u'txtPython', parent=self, pos=wx.Point(72, 24),
              size=wx.Size(368, 168), style=0)
        self.grid1.EnableGridLines(True)        


        
################ Series Selection Panel ##################
           

        self.pnlSelector = pnlSeriesSelector.pnlSeriesSelector(id=wxID_PNLSELECTOR, name=u'pnlSelector',
               parent=self.pnlDocking, pos=wx.Point(0, 0), size=wx.Size(770, 388),
               style=wx.TAB_TRAVERSAL, dbservice= self.sc)

       

############# Graph ###############             
        
        #empty plot
        self.fig = matplotlib.figure.Figure()
        self.axis=self.fig.add_subplot(111)
        self.axis.axis([0, 1, 0, 1])#
        self.axis.plot([],[])  
              
        self.canvas = FigCanvas(self.pnlDocking, -1, self.fig)
        #self.axes.legend(loc= 'upper right')
        self.canvas.draw()
        
############ Docking ###################
        
        self._mgr = wx.aui.AuiManager(self.pnlDocking)
        self._mgr.AddPane(self.grid1, wx.RIGHT, 'Table View')
        self._mgr.AddPane(self.pnlSelector, wx.BOTTOM, 'Series Selector')
        #self._mgr.AddPane(self.txtPythonScript, wx.BOTTOM , 'Script')
        #self._mgr.AddPane(self.txtPythonConsole, wx.BOTTOM , 'Python Console')
        #self._mgr.AddPane(self._ribbon, wx.TOP)
        self._mgr.AddPane(self.canvas, wx.CENTER)
        self._mgr.Update()
        self.Bind(wx.EVT_CLOSE, self.OnClose)



        self._ribbon.Realize()
        self._init_sizers()
        

    def __init__(self, parent):
        self.createdummyService()
        self._init_ctrls(parent)
        self.Refresh()
    
    
    def addPlot(self, DataValue):
        """ Redraws the figure
        """

        for dv in DataValue:
            self.dataValues.append(DataValue.data_value)
            self.dateTimes.append(DataValue.local_date_time.toordinal())
        
        #t = [datetime.date(2012,01,01).toordinal(),datetime.date(2012,01,02).toordinal(),datetime.date(2012,01,03).toordinal(),datetime.date(2012,01,04).toordinal()]
        #s = self.data 

        x = range(len(self.dataValues))
        self.fig = matplotlib.figure.Figure()
        self.axis=self.fig.add_subplot(111)
        self.axis.axis([datetime.date(2008,01,01).toordinal(), datetime.date(2009,01,01).toordinal(), 0, 20])#
        self.axis.plot(self.dateTimes,self.dataValues)  
              
        self.canvas = FigCanvas(self.pnlDocking, -1, self.fig)
        #self.axes.legend(loc= 'upper right')
        self.canvas.draw()
        #self.draw_figure()



        #str = self.textbox.GetValue()
        #self.data = map(int, str.split())
        
        

        # clear the axes and redraw the plot anew
        #
        # self.axes.clear()        
        # #self.axes.grid(self.cb_grid.IsChecked())
        
        # self.axes.bar(
        #     left=x, 
        #     height=self.data, 
        #     width=50 / 100.0, 
        #     align='center', 
        #     alpha=0.44,
        #     picker=5)
        
        # self.canvas.draw()
        
    def OnClose(self, event):
        # deinitialize the frame manager
        self._mgr.UnInit()
        # delete the frame
        self.Destroy()
    
    def createdummyService(self):
        self.sc = SeriesService(connection_string="mssql+pyodbc://ODM:odm@(local)\sqlexpress/LittleBear11")#connection_string="mssql+pyodbc://ODM:odm@Arroyo/LittleBear11")
        # for site in self.sc.get_sites():
        #     print site
        

##    def BindAction(self):
##        #self.Bind(wx.EVT_MENU, self.test, None, 1)
##        #self.Bind(wx.EVT_BUTTON, self.OnBtnAdvButton, id = )
##        
##    def OnBtnAdvButton(self, event):
##        self.new = NewWindow(parent=None, id=-1)
##        self.new.Show()
    
    
    
if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()
    