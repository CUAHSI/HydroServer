#Boa:FramePanel:Panel1

import wx
from wx.lib.pubsub import Publisher

try:
    from agw import flatnotebook as fnb
except ImportError: # if it's not there locally, try the wxPython lib.
    import wx.lib.agw.flatnotebook as fnb


import plotTimeSeries
import plotSummary
import plotHistogram
import plotBoxWhisker
import plotProbability

[wxID_PANEL1, wxID_PAGEBOX, wxID_PAGEHIST, wxID_PAGEPROB, 
wxID_PAGESUMMARY, wxID_PAGETIMESERIES, wxID_TABPLOTS
] = [wx.NewId() for _init_ctrls in range(7)]


class pnlPlot(fnb.FlatNotebook):  
    
    
    
    def _init_ctrls(self, prnt):
        fnb.FlatNotebook.__init__(self, id=wxID_TABPLOTS, name=u'tabPlots',
              parent=prnt, pos=wx.Point(0, 0), size=wx.Size(491, 288),
              agwStyle=fnb.FNB_NODRAG | fnb.FNB_HIDE_TABS)
        # style |= fnb.FNB_HIDE_TABS
        # self.book.SetAGWWindowStyleFlag(style)
        
        self.pltTS = plotTimeSeries.plotTimeSeries(id=wxID_PAGETIMESERIES, name='pltTS',
                parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
                style=wx.TAB_TRAVERSAL) 
        self.AddPage(self.pltTS, 'TimeSeries')
        
        self.pltProb = plotProbability.plotProb(id=wxID_PAGEPROB, name='pltProb',
                parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
                style=wx.TAB_TRAVERSAL) 
        self.AddPage(self.pltProb, 'Probablity')        
        
        self.pltHist = plotHistogram.plotHist(id=wxID_PAGEHIST, name='pltHist',
                parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
                style=wx.TAB_TRAVERSAL) 
        self.AddPage(self.pltHist, 'Histogram')

        self.pltBox = plotBoxWhisker.plotBox(id=wxID_PAGEBOX, name='pltBox',
                parent=self, pos=wx.Point(0, 0), size=wx.Size(605, 458),
                style=wx.TAB_TRAVERSAL) 
        self.AddPage(self.pltBox, 'Box/Whisker')
        
        
        self.pltSum = plotSummary.plotSummary( id = wxID_PAGESUMMARY, name=u'pltSum',
              parent=self, pos=wx.Point(784, 256), size=wx.Size(437, 477),
              style=wx.TAB_TRAVERSAL)
        self.AddPage(self.pltSum, 'Summary')



        Publisher().subscribe(self.onDateChanged, ("onDateChanged"))
        Publisher().subscribe(self.OnPlotType, ("onPlotType"))
        Publisher().subscribe(self.OnShowLegend, ("OnShowLegend"))
        Publisher().subscribe(self.OnNumBins, ("OnNumBins"))
        Publisher().subscribe(self.OnRemovePlot, ("removePlot"))
        Publisher().subscribe(self.OnChangeSelection, ("changePlotSelection"))
        
    def OnChangeSelection(self, sellist):
      self.pltTS.changeSelection(sellist.data)

    def OnRemovePlot(self, seriesID): 
      self.pltTS.removePlot(seriesID)

    def OnNumBins(self , numBins):
      self.pltHist.ChangeNumOfBins(numBins.data)

    def onDateChanged(self, Args): 
      self.pltTS.onDateChanged(Args.data[0], Args.data[1])
    
    def OnPlotType(self, Args):     
      self.pltTS.OnPlotType( Args.data[1])
      self.pltProb.OnPlotType( Args.data[1])


    def OnShowLegend(self, Args):
      event, isVisible = Args.data[0], Args.data[1]
      self.pltTS.OnShowLegend(isVisible)
      
    def addEditPlot(self, Values):
        Filter = " WHERE CensorCode = 'nc'"
        self.pltTS.editSeries(Values, Filter)
    
    def addPlot(self, Values):
    
        self.cursor = Values[0]

       #  sql = "SELECT  DataValue, LocalDateTime FROM DataValues"
       #  self.cursor.execute(sql)
       #  self.values = [list(x) for x in self.cursor.fetchall()]

       
       #  self.dataValues = []
       #  self.dateTimes= []
       #  #self.Series = Values[1]
       #  for dv in self.values: 
       #     self.dataValues.append(dv[0])
       #     self.dateTimes.append(dv[1])
       # # print self.dateTimes   

       #  self.pltSum.addPlot(self.dataValues,  Values[1])
        
       #  self.pltHist.addPlot(self.dataValues, self.dateTimes, Values[1])
       #  self.pltProb.addPlot(self.dataValues, self.dateTimes, Values[1])
       #  self.pltBox.addPlot(self.dataValues, self.dateTimes, Values[1])
       #  self.pltTS.addPlot(self.dataValues, self.dateTimes, Values[1])

        Filter = " WHERE DataValue <> -9999 AND CensorCode = 'nc'"
        self.pltSum.addPlot(Values, Filter)
        self.pltHist.addPlot(Values, Filter)
        self.pltProb.addPlot(Values, Filter)
        self.pltBox.addPlot(Values, Filter)
        self.pltTS.addPlot(Values, Filter)
        


    def selectPlot(self, value):       
        self.SetSelection(value.data)

    def getActivePlotID(self):
        return self.GetSelection()
       
        
    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)
   