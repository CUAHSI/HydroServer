#Boa:FramePanel:pnlSeriesSelector

import wx
import wx.lib.agw.ultimatelistctrl as ULC
from ObjectListView import ObjectListView, ColumnDefn, Filter

from wx.lib.pubsub import Publisher
import sqlite3

import frmODMToolsMain
import frmQueryBuilder

[wxID_PNLSERIESSELECTOR, wxID_PNLSERIESSELECTORBTNFILTER,
 wxID_PNLSERIESSELECTORBTNVIEWALL, wxID_PNLSERIESSELECTORBTNVIEWSELECTED,
 wxID_PNLSERIESSELECTORCBSITES, wxID_PNLSERIESSELECTORCBVARIABLES,
 wxID_PNLSERIESSELECTORCHECKSITE, wxID_PNLSERIESSELECTORCHECKVARIABLE,
 wxID_PNLSERIESSELECTORLBLSITE, wxID_PNLSERIESSELECTORLBLVARIABLE,
 wxID_PNLSERIESSELECTORtableSeries, wxID_PNLSERIESSELECTORPANEL1,
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

        # parent.AddWindow(self.tableSeries, 100, border=5,
        #       flag=wx.EXPAND | wx.ALL)
        parent.Add(self.tableSeries, 1, wx.ALL|wx.EXPAND, 4)

    def _init_coll_boxSizer4_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkSite, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblSite, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbSites, 85, border=3, flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.panel1, 15, border=3, flag=wx.EXPAND | wx.ALL)
        parent.AddWindow(self.panel2, 15, border=3, flag=wx.EXPAND | wx.ALL)
        # parent.AddSizer(self.boxSizer5, 10, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.panel3, 70, border=3, flag=wx.ALL | wx.EXPAND)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.checkVariable, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblVariable, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbVariables, 85, border=3,
              flag=wx.EXPAND | wx.ALL)

    def _init_coll_tableSeries_Columns(self, parent):
       # generated method, don't edit
        columnstitle = ["SeriesID",
                "SiteID",
                "SiteCode",
                "SiteName",
                "VariableID", 
                "VariableCode", 
                "VariableName",
                "Speciation",
                "VariableUnitsID",
                "VariableUnitsName",
                "SampleMedium",
                "ValueType",
                "TimeSupport", 
                "TimeUnitsID", 
                "TimeUnitsName",
                "DataType", 
                "GeneralCategory", 
                "MethodID", 
                "MethodDescriptions",
                "SourceID", 
                "Organization",
                "SourceDescription",
                "Citation", 
                "QualityControlLevelID", 
                "QualityControlLevelCode",
                "BeginDateTime", 
                "EndDateTime", 
                "BeginDateTimeUTC", 
                "EndDateTimeUTC", 
                "ValueCount"]
                

        colnum = 0
        parent.InsertColumn(col=colnum, format=wx.LIST_FORMAT_CENTRE, heading=u'',
             width=25) 
        for c in columnstitle:
            colnum+=1
            parent.InsertColumn(col=colnum, format=wx.LIST_FORMAT_LEFT,
                heading=c, width=140)
        # parent.InsertColumn(col=2, format=wx.LIST_FORMAT_LEFT,
        #      heading=u'Variable Name', width=140)


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

        # self.tableSeries = wx.ListCtrl(id=wxID_PNLSERIESSELECTORtableSeries,
        #       name=u'tableSeries', parent=self.panel3, pos=wx.Point(5, 5),
        #       size=wx.Size(903, 108),
        #       style=wx.HSCROLL | wx.VSCROLL | wx.LC_REPORT)

        self.tableSeries = ULC.UltimateListCtrl(id=wxID_PNLSERIESSELECTORtableSeries,
              name=u'tableSeries', parent=self.panel3, pos=wx.Point(5, 5),
              size=wx.Size(903, 108),              
              agwStyle= ULC.ULC_REPORT | ULC.ULC_HRULES | ULC.ULC_VRULES)
        # self.tableSeries.SetAlternateRowColour("SlateGray")

        
        # self.tableSeries = ObjectListView(self.panel3, id=wxID_PNLSERIESSELECTORtableSeries, name=u'tableSeries',  
        #       style=wx.LC_REPORT|wx.SUNKEN_BORDER)
        # self.tableSeries.SetEmptyListMsg("")

       
        self._init_coll_tableSeries_Columns(self.tableSeries)
        # self.tableSeries.Bind(ULC.EVT_LIST_ITEM_SELECTED,
        #       self.OntableSeriesListItemSelected,
        #       id=wxID_PNLSERIESSELECTORtableSeries)
        # self.tableSeries.Bind(ULC.EVT_LIST_ITEM_DESELECTED,
        #       self.OntableSeriesListItemDeSelected,
        #       id=wxID_PNLSERIESSELECTORtableSeries)

        # ULC.EVT_LIST_ITEM_CHECKING
        self.tableSeries.Bind(ULC.EVT_LIST_ITEM_CHECKING,
              self.OntableSeriesListItemSelected,
              id=wxID_PNLSERIESSELECTORtableSeries)



        
        
        self._init_sizers()

    def __init__(self, parent, id, pos, size, style, name, dbservice):
        self.parent= parent
        self._init_ctrls(parent)
        
        #####INIT DB Connection
        self.dbservice = dbservice
        # self.conn = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
        # self.cursor = self.conn.cursor()
        # self.initDB()


        ### INIT Series Catalog        
        # self.cursor.executemany("INSERT INTO SeriesCatalog VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.dbservice.get_series_test())
        # self.conn.commit()
        # sql = "SELECT * FROM SeriesCatalog"
        # self.cursor.execute(sql)
        # self.tableSeries.SetColumns(ColumnDefn(x[0], valueGetter=i, minimumWidth=40) for (i,x) in enumerate(self.cursor.description))
        # self.tableSeries.InstallCheckStateColumn(self.tableSeries.columns[0])
        # self.Series = [list(x) for x in self.cursor.fetchall()]
        # self.tableSeries.SetObjects(self.Series)

        #####INIT drop down boxes for series selector
        self.siteList=self.dbservice.get_sites()
        for site in self.siteList:
            self.cbSites.Append(site.site_code+'-'+site.site_name)
        self.cbSites.SetSelection(0)
        self.site_code = self.siteList[0].site_code

        self.varList= self.dbservice.get_variables(self.site_code)
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)


        ####INIT table with filters


        # self.siteFilter= Filter.TextSearch(self.tableSeries, text = self.site_code )
        # self.tableSeries.SetFilter(Filter.TextSearch(self.tableSeries, self.tableSeries.columns[0:4]))
        # self.tableSeries.GetFilter().SetText(self.site_code)
        
        # self.tableSeries.RepopulateList()
        


        self.seriesList = self.dbservice.get_series(self.siteList[0].site_code)
        
        # self.list.InsertImageStringItem(sys.maxint, data[0], [3, 4, 7], it_kind=1)
        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)
        # for series in self.seriesList:
        #     self.tableSeries.Append([False, series.site_name ,series.variable_name])
        

        self.SelectedSeries = []

    def OnBtnFilterButton(self, event):
        # self.new = frmQueryBuilder.frmQueryBuilder(parent=None)
        # self.new.Show()
        pass

    def OnBtnViewAllButton(self, event):
        pass

    def OnBtnViewSelectedButton(self, event):
        pass


    def OnCbSitesCombobox(self, event):
        #clear list for new site info

        self.tableSeries.DeleteAllItems()

        
        self.site_code = self.siteList[event.GetSelection()].site_code

        self.varList =[]
        self.varList= self.dbservice.get_variables(self.site_code)

        self.cbVariables.Clear()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        #if (not self.checkVariable):
        

        

        self.seriesList = self.dbservice.get_series(site_code = self.site_code)
        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)
        # for series in self.seriesList:
        #     self.tableSeries.Append(["False", series.site_name ,series.variable_name])


    def OnCbVariablesCombobox(self, event):
        self.tableSeries.DeleteAllItems()

        if (self.checkSite.GetValue() and self.checkVariable.GetValue()):
        #site_code = self.siteList[event.GetSelection()].site_code
            self.var_code = self.varList[event.GetSelection()].variable_code
            self.seriesList = self.dbservice.get_series(site_code = self.site_code, var_code= self.var_code)

        elif (not self.checkSite.GetValue() and self.checkVariable.GetValue()):
            self.var_code = self.varList[event.GetSelection()].variable_code
            self.seriesList = self.dbservice.get_series( var_code= self.var_code)



       #self.tableSeries.GetFilter().SetText(self.site_code)
