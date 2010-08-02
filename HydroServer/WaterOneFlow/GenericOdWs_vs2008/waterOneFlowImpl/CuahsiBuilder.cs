using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;
using System.Web;


namespace WaterOneFlowImpl
{
    using WaterOneFlow.Schema.v1;

    namespace v1_0{
    public sealed class CuahsiBuilder
    {
        /// <summary>
        /// Done to remove default constructor do not remove. FXCop rule CA1053
        /// </summary>
        private CuahsiBuilder()
        {

        }

        /// <summary>
        /// Creates a site response defaults to 1 site with 1 Location.
        /// </summary>
        /// <returns></returns>
        public static SiteInfoResponseType CreateASiteResponse()
        {
            return CreateASetOfSiteResponses(1, 1);
        }

        /// <summary>
        /// Creates a set of site responses.
        /// </summary>
        /// <param name="numberOfSites">The number of sites.</param>
        /// <param name="numberOfLocationsPerSite">The number of locations.</param>
        /// <returns></returns>
        public static SiteInfoResponseType CreateASetOfSiteResponses(int numberOfSites, int numberOfLocationsPerSite)
        {
            SiteInfoResponseType aSite = new SiteInfoResponseType();
            aSite.queryInfo = new QueryInfoType();
            aSite.queryInfo.criteria = new QueryInfoTypeCriteria();
            // can we set up as a list, and cast to array later?
            aSite.site = new site[numberOfSites];
            for (int count = 0; count < numberOfSites; count++)
            {
                aSite.site[count] = new site();

                aSite.site[count].siteInfo = CreateASiteInfoTypeWithLatLongPoint(numberOfLocationsPerSite);

            }
            return aSite;
        }

        public static SiteInfoType CreateASiteInfoTypeWithLatLongPoint()
        {
            return CreateASiteInfoTypeWithLatLongPoint(1);
        }

        public static SiteInfoType CreateASiteInfoTypeWithLatLongPoint(int numberOfLocationsPerSite)
        {
            SiteInfoType si = new SiteInfoType();
            si.geoLocation = new SiteInfoTypeGeoLocation();
            si.geoLocation.geogLocation = new LatLonPointType();
            si.siteCode = new SiteInfoTypeSiteCode[numberOfLocationsPerSite];
            for (int siteCodeCount = 0; siteCodeCount < numberOfLocationsPerSite; siteCodeCount++)
            {
                si.siteCode[siteCodeCount] = new SiteInfoTypeSiteCode();
            }
            return si;

        }

        /// <summary>
        /// Creates one variable.
        /// </summary>
        /// <returns></returns>
        public static VariablesResponseType CreateAVariable()
        {
            return CreateASetOfVariables(1);
        }

        /// <summary>
        /// Creates A set of variables.
        /// </summary>
        /// <param name="numberOFVariables">The number OF variables.</param>
        /// <returns></returns>
        public static VariablesResponseType CreateASetOfVariables(int numberOFVariables)
        {
            //VariablesTypeVariable Response = new VariablesTypeVariable();
            //Response.variable = new VariablesTypeVariable[numberOFVariables];
            VariablesResponseType Response = new VariablesResponseType();
            Response.variables = new VariableInfoType[numberOFVariables];

            // pre-populate the variableID for ease of use
            for (int count = 0; count < numberOFVariables; count++)
            {
                Response.variables[count] = CreateVariableDescriptionType();
                /*
                 Response.variables[count] = new VariableDescriptionType(); 
                VariableDescriptionTypeVariableID[] var = new VariableDescriptionTypeVariableID[1];
                var[0] = new VariableDescriptionTypeVariableID();
                Response.variables[count].variableCode = var;
                 */
            }

            return Response;
        }

        public static VariableInfoType CreateVariableInfoType(
            string oid,
            string vocab,
            string vCode,
            string vName,
            string vDescription,
            units aUnit)
        {

            VariableInfoType vdt = CreateVariableDescriptionType();
            vdt.variableCode[0].Value = vCode;
            vdt.variableCode[0].vocabulary = vocab;
            vdt.variableCode[0].variableID = oid;
            vdt.variableCode[0].defaultSpecified = true;
            vdt.variableCode[0].@default = true;
            vdt.variableDescription = vDescription;
            vdt.variableName = vName;
            vdt.units = aUnit;

            return vdt;
        }

