
import sqlite3

class memoryDatabase(object):


    def __init__(self, dbservice):
        self.dbservice = dbservice        
        self.conn = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
        self.cursor = self.conn.cursor()
        self.editLoaded= False
        self.initDB()
        self.initSC()

    ###########
    #getters
    ###########
    def getCursor(self):
        return self.cursor

    def getConnection(self):
        return self.conn


     ############
     #DB Queries
     ###########   
    def deletePoints(self, filter):
        pass
    def addPoints(self, filter):
        pass
    def updatePoints(self, filter, values):
        pass


    def getDataValuesforEdit(self):  
        # query = "SELECT ValueID, SeriesID, DataValue, ValueAccuracy, LocalDateTime, UTCOffset, DateTimeUTC, QualifierCode, OffsetValue, OffsetTypeID, CensorCode, SampleID FROM DataValuesEdit AS d LEFT JOIN Qualifiers AS q ON (d.QualifierID = q.QualifierID) "
        query = "SELECT * from DataValuesEdit"                      
        self.cursor.execute(query)
        return [list(x) for x in  self.cursor.fetchall()]

    def getEditDataValuesforGraph(self):   
        query ="SELECT DataValue, LocalDateTime, CensorCode, strftime('%m', LocalDateTime) as DateMonth, strftime('%Y', LocalDateTime) as DateYear FROM DataValuesEdit ORDER BY LocalDateTime"
        self.cursor.execute(query)
        return [list(x) for x in  self.cursor.fetchall()]# return a list of lists orig returns a list of cursors
    
    def getEditRowCount(self):
        query ="SELECT COUNT(ValueID) FROM DataValuesEdit "
        self.cursor.execute(query)
        return self.cursor.fetchone()[0]


    def getEditColumns(self):
        sql = "SELECT * FROM DataValuesEdit WHERE 1=0"
        # sql= "SELECT ValueID, SeriesID, DataValue, ValueAccuracy, LocalDateTime, UTCOffset, DateTimeUTC, QualifierCode, OffsetValue, OffsetTypeID, CensorCode, SampleID FROM DataValuesEdit AS d LEFT JOIN Qualifiers AS q ON (d.QualifierID = q.QualifierID) WHERE 1=0"
        self.cursor.execute(sql)  
        return [(x[0],i) for (i,x) in enumerate(self.cursor.description)]

    def getDataValuesforGraph(self, seriesID, strNoDataValue, strStartDate, strEndDate):

        DataValues = self.dbservice.get_data_values_by_series_id(seriesID)  

        #clear any previous queries from table
        self.cursor.execute("DELETE FROM DataValues")

        #fill temporary table with values from requested series
        self.cursor.executemany("INSERT INTO DataValues VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", DataValues)
        self.conn.commit()

        #select values for plotting
        query ="SELECT DataValue, LocalDateTime, CensorCode, strftime('%m', LocalDateTime) as DateMonth, strftime('%Y', LocalDateTime) as DateYear FROM DataValues WHERE (DataValue <> "+ strNoDataValue + ") ORDER BY LocalDateTime"
        self.cursor.execute(query)

        return [list(x) for x in  self.cursor.fetchall()]# return a list of lists orig returns a list of cursors

    def getSeriesCatalog(self):
        sql = "SELECT * FROM SeriesCatalog"
        self.cursor.execute(sql)    
        return [list(x) for x in self.cursor.fetchall()]


    def getSeriesColumns(self):
        sql = "SELECT * FROM SeriesCatalog WHERE 1=0"
        self.cursor.execute(sql)  
        return (x[0] for (i,x) in enumerate(self.cursor.description))



    def resetDB(self, dbservice):
        self.dbservice = dbservice

        self.conn = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
        self.cursor = self.conn.cursor()
        self.initDB()

        self.DataValuesEdit= None
        self.SeriesCatalog = None

    def commit():
        self.conn.commit()

    def rollback():
        self.conn.rollback()

    def stopEdit(self):       
        self.DataValuesEdit= None
        self.editLoaded= False
        self.cursor.execute("DROP TABLE DataValuesEdit")
        self.conn.commit()
        self.createEditTable()


    def initEditValues(self, seriesID):
        if not self.editLoaded:
            self.DataValuesEdit = self.dbservice.get_data_values_by_series_id(seriesID)         
            self.cursor.executemany("INSERT INTO DataValuesEdit VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.DataValuesEdit)
            self.conn.commit()
            self.editLoaded = True



    def initSC(self):
        self.SeriesCatalog =self.dbservice.get_series_test()
        self.cursor.executemany("INSERT INTO SeriesCatalog VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", self.SeriesCatalog)
        self.cursor.execute("ALTER TABLE SeriesCatalog ADD COLUMN isSelected INTEGER ")
        
        self.cursor.execute("UPDATE SeriesCatalog SET isSelected=0")
        self.conn.commit()

    def initDB(self):
        self.cursor.execute("""CREATE TABLE SeriesCatalog
                (SeriesID INTEGER NOT NULL,
                SiteID INTEGER,
                SiteCode VARCHAR(50),
                SiteName VARCHAR(255),
                VariableID INTEGER, 
                VariableCode VARCHAR(50), 
                VariableName VARCHAR(255),
                Speciation VARCHAR(255),
                VariableUnitsID INTEGER,
                VariableUnitsName VARCHAR(255),
                SampleMedium VARCHAR(255),
                ValueType VARCHAR(255),
                TimeSupport FLOAT, 
                TimeUnitsID INTEGER, 
                TimeUnitsName VARCHAR(255),
                DataType VARCHAR(255), 
                GeneralCategory VARCHAR(255), 
                MethodID INTEGER, 
                MethodDescriptions VARCHAR(255),
                SourceID INTEGER, 
                Organization VARCHAR(255),
                SourceDescription VARCHAR(255),
                Citation VARCHAR(255), 
                QualityControlLevelID INTEGER, 
                QualityControlLevelCode VARCHAR(50),
                BeginDateTime TIMESTAMP, 
                EndDateTime TIMESTAMP, 
                BeginDateTimeUTC TIMESTAMP, 
                EndDateTimeUTC TIMESTAMP, 
                ValueCount INTEGER,

                PRIMARY KEY (SeriesID))
                
               """)



        self.cursor.execute("""CREATE TABLE DataValues
                (ValueID INTEGER NOT NULL,
                DataValue FLOAT NOT NULL,
                ValueAccuracy FLOAT,
                LocalDateTime TIMESTAMP NOT NULL,
                UTCOffset FLOAT NOT NULL,
                DateTimeUTC TIMESTAMP NOT NULL,
                SiteID INTEGER NOT NULL,
                VariableID INTEGER NOT NULL,
                OffsetValue FLOAT,
                OffsetTypeID INTEGER,
                CensorCode VARCHAR(50) NOT NULL,
                QualifierID INTEGER,
                MethodID INTEGER NOT NULL,
                SourceID INTEGER NOT NULL,
                SampleID INTEGER,
                DerivedFromID INTEGER,
                QualityControlLevelID INTEGER NOT NULL,

                PRIMARY KEY (ValueID),
                UNIQUE (DataValue, LocalDateTime, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID))
               """)


        self.createEditTable()

    def createEditTable(self):
        self.cursor.execute("""CREATE TABLE DataValuesEdit
                (ValueID INTEGER NOT NULL,
                DataValue FLOAT NOT NULL,
                ValueAccuracy FLOAT,
                LocalDateTime TIMESTAMP NOT NULL,
                UTCOffset FLOAT NOT NULL,
                DateTimeUTC TIMESTAMP NOT NULL,
                SiteID INTEGER NOT NULL,
                VariableID INTEGER NOT NULL,
                OffsetValue FLOAT,
                OffsetTypeID INTEGER,
                CensorCode VARCHAR(50) NOT NULL,
                QualifierID INTEGER,
                MethodID INTEGER NOT NULL,
                SourceID INTEGER NOT NULL,
                SampleID INTEGER,
                DerivedFromID INTEGER,
                QualityControlLevelID INTEGER NOT NULL,

                PRIMARY KEY (ValueID),
                UNIQUE (DataValue, LocalDateTime, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID))
               """)