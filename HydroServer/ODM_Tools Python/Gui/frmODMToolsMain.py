#Boa:Frame:ODMTools

import wx
import wx.grid
import wx.lib.plot
import wx.lib.agw.ribbon as RB
import wx.aui
import wx.richtext
import wx.stc
import matplotlib
import datetime

import sys
sys.path.append('C:\DEV\ODM\HydroServer\ODM_Tools Python')

from odmservices.series_service import SeriesService
##import numpy
##import pylab
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import \
    FigureCanvasWxAgg as FigCanvas, \
    NavigationToolbar2WxAgg as NavigationToolbar
    
    
def CreateBitmap(xpm):
    #bmp = wx.Bitmap("bitmaps/%s"%xpm, wx.BITMAP_TYPE_XPM)   
     
    bmp = wx.Image(xpm, wx.BITMAP_TYPE_ANY).ConvertToBitmap()
    #bmp = bmp.Scale(32, 32, wx.IMAGE_QUALITY_HIGH)
    return bmp    
    

def create(parent):
    return frmODMToolsMain(parent)

[wxID_ODMTOOLS, wxID_ODMTOOLSCHECKLISTBOX2, wxID_ODMTOOLSCOMBOBOX1, 
 wxID_ODMTOOLSCOMBOBOX2, wxID_ODMTOOLSCOMBOBOX4, wxID_ODMTOOLSCOMBOBOX5, 
 wxID_ODMTOOLSGRID1, wxID_ODMTOOLSPANEL1, wxID_ODMTOOLSPANEL2, 
 wxID_ODMTOOLSTOOLBAR1,  wxID_PNLSELECTOR, wxID_PNLSELECTORCHECKBOX1, 
 wxID_PNLSELECTORCHECKBOX2,  wxID_PNLSELECTORCHECKLISTBOX1, wxID_PNLSELECTORCOMBOBOX1, 
 wxID_PNLSELECTORCOMBOBOX2, wxID_PNLSELECTORCOMBOBOX3,  wxID_PNLSELECTORCOMBOBOX4, 
 wxID_PNLSELECTORPNLSELECTOR,  wxID_PNLSELECTORPNLSITE, wxID_PNLSELECTORPNLVARIABLE, 
 wxID_PNLSELECTORSTATICTEXT1, wxID_PNLSELECTORSTATICTEXT2,wxID_TXTPYTHONSCRIPT, 
 wxID_TXTPYTHONCONSOLE, wxID_RIBBONPLOTTIMESERIES, wxID_RIBBONTPLOTPROB,
 wxID_RIBBONPLOTHIST, wxID_RIBBONPLOTBOX, wxID_RIBBONPLOTSUMMARY, 
 wxID_RIBBONPLOTTSTYPE, wxID_RIBBONPLOTTSCOLOR, wxID_RIBBONPLOTTSLEGEND,
 wxID_RIBBONPLOTBOXTYPE, wxID_RIBBONPLOTHISTTYPE, wxID_RIBBONPLOTHISTBIN,
 wxID_RIBBONPLOTDATEEND, wxID_RIBBONPLOTDATEREFRESH, wxID_RIBBONPLOTDATEFULL,
 wxID_RIBBONEDITSERIES, wxID_RIBBONEDITDERIVE, wxID_RIBBONEDITRESTORE,
 wxID_RIBBONEDITSAVE, wxID_RIBBONEDITCHGVALUE, wxID_RIBBONEDITINTEROPOLATE, 
 wxID_RIBBONEDITFLAG, wxID_RIBBONEDITADDPOINT, wxID_RIBBONEDITDELPOINT,
 wxID_RIBBONEDITSCRIPTEXECUTE, wxID_RIBBONEDITSCRIPTOPEN, wxID_RIBBONEDITSCRIPTNEW,
 wxID_RIBBONEDITSCRIPTSAVE, wxID_RIBBONVIEWPLOT, wxID_RIBBONVIEWTABLE,
 wxID_RIBBONVIEWSERIES, wxID_RIBBONVIEWCONSOLE, wxID_RIBBONVIEWSCRIPT,
 wxID_RIBBONPLOTDATESTART,
] = [wx.NewId() for _init_ctrls in range(58)]

