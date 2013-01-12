#Boa:FramePanel:pnlDataTable

import wx
import wx.grid
from ObjectListView import ObjectListView, ColumnDefn
import odmdata
import sqlite3
    
[wxID_PNLDATATABLE, wxID_PNLDATATABLEDATAGRID, 
] = [wx.NewId() for _init_ctrls in range(2)]


class Track:
    """
    A song in some music library
    """
    def __init__(self, **kwargs):
        self.isChecked = False
        self.attributeNames = kwargs.keys()
        self.attributeNames.extend(["isChecked"])
        self.__dict__.update(kwargs)

    



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
        
              
    def Init(self, Values = None):
        self.InitModel(Values)
       
        

    def InitModel(self, DVConn):
       
        cursor = DVConn
        sql = "SELECT * FROM DataValues"
        cursor.execute(sql)


        print enumerate(cursor.description)
        self.myOlv.SetColumns(ColumnDefn(x[0], valueGetter=i, minimumWidth=40) for (i,x) in enumerate(cursor.description))
        self.InitTable()       


        # self.values = [list(x) for x in cursor.fetchall()] 
        self.myOlv.SetObjects([list(x) for x in cursor.fetchall()] )
        

    def InitTable(self):
        #self.myOlv.InstallCheckStateColumn(self.myOlv.columns[0])
        # self.myOlv.useAlternateBackColors = True
        #self.myOlv.evenRowsBackColor = "Silver"
        self.myOlv.oddRowsBackColor = "SlateGray"
        self.myOlv.AutoSizeColumns()

        # isActiveColumn = ColumnDefn("Active?", fixedWidth=24, checkStateGetter="isActive")
        # self.myOlv.CreateCheckStateColumn()
        # self.myOlv.InstallCheckStateColumn(self.myOlv.columns[0])
        #self.myOlv.InstallCheckStateColumn( isActiveColumn)
        
        # self.myOlv.UseSubItemCheckBoxes = true
        # RowBorderDecoration rbd = new RowBorderDecoration()
        # rbd.BorderPen = new Pen(Color.FromArgb(128, Color.LightSeaGreen), 2)
        # rbd.BoundsPadding = new Size(1, 1)
        # rbd.CornerRounding = 4.0f

        # # Put the decoration onto the hot item
        # self.olv1.HotItemStyle = new HotItemStyle()
        # self.olv1.HotItemStyle.Decoration = rbd


#########self.myOlv.GetCheckedObjects
#########IsChecked(ModelObject)
########Uncheck(modelObject), Check(modelObject)



    def InitWidgets(self):
        
        self.myOlv = ObjectListView(self, -1, style=wx.LC_REPORT|wx.SUNKEN_BORDER)
        self.myOlv.SetEmptyListMsg("")

        sizer_2 = wx.BoxSizer(wx.VERTICAL)
        sizer_2.Add(self.myOlv, 1, wx.ALL|wx.EXPAND, 4)
        self.SetSizer(sizer_2)

        self.Layout()
    


    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)
        
        