        public static VariableInfoType CreateVariableDescriptionType()
        {
            VariableInfoType vdt = new VariableInfoType();
            variableCode[] var = new variableCode[1];
            var[0] = new variableCode();
            vdt.variableCode = var;
            vdt.units = new units();
            return vdt;
        }

        /// <summary>
        /// Creates the time series object.
        /// Use CreateTimeSeriesObjectSingleValue to get an object populated with values object 
        /// </summary>
        /// <returns></returns>
        public static TimeSeriesResponseType CreateTimeSeriesObject()
        {
            TimeSeriesResponseType result = new TimeSeriesResponseType();
            result.queryInfo = new QueryInfoType();
            result.queryInfo.criteria = new QueryInfoTypeCriteria();
            result.queryInfo.criteria.timeParam = new QueryInfoTypeCriteriaTimeParam();
            result.timeSeries = new TimeSeriesType();
            SiteInfoType site = new SiteInfoType();
            site.siteCode = new SiteInfoTypeSiteCode[1];
            SiteInfoTypeSiteCode siteId = new SiteInfoTypeSiteCode();
            site.siteCode[0] = siteId;
            result.timeSeries.sourceInfo = site;
            result.timeSeries.variable = CreateVariableDescriptionType();//new VariablesTypeVariable[1];
            //result.timeseries.variable[0] = new VariableDescriptionType(); // new VariablesTypeVariable();
            //result.timeseries.variable.variableCode = new VariableDescriptionTypeVariableID[1];//added to simplify population
            //result.timeseries.variable.variableCode[0] = new VariableDescriptionTypeVariableID(); 
            return result;
        }

        public static TimeSeriesResponseType CreateTimeSeriesObjectSingleValue()
        {
            TimeSeriesResponseType result = CreateTimeSeriesObject();
            result.timeSeries = TimeSeriesObjectSingleValue();
            return result;

        }

        // we will need to add some features.
        public static TimeSeriesType TimeSeriesObjectSingleValue()
        {
            TimeSeriesType tst = new TimeSeriesType();
            tst.values =  new TsValuesSingleVariableType();
            return tst;
        }

        public static seriesCatalogType CreateSeriesCatalog(
            int variableCount,
            string serviceName,
            string serviceUrl)
        {
            seriesCatalogType por = new seriesCatalogType();
            por.menuGroupName = serviceName;
            por.serviceWsdl = serviceUrl;
            por.series = new seriesCatalogTypeSeries[variableCount];
            for (int i = 0; i < variableCount; i++)
            {
                por.series[i] = new seriesCatalogTypeSeries();
                por.series[i].variable = CreateVariableDescriptionType();
                por.series[i].valueCount = new seriesCatalogTypeSeriesValueCount();
            }
            return por;
        }

        /* need method that says
         * createSeriesCatalogRecord(
           int variableID,
            Nullable<W3CDateTime> beginDateTime,
            Nullable<W3CDateTime> endDateTime,
            Nullable<int> valueCount
            )
         * */

        public static seriesCatalogTypeSeries CreateSeriesRecord(
           VariableInfoType variable,
            string sampleMedium,
            Nullable<W3CDateTime> beginDateTime,
            Nullable<W3CDateTime> endDateTime,
            Nullable<int> valueCount
            )
        {
            return CreateSeriesRecord(variable, sampleMedium, beginDateTime, endDateTime,
                                             valueCount, null, null, null, null, false, "P31D", null, null, null, null, null, null, null, null);
        }

        public static seriesCatalogTypeSeries CreateSeriesRecord(
     VariableInfoType variable,
     string sampleMedium,
     Nullable<W3CDateTime> beginDateTime,
     Nullable<W3CDateTime> endDateTime,
     Nullable<int> valueCount,
     Nullable<Boolean> valueCountIsEstimated,
     string dataType
    )
        {
            return CreateSeriesRecord(variable, sampleMedium, beginDateTime, endDateTime,
                                          valueCount, valueCountIsEstimated, null, null, null, false, "P31D", null, null, null, null, null, null, null, null);

        }

