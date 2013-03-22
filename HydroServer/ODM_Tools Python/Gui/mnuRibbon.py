#Boa:FramePanel:Panel1

import wx
import wx.lib.agw.ribbon as RB
from wx.lib.pubsub import Publisher

import pnlDatePicker
import frmDataFilters
import frmChangeValue
import frmAddPoint



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
 wxID_RIBBONPLOTDATESTART, wxID_FileMenu, wxID_STARTDPDATE, wxID_ENDDPDATE,
 wxID_FRAME1SPINCTRL1, wxID_RIBBONEDITFILTER,
 ] = [wx.NewId() for _init_ctrls in range(39)]

def CreateBitmap(xpm):
    bmp = wx.Image(xpm, wx.BITMAP_TYPE_ANY).ConvertToBitmap()
    return bmp   

class mnuRibbon(RB.RibbonBar):
    
    def _init_ctrls(self, prnt):
        RB.RibbonBar.__init__(self,  name='ribbon', parent=prnt, id=wxID_PANEL1)#, agwStyle = RB.RIBBON_BAR_ALWAYS_SHOW_TABS)

        #self.GetArtProvider().SetColourScheme("GRAY","LIGHT GRAY","WHITE")
        self.SetArtProvider(RB.RibbonAUIArtProvider())
        self.SetFont(wx.Font(9, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'Tahoma'))
        fileMenu = RB.RibbonPage(self, wxID_FileMenu, "File", CreateBitmap("images\\3d graph.png"))

#----PlotMenu-------------
        #self.ribbon= RB.RibbonBar(parent=self, id=wx.ID_ANY, name ='ribbon')
        home = RB.RibbonPage(self, wx.ID_ANY, "Plot", CreateBitmap("images\\3d graph.png"))

  #------Plot Type ---------------------------------------------------------------------------      
        
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

#-- PLOT OPTIONS-----------------------------------------------------------------------------                                
        PlotOptions_panel = RB.RibbonPanel(home, wx.ID_ANY, "Plot Options", wx.NullBitmap, wx.DefaultPosition,
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE) 
        self.PlotsOptions_bar = RB.RibbonButtonBar(PlotOptions_panel, wx.ID_ANY)

        self.PlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTTSTYPE, "Plot Type",  
                                CreateBitmap("images\\PlotType.png"), "")

        self.PlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSCOLOR, "Color Setting",  
                                CreateBitmap("images\\ColorSetting.png"), "")
        self.PlotsOptions_bar.AddSimpleButton(wxID_RIBBONPLOTTSLEGEND, "Show Legend",  
                                CreateBitmap("images\\Legend.png"), "")


        self.PlotsOptions_bar.AddSimpleButton( wxID_RIBBONPLOTDATESTART, "# Hist Bins" ,CreateBitmap("images\\Blank.png"), "") #,wx.Size(100, 21))
        self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTDATESTART, False)

        self.spnBins = wx.SpinCtrl(id=wxID_FRAME1SPINCTRL1, initial=0,
              max=100, min=0, name='spnBins', parent=self.PlotsOptions_bar,
              pos=wx.Point(126, 6), size=wx.Size(43, 25),
              style=wx.SP_ARROW_KEYS)
        self.spnBins.SetValue(50)
        self.spnBins.Enabled = False

        
        self.PlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTBOXTYPE, "Box Whisker Type",  
                                CreateBitmap("images\\BoxWhiskerType.png"), "")
        
        self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSTYPE, False) 
        self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSCOLOR, False) 
        self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSLEGEND, False) 
        self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTBOXTYPE, False)
                                
######################TEMPORARILY COMMENTED OUT
        
        # self.PlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTTYPE, "Histogram Type",  
        #                         CreateBitmap("images\\HisType.png"), "")
        # self.PlotsOptions_bar.AddDropdownButton(wxID_RIBBONPLOTHISTBIN, "Binning Algorithms",  
        #                         CreateBitmap("images\\Binning.png"), "")                                                
     
