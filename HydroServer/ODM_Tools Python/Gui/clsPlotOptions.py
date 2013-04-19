import numpy
import math



class plotData (object):
  def __init__(self, sID, dValues, dTimes,  ylabel, title, color ):
    self.SeriesID= sID
    self.DataValues = dValues
    self.DateTimes=dTimes

    self.startDate= min(dTimes)
    self.endDate=max(dTimes)
    self.ylabel = ylabel
    self.title = title
    self.color = color

class axisData (object):
  def __init__(self, axisid, axis,  position, side="", rightadjust="", leftadjust="", minx="", maxx=""):
    self.axisid= axisid
    self.axis = axis
    self.rightadjust= rightadjust
    self.leftadjust = leftadjust
    self.position = position
    self.side = side
    self.minx= minx
    self.maxx= maxx

  def __repr__(self):
    return "<AxisData(id:'%s', axis:'%s', pos:'%s', side:'%s', radj:'%s', ladj:'%s')>" % (self.axisid, self.axis, self.position, self.side, self.rightadjust, self.leftadjust)

class PlotOptions(object):
    # def enum( **enums):
    #     return type('Enum', (), enums)

    # TimeSeriesType= enum('Both'=3, 'Line'=2, 'Point'=1, 'None'=0)
    # BoxWhiskerType = enum('Monthly'=0, 'Seasonal'= 2, 'Yearly'=3, 'Overall'=4)


    

    def __init__(self, TSMethod, color, showLegend, useCensoredData, isPlotCensored):
        self.colorList = ['blue', 'green', 'red', 'cyan', 'orange', 'magenta', 'yellow', 'teal', 'purple']
        
        self.timeSeriesMethod =TSMethod 
        self.isPlotCensored = isPlotCensored
        self.plotColor = self.colorList[color]
        self.showLegend = showLegend
        self.useCensoredData = useCensoredData

        self.numBins = 25
        self.binWidth=1.5
        self.xMax=0
        self.xMin=0
        self.yMax=0
        self.yMin=0
        self.xMajor=0
        # self.timeSeriesMethod ="Both"
        self.boxWhiskerMethod = "Monthly"
        
    
        self.displayFullDate=True
        self._startDateTime=None
        self._endDateTime=None
        self._startDateLimit =None
        self._endDateLimit=None


class OneSeriesPlotInfo(object):
    

    def __init__ (self, prnt):
        self.parent=prnt

        self.seriesID=None
        self.dataTable =None# link to sql database
        # self.cursor=None
        self.siteName=""
        self.variableName=""
        self.dataType=""
        self.variableUnits=""
        self.plotOptions=None
        self.BoxWhisker = None
        
        self.color = "Black"
        self.statistics= None

    def getPlotOptions(self):
        return self.plot_options

class SeriesPlotInfo(object):
    # self._siteDisplayColumn = ""
    
    

    def __init__(self, dbConn,  plotOptions):#siteDisplayColumn,
        # self._siteDisplayColumn = siteDisplayColumn
        self._plotOptions= plotOptions        
        self.dbConn= dbConn
        self._seriesInfos = {}

    def count(self):
        return len(self._seriesInfos)
        
    def Update(self, e, isselected):
        if not isselected :
            del self._seriesInfos[e]
        else:
        ## add dictionary entry with no data
            self._seriesInfos[e]=None

    # def Update(self):            
    #     for key, value in enumerate(self._seriesInfos):
    #         self._seriesInfos[key]=None

    def GetSeriesIDs(self):
        return self._seriesInfos.keys()        

    def GetSeriesInfo(self):

        lst = []#of length len(seriesInfos)

        for key in self.GetSeriesIDs():

            #if the current series is not already in the list
            # seriesinfo = _seriesInfos(key)
            # if seriesInfo is None: 
            if key in self._seriesInfos.keys():
                seriesInfo = OneSeriesPlotInfo(self)
                #add dictionary entry
                self._seriesInfos[key] = seriesInfo
               

                seriesID = key
                series =  self.dbConn.dbservice.get_series_by_id(seriesID)# get from db
                # variable =self.dbservice.get_variable_by_id(series.variable_id)
                
                strStartDate= series.begin_date_time#self._plotOptions._startDateTime 
                strEndDate = series.end_date_time#self._plotOptions._endDateTime#+1 day - 1 millisecond
                variableName = series.variable_name
                unitsName = series.variable_units_name
                siteName = series.site_name
                dataType = series.data_type
                noDataValue = self.dbConn.dbservice.get_no_data_value(series.variable_id)[0]#variable.no_data_value

                data = self.dbConn.getDataValuesforGraph(seriesID, repr(noDataValue), strStartDate.strftime('%y-%m-%d %H:%M:%S'), strEndDate.strftime('%y-%m-%d %H:%M:%S'))
                
                seriesInfo.seriesID = seriesID
                seriesInfo.dataTable = data
                seriesInfo.dataType = dataType
                seriesInfo.siteName =siteName
                seriesInfo.variableName = variableName
                seriesInfo.variableUnits = unitsName
                seriesInfo.statistics =  Statistics( data, self._plotOptions.useCensoredData)
                seriesInfo.BoxWhisker = BoxWhisker(data)
            else:
                seriesinfo = _seriesInfos[key]

            i = len(lst)
            seriesInfo.color = self._plotOptions.colorList[i % len(self._plotOptions.colorList)]
            lst.append(seriesInfo)
        return lst

