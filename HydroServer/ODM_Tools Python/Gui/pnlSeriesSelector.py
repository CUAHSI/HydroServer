#Boa:FramePanel:pnlSeriesSelector

import wx
import frmQueryBuilder
from wx.lib.pubsub import Publisher
import frmODMToolsMain

[wxID_PNLSERIESSELECTOR, wxID_PNLSERIESSELECTORBTNFILTER, 
 wxID_PNLSERIESSELECTORBTNVIEWALL, wxID_PNLSERIESSELECTORBTNVIEWSELECTED, 
 wxID_PNLSERIESSELECTORCBSITES, wxID_PNLSERIESSELECTORCBVARIABLES, 
 wxID_PNLSERIESSELECTORCHECKSITE, wxID_PNLSERIESSELECTORCHECKVARIABLE, 
 wxID_PNLSERIESSELECTORLBLSITE, wxID_PNLSERIESSELECTORLBLVARIABLE, 
 wxID_PNLSERIESSELECTORLISTSERIES, wxID_PNLSERIESSELECTORPANEL1, 
 wxID_PNLSERIESSELECTORPANEL2, wxID_PNLSERIESSELECTORPANEL3, 
 wxID_PNLSERIESSELECTORPANEL4, 
] = [wx.NewId() for _init_ctrls in range(15)]