class frmODMToolsMain(wx.Frame):
    
    
############# Series Selector Sizers ########
    
    def _init_coll_boxSizer3_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkListBox1, 100, border=3,
              flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer4_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkBox1, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.staticText1, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.comboBox2, 30, border=3, flag=wx.ALL)
        parent.AddWindow(self.comboBox1, 50, border=3, flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.pnlSite, 20, border=3, flag=wx.EXPAND | wx.ALL)
        parent.AddWindow(self.pnlVariable, 20, border=3,
              flag=wx.EXPAND | wx.ALL)
        parent.AddWindow(self.pnlSeries, 60, border=3,
              flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkBox2, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.staticText2, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.comboBox3, 30, border=3, flag=wx.ALL)
        parent.AddWindow(self.comboBox4, 50, border=3, flag=wx.EXPAND | wx.ALL)

    def _init_sizersSelector(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self.boxSizer3 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer4 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)
        self._init_coll_boxSizer3_Items(self.boxSizer3)
        self._init_coll_boxSizer4_Items(self.boxSizer4)

        self.pnlSelector.SetSizer(self.boxSizer1)
        self.pnlVariable.SetSizer(self.boxSizer2)
        self.pnlSite.SetSizer(self.boxSizer4)
        self.pnlSeries.SetSizer(self.boxSizer3)
        
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
              pos=wx.Point(863, 545), size=wx.Size(621, 496),
              style=wx.DEFAULT_FRAME_STYLE, title=u'ODM Tools')
        self.SetClientSize(wx.Size(605, 458))
              
              
              