##        for series in self.seriesList:
##            print series

        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)
        # for series in self.seriesList:
        #     self.tableSeries.Append(["False", series.site_name ,series.variable_name])




    def siteAndVariables(self):
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables(self.site_code)
        for var in self.varList:            
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)


        ###FILTER
        # self.siteFilter= Filter.TextSearch(self.tableSeries, text = self.site_code )
        # self.variableFilter = Filter.TextSearch(self.tableSeries, text = self.varList[0].variable_code)
        # self.tableSeries.SetFilter(Filter.Chain(self.siteFilter, self.variableFilter))
        

        self.seriesList = self.dbservice.get_series(site_code = self.siteList[self.cbSites.Selection].site_code, var_code= self.varList[self.cbVariables.Selection].variable_code)
        
        self.cbVariables.Enabled =True
        self.cbSites.Enabled = True

        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)

    def siteOnly(self):
        self.cbVariables.Enabled = False
        self.cbSites.Enabled = True
        
        ###FILTER
        # self.tableSeries.SetFilter(Filter.TextSearch(self.tableSeries, self.tableSeries.columns[0:4]))
        # self.tableSeries.GetFilter().SetText(self.site_code)        
        # self.tableSeries.RepopulateList()

        # print dir(self.cbSites)
        # print self.cbSites.Selection
        # print self.cbSites.CurrentSelection
        self.seriesList = self.dbservice.get_series(site_code = self.siteList[self.cbSites.Selection].site_code)
        

        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)

    def variableOnly(self):
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        self.cbSites.Enabled = False
        self.cbVariables.Enabled = True

        ###FILTER
        # self.tableSeries.SetFilter(Filter.TextSearch(self.tableSeries, self.tableSeries.columns[0:4]))
        # self.tableSeries.GetFilter().SetText(self.varList[0].variable_code)        
        # self.tableSeries.RepopulateList()
        
        self.seriesList = self.dbservice.get_series(var_code= self.varList[0].variable_code)
        for series in self.seriesList:
            ind = self.tableSeries.GetItemCount()
            self.tableSeries.Append([False, series.site_name ,series.variable_name])
            self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)


    def OnCheck(self, event):
        self.tableSeries.DeleteAllItems()
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



    def OntableSeriesListItemDeSelected(self, event):
        #remove from plot
        # print dir(event)

        # else:
            # self.tableSeries.SetStringItem(event.m_itemIndex, 0, "False")
            # self.SelectedSeries.remove(self.seriesList[event.m_itemIndex])

        #if check box is not checked
        if not self.tableSeries.IsItemChecked(event.m_itemIndex):
            print event.m_itemIndex, " deselected"

    def OntableSeriesListItemSelected(self, event):
        # print event.m_itemIndex, " selected"
        # print self.seriesList[event.m_itemIndex]
        # if ( self.tableSeries.GetItemText(event.m_itemIndex) == "False"):
        #     self.tableSeries.SetStringItem(event.m_itemIndex, 0, "True") 

        print dir(event)
        if self.tableSeries.IsItemChecked(event.m_itemIndex): 
            pass
        else: 
            print event.m_itemIndex, " selected"


             
            self.SelectedSeries.append(self.seriesList[event.m_itemIndex])  
            
            self.conn = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
            self.cursor = self.conn.cursor()
            self.initDB()

            #when Selected for editing

            #when selected for plotting
             #get DataValues

            self.DataValues = self.dbservice.get_data_values_by_series_test(self.seriesList[event.m_itemIndex])


            self.cursor.execute("DELETE FROM DataValues")
            self.conn.commit()
            self.cursor.executemany("INSERT INTO DataValues VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.DataValues)
            self.conn.commit()


            Publisher().sendMessage(("add.NewPlot"), [self.cursor, self.seriesList[event.m_itemIndex]])

        self.Refresh()

    def initDB(self):
        self.cursor.execute("""CREATE TABLE SeriesCatalog
                (SeriesID INTEGER NOT NULL,
                SiteID INTEGER,
                SiteCode VARCHAR(50),
                SiteName VARCHAR(255),
                VariableID INTEGER, 
                VariableCode VARCHAR(50), 
                VariableName VARCHAR(255),
                Speciation VARCHAR(255),
                VariableUnitsID INTEGER,
                VariableUnitsName VARCHAR(255),
                SampleMedium VARCHAR(255),
                ValueType VARCHAR(255),
                TimeSupport FLOAT, 
                TimeUnitsID INTEGER, 
                TimeUnitsName VARCHAR(255),
                DataType VARCHAR(255), 
                GeneralCategory VARCHAR(255), 
                MethodID INTEGER, 
                MethodDescriptions VARCHAR(255),
                SourceID INTEGER, 
                Organization VARCHAR(255),
                SourceDescription VARCHAR(255),
                Citation VARCHAR(255), 
                QualityControlLevelID INTEGER, 
                QualityControlLevelCode VARCHAR(50),
                BeginDateTime TIMESTAMP, 
                EndDateTime TIMESTAMP, 
                BeginDateTimeUTC TIMESTAMP, 
                EndDateTimeUTC TIMESTAMP, 
                ValueCount INTEGER,

                PRIMARY KEY (SeriesID))
                
               """)

#isSelected INTEGER NOT NULL,

        self.cursor.execute("""CREATE TABLE DataValues
                (ValueID INTEGER NOT NULL,
                DataValue FLOAT NOT NULL,
                ValueAccuracy FLOAT,
                LocalDateTime TIMESTAMP NOT NULL,
                UTCOffset FLOAT NOT NULL,
                DateTimeUTC TIMESTAMP NOT NULL,
                SiteID INTEGER NOT NULL,
                VariableID INTEGER NOT NULL,
                OffsetValue FLOAT,
                OffsetTypeID INTEGER,
                CensorCode VARCHAR(50) NOT NULL,
                QualifierID INTEGER,
                MethodID INTEGER NOT NULL,
                SourceID INTEGER NOT NULL,
                SampleID INTEGER,
                DerivedFromID INTEGER,
                QualityControlLevelID INTEGER NOT NULL,

                PRIMARY KEY (ValueID),
                UNIQUE (DataValue, LocalDateTime, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID))
               """)


        self.cursor.execute("""CREATE TABLE DataValuesEdit
                (ValueID INTEGER NOT NULL,
                DataValue FLOAT NOT NULL,
                ValueAccuracy FLOAT,
                LocalDateTime TIMESTAMP NOT NULL,
                UTCOffset FLOAT NOT NULL,
                DateTimeUTC TIMESTAMP NOT NULL,
                SiteID INTEGER NOT NULL,
                VariableID INTEGER NOT NULL,
                OffsetValue FLOAT,
                OffsetTypeID INTEGER,
                CensorCode VARCHAR(50) NOT NULL,
                QualifierID INTEGER,
                MethodID INTEGER NOT NULL,
                SourceID INTEGER NOT NULL,
                SampleID INTEGER,
                DerivedFromID INTEGER,
                QualityControlLevelID INTEGER NOT NULL,

                PRIMARY KEY (ValueID),
                UNIQUE (DataValue, LocalDateTime, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID))
               """)