class pnlSeriesSelector(wx.Panel):
    
        
    def _init_coll_boxSizer5_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.btnFilter, 0, border=0, flag=0)
        parent.AddWindow(self.panel4, 70, border=0, flag=0)
        parent.AddWindow(self.btnViewAll, 0, border=0, flag=0)
        parent.AddWindow(self.btnViewSelected, 0, border=0, flag=0)

    def _init_coll_boxSizer3_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.listSeries, 100, border=5,
              flag=wx.EXPAND | wx.ALL)

    def _init_coll_boxSizer4_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkSite, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblSite, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbSites, 85, border=3, flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.panel1, 15, border=3, flag=wx.EXPAND | wx.ALL)
        parent.AddWindow(self.panel2, 15, border=3, flag=wx.EXPAND | wx.ALL)
        parent.AddSizer(self.boxSizer5, 15, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.panel3, 50, border=3, flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkVariable, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblVariable, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbVariables, 85, border=3,
              flag=wx.EXPAND | wx.ALL)

    def _init_coll_listSeries_Columns(self, parent):
        # generated method, don't edit

        parent.InsertColumn(col=0, format=wx.LIST_FORMAT_CENTRE, heading=u'',
              width=50)
        parent.InsertColumn(col=1, format=wx.LIST_FORMAT_LEFT,
              heading=u'Site Name', width=140)
        parent.InsertColumn(col=2, format=wx.LIST_FORMAT_LEFT,
              heading=u'Variable Name', width=140)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self.boxSizer3 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer4 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self.boxSizer5 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)
        self._init_coll_boxSizer3_Items(self.boxSizer3)
        self._init_coll_boxSizer4_Items(self.boxSizer4)
        self._init_coll_boxSizer5_Items(self.boxSizer5)

        self.SetSizer(self.boxSizer1)
        self.panel1.SetSizer(self.boxSizer4)
        self.panel2.SetSizer(self.boxSizer2)
        self.panel3.SetSizer(self.boxSizer3)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Panel.__init__(self, id=wxID_PNLSERIESSELECTOR,
              name=u'pnlSeriesSelector', parent=prnt, pos=wx.Point(511, 413),
              size=wx.Size(935, 270), style=wx.TAB_TRAVERSAL)
        self.SetClientSize(wx.Size(919, 232))
        self.Enable(True)

        self.panel1 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL1, name='panel1',
              parent=self, pos=wx.Point(3, 3), size=wx.Size(913, 30),
              style=wx.TAB_TRAVERSAL)

        self.panel2 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL2, name='panel2',
              parent=self, pos=wx.Point(3, 39), size=wx.Size(913, 30),
              style=wx.TAB_TRAVERSAL)

        self.panel3 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL3, name='panel3',
              parent=self, pos=wx.Point(3, 111), size=wx.Size(913, 118),
              style=wx.TAB_TRAVERSAL)

        self.cbSites = wx.ComboBox(choices=[], id=wxID_PNLSERIESSELECTORCBSITES,
              name=u'cbSites', parent=self.panel1, pos=wx.Point(123, 3),
              size=wx.Size(787, 21), style=0, value=u'')
        self.cbSites.SetLabel(u'')
        self.cbSites.Bind(wx.EVT_COMBOBOX, self.OnCbSitesCombobox,
              id=wxID_PNLSERIESSELECTORCBSITES)

        self.checkSite = wx.CheckBox(id=wxID_PNLSERIESSELECTORCHECKSITE,
              label=u'', name=u'checkSite', parent=self.panel1, pos=wx.Point(3,
              3), size=wx.Size(21, 21), style=0)
        self.checkSite.SetValue(True)
        self.checkSite.Bind(wx.EVT_CHECKBOX, self.OnCheck,
              id=wxID_PNLSERIESSELECTORCHECKSITE)

        self.lblSite = wx.StaticText(id=wxID_PNLSERIESSELECTORLBLSITE,
              label=u'Site', name=u'lblSite', parent=self.panel1,
              pos=wx.Point(30, 3), size=wx.Size(87, 13), style=0)
        self.lblSite.SetToolTipString(u'staticText1')

        self.lblVariable = wx.StaticText(id=wxID_PNLSERIESSELECTORLBLVARIABLE,
              label=u'Variable', name=u'lblVariable', parent=self.panel2,
              pos=wx.Point(30, 3), size=wx.Size(87, 13), style=0)

        self.checkVariable = wx.CheckBox(id=wxID_PNLSERIESSELECTORCHECKVARIABLE,
              label=u'', name=u'checkVariable', parent=self.panel2,
              pos=wx.Point(3, 3), size=wx.Size(21, 16), style=0)
        self.checkVariable.Bind(wx.EVT_CHECKBOX, self.OnCheck,
              id=wxID_PNLSERIESSELECTORCHECKVARIABLE)

        self.cbVariables = wx.ComboBox(choices=[],
              id=wxID_PNLSERIESSELECTORCBVARIABLES, name=u'cbVariables',
              parent=self.panel2, pos=wx.Point(123, 3), size=wx.Size(787, 21),
              style=0, value='comboBox4')
        self.cbVariables.SetLabel(u'')
        self.cbVariables.Enable(False)
        self.cbVariables.Bind(wx.EVT_COMBOBOX, self.OnCbVariablesCombobox,
              id=wxID_PNLSERIESSELECTORCBVARIABLES)

        self.btnFilter = wx.Button(id=wxID_PNLSERIESSELECTORBTNFILTER,
              label=u'Advanced Filter', name=u'btnFilter', parent=self,
              pos=wx.Point(5, 77), size=wx.Size(91, 23), style=0)
        self.btnFilter.Bind(wx.EVT_BUTTON, self.OnBtnFilterButton,
              id=wxID_PNLSERIESSELECTORBTNFILTER)

        self.btnViewAll = wx.Button(id=wxID_PNLSERIESSELECTORBTNVIEWALL,
              label=u'View All', name=u'btnViewAll', parent=self,
              pos=wx.Point(749, 77), size=wx.Size(75, 23), style=0)
        self.btnViewAll.Bind(wx.EVT_BUTTON, self.OnBtnViewAllButton,
              id=wxID_PNLSERIESSELECTORBTNVIEWALL)

        self.btnViewSelected = wx.Button(id=wxID_PNLSERIESSELECTORBTNVIEWSELECTED,
              label=u'View Selected', name=u'btnViewSelected', parent=self,
              pos=wx.Point(824, 77), size=wx.Size(90, 23), style=0)
        self.btnViewSelected.Bind(wx.EVT_BUTTON, self.OnBtnViewSelectedButton,
              id=wxID_PNLSERIESSELECTORBTNVIEWSELECTED)

        self.panel4 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL4, name='panel4',
              parent=self, pos=wx.Point(96, 77), size=wx.Size(653, 25),
              style=wx.TAB_TRAVERSAL)

        self.listSeries = wx.ListCtrl(id=wxID_PNLSERIESSELECTORLISTSERIES,
              name=u'listSeries', parent=self.panel3, pos=wx.Point(5, 5),
              size=wx.Size(903, 108),
              style=wx.HSCROLL | wx.VSCROLL | wx.LC_REPORT)
        self._init_coll_listSeries_Columns(self.listSeries)
        self.listSeries.Bind(wx.EVT_LIST_ITEM_SELECTED,
              self.OnListSeriesListItemSelected,
              id=wxID_PNLSERIESSELECTORLISTSERIES)

        self._init_sizers()

    def __init__(self, parent, id, pos, size, style, name, dbservice): 
        self.parent= parent       
        self._init_ctrls(parent)
        self.dbservice = dbservice
        ##initialize drop down boxes for series selector
        self.siteList=self.dbservice.get_sites()
        for site in self.siteList:
            self.cbSites.Append(site.site_code+'-'+site.site_name)
        self.cbSites.SetSelection(0)
        self.site_code = self.siteList[0].site_code
        
        self.varList= self.dbservice.get_variables(self.siteList[0].site_code)
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)  
        
        self.seriesList = self.dbservice.get_series(self.siteList[0].site_code)
        for series in self.seriesList:       
            self.listSeries.Append([False, series.site_name ,series.variable_name])
            
        self.SelectedSeries = []    

    def OnBtnFilterButton(self, event):
        self.new = frmQueryBuilder.frmQueryBuilder(parent=None)
        self.new.Show()
        
    def OnBtnViewAllButton(self, event):
        event.Skip()

    def OnBtnViewSelectedButton(self, event):
        event.Skip()    
        

    def OnCbSitesCombobox(self, event):
        #clear list for new site info
        
        self.listSeries.DeleteAllItems()
        
        self.varList =[]
        self.site_code = self.siteList[event.GetSelection()].site_code
        
        self.varList= self.dbservice.get_variables(self.site_code)
        self.cbVariables.Clear()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        #if (not self.checkVariable):
        self.seriesList = self.dbservice.get_series(site_code = self.site_code, var_code = self.varList[0].variable_code)
        for series in self.seriesList:
            self.listSeries.Append(["False", series.site_name ,series.variable_name])


    def OnCbVariablesCombobox(self, event):
        self.listSeries.DeleteAllItems()
             
        if (self.checkSite.GetValue() and self.checkVariable.GetValue()):        
        #site_code = self.siteList[event.GetSelection()].site_code             
            self.var_code = self.varList[event.GetSelection()].variable_code
            self.seriesList = self.dbservice.get_series(site_code = self.site_code, var_code= self.var_code)        
        
        elif (not self.checkSite.GetValue() and self.checkVariable.GetValue()):               
            self.var_code = self.varList[event.GetSelection()].variable_code
            self.seriesList = self.dbservice.get_series( var_code= self.var_code) 
        