        public static seriesCatalogTypeSeries CreateSeriesRecord(VariableInfoType variable, string sampleMedium, W3CDateTime? beginDateTime, W3CDateTime? endDateTime, int? valueCount, bool? valueCountIsEstimated, string dataType, string valueType, string generalCategory, bool realTime, string realTimeInterval, string QualityControlLevelTerm, int? qualityControlLevelid, string methodName, int? methodID, string organization, string sourceDescription, int? sourceID, string citation)
        {
            /* don't forget to check the VariableInfoType for the 
             * dataType,ValueType and General Category
             * 
             */
            /*
             * logic
             * create seriesCatalogTypeSeries
             * if variable != null use it. if null, make an empty variable
             * if variable != null
             *    and sampleMedium,dataType,valueType or generalCategory is null
             *    try to get value from variable
             * add datTime interface logic
             * 
             */
            seriesCatalogTypeSeries series = new seriesCatalogTypeSeries();
            series.variable = variable != null ? variable : CreateVariableDescriptionType();
            if (valueCount.HasValue)
            {
                series.valueCount = new seriesCatalogTypeSeriesValueCount();
                series.valueCount.Value = valueCount.Value;
            }



            // if begin time and end time are the same use single

            if (beginDateTime.HasValue)
            {
                TimeIntervalType tm = new TimeIntervalType();

               // tm.beginDateTime = new DateTimeOffset(beginDateTime.Value.DateTime);
                tm.beginDateTime = beginDateTime.Value.DateTime;

                if (endDateTime.HasValue)
                {
                  //  tm.endDateTime = new DateTimeOffset(endDateTime.Value.DateTime);
                    tm.endDateTime = endDateTime.Value.DateTime;
                }
                else
                {
                    tm.endDateTime = tm.beginDateTime;
                }
                series.variableTimeInterval = tm;
            }


            if (realTime)
            {
                TimePeriodRealTimeType rt = new TimePeriodRealTimeType();
                rt.realTimeDataPeriod = realTimeInterval; // 31 day Period
                //rt.beginDateTime = new DateTimeOffset(DateTime.Today.AddDays(-31));
                //rt.endDateTime = new DateTimeOffset(DateTime.Today);
                rt.beginDateTime = DateTime.Today.AddDays(-31);
                rt.endDateTime = DateTime.Today;
                series.variableTimeInterval = rt;
            }

            /* TODO: fully populate
             * These need to use ID< and fully populat from database
             */
            if (qualityControlLevelid.HasValue || !String.IsNullOrEmpty(QualityControlLevelTerm))
            {
                series.QualityControlLevel = new QualityControlLevelType();
                // need to have a dataset with an enum so we can
                // SetEnumFromText(qsds,row,series.QualityControlLevel, typeof(QualityControlLevelEnum));
                if (qualityControlLevelid.HasValue)
                {
                    series.QualityControlLevel.qualityControlLevelID = qualityControlLevelid.Value;
                    series.QualityControlLevel.qualityControlLevelIDSpecified = true;
                }
                if (!String.IsNullOrEmpty(QualityControlLevelTerm))
                {
                    series.QualityControlLevel.Value = QualityControlLevelTerm;
                    
                  // originally defined as an enum, but enums cannot be empty, and we have an id
                    // QualityControlLevelTerm = QualityControlLevelTerm.Replace(" ", "");
                   // if (Enum.IsDefined(typeof(QualityControlLevelEnum), QualityControlLevelTerm))
                   // {
                   //     object aEnum = Enum.Parse(typeof(QualityControlLevelEnum), QualityControlLevelTerm);
                   //     series.QualityControlLevel.Value = (QualityControlLevelEnum)aEnum;
                   // }

                }
            }

            /* TODO: fully populate
             * These need to use ID< and fully populat from database
             */
            if (!String.IsNullOrEmpty(methodName) || methodID.HasValue)
            {
                MethodType method = new MethodType();
                if ( !String.IsNullOrEmpty(methodName)  )
                { method.MethodDescription = methodName; 
                }
                if (methodID.HasValue) {
                    method.methodID = methodID.Value;
                    method.methodIDSpecified = true;

                } 
                series.Method = method;
            }
            if (!String.IsNullOrEmpty(sourceDescription) ||
                !String.IsNullOrEmpty(organization) ||
                sourceID.HasValue)
            {
                SourceType source = new SourceType();
                if (!String.IsNullOrEmpty(sourceDescription) ||
                !String.IsNullOrEmpty(organization) )
                {
                    source.SourceDescription = sourceDescription; 
                source.Organization = organization;
                   
                }
                if (sourceID.HasValue)
                {
                    source.sourceID = sourceID.Value;
                    source.sourceIDSpecified = true;
                }
                series.Source = source;
            }

            return series;

        }

