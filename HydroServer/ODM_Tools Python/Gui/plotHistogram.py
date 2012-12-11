
import wx

from wx.lib.pubsub import Publisher

import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from matplotlib.widgets import Lasso
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar


class plotHist(wx.Panel):
   
   
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
      
      self.figure = matplotlib.figure.Figure()
      self.plot=self.figure.add_subplot(111)
      
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

   
   


  def addPlot(self, datavalues, datetimes, series):
      self.plot.clear()
      self.dataValues = datavalues
      self.dateTimes = datetimes
      self.Series= series
      self.plot.clear()
      self.plot.set_xlabel("Value")
      self.plot.set_ylabel("Count")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
      
      self.plot=self.figure.add_subplot(111)
      self.plot.hist(self.dataValues, 50, normed=1, facecolor='g', alpha=0.75)
       
      self.canvas.draw()

  
  
   
  def SetColor( self, color):
      """Set figure and canvas colours to be the same."""        
      self.figure.set_facecolor( color )
      self.figure.set_edgecolor( color )
      self.canvas.SetBackgroundColour( color )

  
   

       
       
       
  def __init__(self, parent, id, pos, size, style, name):
      self._init_ctrls(parent)