##        for series in self.seriesList:
##            print series
            
        for series in self.seriesList:
            self.listSeries.Append(["False", series.site_name ,series.variable_name]) 

             

    def OnListSeriesListItemSelected(self, event):
        #print self.seriesList[event.m_itemIndex]
        if ( self.listSeries.GetItemText(event.m_itemIndex) == "False"):           
            self.listSeries.SetStringItem(event.m_itemIndex, 0, "True")
            self.SelectedSeries.append(self.seriesList[event.m_itemIndex])
            #get DataValues       
            
            self.DataValues = self.dbservice.get_data_values_by_series(self.seriesList[event.m_itemIndex])
            Publisher().sendMessage(("add.NewPlot"), [self.DataValues, self.seriesList[event.m_itemIndex]])
            
        else:
            self.listSeries.SetStringItem(event.m_itemIndex, 0, "False")
            self.SelectedSeries.remove(self.seriesList[event.m_itemIndex])
    
    def siteAndVariables(self):
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables(self.site_code)
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        self.seriesList = self.dbservice.get_series(site_code = self.siteList[0].site_code, var_code= self.varList[0].variable_code)
        self.cbVariables.Enabled =True
        self.cbSites.Enabled = True
        
    def siteOnly(self):
        self.cbVariables.Enabled = False
        self.cbSites.Enabled = True
        self.seriesList = self.dbservice.get_series(site_code = self.siteList[0].site_code)
    
    def variableOnly(self):
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        self.cbSites.Enabled = False
        self.cbVariables.Enabled = True
        self.seriesList = self.dbservice.get_series(var_code= self.varList[0].variable_code)
           
    
    def OnCheck(self, event):
        self.listSeries.DeleteAllItems()
        if self.checkSite.GetValue():
            if self.checkVariable.GetValue():
                self.siteAndVariables()
            else:
                self.siteOnly()
        else:
            if self.checkVariable.GetValue():
                self.variableOnly()
            else: 
                self.cbSites.Enabled = False
                self.cbVariables.Enabled = False
      
            
##    def InitColumns(self):
##        self.myOlv.SetColumns([
##            ColumnDefn("SiteID", "center", 100, "SiteID"),
##            ColumnDefn("SiteCode", "center", 100, "SiteCode"),
##            ColumnDefn("SiteName", "center", 100, "SiteName"),
##            ColumnDefn("VariableID", "center", 100, "VariableID"),           
##            ColumnDefn("VariableCode", "center", 100, "VariableCode"),
##            ColumnDefn("Speciation", "center", 100, "VariableUnitsID"),
##            ColumnDefn("VariableUnitsID", "center", 100, "VariableUnitsID"),            
##            ColumnDefn("VariableUnitsName", "center", 100, "VariableUnitsName"),
##            ColumnDefn("SampleMedium", "center", 100, "SampleMedium"),
##            ColumnDefn("ValueType", "center", 100, "ValueType"),
##            ColumnDefn("TimeSupport", "center", 100, "TimeSupport"),
##            ColumnDefn("TimeUnitsID", "center", 100, "TimeUnitsID"),
##            ColumnDefn("TimeUnitsName", "center", 100, "TimeUnitsName"),
##            ColumnDefn("DataType", "center", 100, "DataType"),
##            ColumnDefn("Citation", "center", 100, "Citation"),
##            ColumnDefn("QualityControlLevelID", "center", 100, "QualityControlLevelID"),
##            ColumnDefn("QualityControlLevelCode", "center", 100, "QualityControlLevelCode"),
##            ColumnDefn("BeginDateTime", "center", 100, "BeginDateTime",stringConverter="%d-%m-%Y"),
##            ColumnDefn("EndDateTime", "center", 100, "EndDateTime",stringConverter="%d-%m-%Y"),
##            ColumnDefn("BeginDateTimeUTC", "center", 100, "BeginDateTimeUTC",stringConverter="%d-%m-%Y"),
##            ColumnDefn("EndDateTimeUTC", "center", 100, "EndDateTimeUTC",stringConverter="%d-%m-%Y"),
##            ColumnDefn("ValueCount", "center", 100, "ValueCount")
##            
##        ])

    