        public static units CreateUnitsElement(Nullable<UnitsTypeEnum> ut,
                                             String ucode,
                                             String unitAbbreivation,
                                             String unitName)
        {

            units u = new units();
            if (ut.HasValue)
            {
                u.unitsType = ut.Value;
                u.unitsTypeSpecified = true;
            } else
            {
                u.unitsTypeSpecified = false;
            }
            u.unitsCode = ucode;
            u.unitsAbbreviation = unitAbbreivation;
            u.Value = unitName;

            return u;


        }



        public static QueryInfoTypeCriteriaTimeParam createQueryInfoTimeCriteria(string start, string end)
        {
            QueryInfoTypeCriteriaTimeParam t = new QueryInfoTypeCriteriaTimeParam();

            if (!String.IsNullOrEmpty(start) || !String.IsNullOrEmpty(end))
            {
                if (!String.IsNullOrEmpty(start))
                {
                    t.beginDateTime = start;

                }
                if (!String.IsNullOrEmpty(end))
                {
                    t.endDateTime = end;

                }
            }
            else
            {
                t = null;
            }
            return t;
        }



        public static NoteType createNote(string value)
        {
            return createNoteElement(value, null, null, null);
        }

        public static NoteType createNote(string value, string title)
        {
            return createNoteElement(value, title, null, null);
        }

        public static NoteType createNote(string value, string title, string type)
        {

            return createNoteElement(value, title, type, null);
        }

        public static NoteType createNote(string value, string title, string type, string url)
        {
            return createNoteElement(value, title, type, url);
        }

        private static NoteType createNoteElement(string value, string title, string type, string url)
        {
            NoteType aNote = new NoteType();
            aNote.title = title;
            aNote.type = type;
            aNote.Value = value;
            aNote.href = url;
            return aNote;
        }

        public static NoteType[] addNote(NoteType[] notesField, NoteType aNote)
        {
            List<NoteType> notes;
            if (notesField == null)
            {
                notes = new List<NoteType>();
            }
            else
            {
                notes = new List<NoteType>(notesField);
            }
            notes.Add(aNote);
            return notes.ToArray();

        }

        /// <summary>
        /// This converts Strings into XML enumerations.
        /// Converting requires that the parent object of the enumerator be passed.
        /// For example, VariablesType has four  enumerations, valueType,generalCategory,sampleMedium, and dataType
        /// The class enumerations defined in the dataset do not have spaces
        /// so matching requires removing spaces.
        /// If there is not match, then no value is returned.
        /// </summary>
        /// <param name="xmlObjectWithEnum">object which is parent of enumeratot</param>
        /// <param name="datasetRow">row that has value</param>
        /// <param name="fieldToModify">name of field</param>
        /// <param name="enumType">enumerator type</param>
        public static void SetEnumFromText(object xmlObjectWithEnum, DataRow datasetRow, String fieldToModify, Type enumType)
        {
            Type vType = xmlObjectWithEnum.GetType();
            PropertyInfo setEnum = vType.GetProperty(fieldToModify);
            PropertyInfo setEnumSpecified = vType.GetProperty(fieldToModify + "Specified");
            String aValue = (String)datasetRow[fieldToModify];
            aValue = aValue.Replace(" ", "");
            if (Enum.IsDefined(enumType, aValue))
            {
                object aEnum = Enum.Parse(enumType, aValue);
                setEnum.SetValue(xmlObjectWithEnum, aEnum, null);
                setEnumSpecified.SetValue(xmlObjectWithEnum, true, null);
            }

        }

