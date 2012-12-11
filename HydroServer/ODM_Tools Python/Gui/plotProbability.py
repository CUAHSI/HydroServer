
import wx

from wx.lib.pubsub import Publisher

import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from matplotlib.widgets import Lasso
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar


class plotProb(wx.Panel):
   
   
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
      self.plot.axis([0, 1, 0, 1])#
      self.plot.plot([],[])
      self.plot.set_title("No Data To Plot")
            
      self.canvas = FigCanvas(self, -1, self.figure)
      # Create the navigation toolbar, tied to the canvas
      self.toolbar = NavigationToolbar(self.canvas)
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
     
      length = len(datavalues)
      
      self.Yaxis = sorted(datavalues)
      self.Xaxis = []
      for it in range (0, length):
          #curValue = datavalues[it]
          curFreq= self.CalcualteProbabilityFreq(it+1, length)
          curX = self.CalculateProbabilityXPosition(curFreq)
          #self.Yaxis.append(curValue)
          self.Xaxis.append(curX)
      
      #print self.Xaxis
     # print self.Yaxis

      self.Series= series
      self.plot.clear()
      x = range(len(self.Xaxis))
      self.plot.set_xlabel("Cumulative Frequency < Stated Value %")
      self.plot.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      self.plot.set_title(self.Series.site_name+" "+self.Series.variable_name)
             
      self.plot=self.figure.add_subplot(111)
      self.plot.plot( self.Xaxis, self.Yaxis, 'bs')
       
      self.plot.legend(loc= 'upper right')
      self.canvas.draw()

 

   
  def SetColor( self, color):
      """Set figure and canvas colours to be the same."""        
      self.figure.set_facecolor( color )
      self.figure.set_edgecolor( color )
      self.canvas.SetBackgroundColour( color )

  def CalculateProbabilityXPosition(self, freq):
      try:
        return round(4.91*((freq **.14) -(1.00 - freq)**.14), 3)
      except:
        print "An error occurred while calculating the X-Position for a point in the prob plot"
        pass
  def CalcualteProbabilityFreq(self, rank, numRows):     
      try:
        return round((rank - .0375)/(numRows+1-(2*0.375)), 3)
      except:
        print "An error occured while calculating the frequency for a point in the prob plot"
        pass
     
       
  def __init__(self, parent, id, pos, size, style, name):
      self._init_ctrls(parent)