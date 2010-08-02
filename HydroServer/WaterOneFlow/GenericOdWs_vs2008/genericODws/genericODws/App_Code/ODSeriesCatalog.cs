using System;
using System.Collections.Generic;
using System.Configuration;
using log4net;

using WaterOneFlowImpl;

namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;
    using WaterOneFlow.odm.v1_1;

    using SeriesCatalogTableAdapter = WaterOneFlow.odm.v1_1.seriesCatalogDataSetTableAdapters.SeriesCatalogTableAdapter;

    /// <summary>
    /// Summary description for ODSeriesCatalog
    /// </summary>
    public class ODSeriesCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ODSeriesCatalog));

        public ODSeriesCatalog()
        {

        }

        /// <summary>
        /// Get a series catalog for a site.
        /// 
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public static seriesCatalogDataSet GetSeriesCatalogDataSet(int siteID)
        {
            seriesCatalogDataSet sDS = new seriesCatalogDataSet();

            SeriesCatalogTableAdapter seriesTableAdapter =
                new SeriesCatalogTableAdapter();
            seriesTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                seriesTableAdapter.FillBySiteID(sDS.SeriesCatalog, siteID);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot retrieve information from database: " + e.Message); //+ seriesTableAdapter.Connection.DataSource
            }

            return sDS;


        }

        public static seriesCatalogType[] dataSet2SeriesCatalog(
            seriesCatalogDataSet ds,
            VariablesDataset vds)
        {

            /* logic
             *   for each sourceID that is associated with the site
             *     
             * 
             */

            List<seriesCatalogType> catalogs = new List<seriesCatalogType>();

            seriesCatalogType catalog = createSeriesCatalog(ds, vds);
            if (catalog != null)
            {
                catalogs.Add(catalog);
            }

            return catalogs.ToArray();
        }

        private static seriesCatalogType createSeriesCatalog(
            seriesCatalogDataSet ds,
            VariablesDataset vds)
        {
            if (ds.SeriesCatalog.Count > 0)
            {
                Boolean useOD;

                String siteServiceURL;
                String siteServiceName;
                try
                {
                    useOD = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);

                    if (!useOD)
                    {
                        siteServiceURL = ConfigurationManager.AppSettings["externalGetValuesService"];
                        siteServiceName = ConfigurationManager.AppSettings["externalGetValuesName"];
                    }
                    else
                    {
                        siteServiceURL = "http://localhost/";
                        siteServiceName = "OD Web Services";
                    }
                }
                catch
                {
                    useOD = true; // should be caught earlier


                    siteServiceURL = "http://locahost/";
                    siteServiceName = "Fix UseODForValues, externalGetValuesService, externalGetValuesName";

                }
                seriesCatalogType catalog = CuahsiBuilder.CreateSeriesCatalog(
                    ds.SeriesCatalog.Count,
                    siteServiceName, // menu name (aka OD name
                    siteServiceURL// web service location
                 );
                List<seriesCatalogTypeSeries> seriesRecords = new List<seriesCatalogTypeSeries>();
                foreach (seriesCatalogDataSet.SeriesCatalogRow row in ds.SeriesCatalog.Rows)
                {
                    seriesCatalogTypeSeries aRecord = row2SeriesCatalogElement(
                        row, ds, vds);

                    seriesRecords.Add(aRecord);

                }
                catalog.series = seriesRecords.ToArray();
                return catalog;
            }
            else
            {
                seriesCatalogType catalog = CuahsiBuilder.CreateSeriesCatalog(0,
                                                                null, // menu name (aka OD name
                                                                String.Empty // web service location
                    );
                return catalog;
            }
        }

        public static seriesCatalogTypeSeries row2SeriesCatalogElement(
            seriesCatalogDataSet.SeriesCatalogRow row,
            seriesCatalogDataSet ds, VariablesDataset vds)
        {


            int variableID = row.VariableID;
            VariableInfoType variable = ODvariables.GetVariableByID(variableID, vds);
            Nullable<W3CDateTime> beginDateTime = null;
            if (!row.IsBeginDateTimeNull()) beginDateTime = new W3CDateTime(row.BeginDateTime);

            Nullable<W3CDateTime> endDateTime = null;
            if (!row.IsEndDateTimeNull()) endDateTime = new W3CDateTime(row.EndDateTime);

            Nullable<int> valueCount = null;
            if (!row.IsValueCountNull()) valueCount = row.ValueCount;

            int? QualityControlLevelid = null;
            if (!row.IsQualityControlLevelIDNull()) QualityControlLevelid = row.QualityControlLevelID;

            int? MethodID = null;
            if (!row.IsMethodIDNull()) MethodID = row.MethodID;

            int? SourceID = null;
            if (!row.IsSourceIDNull()) SourceID = row.SourceID;


            Nullable<Boolean> valueCountIsEstimated = false;
 
            seriesCatalogTypeSeries record = CuahsiBuilder.CreateSeriesRecord(
                variable,
                variable.sampleMedium.ToString(),
                beginDateTime,
                endDateTime,
                valueCount,
                valueCountIsEstimated,
                null,
                null,
                null,
                false, // real time
                null, // string if real time
                null,
                QualityControlLevelid,
                row.MethodDescription, MethodID,
                row.Organization, row.SourceDescription,
                SourceID,
                row.Citation);

            return record;
        }
    }

}