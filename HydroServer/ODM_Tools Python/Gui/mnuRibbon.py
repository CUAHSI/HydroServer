#Boa:FramePanel:Panel1

import wx
import wx.lib.agw.ribbon as RB
from wx.lib.pubsub import Publisher

import pnlDatePicker


[wxID_PANEL1, wxID_RIBBONPLOTTIMESERIES, wxID_RIBBONPLOTPROB,
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
 ] = [wx.NewId() for _init_ctrls in range(34)]

def CreateBitmap(xpm):
    bmp = wx.Image(xpm, wx.BITMAP_TYPE_ANY).ConvertToBitmap()
    return bmp   

class mnuRibbon(RB.RibbonBar):
    
    def _init_ctrls(self, prnt):
        RB.RibbonBar.__init__(self,  name='ribbon', parent=prnt, id=wxID_PANEL1)

        #self.GetArtProvider().SetColourScheme("GRAY","LIGHT GRAY","WHITE")
        self.SetArtProvider(RB.RibbonAUIArtProvider())
        self.SetFont(wx.Font(20, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'Tahoma'))

        #self.ribbon= RB.RibbonBar(parent=self, id=wx.ID_ANY, name ='ribbon')
        home = RB.RibbonPage(self, wx.ID_ANY, "Plot", CreateBitmap("images\\3d graph.png"))
        
        plot_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plots", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        plots_bar = RB.RibbonButtonBar(plot_panel, wx.ID_ANY)           
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTTIMESERIES, "Time Series",  
                                CreateBitmap("images\\TSA_icon.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTPROB, "Probablity",  
                                CreateBitmap("images\\Probability.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTHIST, "Histogram",  
                                CreateBitmap("images\\Histogram.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTBOX, "Box/Whisker",  
                                CreateBitmap("images\\BoxWisker.png"), "")
        plots_bar.AddSimpleButton(wxID_RIBBONPLOTSUMMARY, "Summary",  
                                CreateBitmap("images\\Summary.png"), "")

#--TIME SERIES PLOT OPTIONS-----------------------------------------------------------------------------                                
        tsPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        tsPlotsOptions_bar = RB.RibbonButtonBar(tsPlotOptions_panel, wx.ID_ANY)
        tsPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTTSTYPE, "Plot Type",  
                                CreateBitmap("images\\PlotType.png"), "")
        tsPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSCOLOR, "Color Setting",  
                                CreateBitmap("images\\ColorSetting.png"), "")
        tsPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSLEGEND, "Show Legend",  
                                CreateBitmap("images\\Legend.png"), "")
                                
#- BOXPLOT OPTIONS------------------------------------------------------------------------------                                
        


        boxPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        boxPlotsOptions_bar = RB.RibbonButtonBar(boxPlotOptions_panel, wx.ID_ANY)
        boxPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTBOXTYPE, "Box Whisker Type",  
                                CreateBitmap("images\\BoxWhiskerType.png"), "")
        boxPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSCOLOR, "Color Setting",  
                                CreateBitmap("images\\ColorSetting.png"), "")
        tsPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSLEGEND, "Show Legend",  
                                CreateBitmap("images\\Legend.png"), "")
                                
#- HISTOGRAM PLOT OPTIONS------------------------------------------------------------------------------
        # histPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
        #                                 wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        # histPlotsOptions_bar = RB.RibbonButtonBar(histPlotOptions_panel, wx.ID_ANY)
        # histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTTYPE, "Histogram Type", CreateBitmap("images\\HisType.png"), "") 
        # histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTBIN, "Binning Algorithms",  
        #                         CreateBitmap("images\\Binning.png"), "")            



        histPlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        histPlotsOptions_bar = RB.RibbonButtonBar(histPlotOptions_panel, wx.ID_ANY)
        histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTTYPE, "Histogram Type",  
                                CreateBitmap("images\\HisType.png"), "")
        histPlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTBIN, "Binning Algorithms",  
                                CreateBitmap("images\\Binning.png"), "")
        histPlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSLEGEND, "Show Legend",  
                                CreateBitmap("images\\Legend.png"), "")                                                        
     
