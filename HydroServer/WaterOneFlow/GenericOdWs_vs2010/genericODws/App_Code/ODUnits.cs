using System;
using System.Data;

using log4net;

using WaterOneFlowImpl;

using tableSpace = WaterOneFlow.odm.v1_1.unitsDatasetTableAdapters;

namespace WaterOneFlow.odws
{
       using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;
    
    using WaterOneFlow.odm.v1_1;
    using UnitsTableAdapter = tableSpace.UnitsTableAdapter;


    /// <summary>
    /// Summary description for ODUnits
    /// </summary>
    public class ODUnits
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ODUnits));
        
        public ODUnits()
        {
 
        }


        public static unitsDataset getUnitsDataset()
        {
            unitsDataset uDS = new unitsDataset();

            UnitsTableAdapter unitsTableAdapter = new UnitsTableAdapter();
            unitsTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                unitsTableAdapter.Fill(uDS.Units);
            } catch  (Exception e)
            {
                log.Fatal("Cannot retrieve units from the database: " + e.Message); //+ unitsTableAdapter.Connection.DataSource
            }


       
            return uDS;
        }

        public static units getUnitsElement(string unitsID, unitsDataset ds)
        {

            DataRow[] dr = ds.Tables["units"].Select("unitID = " + unitsID);

            if (dr.Length > 0)
            {
                unitsDataset.UnitsRow row = (unitsDataset.UnitsRow)dr[0];
                string uID = row.UnitsID.ToString();
                string unitType = String.IsNullOrEmpty(row.UnitsType) ? null : row.UnitsType;
                string unitAbbrev = String.IsNullOrEmpty(row.UnitsAbbreviation) ? null : row.UnitsAbbreviation;
                string unitName = String.IsNullOrEmpty(row.UnitsName) ? null : row.UnitsName;

                units u = CuahsiBuilder.CreateUnitsElement(null, uID, unitAbbrev, unitName);
                return u;
            }
            else
            {
                return null;
            }


        }


    }

}