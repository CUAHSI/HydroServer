#Boa:FramePanel:pnlSeriesSelector

import wx
# import wx.lib.agw.ultimatelistctrl as ULC
# from ObjectListView import ObjectListView, ColumnDefn, Filter

from wx.lib.pubsub import Publisher

import sqlite3
# from ObjectListView import Filter
import wx.lib.agw.ultimatelistctrl as ULC
from clsULC import clsULC, TextSearch, Chain
import frmODMToolsMain
import frmQueryBuilder

from odmdata import memoryDatabase
# import memoryDatabase

# import wx.lib.agw.ultimatelistctrl as ULC

[wxID_PNLSERIESSELECTOR, wxID_PNLSERIESSELECTORCBSITES, wxID_PNLSERIESSELECTORCBVARIABLES,
 wxID_PNLSERIESSELECTORCHECKSITE, wxID_PNLSERIESSELECTORCHECKVARIABLE,
 wxID_PNLSERIESSELECTORLBLSITE, wxID_PNLSERIESSELECTORLBLVARIABLE,
 wxID_PNLSERIESSELECTORtableSeries, wxID_PNLSERIESSELECTORPANEL1,
 wxID_PNLSERIESSELECTORPANEL2, wxID_PNLSIMPLE, wxID_PNLRADIO,
 wxID_FRAME1RBADVANCED, wxID_FRAME1RBALL, 
 wxID_FRAME1RBSIMPLE, wxID_FRAME1SPLITTER,wxID_PNLSPLITTER,
] = [wx.NewId() for _init_ctrls in range(17)]

