#Boa:FramePanel:Panel1

import wx

from wx.lib.pubsub import Publisher


import matplotlib
matplotlib.use('WXAgg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
from matplotlib.widgets import Lasso

class pnlPlot(wx.Panel):
    
        
    
    
    
    def _init_ctrls(self, prnt):
        #matplotlib.figure.Figure.__init__(self)
        wx.Panel.__init__(self, prnt, -1)
        
        
       


        self.fig = matplotlib.figure.Figure()
        self.timeSeries=self.fig.add_subplot(111)
        self.timeSeries.axis([0, 1, 0, 1])#
        self.timeSeries.plot([],[])
        self.timeSeries.set_title("No Data To Plot")
              
        self.canvas = FigCanvas(self, -1, self.fig)
        
        
        self.canvas.SetCursor(wx.StockCursor(wx.CURSOR_CROSS))
        
        # This way of adding to sizer allows resizing
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(self.canvas, 2, wx.LEFT|wx.TOP|wx.BOTTOM|wx.EXPAND, 0)
        self.SetAutoLayout(True)
        self.SetSizer(sizer)
        self.Fit()

        self.canvas.mpl_connect('pick_event', self.on_pick)
        self.canvas.mpl_connect('button_press_event', self.onclick)
        
        
        self.canvas.draw()
    
        
        self.BuildPopup()      

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
       
        self.timeSeries.clear()
        x = range(len(self.dataValues))
        self.timeSeries.set_xlabel("Date Time")
        self.timeSeries.set_ylabel(self.Series.variable_name+ "("+self.Series.variable_units_name+")")
        self.timeSeries.set_title(self.Series.site_name+" "+self.Series.variable_name)
       
        
        self.timeSeries=self.fig .add_subplot(111)
        self.timeSeries.axis([min(self.dateTimes), max(self.dateTimes), min(self.dataValues), max(self.dataValues)])#
        self.timeSeries.plot_date( self.dateTimes, self.dataValues, ':rs', xdate = True, tz = None )
        
        #self.timeSeries.legend(loc= 'upper right')
        self.canvas.draw()

       
        
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
        
    def clear(self):
        """ clear plot """
        self.axes.cla()
        self.conf.ntrace = 0
        self.conf.xlabel = ''
        self.conf.ylabel = ''
        self.conf.title  = ''


    ####
    ## GUI events
    ####
    def reportLeftDown(self, event=None, **kw):
        if event is None:
            return
        self.write_message("%f, %f" % (event.xdata, event.ydata), panel=1)

    def onLeftDown(self, event=None):
        """ left button down: report x,y coords, start zooming mode"""
        if event is None:
            return
        if event.inaxes not in self.fig.get_axes():
            return

        self.cursor_state = self.conf.cursor_mode # 'zoom'  # or 'lasso'!
        if event.inaxes is not None:
            self.reportLeftDown(event=event)
            if self.cursor_state == 'zoom':
                self.zoom_ini = (event.x, event.y, event.xdata, event.ydata)
            elif self.cursor_state == 'lasso':
                self.lasso = Lasso(event.inaxes, (event.xdata, event.ydata),
                                   self.lassoHandler)
                ## set lasso color
                cmap = getattr(self.conf, 'cmap', None)
                if cmap is not None:
                    rgb = (int(i*255)^255 for i in cmap._lut[0][:3])
                    col = '#%02x%02x%02x' % tuple(rgb)
                    self.lasso.line.set_color(col)
                else:
                    self.lasso.line.set_color('goldenrod')
            self.ForwardEvent(event=event.guiEvent)

    

    def lassoHandler(self, vertices):
        conf = self.conf
        fcols = conf.scatter_coll.get_facecolors()
        ecols = conf.scatter_coll.get_edgecolors()
        mask = points_inside_poly(conf.scatter_data, vertices)
        pts = nonzero(mask)[0]
        self.conf.scatter_mask = mask
        for i in range(len(conf.scatter_data)):
            if i in pts:
                ecols[i] = to_rgba(conf.scatter_selectedge)
                fcols[i] = to_rgba(conf.scatter_selectcolor)
                fcols[i][3] = 0.5
            else:
                fcols[i] = to_rgba(conf.scatter_normalcolor)
                ecols[i] = to_rgba(conf.scatter_normaledge)

        self.lasso = None
        self.canvas.draw_idle()
        if (self.lasso_callback is not None and
            hasattr(self.lasso_callback , '__call__')):
            self.lasso_callback(data = conf.scatter_coll.get_offsets(),
                                selected = pts, mask=mask)

    def zoom_OK(self, start, stop):
        return True

    def onLeftUp(self, event=None):
        """ left button up: zoom in or handle lasso"""
        if event is None:
            return
        if self.cursor_state == 'zoom':
            self._onLeftUp_Zoom(event)

        self.canvas.draw()
        self.cursor_state = None
        self.ForwardEvent(event=event.guiEvent)

    def _onLeftUp_Zoom(self, event=None):
        """ left up / zoom mode"""
        ini_x, ini_y, ini_xd, ini_yd = self.zoom_ini
        try:
            dx = abs(ini_x - event.x)
            dy = abs(ini_y - event.y)
        except:
            dx, dy = 0, 0
        t0 = time.time()
        self.rbbox = None
        if (dx > 3) and (dy > 3) and (t0-self.mouse_uptime)>0.1:
            self.mouse_uptime = t0
            zlims, tlims = {}, {}
            for ax in self.fig.get_axes():
                xmin, xmax = ax.get_xlim()
                ymin, ymax = ax.get_ylim()
                zlims[ax] = [xmin, xmax, ymin, ymax]
            if len(self.zoom_lims) == 0:
                self.zoom_lims.append(zlims)
            # for multiple axes, we first collect all the new limits, and
            # only then apply them
            for ax in self.fig.get_axes():
                ax_inv = ax.transData.inverted
                try:
                    x1, y1 = ax_inv().transform((event.x, event.y))
                except:
                    x1, y1 = event.xdata, event.ydata
                try:
                    x0, y0 = ax_inv().transform((ini_x, ini_y))
                except:
                    x0, y0 = ini_xd, ini_yd

                tlims[ax] = [min(x0, x1), max(x0, x1),
                             min(y0, y1), max(y0, y1)]
            self.zoom_lims.append(tlims)
            # now apply limits:
            self.set_viewlimits()

    def ForwardEvent(self, event=None):
        """finish wx event, forward it to other wx objects"""
        if event is not None:
            event.Skip()
            if os.name == 'posix' or  self.HasCapture():
                try:
                    self.ReleaseMouse()
                except:
                    pass

    def onRightDown(self, event=None):
        """ right button down: show pop-up"""
        if event is None:
            return
        # note that the matplotlib event location have to be converted
        if event.inaxes is not None and self.popup_menu is not None:
            pos = event.guiEvent.GetPosition()
            wx.CallAfter(self.PopupMenu, self.popup_menu, pos)
        self.ForwardEvent(event=event.guiEvent)

    def onRightUp(self, event=None):
        """ right button up: put back to cursor mode"""
        if event is not None:
            self.ForwardEvent(event=event.guiEvent)
    def unzoom_all(self, event=None):
        """ zoom out full data range """
        if len(self.zoom_lims) > 0:
            self.zoom_lims = [self.zoom_lims[0]]
        self.unzoom(event)

    def unzoom(self, event=None, set_bounds=True):
        """ zoom out 1 level, or to full data range """
        lims = None
        if len(self.zoom_lims) > 1:
            lims = self.zoom_lims.pop()
        ax = self.axes
        # print 'base unzoom ', lims, set_bounds
        if lims is None: # auto scale
            self.zoom_lims = [None]
            xmin, xmax, ymin, ymax = self.data_range
            ax.set_xlim((xmin, xmax), emit=True)
            ax.set_ylim((ymin, ymax), emit=True)
            if set_bounds:
                ax.update_datalim(((xmin, ymin), (xmax, ymax)))
                ax.set_xbound(ax.xaxis.get_major_locator(
                    ).view_limits(xmin, xmax))
                ax.set_ybound(ax.yaxis.get_major_locator(
                    ).view_limits(ymin, ymax))
        else:
            self.set_viewlimits()

        self.canvas.draw()
        
        
        
        
    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)