#-------------------------------------------------------------------------------
        dateTime_panel = RB.RibbonPanel(home, wx.ID_ANY, "Date Time", wx.NullBitmap, wx.DefaultPosition, 
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        #radio1 = wx.RadioButton( dummy_2, -1, " Radio1 ", style =wx.RB_GROUP )

        # dateTime_toolbar= RB.RibbonToolBar(dateTime_panel)
        dateTime_buttonbar = RB.RibbonButtonBar(dateTime_panel)
 
        dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATESTART, "Start" ,CreateBitmap("images\\Calendar.png"), "") #,wx.Size(100, 21))
        dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATEEND, "End" ,CreateBitmap("images\\Calendar.png"), "") #,wx.Size(100, 21))
       # dateTime_buttonbar.AddTool(wxID_RIBBONPLOTDATESTART,  CreateBitmap("images\\Calendar.png"), kind=pnlDatePicker.pnlDatePicker, client_data=[wxID_RIBBONPLOTDATESTART, "startDate", "Start Date", wx.DateTimeFromDMY(30, 10, 2010, 0, 0, 0)])
        
        
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEREFRESH, "Refresh",  
                                CreateBitmap("images\\DateSetting.png"), "")
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEFULL, "Full Date Range",  
                                CreateBitmap("images\\FullDateRange.png"), "")                                                                                          
                                    





        # self.startDate = pnlDatePicker.pnlDatePicker( home, wxID_RIBBONPLOTDATESTART, 
        #          "Start Date", wx.DateTimeFromDMY(30, 10, 2010, 0, 0, 0))
        # self.endDate = pnlDatePicker.pnlDatePicker( home, wxID_RIBBONPLOTDATEEND, 
        #          "End Date", wx.DateTimeFromDMY(30, 9, 2009, 0, 0, 0))

       
