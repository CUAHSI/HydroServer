
import wx

from wx.lib.pubsub import Publisher

import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from matplotlib.widgets import Lasso
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar

 
from wx.lib.pubsub import Publisher




class plotBox(wx.Panel):
   
   
  def _init_coll_boxSizer1_Items(self, parent):
      # generated method, don't edit

      parent.AddWindow(self.canvas, 1, wx.LEFT | wx.TOP | wx.GROW)
      parent.AddWindow(self.toolbar, 0,  wx.EXPAND)
       

  def _init_sizers(self):
      # generated method, don't edit
      self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)
      self._init_coll_boxSizer1_Items(self.boxSizer1)
      self.SetSizer(self.boxSizer1)
   
   
   
  def _init_ctrls(self, prnt):
      #matplotlib.figure.Figure.__init__(self)
      wx.Panel.__init__(self, prnt, -1)
      

      Publisher().subscribe(self.monthly, ("box.Monthly"))
      Publisher().subscribe(self.yearly, ("box.Yearly"))
      Publisher().subscribe(self.seasonaly, ("box.Seasonal"))
      Publisher().subscribe(self.overall, ("box.Overall")) 


      self.figure = matplotlib.figure.Figure()
      self.plot=self.figure.add_subplot(111)
      self.plot.axis([0, 1, 0, 1])#
      self.plot.set_title("No Data To Plot")
            
      self.canvas = FigCanvas(self, -1, self.figure)
      # Create the navigation toolbar, tied to the canvas
      self.toolbar = NavigationToolbar(self.canvas, True)
      self.toolbar.Realize()
       
       
      #self.canvas.SetCursor(wx.StockCursor(wx.CURSOR_CROSS))        
      #self.canvas.SetScrollbar(wx.HORIZONTAL, 0,5, 1000)
      self.SetColor("WHITE")
      self.canvas.SetFont(wx.Font(20, wx.SWISS, wx.NORMAL, wx.NORMAL,
            False, u'Tahoma'))


      
       
      self.canvas.draw()
       

      self._init_sizers()

   
   

  def addPlot(self, Values, Filter):

      self.cursor = Values[0]


      self.cursor.execute("SELECT  DataValue, CAST(strftime('%m', LocalDateTime) AS INTEGER) AS Month, CAST(strftime('%Y', LocalDateTime)AS INTEGER) As Year FROM DataValues "+Filter)
      self.Data= self.cursor.fetchall() 

      self.Series= Values[1]
      

      self.overall("")             

 
  def SetColor( self, color):
      """Set figure and canvas colours to be the same."""        
      self.figure.set_facecolor( color )
      self.figure.set_edgecolor( color )
      self.canvas.SetBackgroundColour( color )
       
  def monthly(self, str):


      self.plot.clear()
      
      self.plot.set_xlabel("Monthly")
      x = range(len(self.Data))
      self.plot.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
      self.plot.boxplot( [[x[0] for x in self.Data if x[1]==1], [x[0] for x in self.Data if x[1]==2], [x[0] for x in self.Data if x[1]==3],[x[0] for x in self.Data if x[1]==4], [x[0] for x in self.Data if x[1]==5], [x[0] for x in self.Data if x[1]==6], [x[0] for x in self.Data if x[1]==7], [x[0] for x in self.Data if x[1]==8], [x[0] for x in self.Data if x[1]==9], [x[0] for x in self.Data if x[1]==10], [x[0] for x in self.Data if x[1]==11], [x[0] for x in self.Data if x[1]==12]], notch = True, sym = "gs")
      self.plot.set_xticklabels(['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'])
      self.canvas.draw()



  def seasonaly(self, str):
      self.plot.clear()
      x = range(len(self.Data))
      self.plot.set_xlabel("Seasonally")
      self.plot.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
      self.plot.boxplot( [[x[0] for x in self.Data if x[1] in (1,2,3)], [x[0] for x in self.Data if x[1]in (4,5,6)], [x[0] for x in self.Data if x[1]in (6,7,8)],[x[0] for x in self.Data if x[1]in (10,11,12)]], notch = True, sym = "gs")
      self.plot.set_xticklabels( ['Winter', 'Spring', 'Summer', 'Fall'])
      self.canvas.draw()


  def yearly(self, str):
      
      years = sorted(list(set([x[2] for x in self.Data] )))      
      histlist = []
      for y in years:
          histlist.append([x[0] for x in self.Data if x[2]==y])

      self.plot.clear()
      self.plot.set_xlabel("Yearly")
      x = range(len(self.Data))
      self.plot.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
      self.plot.boxplot( histlist , notch = True, sym = "gs")
      self.plot.set_xticklabels( years)
      self.canvas.draw()


  def overall(self, str): 
      
      self.plot.set_xlabel("Overall") 
      self.plot.clear()
      x = range(len(self.Data))
      self.plot.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
      self.plot.boxplot( [x[0] for x in self.Data], notch = True, sym = "gs")
      self.canvas.draw()


       
  def __init__(self, parent, id, pos, size, style, name):
      self._init_ctrls(parent)