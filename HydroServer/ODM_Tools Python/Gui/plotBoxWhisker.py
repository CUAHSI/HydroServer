
import wx

from wx.lib.pubsub import Publisher

import matplotlib
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar
import matplotlib.pyplot as plt
import math
import textwrap
import numpy as np


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

   

  def addPlot(self, cursor, series, Filter):

      # self.cursor = Values[0]
      self.cursor = cursor
      self.cursor.execute("SELECT  DataValue, CAST(strftime('%m', LocalDateTime) AS INTEGER) AS Month, CAST(strftime('%Y', LocalDateTime)AS INTEGER) As Year FROM DataValues "+Filter)
      self.Data= self.cursor.fetchall() 

      # self.Series= Values[1]
      self.Series = series
      self.overall("")             


 
  def SetColor( self, color):
      """Set figure and canvas colours to be the same."""        
      self.figure.set_facecolor( color )
      self.figure.set_edgecolor( color )
      self.canvas.SetBackgroundColour( color )
       


  def monthly(self, str):

      self.updatePlot("Monthly",  [[x[0] for x in self.Data if x[1]==1], [x[0] for x in self.Data if x[1]==2], [x[0] for x in self.Data if x[1]==3],[x[0] for x in self.Data if x[1]==4], [x[0] for x in self.Data if x[1]==5], [x[0] for x in self.Data if x[1]==6], [x[0] for x in self.Data if x[1]==7], [x[0] for x in self.Data if x[1]==8], [x[0] for x in self.Data if x[1]==9], [x[0] for x in self.Data if x[1]==10], [x[0] for x in self.Data if x[1]==11], [x[0] for x in self.Data if x[1]==12]])
      
      self.plot.set_xticklabels(['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'])
      self.canvas.draw()



  def seasonaly(self, str):

      self.updatePlot("Seasonally",  [[x[0] for x in self.Data if x[1] in (1,2,3)], [x[0] for x in self.Data if x[1]in (4,5,6)], [x[0] for x in self.Data if x[1]in (6,7,8)],[x[0] for x in self.Data if x[1]in (10,11,12)]])
     
      self.plot.set_xticklabels( ['Winter', 'Spring', 'Summer', 'Fall'])
      self.canvas.draw()



  def yearly(self, str):
      
      years = sorted(list(set([x[2] for x in self.Data] )))      
      histlist = []
      for y in years:
          histlist.append([x[0] for x in self.Data if x[2]==y])

      self.updatePlot("Yearly", histlist)
      self.plot.set_xticklabels( years)
      self.canvas.draw()



  def overall(self, str): 
            
      self.updatePlot("Overall", [x[0] for x in self.Data])
      self.plot.set_xticklabels( [''])
      # self.plot.set_xlabel(color = "WHITE")
      self.canvas.draw()
      


  def updatePlot(self, title, data):
      self.plot.clear()
      self.plot.set_xlabel("\n".join(textwrap.wrap(title, 55))) 
      self.plot.set_ylabel("\n".join(textwrap.wrap(self.Series.variable_name+ "("+self.Series.variable_units_name+")", 50)))
      self.plot.set_title("\n".join(textwrap.wrap(self.Series.site_name+" "+self.Series.variable_name, 55 )))

      med, cl, mean, ci = self.calcConfInterval(data)
      bp=self.plot.boxplot( data,  sym = "-gs", notch = True, bootstrap = 5000,  conf_intervals = cl)
      

      # Plot Mean and its confidence interval
      for x in range(len(mean)):
        self.plot.vlines(x+1, ci[x][0], ci[x][1], color='r', linestyle = "solid" )
      self.plot.scatter([range(1,len(mean)+1)], mean, marker='o', c='r', s= 10)
      
      
      # Plot Median 
      self.plot.scatter([range(1,len(med)+1)], med, marker='s', c="k", s= 10)
      # Plot the confidence limit of the median 
      # for x in range(len(mean)):
      #   self.plot.hlines(cl[x][0], (x+1)-.25, (x+1)+.25, color='GREY', linestyle = "solid" )
      #   self.plot.hlines(cl[x][1], (x+1)-.25, (x+1)+.25, color='GREY', linestyle = "solid" )  

      # Set Colors of the Box Whisker plot   
      plt.setp(bp['whiskers'], color = 'k', linestyle = '-')
      plt.setp(bp['medians'], color = 'k', linestyle = '-')
      plt.setp(bp['boxes'], color = 'GREY', linestyle = '-')
      plt.setp(bp['caps'], color = 'k')
      plt.setp(bp['fliers'], markersize = 3.5)

      # self.plot.set_ybound(min(data),max(data))
      self.plot.set_autoscale_on(True)

      self.canvas.draw()



  def calcConfInterval(self, PlotData):
      medians = []
      confint = []
      conflimit = []
      means = []
      if len(PlotData)>12 :
        vals = self.indivConfInter(PlotData)
        medians.append(vals[0])
        means.append(vals[1])
        conflimit.append((vals[4], vals[5]))
        confint.append((vals[2], vals[3]))
        # print vals

      else:      
        for data in PlotData:
          vals = self.indivConfInter(data)
          medians.append(vals[0])
          means.append(vals[1])
          conflimit.append((vals[4], vals[5]))
          confint.append((vals[2], vals[3]))
          # print vals

      return medians, conflimit, means, confint



  def indivConfInter(self, data):
      if len(data)>0:
        med = np.median(data)
        mean = np.mean(data)
        stdDev = math.sqrt(np.var(data))
        ci95low = mean - 10*(1.96 *(stdDev/math.sqrt(len(data))))
        ci95up = mean + 10*(1.96 *(stdDev/math.sqrt(len(data))))

        cl95low = med - (1.96 *(stdDev/math.sqrt(len(data))))
        cl95up = med + (1.96 *(stdDev/math.sqrt(len(data))))
      
        return [med, mean, ci95low, ci95up, cl95low, cl95up]
      else: return [ None, None, None, None, None, None]
     

       
  def __init__(self, parent, id, pos, size, style, name):
      self._init_ctrls(parent)