#-------------------------------------------------------------------------------
      




        dateTime_panel = RB.RibbonPanel(home, wx.ID_ANY, "Date Time", wx.NullBitmap, wx.DefaultPosition, 
                                        wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        #radio1 = wx.RadioButton( dummy_2, -1, " Radio1 ", style =wx.RB_GROUP )

        # dateTime_toolbar= RB.RibbonToolBar(dateTime_panel)
        dateTime_buttonbar = RB.RibbonButtonBar(dateTime_panel)
 
        # dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATESTART, "Start" ,CreateBitmap("images\\Calendar.png"), "") #,wx.Size(100, 21))
        # dateTime_buttonbar.AddHybridButton( wxID_RIBBONPLOTDATEEND, "End" ,CreateBitmap("images\\Calendar.png"), "") #,wx.Size(100, 21))
         # dateTime_buttonbar.AddTool(wxID_RIBBONPLOTDATESTART,  CreateBitmap("images\\Calendar.png"), kind=pnlDatePicker.pnlDatePicker, client_data=[wxID_RIBBONPLOTDATESTART, "startDate", "Start Date", wx.DateTimeFromDMY(30, 10, 2010, 0, 0, 0)])
        

         ###Filler buttons to allow enough room for start and end date drop down menus

        dateTime_buttonbar.AddSimpleButton( wxID_RIBBONPLOTDATESTART, "" ,CreateBitmap("images\\Blank.png"), "") #,wx.Size(100, 21))
        dateTime_buttonbar.AddSimpleButton( wxID_RIBBONPLOTDATESTART, "" ,CreateBitmap("images\\Blank.png"), "") #,wx.Size(100, 21))
        dateTime_buttonbar.AddSimpleButton( wxID_RIBBONPLOTDATESTART, "" ,CreateBitmap("images\\Blank.png"), "") #,wx.Size(100, 21))
        dateTime_buttonbar.EnableButton(wxID_RIBBONPLOTDATESTART, False)



        # self.staticText2 = wx.StaticText(id=wx.ID_ANY,
        #       label=u'Start Date:', name='staticText2', parent=dateTime_buttonbar,
        #       pos=wx.Point(0, 16), size=wx.Size(55, 13), style=0)
        self.dpStartDate = wx.DatePickerCtrl(id=wxID_STARTDPDATE, name=u'dpStartDate',
              parent=dateTime_buttonbar, pos=wx.Point(5, 8), size=wx.Size(120, 24),
              style=wx.DP_DROPDOWN)
        self.dpStartDate.SetValue(wx.DateTimeFromDMY(16, 1, 2008, 0, 0, 0))#wx.DateTimeFromDMY(30, 10, 2010, 0, 0, 0)        
        self.dpStartDate.SetLabel(repr(wx.DateTimeFromDMY(16, 1, 2008, 0, 0, 0)))#.strftime("%m-%d-%Y"))#"%Y-%m-%d'"")#'11/30/2010'
        self.dpStartDate.SetToolTipString(u'Start Date')
       

        # self.staticText1 = wx.StaticText(id=wx.ID_ANY,
        #       label=u'End Date:', name='staticText1', parent=dateTime_buttonbar,
        #       pos=wx.Point(0, 48), size=wx.Size(49, 13), style=0)

        self.dpEndDate = wx.DatePickerCtrl(id=wxID_ENDDPDATE, name=u'dpEndDate',
              parent=dateTime_buttonbar, pos=wx.Point(5, 40), size=wx.Size(120, 24),
              style=wx.DP_DROPDOWN)
        self.dpEndDate.SetValue(wx.DateTimeFromDMY(01, 04, 2008, 0, 0, 0))#wx.DateTimeFromDMY(30, 10, 2010, 0, 0, 0)        
        self.dpEndDate.SetLabel(repr(wx.DateTimeFromDMY(1, 04, 2008, 0, 0, 0)))#.strftime("%m-%d-%Y"))#"%Y-%m-%d'"")#'11/30/2010'
        self.dpEndDate.SetToolTipString(u'End Date')

        
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEREFRESH, "Refresh",  
                                CreateBitmap("images\\DateSetting.png"), "")
        dateTime_buttonbar.AddSimpleButton(wxID_RIBBONPLOTDATEFULL, "Full Date Range",  
                                CreateBitmap("images\\FullDateRange.png"), "")                                                                                          
                                    


     

       
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
        edit_bar.AddSimpleButton(wxID_RIBBONEDITFILTER, "Filter Points", 
                                CreateBitmap("images\\Filter List.png"), "") 
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
        # script_panel = RB.RibbonPanel(editPage, wx.ID_ANY, "Script", wx.NullBitmap, wx.DefaultPosition,
        #                                 wx.DefaultSize, RB.RIBBON_PANEL_NO_AUTO_MINIMISE)
        # script_bar = RB.RibbonButtonBar(script_panel)
        # script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTEXECUTE, "Execute",  
        #                         CreateBitmap("images\\Window Enter.png"), "") 
        # script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTOPEN, "Open",  
        #                         CreateBitmap("images\\Open file.png"), "")
        # script_bar.AddSimpleButton(wxID_RIBBONEDITSCRIPTNEW, "New",  
        #                         CreateBitmap("images\\File New.png"), "")
        # script_bar.AddHybridButton(wxID_RIBBONEDITSCRIPTSAVE, "Save",  
        #                         CreateBitmap("images\\Save (2).png"), "")                            

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
                                
        self.SetActivePageByIndex(1)

        self.BindEvents()  
        
                             
    def __init__(self, parent, id, name):
        self.parent=parent
        self._init_ctrls(parent)
        
    def BindEvents(self):
        #self.Bind(wx.EVT_MENU, self.test, None, 1)
        #self.Bind(wx.EVT_BUTTON, self.OnBtnAdvButton, id = )

        ###Docking Window Selection
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWTABLE) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWSERIES)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWPLOT)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWCONSOLE)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onDocking, id=wxID_RIBBONVIEWSCRIPT)


        ###Plot type Selection
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTTIMESERIES) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTPROB)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTBOX)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTHIST)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onPlotSelection, id=wxID_RIBBONPLOTSUMMARY)
        

        ###Dropdownbox events
        self.Bind(RB.EVT_RIBBONBUTTONBAR_DROPDOWN_CLICKED, self.OnPlotTypeDropdown, id=wxID_RIBBONPLOTTSTYPE)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_DROPDOWN_CLICKED, self.OnBoxTypeDropdown, id=wxID_RIBBONPLOTBOXTYPE)
        
        ###date changed
        self.Bind(wx.EVT_DATE_CHANGED, self.oneDateChanged, id = wxID_ENDDPDATE)
        self.Bind(wx.EVT_DATE_CHANGED, self.onsDateChanged, id = wxID_STARTDPDATE)
        self.Bind(wx.EVT_SPINCTRL, self.OnNumBins, id=wxID_FRAME1SPINCTRL1)

        
        ###Add event  to editab
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.onExecuteScript, id= wxID_RIBBONEDITSCRIPTEXECUTE)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED,  self.OnEditSeries, id= wxID_RIBBONEDITSERIES)




        ###Ribbon Event
        self.Bind(RB.EVT_RIBBONBAR_PAGE_CHANGED, self.OnFileMenu, id=wxID_PANEL1)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnShowLegend, id=wxID_RIBBONPLOTTSLEGEND)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditFilter, id= wxID_RIBBONEDITFILTER)  
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditChangeValue, id= wxID_RIBBONEDITCHGVALUE)                               
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditInterpolate, id= wxID_RIBBONEDITINTEROPOLATE)
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditFlag, id= wxID_RIBBONEDITFLAG) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditAddPoint, id= wxID_RIBBONEDITADDPOINT) 
        self.Bind(RB.EVT_RIBBONBUTTONBAR_CLICKED, self.OnEditDelPoint, id= wxID_RIBBONEDITDELPOINT)  

        self.isLegendVisible = False;


    def OnEditFilter(self, event):
        data_filter = frmDataFilters.frmDataFilter(self, self.parent.getEditService())
        self.filterlist = data_filter.ShowModal()
        pass
    def OnEditChangeValue(self, event):
        change_value=frmChangeValue.frmChangeValue(self)
        change_value.ShowModal()
        pass
    def OnEditInterpolate(self, event):
        pass
    def OnEditFlag(self, event):
        pass
    def OnEditAddPoint(self, event):
        add_value=frmAddPoint.frmAddPoint(self)
        add_value.ShowModal()
    def OnEditDelPoint(self, event):
        pass

    def OnEditSeries(self, event):
        Publisher.sendMessage(("selectEdit"), event)

    def OnNumBins(self, event):
        Publisher.sendMessage(("OnNumBins"), event.Selection)

    def OnShowLegend(self, event):
        Publisher.sendMessage(("OnShowLegend"), [event, self.isLegendVisible])        
        self.isLegendVisible = not self.isLegendVisible

    def oneDateChanged(self,event):
        # print dir(event)
        Publisher.sendMessage(("onDateChanged"), [event.Date, "end"])

    def onsDateChanged(self,event):
        # print event.Date
        Publisher.sendMessage(("onDateChanged"), [event.Date, "start"])

    def OnFileMenu(self, event):
        if self.GetActivePage()==0:
            menu = wx.Menu()
            self.Bind(wx.EVT_MENU,  self.onChangeDBConfig, menu.Append(wx.ID_ANY, "Change DB Configuration"))
            self.Bind(wx.EVT_MENU, self.onClose, menu.Append(wx.ID_ANY, "Close"))

            self.PopupMenu(menu) 

    def onClose(self, event):
        Publisher.sendMessage(("onClose"), event)


    def onChangeDBConfig(self, event):
        Publisher().sendMessage(("change.dbConfig"), event)
        self.SetActivePageByIndex(1)
               
        
    def onExecuteScript(self, event):
        Publisher().sendMessage(("execute.script"), event)


    def OnBoxTypeDropdown(self, event):
        menu = wx.Menu()
        self.Bind(wx.EVT_MENU,  self.OnBoxMonthly, menu.Append(wx.ID_ANY, "Monthly") )       
        self.Bind(wx.EVT_MENU,  self.OnBoxYearly, menu.Append(wx.ID_ANY, "Yearly"))
        self.Bind(wx.EVT_MENU,  self.OnBoxSeasonal, menu.Append(wx.ID_ANY, "Seasonal"))
        self.Bind(wx.EVT_MENU,  self.OnBoxOverall, menu.Append(wx.ID_ANY, "Overall"))

        event.PopupMenu(menu)  


    def OnBoxMonthly(self, event):
        Publisher().sendMessage(("box.Monthly"), event)

    def OnBoxYearly(self, event):
        Publisher().sendMessage(("box.Yearly"), event)

    def OnBoxSeasonal(self, event):
        Publisher().sendMessage(("box.Seasonal"), event)

    def OnBoxOverall(self, event):
        Publisher().sendMessage(("box.Overall"), event)      

    def OnPlotTypeDropdown(self, event):
        menu = wx.Menu()
        self.Bind(wx.EVT_MENU,  self.OnPlotTypeLine, menu.Append(wx.ID_ANY, "Line"))
        self.Bind(wx.EVT_MENU,  self.OnPlotTypePoint, menu.Append(wx.ID_ANY, "Point"))
        self.Bind(wx.EVT_MENU,  self.OnPlotTypeBoth, menu.Append(wx.ID_ANY, "Both"))

        event.PopupMenu(menu) 

    def OnPlotTypeLine(self, event):
        Publisher().sendMessage(("onPlotType"), [event, "line"])

    def OnPlotTypePoint(self, event):
        Publisher().sendMessage(("onPlotType"), [event, "point"])

    def OnPlotTypeBoth(self, event):
        Publisher().sendMessage(("onPlotType"), [event, "both"])


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
        self.enableButtons(value)
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
            

    def enableButtons(self, plot):
        ##tims series or probability
        if plot == 0 or plot == 1:
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSTYPE, True) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSCOLOR, True) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSLEGEND, True) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTBOXTYPE, False) 
            self.spnBins.Enabled = False
        ##HIstogram
        elif plot == 2:
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSTYPE, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSCOLOR, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSLEGEND, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTBOXTYPE, False) 
            self.spnBins.Enabled = True
        ##Box Plot
        elif plot == 3:
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSTYPE, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSCOLOR, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSLEGEND, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTBOXTYPE, True) 
            self.spnBins.Enabled = False
         #Summary   
        elif plot == 4: 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSTYPE, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSCOLOR, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTTSLEGEND, False) 
            self.PlotsOptions_bar.EnableButton(wxID_RIBBONPLOTBOXTYPE, False)   
            self.spnBins.Enabled = False



        
            
##        
##    def OnBtnAdvButton(self, event):
##        self.new = NewWindow(parent=None, id=-1)
##        self.new.Show()
     
        
