#Boa:FramePanel:Panel1

import wx

from wx.lib.pubsub import Publisher


import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from matplotlib.widgets import Lasso
from mnuPlotToolbar import MyCustomToolbar as NavigationToolbar

class pnlPlot(wx.Panel):
    
    
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
        self.timeSeries=self.figure.add_subplot(111)
        self.timeSeries.axis([0, 1, 0, 1])#
        self.timeSeries.plot([],[])
        self.timeSeries.set_title("No Data To Plot")
              
        self.canvas = FigCanvas(self, -1, self.figure)
        # Create the navigation toolbar, tied to the canvas
        self.toolbar = NavigationToolbar(self.canvas)
        toolbar.Realize()
        
        
        #self.canvas.SetCursor(wx.StockCursor(wx.CURSOR_CROSS))        
        self.canvas.SetScrollbar(wx.HORIZONTAL, 0,5, 1000)
        self.SetColor("WHITE")
        self.canvas.SetFont(wx.Font(20, wx.SWISS, wx.NORMAL, wx.NORMAL,
              False, u'Tahoma'))
        
        #self.canvas.gca().xaxis.set_major_locator()



        self.canvas.mpl_connect('pick_event', self.on_pick)
        self.canvas.mpl_connect('button_press_event', self.onclick)
        self.canvas.Bind(wx.EVT_SCROLLWIN, self.OnScrollEvt)
        
       
        
        self.canvas.draw()
        
        
        self.BuildPopup()      

        self._init_sizers()

    
    def addPlot(self, Values):
     
        self.dataValues = []
        self.dateTimes= []
        self.Series = Values[1]
        for dv in Values[0]:
            self.dataValues.append(dv.data_value)
            self.dateTimes.append(dv.local_date_time)
        self.timeSeries.clear()
        self.init_data()   
        self.init_plot()
        #self.addtimeSeriesPlot()


    def addtimeSeriesPlot(self):
       
        self.timeSeries.clear()
        x = range(len(self.dataValues))
        self.timeSeries.set_xlabel("Date Time")
        self.timeSeries.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
        self.timeSeries.set_title(self.Series.site_name+" "+self.Series.variable_name)
       
        
        self.timeSeries=self.figure.add_subplot(111)
        self.timeSeries.plot_date( self.dateTimes, self.dataValues, ':rs', xdate = True, tz = None )
        
        #self.timeSeries.legend(loc= 'upper right')
        self.canvas.draw()

    def draw_plot(self):
        # Update data in plot:
        self.plot_data.set_xdata(self.x[self.i_start:self.i_end])
        self.plot_data.set_ydata(self.y[self.i_start:self.i_end])
        # Adjust plot limits:
        self.timeSeries.set_xlim((min(self.x[self.i_start:self.i_end]),
                           max(self.x[self.i_start:self.i_end])))
        self.timeSeries.set_ylim((min(self.y[self.i_start:self.i_end]),
                            max(self.y[self.i_start:self.i_end])))
        # Redraw:                  
        self.canvas.draw()   
        
    

    def init_data(self):
        # Generate some data to plot:
        self.y = self.dataValues
        self.x = self.dateTimes

        # Extents of data sequence: 
        self.i_min =0
        self.i_max = len(self.x)
        # Size of plot window:              
        self.i_window = len(self.y)
        # Indices of data interval to be plotted:
        self.i_start = 0
        self.i_end = self.i_start + self.i_window

    def init_plot(self):
        
        self.plot_data = \
            self.timeSeries.plot_date(self.x[self.i_start:self.i_end],
                                self.y[self.i_start:self.i_end], ':bs', xdate = True, tz = None )[0]

        self.timeSeries.set_xlabel("Date Time")
        self.timeSeries.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
        self.timeSeries.set_title(self.Series.site_name+" "+self.Series.variable_name)
        self.canvas.draw()

    def OnScrollEvt(self, event):
      # Update the indices of the plot:
        self.i_start = self.i_min + event.GetPosition()
        self.i_end = self.i_min + self.i_window + event.GetPosition()
        self.draw_plot()   
    
    def SetColor( self, color):
        """Set figure and canvas colours to be the same."""        
        self.figure.set_facecolor( color )
        self.figure.set_edgecolor( color )
        self.canvas.SetBackgroundColour( color )

    def on_pick(self, event):
        # The event received here is of the type
        # matplotlib.backend_bases.PickEvent
        #
        # It carries lots of information, of which we're using
        # only a small amount here.
        # 
        print "point selected"
        plot_points = event.artist.get_points()
        print  plot_points
        msg = "You've clicked on a point with coords:\n %s" % plot_points
        
        dlg = wx.MessageDialog(
            self, 
            msg, 
            "ok",
            wx.OK | wx.ICON_INFORMATION)

        dlg.ShowModal() 
        dlg.Destroy()  

    def onclick(self, event):
        print 'button=%d, x=%d, y=%d, xdata=%f, ydata=%f'%(event.button, event.x, event.y, event.xdata, event.ydata)    
        
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