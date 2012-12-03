#Boa:FramePanel:pnlDataTable

import wx
import wx.grid
from ObjectListView import ObjectListView, ColumnDefn
import odmdata
    
[wxID_PNLDATATABLE, wxID_PNLDATATABLEDATAGRID, 
] = [wx.NewId() for _init_ctrls in range(2)]

class pnlDataTable(wx.Panel):
    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.dataGrid, 100, border=0, flag=wx.GROW | wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)

        self.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Panel.__init__(self, id=wxID_PNLDATATABLE, name=u'pnlDataTable',
              parent=prnt, pos=wx.Point(717, 342), size=wx.Size(677, 449),
              style=wx.TAB_TRAVERSAL)
        self.InitWidgets()
        self.InitColumns()
        
              
    def Init(self, Values = None):
        self.InitModel(Values)
        #self.InitWidgets()
        

    def InitModel(self, Values):
        self.values = Values 
        print type(self.values)        
        print type(self.values[0])
        print dir(self.values[0])
        print isinstance(self.values[0], odmdata.data_value.DataValue)
        self.myOlv.SetObjects(self.values)

    def InitWidgets(self):
        
        self.myOlv = ObjectListView(self, -1, style=wx.LC_REPORT|wx.SUNKEN_BORDER)
        sizer_2 = wx.BoxSizer(wx.VERTICAL)
        sizer_2.Add(self.myOlv, 1, wx.ALL|wx.EXPAND, 4)
        self.SetSizer(sizer_2)
        # self.myOlv.SetFont(wx.Font(9, wx.SWISS, wx.NORMAL, wx.NORMAL,
        #       False, u'Tahoma'))

        self.Layout()
        
        
    def InitColumns(self):


        self.myOlv.SetColumns([
##            ColumnDefn("Title", "left", 120, "title"),
##            ColumnDefn("Size (MB)", "center", 100, "GetSizeInMb", stringConverter="%.1f"),
##            ColumnDefn("Last Played", "left", 100, "lastPlayed", stringConverter="%d-%m-%Y"),
##            ColumnDefn("Rating", "center", 100, "rating"),

            ColumnDefn("ValueID", "center", 100, "ValueID"),
            ColumnDefn("DataValue", "center", 100, "DataValue"),
            ColumnDefn("ValueAccuracy", "center", 100, "ValueAccuracy"),
            ColumnDefn("LocalDateTime", "center", 100, "LocalDateTime"),           
            ColumnDefn("UTCOffset", "center", 100, "UTCOffset"),
            ColumnDefn("DateTimeUTC", "center", 100, "DateTimeUTC"),
            ColumnDefn("SiteID", "center", 100, "SiteID"),            
            ColumnDefn("VariableID", "center", 100, "VariableID"),
            ColumnDefn("OffsetValue", "center", 100, "OffsetValue"),
            ColumnDefn("OffsetTypeID", "center", 100, "OffsetTypeID"),
            ColumnDefn("CensorCode", "center", 100, "CensorCode"),
            ColumnDefn("QualifierID", "center", 100, "QualifierID"),
            ColumnDefn("MethodID", "center", 100, "MethodID"),
            ColumnDefn("SourceID", "center", 100, "SourceID"),
            ColumnDefn("SampleID", "center", 100, "SampleID"),
            ColumnDefn("DerivedFromID", "center", 100, "DerivedFromID"),
            ColumnDefn("QualityControlLevelID", "center", 100, "QCLID")
            
        ])



    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)
        
        
##        self.colLabels=['SiteID','SiteCode','SiteName','VariableID','VariableCode','Speciation','VariableUnitsID'
##            ,'VariableUnitsName','SampleMedium','ValueType','TimeSupport','TimeUnitsID','TimeUnitsName','DataType'
##            ,'GeneralCategory','MethodID','MethodDescription','SourceID','SourceDescription','Organization'
##            ,'Citation','QualityControlLevelID','QualityControlLevelCode','BeginDateTime','EndDateTime','BeginDateTimeUTC'
##            ,'EndDateTimeUTC','ValueCount']
##            
##        for col in range(len(self.colLabels)):
##            self.dataGrid.SetColLabelValue(col, self.colLabels[col])
