using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_1;

using VariableParam = WaterOneFlowImpl.VariableParam;

/// <summary>
/// Summary description for GetValuesOD
/// </summary>
namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    using CuahsiBuilder = WaterOneFlowImpl.v1_1.CuahsiBuilder;

    namespace v1_1
    {
        public class GetValuesOD
        {
            /* concept 
             * this will be it's own class
             * it will load one static/shared table for: 
             * - ODvariables
             * - ODUnits
             * 
             *  Then for each request, it will retrive 
             * - ODSiteInfo
             * - OCValues
             * 
             * It will then output the timeseries
             * */

            static VariablesDataset variableDs;
            static unitsDataset unitsDs;
            static ConnectionStringSettings oDconnectionString;

            siteInfoDataSet siteInfoDs;

            public GetValuesOD()
            {
                //
                // TODO: Add constructor logic here
                //
                variableDs = ODvariables.GetVariableDataSet();
                unitsDs = ODUnits.getUnitsDataset();
                oDconnectionString = ConfigurationManager.ConnectionStrings["ODDB"];

            }


            public IEnumerable<TimeSeriesType> GetTimesSeriesTypeForSiteVariable(string SiteNumber, string StartDate, string EndDate)
            {

                W3CDateTime? BeginDateTime;
                W3CDateTime? EndDateTime;
                int? variableId = null;
                int? siteID;

                VariableInfoType varInfoType = null;
                SiteInfoType siteType = null;

                BeginDateTime = GetBeginDateTime(StartDate);

                EndDateTime = GetEndDateTime(EndDate);

                locationParam sq = GetLocationParameter(SiteNumber);

                siteInfoDataSet sitDs = ODSiteInfo.GetSiteInfoDataSet(sq);
                if (sitDs != null && sitDs.sites.Count > 0)
                {
                    siteID = sitDs.sites[0].SiteID;
                    ValuesDataSet valuesDs = getValuesDataset(siteID, null, BeginDateTime, EndDateTime);
                    DataTable variableTable = DataSetHelper.SelectDistinct("variableIds", valuesDs.DataValues, "VariableID");

                    if (variableTable.Rows.Count == 0)
                    {
                        throw new WaterOneFlowException("No Data Available for Time Period.");
                    }

                    foreach (DataRow dataRow in variableTable.Rows)
                    {
                        TimeSeriesType timeSeries = new TimeSeriesType();

                        timeSeries.sourceInfo = ODSiteInfo.row2SiteInfoElement(sitDs.sites[0], sitDs);

                        int id = (int)dataRow[0];
                        VariableInfoType vit = ODvariables.GetVariableByID(id, variableDs);
                        timeSeries.variable = vit;


                        // DataView view = new DataView(valuesDs.DataValues, "VariableId = " + id, " DateTime ASC", DataViewRowState.CurrentRows);

                        timeSeries.values = getValues(valuesDs, null, id);

                        yield return timeSeries;
                    }

                }
            }

            public TimeSeriesResponseType GetValuesForSiteVariable(string SiteNumber, string StartDate, string EndDate)
            {
                TimeSeriesResponseType response = new TimeSeriesResponseType();
                response.timeSeries = new List<TimeSeriesType>(
                    GetTimesSeriesTypeForSiteVariable(SiteNumber, StartDate, EndDate)).ToArray();


                response.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetValuesForASite", new string[] {SiteNumber},
                                                                       null, null, StartDate, EndDate);
                CuahsiBuilder.addNote(response.queryInfo.note,
                                      CuahsiBuilder.createNote("AllValuesForASite")); 
                
                return response;
            }

            public TimeSeriesResponseType getValues(string SiteNumber, string Variable, string StartDate, string EndDate)
            {
                // convert dates
                // get site info
                // get site ID
                // return value dataset

                TimeSeriesResponseType response;
                W3CDateTime? BeginDateTime;
                W3CDateTime? EndDateTime;
                int? variableId = null;
                int? siteID;

                VariableInfoType varInfoType = null;
                SiteInfoType siteType = null;

                BeginDateTime = GetBeginDateTime(StartDate);

                EndDateTime = GetEndDateTime(EndDate);

                VariableParam vp = GetVariableParameter(Variable, ref variableId, ref varInfoType);
                locationParam sq = GetLocationParameter(SiteNumber);

                siteInfoDataSet sitDs = ODSiteInfo.GetSiteInfoDataSet(sq);
                response = CuahsiBuilder.CreateTimeSeriesObjectSingleValue(1);

                if (sitDs != null && sitDs.sites.Count > 0)
                {
                    siteID = sitDs.sites[0].SiteID;
                    ValuesDataSet valuesDs = getValuesDataset(siteID, variableId, BeginDateTime, EndDateTime);

                    response.timeSeries[0].values = getValues(valuesDs, vp, variableId);

                    // above is the values, add the site, and variables
                    response.timeSeries[0].variable = varInfoType;

                    response.timeSeries[0].sourceInfo = ODSiteInfo.row2SiteInfoElement(sitDs.sites[0], sitDs);

                }

               // AddQueryInfo(StartDate, EndDate, Variable, SiteNumber, response);

              response.queryInfo =  CuahsiBuilder.CreateQueryInfoType("GetValues",
                    new string[] {SiteNumber} , null, new string[] {Variable}, StartDate, EndDate); 
 
                return response;
            }

            private static void AddQueryInfo(string StartDate, string EndDate, string Variable, string SiteNumber, TimeSeriesResponseType response)
            {

                response.queryInfo = new QueryInfoType();
                response.queryInfo.criteria = new QueryInfoTypeCriteria();

                response.queryInfo.creationTime = DateTime.UtcNow;
                response.queryInfo.creationTimeSpecified = true;
                response.queryInfo.criteria.locationParam = SiteNumber;
                response.queryInfo.criteria.variableParam = Variable;
                response.queryInfo.criteria.timeParam = CuahsiBuilder.createQueryInfoTimeCriteria(StartDate, EndDate);
                NoteType sourceNote = CuahsiBuilder.createNote("OD Web Service");
                response.queryInfo.note = CuahsiBuilder.addNote(response.queryInfo.note,
                                                                sourceNote);
            }

            private static locationParam GetLocationParameter(string SiteNumber)
            {
                locationParam sq;
                sq = new locationParam(SiteNumber);

                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + SiteNumber);
                }
                return sq;
            }

            private VariableParam GetVariableParameter(string Variable, ref int? variableId, ref VariableInfoType varInfoType)
            {
                VariableParam vp = null;
                if (Variable != null)
                {

                    vp = new VariableParam(Variable);
                    VariableInfoType[] v = ODvariables.getVariable(vp, variableDs);
                    if (v != null && v.Length > 0)
                    {
                        variableId = Convert.ToInt16(v[0].variableCode[0].variableID);
                        varInfoType = v[0];
                    }
                    else
                    {
                        throw new WaterOneFlowException("Variable parameter not found: " + Variable);

                    }
                }
                return vp;
            }

            private static W3CDateTime? GetEndDateTime(string EndDate)
            {
                W3CDateTime? EndDateTime;
                if (!String.IsNullOrEmpty(EndDate))
                {
                    try
                    {
                        EndDateTime = W3CDateTime.Parse(EndDate);
                    }
                    catch
                    {
                        throw new WaterOneFlowException("Improper EndDate '" +
                                                        EndDate + "' Must be YYYY-MM-DD");
                    }

                }
                else
                {
                    EndDateTime = null;
                }
                return EndDateTime;
            }

            private W3CDateTime? GetBeginDateTime(string StartDate)
            {
                W3CDateTime? BeginDateTime;
                if (!String.IsNullOrEmpty(StartDate))
                {
                    try
                    {
                        BeginDateTime = W3CDateTime.Parse(StartDate);
                    }
                    catch
                    {
                        throw new WaterOneFlowException("Improper BeginDate '" +
                                                        StartDate + "' Must be YYYY-MM-DD");
                    }
                }
                else
                {
                    BeginDateTime = null;
                }
                return BeginDateTime;
            }

            public static TsValuesSingleVariableType[] getValues(ValuesDataSet ValuesDs, VariableParam variableParam, int? variableId)
            {
                // TimeSeriesResponseType response = CuahsiBuilder.CreateTimeSeriesObjectSingleValue(1);

                TsValuesSingleVariableType[] valuesList = new TsValuesSingleVariableType[1];

                TsValuesSingleVariableType values = new TsValuesSingleVariableType();

                valuesList[0] = values;

                // get siteInfo
                // get variable Info
                // get Values

                string valuesWhereClause = OdValuesCommon.CreateValuesWhereClause(variableParam, variableId);

                // reformats values dataset into a TimeSeriesResponseType
                IEnumerable<ValueSingleVariable> valueE = ODValues.dataset2ValuesList(ValuesDs, variableParam, variableId, variableDs);

                
                // do this by keeping a list of ID's then generating in after the values list is done
                values.value = new List<ValueSingleVariable>(valueE).ToArray();
                //values.count = values.value.Length;

                if (values.value.Length > 0)
                {
                    // add qualifiers
                    List<QualifierType> qualifers = ODValues.datasetQualifiers(ValuesDs, valuesWhereClause);
                    if (qualifers != null && qualifers.Count > 0)
                    {
                        values.qualifier = qualifers.ToArray();
                    }
                    // add methods
                    List<MethodType> methods = ODValues.datasetMethods(ValuesDs, valuesWhereClause);
                    if (methods != null && methods.Count > 0)
                    {
                        values.method = methods.ToArray();
                    }
                    List<SourceType> sources = ODValues.datasetSources(ValuesDs, valuesWhereClause);
                    if (sources != null && sources.Count > 0)
                    {
                        values.source = sources.ToArray();
                    }
                    List<OffsetType> offsets = ODValues.datasetOffsetTypes(ValuesDs, valuesWhereClause);
                    if (offsets != null && offsets.Count > 0)
                    {
                        values.offset = offsets.ToArray();
                    }

                    List<QualityControlLevelType> qcLevels = ODValues.DatasetQCLevels(ValuesDs, valuesWhereClause);
                    if (qcLevels != null && qcLevels.Count > 0)
                    {
                        values.qualityControlLevel = qcLevels.ToArray();
                    }
                    List<SampleType> samples = ODValues.datasetSamples(ValuesDs, valuesWhereClause);
                    if (samples != null && samples.Count > 0)
                    {
                        values.sample = samples.ToArray();
                    }

                    IEnumerable<CensorCodeType> codeTypes = ODValues.datasetCensorCodes(ValuesDs, valuesWhereClause);
                    values.censorCode = new List<CensorCodeType>(codeTypes).ToArray();
                }

                return valuesList;
            }

            public ValuesDataSet getValuesDataset(int? siteId, int? variableId, W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            {
                ValuesDataSet valuesDs;
                if (!variableId.HasValue && !BeginDateTime.HasValue && !EndDateTime.HasValue)
                {
                    valuesDs = ODValues.GetValuesDataSet(siteId.Value);
                }
                else if (!variableId.HasValue && BeginDateTime.HasValue && EndDateTime.HasValue)
                {
                    valuesDs = ODValues.GetValuesDataSet(siteId.Value, BeginDateTime.Value, EndDateTime.Value);
                }
                else if (variableId.HasValue && !BeginDateTime.HasValue && !EndDateTime.HasValue)
                {
                    valuesDs = ODValues.GetValuesDataSet(siteId, variableId);
                }
                else if (variableId.HasValue && BeginDateTime.HasValue && !EndDateTime.HasValue)
                {
                    EndDateTime = W3CDateTime.Now;
                    valuesDs = ODValues.GetValuesDataSet(siteId,
                                                         variableId,
                                                         BeginDateTime.Value,
                                                          EndDateTime.Value // set above
                        );
                }
                else if (variableId.HasValue && !BeginDateTime.HasValue && EndDateTime.HasValue)
                {
                    BeginDateTime = W3CDateTime.Parse(ConfigurationManager.AppSettings["MinimalSQLDate"]);

                    valuesDs = ODValues.GetValuesDataSet(siteId,
                                                         variableId,
                                                         BeginDateTime.Value,  // set above
                                                         EndDateTime.Value
                        );
                }
                else
                {
                    valuesDs = ODValues.GetValuesDataSet(siteId,
                                                         variableId,
                                                         BeginDateTime.Value,
                                                         EndDateTime.Value
                        );
                }

                return valuesDs;

            }
        }
    }
}