############### Ribbon ###################
        self._ribbon = RB.RibbonBar(parent=self, id=wx.ID_ANY, name ='ribbon')
        home = RB.RibbonPage(self._ribbon, wx.ID_ANY, "Plot", CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\3d graph.png"))
        
        plot_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plots", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        plots_bar = RB.RibbonButtonBar(plot_panel, wx.ID_ANY)           
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTTIMESERIES, "Time Series",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\TSA_icon.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONTPLOTPROB, "Probablity",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Probability.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONTPLOTPROB, "Histogram",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Histogram.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTBOX, "Box/Whisker",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\BoxWisker.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTSUMMARY, "Summary",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Summary.png"), "")

#-------------------------------------------------------------------------------                                
        tsPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        tsPlotsOptions_bar = RB.RibbonButtonBar(tsPlotOptions_panel, wx.ID_ANY)
        tsPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTTSTYPE, "Plot Type",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\PlotType.png"), "")
        tsPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSCOLOR, "Color Setting",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\ColorSetting.png"), "")
        tsPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSLEGEND, "Show Legend",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Legend.png"), "")
                                
#-------------------------------------------------------------------------------                                
        boxPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        boxPlotsOptions_bar = RB.RibbonButtonBar(boxPlotOptions_panel, wx.ID_ANY)
        boxPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTBOXTYPE, "Box Whisker Type",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\BoxWhiskerType.png"), "")
                                
#-------------------------------------------------------------------------------
        histPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        histPlotsOptions_bar = RB.RibbonButtonBar(histPlotOptions_panel, wx.ID_ANY)
        histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTTYPE, "Histogram Type",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\HisType.png"), "") 
        histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTBIN, "Binning Algorithms",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Binning.png"), "")                                                                    
     
#-------------------------------------------------------------------------------
        dateTime_panel = RB.RibbonPanel(home, wx.ID_ANY, "Date Time", wx.NullBitmap, wx.DefaultPosition, 
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        #dateTime_toolbar= RB.RibbonToolBar(dateTime_panel)
        dateTime_buttonbar = RB.RibbonButtonBar(dateTime_panel)
        dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATESTART, "Start" ,CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Calendar.png"), "") #,wx.Size(100, 21))
        dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATEEND, "End" ,CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Calendar.png"), "") #,wx.Size(100, 21))
        
        
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEREFRESH, "Refresh",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\DateSetting.png"), "")
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEFULL, "Full Date Range",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\FullDateRange.png"), "")                                                                                            
                                    
#-------------------------------------------------------------------------------
        editPage = RB.RibbonPage(self._ribbon, wx.ID_ANY, "Edit", CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Brush.png"))
        
        main_panel = RB.RibbonPanel(editPage, wx.ID_ANY, "Main", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        main_bar = RB.RibbonButtonBar(main_panel)                                                                 
        main_bar.AddSimpleButton(wxID_RIBBONEDITSERIES, "Edit Series",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Edit (2).png"), "")                                                                                            
        main_bar.AddSimpleButton(wxID_RIBBONEDITDERIVE, "Derive New Series",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\DeriveNewSeries.png"), "")                                                                                            
        main_bar.AddSimpleButton(wxID_RIBBONEDITRESTORE, "Restore",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Restore.png"), "")                                                                                            
        main_bar.AddHybridButton(wxID_RIBBONEDITSAVE, "Save",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Save Data.png"), "")                                                                                            
 
 #------------------------------------------------------------------------------
        edit_panel = RB.RibbonPanel( editPage, wx.ID_ANY, "Edit Functions" , wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        edit_bar= RB.RibbonButtonBar(edit_panel)
        edit_bar.AddSimpleButton(wxID_RIBBONEDITCHGVALUE, "Change Value", 
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\EditView_icon.png"), "")                                
        edit_bar.AddSimpleButton(wxID_RIBBONEDITINTEROPOLATE, "Interpolate", 
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Interpolate.png"), "") 
        edit_bar.AddSimpleButton(wxID_RIBBONEDITFLAG, "Flag",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Flag.png"), "")  
        edit_bar.AddSimpleButton(wxID_RIBBONEDITADDPOINT, "Add Point",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Add (2).png"), "")
        edit_bar.AddSimpleButton(wxID_RIBBONEDITDELPOINT, "Delete Point",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Delete (3).png"), "")                                                                                                                                                              

#------------------------------------------------------------------------------- 
        script_panel = RB.RibbonPanel(editPage, wx.ID_ANY, "Script", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        script_bar = RB.RibbonButtonBar(script_panel)
        script_bar.AddSimpleButton(wx.ID_ANY, "Execute",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Window Enter.png"), "") 
        script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTOPEN, "Open",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Open file.png"), "")
        script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTNEW, "New",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\File New.png"), "")
        script_bar.AddHybridButton(wxID_RIBBONEDITSCRIPTSAVE, "Save",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Save (2).png"), "")                            

#-------------------------------------------------------------------------------
        viewPage = RB.RibbonPage(self._ribbon, wx.ID_ANY, "View", CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Brush.png"))
        view_panel = RB.RibbonPanel( viewPage, wx.ID_ANY, "Tools" , wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)                                                                                                                
        view_bar= RB.RibbonButtonBar(view_panel)
        view_bar.AddSimpleButton(wxID_RIBBONVIEWPLOT, "Plot", 
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Line Chart.png"), "")                                
        view_bar.AddSimpleButton(wxID_RIBBONVIEWTABLE, "Table", 
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Table.png"), "") 
        view_bar.AddSimpleButton(wxID_RIBBONVIEWSERIES, "Series Selector",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Bitmap editor.png"), "")  
        view_bar.AddSimpleButton(wxID_RIBBONVIEWCONSOLE, "Python Console",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Window Command Line.png"), "")
        view_bar.AddSimpleButton(wxID_RIBBONVIEWSCRIPT, "PythonScript",  
                                CreateBitmap("C:\\Users\\Stephanie\\Pictures\\icons\\png\\32x32\\Script.png"), "") 
              
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
           
        self.pnlSelector = wx.Panel(id=wxID_PNLSELECTOR, name=u'pnlSelector',
              parent=self.pnlDocking, pos=wx.Point(0, 0), size=wx.Size(770, 388),
              style=wx.TAB_TRAVERSAL)

        self.pnlSite = wx.Panel(id=wxID_PNLSELECTORPNLSITE, name=u'pnlSite',
              parent=self.pnlSelector, pos=wx.Point(3, 3), size=wx.Size(748, 29),
              style=wx.TAB_TRAVERSAL)
        self.pnlSite.SetMinSize(wx.Size(-1, 30))
        self.pnlSite.SetLabel(u'pnlSite')

        self.comboBox2 = wx.ComboBox(choices=[], id=wxID_PNLSELECTORCOMBOBOX2,
              name='comboBox2', parent=self.pnlSite, pos=wx.Point(107, 3),
              size=wx.Size(235, 21), style=0, value='comboBox2')

        self.checkBox1 = wx.CheckBox(id=wxID_PNLSELECTORCHECKBOX1, label=u'',
              name='checkBox1', parent=self.pnlSite, pos=wx.Point(3, 3),
              size=wx.Size(18, 21), style=0)
        self.checkBox1.SetValue(False)

        self.comboBox1 = wx.ComboBox(choices=[], id=wxID_PNLSELECTORCOMBOBOX1,
              name='comboBox1', parent=self.pnlSite, pos=wx.Point(348, 3),
              size=wx.Size(397, 21), style=0, value='comboBox1')

        self.staticText1 = wx.StaticText(id=wxID_PNLSELECTORSTATICTEXT1,
              label=u'Site', name='staticText1', parent=self.pnlSite,
              pos=wx.Point(27, 3), size=wx.Size(74, 19), style=0)
        self.staticText1.SetToolTipString(u'staticText1')
        self.staticText1.SetFont(wx.Font(13, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'MS Serif'))

        self.pnlVariable = wx.Panel(id=wxID_PNLSELECTORPNLVARIABLE,
              name=u'pnlVariable', parent=self.pnlSelector, pos=wx.Point(3, 38),
              size=wx.Size(748, 29), style=wx.TAB_TRAVERSAL)
        self.pnlVariable.SetMinSize(wx.Size(-1, 30))
        self.pnlVariable.SetHelpText(u'')
        self.pnlVariable.SetMaxSize(wx.Size(-1, 30))

        self.comboBox3 = wx.ComboBox(choices=[], id=wxID_PNLSELECTORCOMBOBOX3,
              name='comboBox3', parent=self.pnlVariable, pos=wx.Point(107, 3),
              size=wx.Size(235, 21), style=0, value='comboBox3')

        self.checkBox2 = wx.CheckBox(id=wxID_PNLSELECTORCHECKBOX2, label=u'',
              name='checkBox2', parent=self.pnlVariable, pos=wx.Point(3, 3),
              size=wx.Size(18, 16), style=0)
        self.checkBox2.SetValue(True)

        self.staticText2 = wx.StaticText(id=wxID_PNLSELECTORSTATICTEXT2,
              label=u'Variable', name='staticText2', parent=self.pnlVariable,
              pos=wx.Point(27, 3), size=wx.Size(74, 19), style=0)
        self.staticText2.SetFont(wx.Font(13, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'MS Serif'))

        self.comboBox4 = wx.ComboBox(choices=[], id=wxID_PNLSELECTORCOMBOBOX4,
              name='comboBox4', parent=self.pnlVariable, pos=wx.Point(348, 3),
              size=wx.Size(397, 21), style=0, value='comboBox4')

        self.pnlSeries = wx.Panel(id=wxID_PNLSELECTORPNLSELECTOR,
              name=u'pnlSelector', parent=self.pnlSelector, pos=wx.Point(3, 73),
              size=wx.Size(748, 274), style=wx.TAB_TRAVERSAL)

        self.checkListBox1 = wx.CheckListBox(choices=[],
              id=wxID_PNLSELECTORCHECKLISTBOX1, name='checkListBox1',
              parent=self.pnlSeries, pos=wx.Point(3, 3), size=wx.Size(742,
              268), style=0)
        self.checkListBox1.SetMinSize(wx.Size(-1, -1))

        self._init_sizersSelector()
      

############# Graph ###############             
        self.data = [9, 6, 5, 14]
        
        t = [datetime.date(2012,01,01).toordinal(),datetime.date(2012,01,02).toordinal(),datetime.date(2012,01,03).toordinal(),datetime.date(2012,01,04).toordinal()]
        s = self.data        
##        pylab.plot(t, s)
## 
##        pylab.xlabel('DateTime')
##        pylab.ylabel('Value')
##        pylab.title('SiteName')
##        pylab.grid(True)
## 
##        pylab.show()

        x = range(len(self.data))
        self.fig = matplotlib.figure.Figure()
        self.axis=self.fig.add_subplot(111)
        self.axis.axis([datetime.date(2011,12,31).toordinal(), datetime.date(2012,01,05).toordinal(), 0, 20])#
        self.axis.plot(t,s)  
              
        self.canvas = FigCanvas(self.pnlDocking, -1, self.fig)
        #self.axes.legend(loc= 'upper right')
        self.canvas.draw()
        #self.draw_figure()
        
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
    
    
    def draw_figure(self):
        """ Redraws the figure
        """
        #str = self.textbox.GetValue()
        #self.data = map(int, str.split())
        
        

        # clear the axes and redraw the plot anew
        #
        self.axes.clear()        
        #self.axes.grid(self.cb_grid.IsChecked())
        
        self.axes.bar(
            left=x, 
            height=self.data, 
            width=50 / 100.0, 
            align='center', 
            alpha=0.44,
            picker=5)
        
        self.canvas.draw()
        
    def OnClose(self, event):
        # deinitialize the frame manager
        self._mgr.UnInit()
        # delete the frame
        self.Destroy()
    
    def createdummyService(self):
        self.sc = SeriesService("mssql+pyodbc://NIDIS:N1d1s!@drought.uwrl.usu.edu\Summary")
        for site in self.sc.get_sites():
            print site
        

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
    