        private static string UrlFromContext(HttpContext Context, String AsmxPageName)
        {
            String serviceUrl;
            string Port = Context.Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;


            string Protocol = Context.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";


            // *** Figure out the base Url which points at the application's root

            serviceUrl = Protocol + Context.Request.ServerVariables["SERVER_NAME"] +

                                        Port +
                                        Context.Request.ApplicationPath
                                        + "/" + AsmxPageName;

            return serviceUrl;
        }

        /// <summary>
        /// Returns the URL of the 
        /// Requires application property "asmxPage"
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        private static string UrlFromContext(HttpContext Context)
        {
            return UrlFromContext(Context, ConfigurationManager.AppSettings["asmxPage"]);
        }

        //GetValuesName, ServiceMenuName
        /// <summary>
        /// 
        /// Requires application properties:
        /// asmxPage
        /// GetValuesName
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="SeriesCatalog"></param>
        public static void AddGetValuesWSDLLocation(HttpContext Context, seriesCatalogType SeriesCatalog)
        {
            AddGetValuesWSDLLocation(UrlFromContext(Context),
               ConfigurationManager.AppSettings["GetValuesName"],
               SeriesCatalog);
        }

        /// <summary>
        /// Populates the serviceWSDL, and menuGroupNames for the provided SeriesCatalog.
        /// </summary>
        /// <param name="WsdlBaseUrl">The base URL of the web service that has the GetValues service, without the page name</param>
        /// <param name="AsmxPage">The name of the page with the .asmx </param>
        /// <param name="ServiceMenuName">The menu name that may optionally be dsiplyed to clients</param>
        /// <param name="SeriesCatalog">A seriesCatalog</param> 
        public static void AddGetValuesWSDLLocation(String WsdlBaseUrl, String AsmxPage, String ServiceMenuName, seriesCatalogType SeriesCatalog)
        {
            AddGetValuesWSDLLocation(WsdlBaseUrl + AsmxPage, ServiceMenuName, SeriesCatalog);
        }
        /// <summary>
        /// Populates the serviceWSDL, and menuGroupNames for the provided SeriesCatalog.
        /// </summary>
        /// <param name="WsdlUrl">The base URL of the web service that has the GetValues service, without the page name</param>
        /// <param name="ServiceMenuName">The menu name that may optionally be dsiplyed to clients</param>
        /// <param name="SeriesCatalog">A seriesCatalog</param> 
        public static void AddGetValuesWSDLLocation(String WsdlUrl, String ServiceMenuName, seriesCatalogType SeriesCatalog)
        {
            SeriesCatalog.serviceWsdl = WsdlUrl;
            SeriesCatalog.menuGroupName = ServiceMenuName;
        }

    }   // end class

    /* 
     * Add Convieniece functions
     * (/)-addQueryCriteriaTimeInfo 
     * - setUnits(variableInfoType, int unitsID)
     * - setUnits(variableInfoType, string unitsCode)
     * -- non-static. these would access the database, and produce proper units
     *         non-static becasue we want to cache the dataset.
     * (/)-  static addNote(Object, string type,string noteValue)
     * -- read the object, see if it has a note field, 
     * ---- if note field is null, intialize it.
     * ---- if note field is not cull, add an aditional note 
     * - static addVariableCode(VaribaleInfoType, variableCode, variableName,.. setAsDefault)
     * -- if  variableCode is null, intialize it.
     * -- if  variableCode is not cull, add an aditional note
     * -- if set as default= true, see that other variableCodes are not set as default
     * - static addCuahsiVariableCode(aribaleInfoType, string vocabulary, string variableCode, setAsDefault)
     * -- do vocabulary translation, if match existss, then add it.
     * -- if set as default= true, see that other variableCodes are not set as default
     * - static createCuahsiVariableInfoType(object, string variableCode);
     *  -- create a variableInfoType given a cuahsi variableID
     * */

}// end namespace
}