class pnlSeriesSelector(wx.Panel):

    ## Radio Sizer
    def _init_coll_boxSizer5_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.rbAll, 0, border=1, flag=wx.ALL)
        parent.AddWindow(self.rbSimple, 0, border=1, flag=wx.ALL)
        parent.AddWindow(self.rbAdvanced, 0, border=1, flag=wx.ALL)


    ## Splitter Sizer
    def _init_coll_boxSizer3_Items(self, parent):
        # generated method, don't edit
        parent.AddWindow(self.splitter, 100, border=0, flag=wx.EXPAND)

    ## Panel Sizer
    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit
        parent.AddSizer(self.boxSizer5, 7, border=5, flag=wx.EXPAND)
        parent.AddWindow(self.pnlSplitter, 93, border=3, flag=wx.ALL | wx.EXPAND)

    ## Site Sizer
    def _init_coll_boxSizer4_Items(self, parent):
        # generated method, don't edit
        parent.AddWindow(self.checkSite, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblSite, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbSites, 85, border=3, flag=wx.ALL | wx.EXPAND)        
        
    ## Variable Sizer
    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit
        parent.AddWindow(self.checkVariable, 3, border=3, flag=wx.ALL)
        parent.AddWindow(self.lblVariable, 10, border=3, flag=wx.ALL)
        parent.AddWindow(self.cbVariables, 85, border=3, flag=wx.ALL | wx.EXPAND) 

    ##  Simple Filter Sizer    
    def _init_coll_boxSizer6_Items(self, parent):
        parent.AddWindow(self.panel1, 0, border=3, flag=wx.ALL | wx.EXPAND)
        parent.AddWindow(self.panel2, 0, border=3, flag=wx.ALL | wx.EXPAND)
        # parent.AddSizer(self.boxSizer4, 0, border=5, flag=wx.EXPAND)
        # parent.AddSizer(self.boxSizer2, 0, border=5, flag=wx.EXPAND)
   
   
    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)
        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)
        self.boxSizer3 = wx.BoxSizer(orient=wx.VERTICAL)
        self.boxSizer4 = wx.BoxSizer(orient=wx.HORIZONTAL)
        self.boxSizer5 = wx.BoxSizer(orient=wx.HORIZONTAL)
        self.boxSizer6 = wx.BoxSizer(orient=wx.VERTICAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)
        self._init_coll_boxSizer3_Items(self.boxSizer3)
        self._init_coll_boxSizer4_Items(self.boxSizer4)
        self._init_coll_boxSizer5_Items(self.boxSizer5)
        self._init_coll_boxSizer6_Items(self.boxSizer6)

        self.SetSizer(self.boxSizer1)        
        self.panel1.SetSizer(self.boxSizer4)
        self.panel2.SetSizer(self.boxSizer2)
        self.pnlSimple.SetSizer(self.boxSizer6)
        self.pnlSplitter.SetSizer(self.boxSizer3)
        # self.pnlRadio.SetSizer(self.boxSizer5)

    def _init_ctrls(self, prnt):
        # generated method, don't edit

        wx.Panel.__init__(self, id=wxID_PNLSERIESSELECTOR,
              name=u'pnlSeriesSelector', parent=prnt, pos=wx.Point(511, 413),
              size=wx.Size(935, 270), style=wx.TAB_TRAVERSAL)
        self.SetClientSize(wx.Size(919, 232))
        self.Enable(True)
        
        ## Radio panel
        self.pnlRadio = wx.Panel(id=wxID_PNLRADIO, name='pnlRadio',
              parent=self, pos=wx.Point(3, 3), size=wx.Size(919, 20),
              style=wx.TAB_TRAVERSAL)
              
        self.rbAll = wx.RadioButton(id=wxID_FRAME1RBALL, label=u'All',
              name=u'rbAll', parent=self.pnlRadio, pos=wx.Point(0, 0),
              size=wx.Size(81, 20), style=0)
        self.rbAll.SetValue(True)
        self.rbAll.Bind(wx.EVT_RADIOBUTTON, self.OnRbAllRadiobutton,
              id=wxID_FRAME1RBALL)

        self.rbSimple = wx.RadioButton(id=wxID_FRAME1RBSIMPLE,
              label=u'Simple Filter', name=u'rbSimple', parent=self.pnlRadio,
              pos=wx.Point(81, 0), size=wx.Size(112, 20), style=0)
        self.rbSimple.Bind(wx.EVT_RADIOBUTTON, self.OnRbSimpleRadiobutton,
              id=wxID_FRAME1RBSIMPLE)

        self.rbAdvanced = wx.RadioButton(id=wxID_FRAME1RBADVANCED,
              label=u'Advanced Filter', name=u'rbAdvanced', parent=self.pnlRadio,
              pos=wx.Point(193, 0), size=wx.Size(104, 20), style=0)
        self.rbAdvanced.Bind(wx.EVT_RADIOBUTTON, self.OnRbAdvancedRadiobutton,
              id=wxID_FRAME1RBADVANCED)  
        # self.rbAdvanced.Enable(False)
        
              
        
        ## Splitter panel
        self.pnlSplitter = wx.Panel(id=wxID_PNLSPLITTER, name='pnlSplitter',
              parent=self, pos=wx.Point(3, 3), size=wx.Size(919, 349),
              style=wx.TAB_TRAVERSAL)
              
        self.splitter = wx.SplitterWindow(id=wxID_FRAME1SPLITTER,
              name=u'splitter', parent=self.pnlSplitter, pos=wx.Point(0, 0),
              size=wx.Size(604, 137), style=wx.SP_3D)
        self.splitter.SetMinSize(wx.Size(-1, -1))
              
               
        ## panel for simple filter(top of splitter)
        self.pnlSimple = wx.Panel(id=wxID_PNLSIMPLE, name='panel3',
              parent=self.splitter, pos=wx.Point(0, 0), size=wx.Size(919, 300),
              style=wx.TAB_TRAVERSAL)
        
        
        ## Site Panel   
        self.panel1 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL1, name='panel1',
              parent=self.pnlSimple, pos=wx.Point(3, 3), size=wx.Size(919, 30),
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

        ### Variable Panel
        self.panel2 = wx.Panel(id=wxID_PNLSERIESSELECTORPANEL2, name='panel2',
              parent=self.pnlSimple, pos=wx.Point(3, 39), size=wx.Size(919, 30),
              style=wx.TAB_TRAVERSAL)
              
        self.lblVariable = wx.StaticText(id=wxID_PNLSERIESSELECTORLBLVARIABLE,
              label=u'Variable', name=u'lblVariable', parent=self.panel2,
              pos=wx.Point(30, 3), size=wx.Size(87, 13), style=0)

        self.checkVariable = wx.CheckBox(id=wxID_PNLSERIESSELECTORCHECKVARIABLE,
              label=u'', name=u'checkVariable', parent=self.panel2,
              pos=wx.Point(3, 3), size=wx.Size(21, 21), style=0)
        self.checkVariable.Bind(wx.EVT_CHECKBOX, self.OnCheck,
              id=wxID_PNLSERIESSELECTORCHECKVARIABLE)

        self.cbVariables = wx.ComboBox(choices=[],
              id=wxID_PNLSERIESSELECTORCBVARIABLES, name=u'cbVariables',
              parent=self.panel2, pos=wx.Point(123, 3), size=wx.Size(123, 3),
              style=0, value='comboBox4')
        self.cbVariables.SetLabel(u'')
        self.cbVariables.Enable(False)
        self.cbVariables.Bind(wx.EVT_COMBOBOX, self.OnCbVariablesCombobox,
              id=wxID_PNLSERIESSELECTORCBVARIABLES)

        self.tableSeries = clsULC(id=wxID_PNLSERIESSELECTORtableSeries,
              name=u'tableSeries', parent=self.splitter, pos=wx.Point(5, 5),
              size=wx.Size(903, 108),              
              agwStyle= ULC.ULC_REPORT | ULC.ULC_HRULES | ULC.ULC_VRULES | ULC.ULC_HAS_VARIABLE_ROW_HEIGHT |ULC.ULC_SINGLE_SEL)

        self.splitter.SplitHorizontally(self.pnlSimple, self.tableSeries, 1)

        self.tableSeries.Bind(ULC.EVT_LIST_ITEM_CHECKED,
              self.OntableSeriesListItemSelected,
              id=wxID_PNLSERIESSELECTORtableSeries)
        
        self.tableSeries.Bind(wx.EVT_LIST_ITEM_RIGHT_CLICK,
              self.OnTableRightDown,
              id=wxID_PNLSERIESSELECTORtableSeries)

        Publisher().subscribe(self.OnEditButton, ("selectEdit"))
        self._init_sizers()

    

    def __init__(self, parent, id, pos, size, style, name, dbservice):
        self.parent= parent
        self._init_ctrls(parent)
        self.site_code = None
        self.variable_code = None

        #####INIT DB Connection
        self.dbservice = dbservice
        # self.dataRep=memoryDatabase(dbservice)
        self.conn = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
        self.cursor = self.conn.cursor()
        self.initDB()

        ### INIT Series Catalog        
        self.cursor.executemany("INSERT INTO SeriesCatalog VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.dbservice.get_series_test())
        self.cursor.execute("ALTER TABLE SeriesCatalog ADD COLUMN isSelected INTEGER ")
        
        self.cursor.execute("UPDATE SeriesCatalog SET isSelected=0")
        self.conn.commit()

        sql = "SELECT * FROM SeriesCatalog"
        self.cursor.execute(sql)        
        # self.Series = [list(x) for x in self.cursor.fetchall()]
        # self.tableSeries.SetObjects(self.Series)
        self.tableSeries.SetColumns(x[0] for (i,x) in enumerate(self.cursor.description))
        # self.tableSeries.SetCursor(self.cursor)
    

        # self.seriesList= 
        # self.tableSeries.SetObjects(self.dbservice.get_series())
        self.tableSeries.SetObjects([list(x) for x in self.cursor.fetchall()])

        # self.tableSeries.SetColumns(self.dataRep.getSeriesColumns())
        # self.tableSeries.SetObjects(self.dataRep.getSeriesCatalog())



        #####INIT drop down boxes for Simple Filter
        self.siteList=self.dbservice.get_sites()
        
        for site in self.siteList:
            self.cbSites.Append(site.site_code+'-'+site.site_name)
        self.cbSites.SetSelection(0)
        self.site_code = self.siteList[0].site_code

        self.varList= self.dbservice.get_variables(self.site_code)
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)


    def OnTableRightDown(self, event):
       
      # build pop-up menu for right-click display
        self.selectedIndex= event.m_itemIndex
        self.selectedID = self.tableSeries.GetColumnText(event.m_itemIndex, 1)
        # print self.selectedID
        popup_edit_series = wx.NewId()
        popup_plot_series = wx.NewId()
        popup_export_data = wx.NewId()
        popup_export_metadata = wx.NewId()
        popup_select_all = wx.NewId()
        popup_select_none = wx.NewId()
        popup_menu = wx.Menu()
        self.Bind(wx.EVT_MENU,  self.OnRightPlot, popup_menu.Append(popup_plot_series, 'Plot'))
        self.Bind(wx.EVT_MENU,  self.OnRightEdit, popup_menu.Append(popup_edit_series, 'Edit'))
        popup_menu.AppendSeparator()
        self.Bind(wx.EVT_MENU,  self.OnRightExData, popup_menu.Append(popup_export_data, 'Export Data'))
        self.Bind(wx.EVT_MENU,  self.OnRightExMeta, popup_menu.Append(popup_export_metadata, 'Export MetaData'))

        self.tableSeries.PopupMenu(popup_menu)
        event.Skip()

    def OnRbAdvancedRadiobutton(self, event):
        #open filter window and hide top Panel
        self.splitter.SetSashPosition(1)

        series_filter = frmQueryBuilder.frmQueryBuilder(self)
        self.filterlist = series_filter.ShowModal()        
        # print self.filterlist
        event.Skip()

    def OnRbAllRadiobutton(self, event):
        #Hide top panel
        self.splitter.SetSashPosition(1) 
        self.SetFilter()
        event.Skip()
        

    def OnRbSimpleRadiobutton(self, event):
        #show top Panel
        self.splitter.SetSashPosition(70)       
        self.SetFilter(self.site_code, self.variable_code)
        event.Skip()
       


    def OnRightPlot(self, event):
        # print self.tableSeries.IsItemChecked(self.selectedIndex)
        # self.tableSeries.GetItem(self.selectedID, 0).Check = True
        # print "in OnRightPlot"
        event.Skip()

    def OnRightEdit(self, event):
        self.SelectForEdit(self.tableSeries.GetColumnText(self.selectedIndex, 1))
        event.Skip()

    def OnEditButton(self, vals):
        self.SelectForEdit(self.tableSeries.GetColumnText(self.tableSeries.GetSelection(), 1))
    
    
    
    def OnRightExData(self, event):
        # print "in OnRightExData"
        event.Skip()
    
    def OnRightExMeta(self, event):
        # print "in OnRightExMeta" 
        event.Skip()



    def OnCbSitesCombobox(self, event):
        self.site_code = self.siteList[event.GetSelection()].site_code


        self.varList =[]
        self.varList= self.dbservice.get_variables(self.site_code)

        self.cbVariables.Clear()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        #if (not self.checkVariable):

        if (self.checkSite.GetValue() and not self.checkVariable.GetValue()):
            self.variable_code = None

        self.SetFilter(site_code = self.site_code, var_code = self.variable_code)
        event.Skip()
       


    def OnCbVariablesCombobox(self, event):
        self.variable_code = self.varList[event.GetSelection()].variable_code
        # if (self.checkSite.GetValue() and self.checkVariable.GetValue()):
        #     self.seriesList = self.dbservice.get_series(site_code = self.site_code, var_code= self.variable_code)
        if (not self.checkSite.GetValue() and self.checkVariable.GetValue()):
            self.site_code = None
        self.SetFilter(site_code = self.site_code, var_code = self.variable_code)
        event.Skip()


      


    def siteAndVariables(self):
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables(self.site_code)
        for var in self.varList:            
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)


        
        self.variable_code=self.varList[self.cbVariables.Selection].variable_code
        self.site_code = self.siteList[self.cbSites.Selection].site_code

        self.SetFilter(site_code = self.site_code, var_code = self.variable_code)
        
        self.cbVariables.Enabled =True
        self.cbSites.Enabled = True

        
        

    def siteOnly(self):
        self.cbVariables.Enabled = False
        self.cbSites.Enabled = True
        self.variable_code = None
        
        
        self.site_code =  self.siteList[self.cbSites.Selection].site_code
        self.SetFilter(site_code = self.site_code) 
       

        

    def variableOnly(self):
        self.site_code = None
        self.cbVariables.Clear()
        self.varList= self.dbservice.get_variables()
        for var in self.varList:
            self.cbVariables.Append(var.variable_code+'-'+var.variable_name)
        self.cbVariables.SetSelection(0)
        self.cbSites.Enabled = False
        self.cbVariables.Enabled = True

       
        self.variable_code=self.varList[0].variable_code

        self.SetFilter( var_code = self.variable_code)
               


    def OnCheck(self, event):
        # self.tableSeries.DeleteAllItems()
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
        event.Skip()

    def SetFilter(self, site_code = '', var_code = '', advfilter = ''):        
        if (site_code and var_code):
            self.siteFilter= TextSearch(self.tableSeries, columns = self.tableSeries.columns[2:4], text = site_code )
            self.variableFilter = TextSearch(self.tableSeries, columns = self.tableSeries.columns[5:7], text = var_code)
            self.tableSeries.SetFilter(Chain(self.siteFilter, self.variableFilter))
        elif (site_code):
            self.tableSeries.SetFilter(TextSearch(self.tableSeries, columns = self.tableSeries.columns[2:4], text = site_code) )
        elif (var_code):
            self.tableSeries.SetFilter(TextSearch(self.tableSeries, columns = self.tableSeries.columns[5:7], text = var_code) )
        elif(advfilter):
            self.tableSeries.SetFilter(advfilter)
        else:
            self.tableSeries.ClearFilter()

        self.tableSeries.RepopulateList()
        # print self.tableSeries.GetItemCount()

  
    def OntableSeriesListItemSelected(self, event):
        # print"in item selected", event.m_itemIndex, self.tableSeries.IsItemChecked(event.m_itemIndex)
        # print dir(event)
        sid= self.tableSeries.innerList[event.m_itemIndex][0]
        if not self.tableSeries.IsItemChecked(event.m_itemIndex):         
            Publisher().sendMessage(("removePlot"), sid)
            #set isselected value to False
            # self.cursor.execute("UPDATE SeriesCatalog SET isSelected = 0 WHERE SeriesID =", self.tableSeries.innerList[event.m_itemIndex].id)
            # self.tableSeries.innerList[event.m_itemIndex]
            # self.tableSeries.CheckItem(event.GetItem())
            self.tableSeries.innerList[event.m_itemIndex][-1]= False


        else:  
            #set isselected value to True 
            self.tableSeries.innerList[event.m_itemIndex][-1]= True

                    
            # get DataValues
            self.DataValues = self.dbservice.get_data_values_by_series_id(sid)
         
            self.cursor.execute("DELETE FROM DataValues")
            self.cursor.executemany("INSERT INTO DataValues VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.DataValues)
            self.conn.commit()

            Publisher().sendMessage(("add.NewPlot"), [self.cursor,self.tableSeries.innerList[event.m_itemIndex]])
            self.parent.Parent.addPlot(self.cursor, self.dbservice.get_series_by_id( sid))
            # self.parent.Parent.addPlot(self.dataRep ,sid)

        self.Refresh()
        event.Skip()

    def SelectForEdit(self, seriesID):
        self.DataValues = self.dbservice.get_data_values_by_series_id(seriesID)
            
        # self.cursor.execute("DELETE FROM DataValuesEdit")
        # self.conn.commit()
        
        self.cursor.executemany("INSERT INTO DataValuesEdit VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.DataValues)
        self.conn.commit()
        self.cursor.execute("ALTER TABLE DataValuesEdit ADD COLUMN isSelected INTEGER ")
        self.conn.commit()
        self.cursor.execute("UPDATE DataValuesEdit SET isSelected=0")
        self.conn.commit()
        # print type(self.parent.Parent), dir (self.parent.Parent)
        self.parent.Parent.addEdit(self.cursor, self.dbservice.get_series_by_id(seriesID))
        # Publisher().sendMessage(("edit.NewPlot"), [self.cursor, self.dbservice.get_series_by_id(seriesID)])
        
   
    def stopEdit(self):
        self.cursor.execute("DROP TABLE DataValuesEdit")
        self.conn.commit()
        self.createEditTable()

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
        self.createEditTable()

    def createEditTable(self):
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

    