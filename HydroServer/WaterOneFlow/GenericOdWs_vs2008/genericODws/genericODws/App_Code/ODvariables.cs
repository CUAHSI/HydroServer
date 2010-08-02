using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;
using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_0;
using VariableParam = WaterOneFlowImpl.VariableParam;
using tableSpace = WaterOneFlow.odm.v1_1.VariablesDatasetTableAdapters;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.Schema.v1;
    using WaterOneFlow.odm.v1_1;
    using UnitsTableAdapter = tableSpace.UnitsTableAdapter;
    using VariablesTableAdapter = tableSpace.VariablesTableAdapter;
    using CategoriesTableAdapter = tableSpace.CategoriesTableAdapter;
    using VariablesRow = WaterOneFlow.odm.v1_1.VariablesDataset.VariablesRow;

    /// <summary>
    /// Summary description for ODvariables
    /// </summary>
    public class ODvariables
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (ODvariables));

        /// <summary>
        /// In order to use this class, an application variable must be set.
        /// 'ODNetworkID' type=int.
        ///  where the int, is the networkID in the t_network table.
        /// 
        /// </summary>
        public ODvariables()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Returns a VariablesDataSet, as defined by VariablesDataSet.xsd
        /// 
        /// In SDSC code, this variable is loaded once, and is stored in an 
        /// Application, or AppServer variable, and queries are run against the stored dataset.
        /// Other methods in this class are used to query the dataset.
        /// 
        /// In order to use this method, an application variable must be set.
        /// 'ODNetworkID' type=int.
        ///  where the int, is the networkID in the t_network table.
        /// </summary>
        /// <returns></returns>
        public static VariablesDataset GetVariableDataSet()
        {
            int networkID;
            // Could ingore this, and just fill with all
            try
            {
                networkID = Convert.ToInt32(
                    System.Configuration.ConfigurationManager.AppSettings["ODNetworkID"]
                    );
            }
            catch (Exception e)
            {
                throw new WaterOneFlowServerException(
                    "Application Setting 'ODNetworkID' is missing, or is not an integer. Please add or correct 'ODNetworkID'.");
            }
            return GetVariableDataSet(networkID);
        }

        /// <summary>
        /// Returns a VariablesDataSet, as defined by VariablesDataSet.xsd
        /// 
        /// In SDSC code, this variable is loaded once, and is stored in an 
        /// Application, or AppServer variable, and queries are run against the stored dataset.
        /// Other methods in this class are used to query the dataset.
        /// </summary>
        /// <param name="networkID"></param>
        /// <returns></returns>
        public static VariablesDataset GetVariableDataSet(int networkID)
        {
            VariablesDataset ds = new VariablesDataset();

            UnitsTableAdapter unitTableAdapter = new UnitsTableAdapter();
            VariablesTableAdapter varsTableAdapter = new VariablesTableAdapter();
            unitTableAdapter.Connection.ConnectionString = Config.ODDB();
            varsTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                unitTableAdapter.Fill(ds.Units);
                varsTableAdapter.Fill(ds.Variables);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot retrieve units or variables from database" + e.Message);
                    // + unitTableAdapter.Connection.DataSource
                throw new WaterOneFlowServerException("Cannot retrieve units or variables from database", e);
            }

            GetCategories(ds);
            return ds;
        }

        /// <summary>
        /// Add catagories for each one of the variableID's
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static void GetCategories(VariablesDataset ds)
        {
            if (ds != null)
            {
                CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
                ds.Categories.Clear();
                //foreach (VariablesRow vRow in ds.Variables.Rows)
                //{
                //    categoriesTableAdapter.FillByVariableID(ds.Categories, vRow.VariableID);
                //}
            }
        }

        public static VariableInfoType[] getVariable(VariableParam vParam, VariablesDataset ds)
        {
            List<VariableInfoType> vars = new List<VariableInfoType>();
            if (vParam != null)
            {
                /* need to use a data view, so the we can set a filter that does not effect the whole dataset
                  DataView has a ToTable method that is uses to create a new DS, and fill
                 * a new VariablesDataset. Typed Datasets are useful ;)
                 */

                DataView view = new DataView();
                view.Table = ds.Tables["Variables"];

                if (vParam.IsId)
                {
                    view.RowFilter = "VariableID = " + vParam.Code + " ";
                }
                else
                {
                    view.RowFilter = "VariableCode = '" + vParam.Code + "' ";
                    // list of possible options. Allowing any will break the query (aka QualityControlLevelID, etc)
                    String[] options = {"samplemedium", "datatype", "valuetype"};

                    foreach (string opt in options)
                    {
                        if (vParam.options.ContainsKey(opt))
                        {
                            if (!String.IsNullOrEmpty(vParam.options[opt]))
                            {
                                String rowFilter = view.RowFilter + " AND "
                                                   + opt + "='" + vParam.options[opt] + "'";
                                view.RowFilter = rowFilter;
                            }
                        }
                    }
                }

                DataTable v = view.ToTable();
                if (v.Rows.Count > 0)
                {
                    VariablesDataset vtemp = new VariablesDataset();

                    vtemp.Variables.Merge(v);

                    foreach (VariablesDataset.VariablesRow row in vtemp.Variables.Rows)
                    {
                        VariableInfoType result = rowToVariableInfoType(row,
                                                                        ds
                            );
                        vars.Add(result);
                    }

                    return vars.ToArray();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static VariableInfoType[] getVariables(VariableParam[] vParams, VariablesDataset ds)
        {
            List<VariableInfoType> vit = new List<VariableInfoType>();

            // if there are no variableParameters, return all varaibles
            if (vParams == null || vParams.Length == 0)
            {
                foreach (VariablesDataset.VariablesRow row in ds.Variables.Rows)
                {
                    VariableInfoType result = rowToVariableInfoType(row,
                                                                    ds
                        );
                    vit.Add(result);
                }
                return vit.ToArray();
            }
            else
            {
                foreach (VariableParam vParam in vParams)
                {
                    VariableInfoType[] vars = getVariable(vParam, ds);
                    if (vars != null) vit.AddRange(vars);
                }
                return vit.ToArray();
            }
        }

        /// <summary>
        /// Gets the variables.
        /// used to test the variable datatable.
        /// </summary>
        /// <returns></returns>
        public static VariableInfoType[] GetVariables()
        {
            List<VariableInfoType> vars = new List<VariableInfoType>();
            VariablesDataset ds = GetVariableDataSet();

            foreach (VariablesDataset.VariablesRow row in ds.Variables)
            {
                VariableInfoType vit = rowToVariableInfoType(row, ds);
                vars.Add(vit);
            }
            return vars.ToArray();
        }

        /// <summary>
        /// Returns the variable associated with a variableID
        /// 
        /// Note: this will only return one value... and only one value.
        /// </summary>
        /// <param name="variableID"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static VariableInfoType GetVariableByID(Nullable<int> variableID, VariablesDataset ds)
        {
            VariableInfoType[] vit;
            if (variableID.HasValue)
            {
                vit = GetVariablesByID(new int[] {variableID.Value}, ds);
            }
            else
            {
                vit = GetVariablesByID(new int[] {}, ds);
            }

            if (vit == null)
            {
                return null;
            }
            else
            {
                // there should only be one, and only one value with a variable ID.
                if (vit.Length == 1)
                {
                    return vit[0];
                }
                else
                {
                    return vit[0];
                    // TODO throw error
                }
            }
        }

        public static VariableInfoType[] GetVariablesByID(int[] variableIDs, VariablesDataset ds)
        {
            List<VariableInfoType> vars = new List<VariableInfoType>();


            if (variableIDs.Length == 0)
            {
                foreach (VariablesDataset.VariablesRow row in ds.Variables.Rows)
                {
                    VariableInfoType result = rowToVariableInfoType(row,
                                                                    ds
                        );
                    vars.Add(result);
                }
                return vars.ToArray();
            }
            else
            {
                StringBuilder sBuilder = new StringBuilder("(");
                int i = 0;
                foreach (int s in variableIDs)
                {
                    if (i > 0) sBuilder.Append(",");
                    sBuilder.Append("'");
                    sBuilder.Append(s.ToString());
                    sBuilder.Append("'");
                    i++;
                }
                sBuilder.Append(")");

                //DataRow dr = ds.Tables["variables"].Select("variableCode = " + vCode);
                DataRow[] dr = ds.Tables["variables"].Select("variableID IN " + sBuilder.ToString());

                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        VariableInfoType result = rowToVariableInfoType((
                                                                        VariablesDataset.VariablesRow) row,
                                                                        ds
                            );
                        vars.Add(result);
                    }
                    return vars.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Builds a VariableInfoType from a dataset row 
        /// the dataSet is stored in the NWISService variableDataSet.
        /// Find the rwo you want with the command:
        /// 
        /// and convert. 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static VariableInfoType rowToVariableInfoType(VariablesDataset.VariablesRow row, VariablesDataset ds)
        {
            units aUnit = null;

            aUnit = getUnitsElement(row.VariableUnitsID, ds);


            String vCode = !String.IsNullOrEmpty(row.VariableCode) ? row.VariableCode : null;

            int vid = row.VariableID;
            // appSetting['vocabulary'] 

            String vocab = System.Configuration.ConfigurationManager.AppSettings["vocabulary"];
            String varName = !String.IsNullOrEmpty(row.VariableName) ? row.VariableName : null;

            VariableInfoType vt = CuahsiBuilder.CreateVariableInfoType(
                vid.ToString(),
                vocab,
                vCode,
                varName,
                null, //variable description
                aUnit
                );

            // add time support
            vt.timeSupport = new VariableInfoTypeTimeSupport();
            if (row.IsRegular)
            {
                vt.timeSupport.isRegular = true;
                vt.timeSupport.isRegularSpecified = true;
                vt.timeSupport.timeInterval = Convert.ToInt32(row.TimeSupport);
                vt.timeSupport.timeIntervalSpecified = true;
                // this is different that the other "units", so populate by code
                units tUnit = getUnitsElement(row.TimeUnitsID, ds);
                if (tUnit != null)
                {
                    vt.timeSupport.unit = new UnitsType();
                    vt.timeSupport.unit.UnitID = int.Parse(tUnit.unitsCode);
                    vt.timeSupport.unit.UnitIDSpecified = true;
                    vt.timeSupport.unit.UnitDescription = tUnit.Value;
                    vt.timeSupport.unit.UnitAbbreviation = tUnit.unitsAbbreviation;
                    if (tUnit.unitsTypeSpecified)
                    {
                        // if it's specified in the units, then it's a valid enum
                        vt.timeSupport.unit.UnitType = tUnit.unitsType;
                        vt.timeSupport.unit.UnitTypeSpecified = true;
   
                    }
                }
            }
            else
            {
                vt.timeSupport.isRegular = false;
                vt.timeSupport.isRegularSpecified = true;
            }
            CuahsiBuilder.SetEnumFromText(vt, row, "valueType", typeof (valueTypeEnum));
            CuahsiBuilder.SetEnumFromText(vt, row, "sampleMedium", typeof (SampleMediumEnum));
            CuahsiBuilder.SetEnumFromText(vt, row, "dataType", typeof (dataTypeEnum));
            CuahsiBuilder.SetEnumFromText(vt, row, "generalCategory", typeof (generalCategoryEnum));
            // if (!String.IsNullOrEmpty(row.NoDataValue)) {
            vt.NoDataValue = row.NoDataValue.ToString();
            // }
            return vt;
        }

        public static units getUnitsElement(int unitsID, VariablesDataset ds)
        {
            DataRow[] dr = ds.Tables["units"].Select("unitsID = " + unitsID);

            if (dr.Length > 0)
            {
                VariablesDataset.UnitsRow row = (VariablesDataset.UnitsRow) dr[0];
                string uID = row.UnitsID.ToString();
                string unitType = String.IsNullOrEmpty(row.UnitsType) ? null : row.UnitsType;
                string unitAbbrev = String.IsNullOrEmpty(row.UnitsAbbreviation) ? null : row.UnitsAbbreviation;
                string unitName = String.IsNullOrEmpty(row.UnitsName) ? null : row.UnitsName;

                units u = CuahsiBuilder.CreateUnitsElement(null, uID, unitAbbrev, unitName);
                CuahsiBuilder.SetEnumFromText(u, row, "unitsType", typeof (UnitsTypeEnum));
                return u;
            }
            else
            {
                return null;
            }
        }
    }
}