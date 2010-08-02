using System;
using System.Data;
using log4net;
using UnitsType = WaterOneFlow.Schema.v1_1.UnitsType;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    using CuahsiBuilder = WaterOneFlowImpl.v1_1.CuahsiBuilder;
    using UnitsTableAdapter = WaterOneFlow.odm.v1_1.unitsDatasetTableAdapters.UnitsTableAdapter;

    namespace v1_1
    {
        /// <summary>
        /// Summary description for ODUnits
        /// </summary>
        public class ODUnits
        {
            private static readonly ILog log = LogManager.GetLogger(typeof (ODUnits));

            public ODUnits()
            {
            }


            public static unitsDataset getUnitsDataset()
            {
                unitsDataset uDS = new unitsDataset();

                UnitsTableAdapter unitsTableAdapter = new UnitsTableAdapter();
                unitsTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                try
                {
                    unitsTableAdapter.Fill(uDS.Units);
                }
                catch (Exception e)
                {
                    log.Fatal("Cannot retrieve units from the database: " + e.Message); 
                }

                return uDS;
            }

            public static UnitsType getUnitsElement(string unitsID, unitsDataset ds)
            {

                DataRow[] dr = ds.Tables["units"].Select("unitID = " + unitsID);

                if (dr.Length > 0)
                {
                    unitsDataset.UnitsRow row = (unitsDataset.UnitsRow) dr[0];
                    string uID = row.UnitsID.ToString();

                    UnitsType u = CuahsiBuilder.CreateUnitsElement(
                        row.UnitsType, 
                        uID, 
                        row.UnitsAbbreviation,
                         row.UnitsName
                         );
                    return u;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}