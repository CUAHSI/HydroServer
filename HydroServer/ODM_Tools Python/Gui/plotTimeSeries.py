
import wx


import textwrap
import datetime
import numpy as np
import matplotlib
import matplotlib.pyplot as plt


matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
# from matplotlib.widgets import Lasso
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar
from random import *
from wx.lib.pubsub import Publisher




class plotTimeSeries(wx.Panel):
   
   
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
      
      self.figure = Figure()#matplotlib.figure.Figure()
      self.timeSeries=self.figure.add_subplot(111)
      self.timeSeries.axis([0, 1, 0, 1])#
      self.timeSeries.plot([],[])
      self.timeSeries.set_title("No Data To Plot")
            
      self.canvas = FigCanvas(self, -1, self.figure)
      # Create the navigation toolbar, tied to the canvas
      self.toolbar = NavigationToolbar(self.canvas)
      self.toolbar.Realize()


      self.timeSeries.legend(loc = "lower center")
      self.format = '-o'

      self.SetColor("WHITE")
      self.canvas.SetFont(wx.Font(20, wx.SWISS, wx.NORMAL, wx.NORMAL,
            False, u'Tahoma'))
       
      #self.canvas.gca().xaxis.set_major_locator()



      self.canvas.mpl_connect('pick_event', self.on_pick)
      # self.canvas.mpl_connect('button_press_event', self.onclick)
      
      self.isfirstplot = True

      self.BuildPopup()
      self.canvas.draw()      
      self._init_sizers()

   
  def randBinList(self, n):
      selected = []
      val = n+1
      for b in range(1,val):
        selected.append(randint(0,1))
      return selected
      #return lambda n: [randint(0,1) for b in range(1,n+1)]

  def editSeries(self, seriesID):
      self.timeSeries.clear()


      #####include NoDV in plot
      # remove from regular 'lines'
      self.removePlot(seriesID)

      #add plot with line only in black      
      self.timeSeries.set_ylabel("\n".join(textwrap.wrap(self.Series.variable_name+ "("+self.Series.variable_units_name+")",50)))
      self.timeSeries.set_title("\n".join(textwrap.wrap(self.Series.site_name+" "+self.Series.variable_name, 55)))      
      self.timeSeries.plot_date( self.dateTimes, self.dataValues,'-k', xdate = True, tz = None )

      # add scatterplot with colorlist as colorchart
      # self.colorlist = ['k' if x==0 else 'r' for x in self.randBinList(len(self.dataValues))]
      self.colorlist = self.randBinList(len(self.dataValues))
      self.editPoint = self.timeSeries.scatter(self.dateTimes, self.dataValues, s= 20, c=['k' if x==0 else 'r' for x in self.colorlist])
      #   self.isfirstplot = False
      self.editPoint.set_picker(True) 

      self.canvas.draw()



  def onDateChanged(self, date, time): 
      # print date
      # self.timeSeries.clear()
      date = datetime.datetime(date.Year, date.Month, date.Day, 0, 0, 0)
      if time == "start":
        self.startDate = date
      else:
        self.endDate = date 
      
      # print "SELECT  DataValue, LocalDateTime FROM DataValues "+self.dataFilter + " AND (LocalDateTime BETWEEN '" + str(self.startDate)+"' AND '" + str(self.endDate)+"')"
      # print "SELECT  DataValue, LocalDateTime FROM DataValues "+self.dataFilter + " AND ( strftime('%m/%d/%Y %H:%M:%S', LocalDateTime) BETWEEN '" + str(self.startDate)+"' AND '" + str(self.endDate)+"')"
      # self.cursor.execute("SELECT  DataValue, LocalDateTime FROM DataValues "+self.dataFilter + " AND ( strftime('%m/%d/%Y %H:%M:%S', LocalDateTime) BETWEEN '" + str(self.startDate)+"' AND '" + str(self.endDate)+"')")

      # results = self.cursor.fetchall()
      # self.dataValues =[x[0] for x in results]
      # self.dateTimes = [x[1] for x in results]
      # print self.dateTimes
      # print len(results)
      self.plot.set_xbound(self.startDate,self.endDate)
      # self.timeSeries.set_xlim(self.startDate, self.endDate)
      # self.timeSeries.set_xlabel("Date Time")
      # self.timeSeries.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
      # self.timeSeries.set_title(self.Series.site_name+" "+self.Series.variable_name)
      # self.lines= self.timeSeries.plot_date( self.dateTimes, self.dataValues, self.format, xdate = True, tz = None )
      self.canvas.draw()
  
   

  def OnShowLegend(self, isVisible):
    # print self.timeSeries.show_legend
    self.timeSeries.plot(legend= not isVisible)
    self.canvas.draw()
      


  def OnPlotType(self, ptype):
    # self.timeSeries.clear()
    if ptype == "line":
      ls = '-'
      m='None'
    elif ptype == "point":
      ls='None'
      m='o'      
    else:
      ls = '-'
      m='o'
    # print plt.setp(self.lines)
    # print(len(self.lines))
    format = ls+m
    for line in self.lines:
      plt.setp(line, linestyle = ls, marker =  m)

    self.canvas.draw()


  def addPlot(self, Values, Filter):
      self.dataFilter = Filter
      self.cursor = Values[0]

      self.cursor.execute("SELECT  DataValue, LocalDateTime FROM DataValues"+self.dataFilter)
      results = self.cursor.fetchall()
      self.dataValues =[x[0] for x in results]
      self.dateTimes = [x[1] for x in results]
      self.startDate= min(self.dateTimes)
      self.endDate = max(self.dateTimes)

      # print self.startDate
      # print self.endDate      
      # print len(self.dateTimes)

      self.Series= Values[1]

      # self.editSeries(1)
      
      # self.timeSeries.clear()
      # self.colorlist = self.randBinList(len(self.dataValues))
      # x = range(len(self.dataValues))

      
      if self.isfirstplot:
        self.timeSeries.clear()
        self.timeSeries.set_ylabel("\n".join(textwrap.wrap(self.Series.variable_name+ "("+self.Series.variable_units_name+")",50)))
        self.timeSeries.set_title("\n".join(textwrap.wrap(self.Series.site_name+" "+self.Series.variable_name,55)))
        self.lines= self.timeSeries.plot_date( self.dateTimes, self.dataValues,self.format+'r', xdate = True, tz = None )
        self.isfirstplot = False
      else:
        ax2 = self.timeSeries.twinx()
        ax2.set_ylabel("\n".join(textwrap.wrap(self.Series.variable_name+ "("+self.Series.variable_units_name+")",50)))
        self.lines.append(ax2.plot_date( self.dateTimes, self.dataValues,self.format+'b', xdate = True, tz = None))
        # print len(self.lines)
        ax2.legend(loc= 'lower center')
        ax3 = ax2.twinx()
        ax3.set_ylabel("\n".join(textwrap.wrap(self.Series.variable_name+ "("+self.Series.variable_units_name+")",50)))
        self.lines.append(ax3.plot_date( self.dateTimes, self.dataValues,self.format+'g', xdate = True, tz = None))
      
      self.timeSeries.set_xlabel("Date Time")



        # print len(self.lines)

      # self.lines= self.timeSeries.plot_date( self.dateTimes, self.dataValues,self.format, xdate = True, tz = None )
      
      #self.timeSeries.set_xticks( minor=False)
      

      # handles, labels = self.timeSeries.get_legend_handles_labels()    
      # self.timeSeries.legend(handles, labels, loc= 'lower center')


      self.timeSeries.legend(loc= 'lower center')
      self.canvas.draw()


  def removePlot(self, seriesID): 
     #if series id matches a key in the dictionary      
      # self.lines.pop(0).remove()
      print "in remove plot"
      pass
  
   
  def SetColor( self, color):
      """Set figure and canvas colours to be the same."""        
      self.figure.set_facecolor( color )
      self.figure.set_edgecolor( color )
      self.canvas.SetBackgroundColour( color )

  def on_pick(self, event):
      # print dir(event)
      # print "artist", dir(event.artist)
      # print "picker", dir(event.artist.get_picker)
      # print "pickradius", dir(event.artist.get_pickradius)
      # print "get_snaP", dir(event.artist.get_snap)
      # ind = event.ind

      print(event.ind, np.take(self.dateTimes, event.ind), np.take(self.dataValues, event.ind))





      # The event received here is of the type
      # matplotlib.backend_bases.PickEvent
      #
      # It carries lots of information, of which we're using
      # only a small amount here.
      #
      # print "point selected"
      # plot_points = event.artist.get_points()
      # print  plot_points
      # msg = "You've clicked on a point with coords:\n %s" % plot_points
       
      # dlg = wx.MessageDialog(
      #     self,
      #     msg,
      #     "ok",
      #     wx.OK | wx.ICON_INFORMATION)
      # dlg.ShowModal()
      # dlg.Destroy()  



      

  # def onclick(self, event):
  #     print 'button=%d, x=%d, y=%d, xdata=%f, ydata=%f'%(event.button, event.x, event.y, event.xdata, event.ydata)    
      
  def BuildPopup(self):
      # build pop-up menu for right-click display
      self.popup_unzoom_all = wx.NewId()
      self.popup_unzoom_one = wx.NewId()
      self.popup_config     = wx.NewId()
      self.popup_save   = wx.NewId()
      self.popup_menu = wx.Menu()
      self.popup_menu.Append(self.popup_unzoom_one, 'Zoom out')
      self.popup_menu.Append(self.popup_unzoom_all, 'Zoom all the way out')
      self.popup_menu.AppendSeparator()



       
  def __init__(self, parent, id, pos, size, style, name):
      self._init_ctrls(parent)