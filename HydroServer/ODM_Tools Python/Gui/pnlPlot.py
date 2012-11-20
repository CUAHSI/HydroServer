#Boa:FramePanel:Panel1

import wx
from wxmplot import PlotApp

from wx.lib.pubsub import Publisher



import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas

[wxID_PANEL1] = [wx.NewId() for _init_ctrls in range(1)]

class pnlPlot(wx.Panel):
    
    def _init_sizers(self):
        # generated method, don't edit
        self.s = wx.BoxSizer(wx.VERTICAL)        
        
        self._init_s_Items(self.s)        
        
        self.SetSizer(self.s)
    
    def _init_s_Items(self, parent):
        # generated method, don't edit        
        
        parent.AddWindow(self.figTS, 0, flag=wx.ALL | wx.EXPAND)
    
    
    
    
    def _init_ctrls(self, prnt):
        #matplotlib.figure.Figure.__init__(self)
        wx.Panel.__init__(self, style=wx.TAB_TRAVERSAL, name='', parent=prnt, pos=wx.DefaultPosition, id=wxID_PANEL1, size=wx.Size(200, 100))
        
##        self.plot = PlotApp()
##        xx  = [datetime.date(2012,01,01).toordinal(),datetime.date(2012,01,02).toordinal(),datetime.date(2012,01,03).toordinal(),datetime.date(2012,01,04).toordinal()] 
##        y1  = [2.0,2.5, 1.5,2.75]
##        self.plot.plot(xx, y1, color='blue',  style='solid',
##            title='SiteName-VariableName',  label='SiteName-VariableName',
##            ylabel='Variable',
##            xlabel='Date Time' )      
##        self.plot.run()
      
##        self.figBox = matplotlib.figure.Figure()
##        self.axis=self.figBox.add_subplot(111)
##        #self.axis.axis([0, 1, 0, 1])#
##        self.axis.plot([],[]) 

       


        self.figTS = matplotlib.figure.Figure()
        self.timeSeries=self.figTS.add_subplot(111)
        self.timeSeries.axis([0, 1, 0, 1])#
        self.timeSeries.plot([],[]) 
              
        self.canvasTS = FigCanvas(self, figsize = self.size, -1, self.figTS)
        #self.axes.legend(loc= 'upper right')
        self.canvasTS.draw()

        self.canvasTS.mpl_connect('pick_event', self.on_pick)
             

        #self._init_sizers()

    
    def addPlot(self, Values):
     
        self.dataValues = []
        self.dateTimes= []
        self.Series = Values.data[1]
        for dv in Values.data[0]:
            self.dataValues.append(dv.data_value)
            self.dateTimes.append(dv.local_date_time)

        self.addtimeSeriesPlot()


    def addtimeSeriesPlot(self):

##        self.plot.oplot(self.dateTimes, self.dataValues,  style='solid', 
##            title=self.Series.site_name+'-'+self.Series.variable_name,  
##            ylabel=self.Series.variable_name+"("+self.Series.variable_units_name+")",
##            xlabel='Date Time', 
##            label =self.Series.site_name+'-'+self.Series.variable_name)
##        self.plot.run()

        # self.axis.clear()
        self.timeSeries.clear()
        x = range(len(self.dataValues))
        # self.axis.xlabel("Date Time")
        # self.axis.ylabel("Variable")
        self.canvasTS.mpl_connect('pick_event', self.on_pick)
        self.canvasTS.mpl_connect('button_press_event', self.onclick)
        
        self.timeSeries=self.figTS.add_subplot(111)
        self.timeSeries.axis([min(self.dateTimes), max(self.dateTimes), 0, max(self.dataValues)])#
        self.timeSeries.plot( self.dateTimes, self.dataValues, ':rs')
        #self.timeSeries.legend(loc= 'upper right')
        self.canvasTS.draw()




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
        
        
    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)