#-------------------------------------------------------------------------------
        editPage = RB.RibbonPage(self, wx.ID_ANY, "Edit", CreateBitmap("images\\Brush.png"))
        
        main_panel = RB.RibbonPanel(editPage, wx.ID_ANY, "Main", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        main_bar = RB.RibbonButtonBar(main_panel)                                                                 
        main_bar.AddSimpleButton(wxID_RIBBONEDITSERIES, "Edit Series",  
                                CreateBitmap("images\\Edit (2).png"), "")                                                                                            
        main_bar.AddSimpleButton(wxID_RIBBONEDITDERIVE, "Derive New Series",  
                                CreateBitmap("images\\DeriveNewSeries.png"), "")                                                                                            
        main_bar.AddSimpleButton(wxID_RIBBONEDITRESTORE, "Restore",  
                                CreateBitmap("images\\Restore.png"), "")                                                                                            
        main_bar.AddHybridButton(wxID_RIBBONEDITSAVE, "Save",  
                                CreateBitmap("images\\Save Data.png"), "")                                                                                            
 
 #------------------------------------------------------------------------------
        edit_panel = RB.RibbonPanel( editPage, wx.ID_ANY, "Edit Functions" , wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        edit_bar= RB.RibbonButtonBar(edit_panel)
        edit_bar.AddSimpleButton(wxID_RIBBONEDITCHGVALUE, "Change Value", 
                                CreateBitmap("images\\EditView_icon.png"), "")                                
        edit_bar.AddSimpleButton(wxID_RIBBONEDITINTEROPOLATE, "Interpolate", 
                                CreateBitmap("images\\Interpolate.png"), "") 
        edit_bar.AddSimpleButton(wxID_RIBBONEDITFLAG, "Flag",  
                                CreateBitmap("images\\Flag.png"), "")  
        edit_bar.AddSimpleButton(wxID_RIBBONEDITADDPOINT, "Add Point",  
                                CreateBitmap("images\\Add (2).png"), "")
        edit_bar.AddSimpleButton(wxID_RIBBONEDITDELPOINT, "Delete Point",  
                                CreateBitmap("images\\Delete (3).png"), "")                                                                                                                                                              

#------------------------------------------------------------------------------- 
        script_panel = RB.RibbonPanel(editPage, wx.ID_ANY, "Script", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        script_bar = RB.RibbonButtonBar(script_panel)
        script_bar.AddSimpleButton(wx.ID_ANY, "Execute",  
                                CreateBitmap("images\\Window Enter.png"), "") 
        script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTOPEN, "Open",  
                                CreateBitmap("images\\Open file.png"), "")
        script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTNEW, "New",  
                                CreateBitmap("images\\File New.png"), "")
        script_bar.AddHybridButton(wxID_RIBBONEDITSCRIPTSAVE, "Save",  
                                CreateBitmap("images\\Save (2).png"), "")                            

#-------------------------------------------------------------------------------
        viewPage = RB.RibbonPage(self, wx.ID_ANY, "View", CreateBitmap("images\\Brush.png"))
        view_panel = RB.RibbonPanel( viewPage, wx.ID_ANY, "Tools" , wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)                                                                                                                
        view_bar= RB.RibbonButtonBar(view_panel)
        view_bar.AddSimpleButton(wxID_RIBBONVIEWPLOT, "Plot", 
                                CreateBitmap("images\\Line Chart.png"), "")                                
        view_bar.AddSimpleButton(wxID_RIBBONVIEWTABLE, "Table", 
                                CreateBitmap("images\\Table.png"), "") 
        view_bar.AddSimpleButton(wxID_RIBBONVIEWSERIES, "Series Selector",  
                                CreateBitmap("images\\Bitmap editor.png"), "")  
        view_bar.AddSimpleButton(wxID_RIBBONVIEWCONSOLE, "Python Console",  
                                CreateBitmap("images\\Window Command Line.png"), "")
        view_bar.AddSimpleButton(wxID_RIBBONVIEWSCRIPT, "PythonScript",  
                                CreateBitmap("images\\Script.png"), "") 
                                
        self.BindEvents()  
        
                             
    def __init__(self, parent, id, name):
        self._init_ctrls(parent)
        
    def BindEvents(self):
        #self.Bind(wx.EVT_MENU, self.test, None, 1)
        #self.Bind(wx.EVT_BUTTON, self.OnBtnAdvButton, id = )
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWTABLE) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWSERIES)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWPLOT)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWCONSOLE)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWSCRIPT)

        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTTIMESERIES) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTPROB)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTBOX)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTHIST)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTSUMMARY)

        

    def onPlotSelection(self, event):
        if event.Id == wxID_RIBBONPLOTTIMESERIES:       
            value = 0
        elif event.Id ==wxID_RIBBONPLOTPROB:
            value= 1
        elif event.Id == wxID_RIBBONPLOTHIST:
            value=2
        elif event.Id == wxID_RIBBONPLOTBOX:
            value=3
        elif event.Id == wxID_RIBBONPLOTSUMMARY:
            value= 4  
        Publisher().sendMessage(("select.Plot"), value)



    def onDocking(self, event):
        
        if event.Id == wxID_RIBBONVIEWSCRIPT:
            value = "Script"
        elif event.Id ==wxID_RIBBONVIEWCONSOLE:
            value= "Console"
        elif event.Id == wxID_RIBBONVIEWSERIES:
            value="Selector"
        elif event.Id == wxID_RIBBONVIEWTABLE:
            value="Table"
        elif event.Id == wxID_RIBBONVIEWPLOT:
            value= "Plot"       
                 
        Publisher().sendMessage(("adjust.Docking"), value)
            
##        
##    def OnBtnAdvButton(self, event):
##        self.new = NewWindow(parent=None, id=-1)
##        self.new.Show()
     
        
