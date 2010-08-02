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

using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_0;
using VariableParam = WaterOneFlowImpl.VariableParam;

/// <summary>
/// Summary description for GetValuesOD
/// </summary>
namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;

    using WaterOneFlow.odm.v1_1;

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
            VariableParam vp;
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
            else
            {
                throw new WaterOneFlowException("Variable parameter is required ");

            }
            locationParam sq;
            sq = new locationParam(SiteNumber);

            if (sq.isGeometry)
            {
                throw new WaterOneFlowException("Location by Geometry not accepted: " + SiteNumber);
            }

            siteInfoDataSet sitDs = ODSiteInfo.GetSiteInfoDataSet(sq);
            if (sitDs != null && sitDs.sites.Count > 0)
            {
                siteID = sitDs.sites[0].SiteID;
                ValuesDataSet valuesDs = getValuesDataset(siteID, variableId, BeginDateTime, EndDateTime, vp);

                response = getValues(valuesDs, vp);

                // above is the values, add the site, and variables
                response.timeSeries.variable = varInfoType;

                if (varInfoType != null)
                {
                    if (varInfoType.units != null)
                    {
                        response.timeSeries.values.unitsAbbreviation = varInfoType.units.unitsAbbreviation;
                        response.timeSeries.values.unitsCode = varInfoType.units.unitsCode;

                        if (varInfoType.units.unitsType != null)
                        {
                            response.timeSeries.values.unitsType = varInfoType.units.unitsType;
                            response.timeSeries.values.unitsTypeSpecified = true;
                        }
                        response.timeSeries.values.unitsAreConverted = false;
                    }

                }

                response.timeSeries.sourceInfo = ODSiteInfo.row2SiteInfoElement(sitDs.sites[0], sitDs);

            }
            else
            {
                response = CuahsiBuilder.CreateTimeSeriesObject();
            }
            // add query info
            response.queryInfo.creationTime = DateTime.UtcNow;
            //response.queryInfo.creationTime = DateTimeOffset.UtcNow;
            response.queryInfo.creationTimeSpecified = true;
            response.queryInfo.criteria.locationParam = SiteNumber;
            response.queryInfo.criteria.variableParam = Variable;
            response.queryInfo.criteria.timeParam = CuahsiBuilder.createQueryInfoTimeCriteria(StartDate, EndDate);
            NoteType sourceNote = CuahsiBuilder.createNote("OD Web Service");
            response.queryInfo.note = CuahsiBuilder.addNote(response.queryInfo.note,
                                                            sourceNote);


            return response;
        }

        public static TimeSeriesResponseType getValues(ValuesDataSet ValuesDs, VariableParam variable)
        {
            TimeSeriesResponseType response = CuahsiBuilder.CreateTimeSeriesObjectSingleValue();

            // get siteInfo

            // get variable Info

            // get Values
            // reformats values dataset into a TimeSeriesResponseType
            List<ValueSingleVariable> valueList = ODValues.dataset2ValuesList(ValuesDs, variable);

            response.timeSeries.values.value = valueList.ToArray();
            response.timeSeries.values.count = valueList.Count.ToString();

            // add qualifiers
            List<qualifier> qualifers = ODValues.datasetQualifiers(ValuesDs);
            if (qualifers != null && qualifers.Count > 0)
            {
                response.timeSeries.values.qualifier = qualifers.ToArray();
            }
            // add methods
            List<MethodType> methods = ODValues.datasetMethods(ValuesDs);
            if (methods != null && methods.Count > 0)
            {
                response.timeSeries.values.method = methods.ToArray();
            }
            List<SourceType> sources = ODValues.datasetSources(ValuesDs);
            if (sources != null && sources.Count > 0)
            {
                response.timeSeries.values.source = sources.ToArray();
            }
            List<OffsetType> offsets = ODValues.datasetOffsetTypes(ValuesDs);
            if (offsets != null && offsets.Count > 0)
            {
                response.timeSeries.values.offset = offsets.ToArray();
            }
            return response;
        }

        public ValuesDataSet getValuesDataset(int? siteId, int? variableId, W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime, VariableParam variable)
        {
            ValuesDataSet valuesDs;
            if (variableId == null && BeginDateTime == null && EndDateTime == null)
            {
                valuesDs = ODValues.GetValuesDataSet(siteId.Value);
            }
            else if (variableId != null && BeginDateTime == null && EndDateTime == null)
            {
                valuesDs = ODValues.GetValuesDataSet(siteId, variableId);
            }
            else if (variableId != null && BeginDateTime != null && EndDateTime == null)
            {
                EndDateTime = W3CDateTime.Now;
                valuesDs = ODValues.GetValuesDataSet(siteId,
                                                     variableId,
                                                     BeginDateTime.Value,
                                                      EndDateTime.Value // set above
                    );
            }
            else if (variableId != null && BeginDateTime == null && EndDateTime != null)
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