class Statistics(object):

    def __init__(self, dataTable, useCensoredData):

        if useCensoredData:
            dataValues =[x[0] for x in dataTable ]
        else: 
            dataValues =[x[0] for x in dataTable if x[2] =='nc']           
        
       

        data=sorted(dataValues)

        count = self.NumberofObservations = len(data)

        
        self.NumberofCensoredObservations=  [x[2] for x in dataTable].count('nc') #self.cursor.fetchone()[0]
        
        self.ArithemticMean=round(numpy.mean(data),5)
        
        sumval = 0 
        sign = 1 
        for dv in data:
            if dv == 0:
                sumval = sumval+ numpy.log2(1)
            else:
                if dv < 0:
                    sign = sign * -1
                sumval = sumval+ numpy.log2(numpy.absolute(dv))    

        if count > 0:
            self.GeometricMean= round(sign * (2 ** float(sumval / float(count))),5)
            self.Maximum= round(max(data),5) 
            self.Minimum= round(min(data), 5)
            self.StandardDeviation= round(numpy.std(data),5) 
            self.CoefficientofVariation= round(numpy.var(data),5)


            ##Percentiles
            self.Percentile10=round(data[int(math.floor(count/10))],5)  
            self.Percentile25=round(data[int(math.floor(count/4))],5)

                 
            if count % 2 == 0 :
                self.Percentile50= round((data[int(math.floor((count/2)-1))]+ data[int(count/2)])/2,5)  
            else:
                self.Percentile50= round(data[int(numpy.ceil(count/2))],5)    

            self.Percentile75=round(data[int(math.floor(count/4*3))],5)       
            self.Percentile90= round(data[int(math.floor(count/10*9))],5)

class BoxWhisker(object):
    def __init__(self, dataTable):
        self.intervals = {}
        data = [x[0] for x in dataTable]
        self.intervals["Overall"] = BoxWhiskerPlotInfo(data, [''], self.calcConfInterval(data))
        


        years = sorted(list(set([x[4] for x in dataTable] )))      
        data = []
        for y in years:
          data.append([x[0] for x in dataTable if x[4]==y])
        self.intervals["Yearly"] = BoxWhiskerPlotInfo(data, years, self.calcConfInterval(data))


        data = [[x[0] for x in dataTable if x[3] in (1,2,3)], 
                [x[0] for x in dataTable if x[3]in (4,5,6)], 
                [x[0] for x in dataTable if x[3]in (6,7,8)],
                [x[0] for x in dataTable if x[3]in (10,11,12)]]
        self.intervals["Seasonally"] = BoxWhiskerPlotInfo(data, ['Winter', 'Spring', 'Summer', 'Fall'], self.calcConfInterval(data))


        data =[ [x[0] for x in dataTable if x[3]==1], 
                [x[0] for x in dataTable if x[3]==2], 
                [x[0] for x in dataTable if x[3]==3],
                [x[0] for x in dataTable if x[3]==4], 
                [x[0] for x in dataTable if x[3]==5], 
                [x[0] for x in dataTable if x[3]==6], 
                [x[0] for x in dataTable if x[3]==7], 
                [x[0] for x in dataTable if x[3]==8], 
                [x[0] for x in dataTable if x[3]==9], 
                [x[0] for x in dataTable if x[3]==10], 
                [x[0] for x in dataTable if x[3]==11], 
                [x[0] for x in dataTable if x[3]==12]]
      
        self.intervals["Monthly"] = BoxWhiskerPlotInfo(data,['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'], self.calcConfInterval(data))



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
        med = numpy.median(data)
        mean = numpy.mean(data)
        stdDev = math.sqrt(numpy.var(data))
        ci95low = mean - 10*(1.96 *(stdDev/math.sqrt(len(data))))
        ci95up = mean + 10*(1.96 *(stdDev/math.sqrt(len(data))))

        cl95low = med - (1.96 *(stdDev/math.sqrt(len(data))))
        cl95up = med + (1.96 *(stdDev/math.sqrt(len(data))))
      
        return [med, mean, ci95low, ci95up, cl95low, cl95up]
      else: return [ None, None, None, None, None, None]

class  BoxWhiskerPlotInfo(object):
    def __init__( self, data, xLabels, dets):
        self.data = data
        self.xlabels= xLabels

        self.medians = dets[0]
        self.confint= dets[1]
        self.conflimit = dets[2]
        self.means = dets[3]

        
        
        
        
        
        
        
        
        
        

  

        





