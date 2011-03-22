using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text;
using log4net;

using WaterOneFlowImpl;

namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;

    using WaterOneFlow.odm.v1_1;

    using ValuesDataSetTableAdapters = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters;
    using DataValuesTableAdapter = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters.DataValuesTableAdapter;
    using unitsDatasetTableAdapters = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters.UnitsTableAdapter;
    using UnitsTableAdapter = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters.UnitsTableAdapter;
    using QualifiersTableAdapter = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters.QualifiersTableAdapter;
    using VariablesDataset = WaterOneFlow.odm.v1_1.VariablesDataset;

    // <summary>
    /// Summary description for ODValues
    /// </summary>
    public class ODValues
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ODValues));

        public ODValues()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region odm 1 series based
        public static ValuesDataSet GetValuesDataSet(int siteID)
        {
            ValuesDataSet ds = basicValuesDataSet();

            ValuesDataSetTableAdapters.DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
            valuesTableAdapter.Connection.ConnectionString = Config.ODDB();

            try
            {
                valuesTableAdapter.FillBySiteID(ds.DataValues, siteID);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot retrieve information from database: " + e.Message); //+ valuesTableAdapter.Connection.DataSource
            }


            return ds;

        }

        public static ValuesDataSet GetValuesDataSet(int? siteID, int? VariableID)
        {


            ValuesDataSet ds = basicValuesDataSet();
            if (!siteID.HasValue || !VariableID.HasValue) return ds;
            ValuesDataSetTableAdapters.DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
            valuesTableAdapter.Connection.ConnectionString = Config.ODDB();

            valuesTableAdapter.FillBySiteIDVariableID(ds.DataValues, siteID.Value, VariableID.Value);

            return ds;

        }

        public static ValuesDataSet GetValuesDataSet(int? siteID, int? VariableID, W3CDateTime BeginDateTime, W3CDateTime EndDateTime)
        {

            ValuesDataSet ds = basicValuesDataSet();
            if (!siteID.HasValue || !VariableID.HasValue) return ds;
            ValuesDataSetTableAdapters.DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
            valuesTableAdapter.Connection.ConnectionString = Config.ODDB();

            valuesTableAdapter.FillBySiteIdVariableIDBetweenDates(ds.DataValues, siteID.Value, VariableID.Value, BeginDateTime.DateTime, EndDateTime.DateTime);

            return ds;

        }

        // never implemented or used. Now implemented as a filter using a passed variable parameter
        //public static ValuesDataSet GetValueDataSet(int? siteID, int? VariableID, int? MethodID, int? SourceID, int? QualityControlLevelID, W3CDateTime BeginDateTime, W3CDateTime EndDateTime)
        //{
        //    ValuesDataSet ds = basicValuesDataSet();
        //    if (!siteID.HasValue || !VariableID.HasValue) return ds;
        //    ValuesDataSetTableAdapters.DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
        //    valuesTableAdapter.Connection.ConnectionString = Config.ODDB();

        //    valuesTableAdapter.FillBySiteIdVariableIDBetweenDates(ds.DataValues, siteID.Value, VariableID.Value, BeginDateTime.DateTime, EndDateTime.DateTime);

        //    return ds;
        //}
        #endregion

        // fills dataset with basic tables
        private static ValuesDataSet basicValuesDataSet()
        {
            ValuesDataSet ds = new ValuesDataSet();

            ValuesDataSetTableAdapters.UnitsTableAdapter unitsTableAdapter =
                new UnitsTableAdapter();
            unitsTableAdapter.Connection.ConnectionString = Config.ODDB();

            ValuesDataSetTableAdapters.OffsetTypesTableAdapter offsetTypesTableAdapter =
                      new ValuesDataSetTableAdapters.OffsetTypesTableAdapter();
            offsetTypesTableAdapter.Connection.ConnectionString = Config.ODDB();

            ValuesDataSetTableAdapters.QualityControlLevelsTableAdapter qualityControlLevelsTableAdapter =
                     new ValuesDataSetTableAdapters.QualityControlLevelsTableAdapter();
            qualityControlLevelsTableAdapter.Connection.ConnectionString = Config.ODDB();

            ValuesDataSetTableAdapters.MethodsTableAdapter methodsTableAdapter =
                            new ValuesDataSetTableAdapters.MethodsTableAdapter();
            methodsTableAdapter.Connection.ConnectionString = Config.ODDB();

            ValuesDataSetTableAdapters.SamplesTableAdapter samplesTableAdapter =
                          new ValuesDataSetTableAdapters.SamplesTableAdapter();
            samplesTableAdapter.Connection.ConnectionString = Config.ODDB();

            ValuesDataSetTableAdapters.SourcesTableAdapter sourcesTableAdapter =
                         new ValuesDataSetTableAdapters.SourcesTableAdapter();
            sourcesTableAdapter.Connection.ConnectionString = Config.ODDB();

            QualifiersTableAdapter qualifiersTableAdapter =
                new QualifiersTableAdapter();
            qualifiersTableAdapter.Connection.ConnectionString = Config.ODDB();

            unitsTableAdapter.Fill(ds.Units);
            offsetTypesTableAdapter.Fill(ds.OffsetTypes);
            qualityControlLevelsTableAdapter.Fill(ds.QualityControlLevels);
            methodsTableAdapter.Fill(ds.Methods);
            samplesTableAdapter.Fill(ds.Samples);
            sourcesTableAdapter.Fill(ds.Sources);
            qualifiersTableAdapter.Fill(ds.Qualifiers);



            return ds;

        }


        /// <summary>
        /// DataValue creation. Converts a ValuesDataSet to the XML schema ValueSingleVariable
        /// If variable is null, it will return all
        /// If variable has extra options (variable:code/Value=Key/Value=Key)
        /// 
        /// </summary>
        /// <param name="ds">Dataset that you want converted</param>
        /// <param name="variable">Variable that you want to use to place limits on the returned data</param>
        /// <returns></returns>
        public static List<ValueSingleVariable> dataset2ValuesList(ValuesDataSet ds, VariableParam variable)
        {


            List<ValueSingleVariable> tsTypeList = new List<ValueSingleVariable>();


            /* logic
             * if there is a variable that has options, then get a set of datarows
           * using a select clause
             * use an enumerator, since it is generic
             * */
            IEnumerator dataValuesEnumerator ;

            ValuesDataSet.DataValuesRow[] dvRows; // if we find options, we need to use this.
            
                 String select = OdValuesCommon.CreateValuesWhereClause(variable, null);

                 if (select.Length > 0)
                 {
                     dvRows = (ValuesDataSet.DataValuesRow[])ds.DataValues.Select(select.ToString());

                     dataValuesEnumerator = dvRows.GetEnumerator();

                 }
                 else
                 {
                     dataValuesEnumerator = ds.DataValues.GetEnumerator();
                 }

            //  foreach (ValuesDataSet.DataValuesRow aRow in ds.DataValues){
            while (dataValuesEnumerator.MoveNext())
            {
                ValuesDataSet.DataValuesRow aRow = (ValuesDataSet.DataValuesRow)dataValuesEnumerator.Current;
                try
                {
                    ValueSingleVariable tsTypeValue = new ValueSingleVariable();

                    #region DateTime Standard
                    tsTypeValue.dateTime = Convert.ToDateTime(aRow.DateTime);
                    //tsTypeValue.dateTimeSpecified = true;
                    DateTime temprealdate;



                    //<add key="returnUndefinedUTCorLocal" value="Undefined"/>
                    if (ConfigurationManager.AppSettings["returnUndefinedUTCorLocal"].Equals("Undefined"))
                    {
                        temprealdate = Convert.ToDateTime(aRow.DateTime); // not time zone shift

                    }
                    else if (ConfigurationManager.AppSettings["returnUndefinedUTCorLocal"].Equals("Local"))
                    {

                        TimeSpan zone = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                        Double offset = Convert.ToDouble(aRow.UTCOffset);

                        if (zone.TotalHours.Equals(offset))
                        {
                            // zone is the same as server. Shift
                            temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTime), DateTimeKind.Local);
                        }
                        else
                        {
                            //// zone is not the same. Output in UTC.
                            //temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTime), DateTimeKind.Utc);
                            //// correct time with shift.
                            //temprealdate = temprealdate.AddHours(offset);

                            // just use the DateTime UTC
                            temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTimeUTC), DateTimeKind.Utc);

                        }
                    }
                    else if (ConfigurationManager.AppSettings["returnUndefinedUTCorLocal"].Equals("UTC"))
                    {
                        temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTimeUTC), DateTimeKind.Utc);

                    }
                    else
                    {
                        temprealdate = Convert.ToDateTime(aRow.DateTime); // not time zone shift


                    }

                    temprealdate = Convert.ToDateTime(aRow.DateTime); // not time zone shift
#endregion
#region DateTimeOffset Failed
                    /// using XML overrides
                    // Attemp to use DateTimeOffset in xml Schema
                    //TimeSpan zone = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                    //Double offset = Convert.ToDouble(aRow.UTCOffset);

                    //DateTimeOffset temprealdate;
                    //temprealdate = new DateTimeOffset(Convert.ToDateTime(aRow.DateTime), 
                    //    new TimeSpan(Convert.ToInt32(offset),0,0));
                    //DateTimeOffset temprealdate;
                    //temprealdate = new DateTimeOffset(Convert.ToDateTime(aRow.DateTime),
                    //    new TimeSpan(Convert.ToInt32(offset), 0, 0));
                 
                    //tsTypeValue.dateTime = temprealdate;
                    //tsTypeValue.dateTimeSpecified = true;
                    #endregion

                    //tsTypeValue.censored = string.Empty;
                    if (string.IsNullOrEmpty(aRow.Value.ToString()))
                        continue;
                    else
                        tsTypeValue.Value = Convert.ToDecimal(aRow.Value);

                    try
                    {

                        tsTypeValue.censorCode = (CensorCodeEnum)Enum.Parse(typeof(CensorCodeEnum), aRow.CensorCode, true);
                        tsTypeValue.censorCodeSpecified = true;

                        if (!aRow.IsOffsetTypeIDNull())
                        {
                            tsTypeValue.offsetTypeID = aRow.OffsetTypeID;
                            tsTypeValue.offsetTypeIDSpecified = true;

                            // enabled to fix issue with hydroobjects
                            ValuesDataSet.OffsetTypesRow off = ds.OffsetTypes.FindByOffsetTypeID(aRow.OffsetTypeID);
  

                            ValuesDataSet.UnitsRow offUnit = ds.Units.FindByUnitsID(off.OffsetUnitsID);
                            tsTypeValue.offsetUnitsCode = offUnit.UnitsID.ToString();
                            tsTypeValue.offsetUnitsAbbreviation = offUnit.UnitsAbbreviation;
                        }

                        // offset value may be separate from the units... anticpating changes for USGS
                        if (!aRow.IsOffsetValueNull())
                        {
                            tsTypeValue.offsetValue = aRow.OffsetValue;
                            tsTypeValue.offsetValueSpecified = true;
                        }

                       
                        ValuesDataSet.MethodsRow meth = ds.Methods.FindByMethodID(aRow.MethodID);
                        tsTypeValue.methodID = aRow.MethodID;
                        tsTypeValue.methodIDSpecified = true;
                        

                        if (!aRow.IsQualifierIDNull())
                        {
                            ValuesDataSet.QualifiersRow qual = ds.Qualifiers.FindByQualifierID(aRow.QualifierID);
                            if (qual != null)
                            {
                                tsTypeValue.qualifiers = qual.QualifierCode;
                                
                            }
                        }


                        ValuesDataSet.QualityControlLevelsRow qcl =
                            ds.QualityControlLevels.FindByQualityControlLevelID(aRow.QualityControlLevelID);
                        string qlName = qcl.Definition.Replace(" ", "");

                        if (Enum.IsDefined(typeof(QualityControlLevelEnum), qlName))
                        {
                            tsTypeValue.qualityControlLevel = (QualityControlLevelEnum)
                                                              Enum.Parse(
                                                                  typeof(QualityControlLevelEnum), qlName, true);
                            if (tsTypeValue.qualityControlLevel != QualityControlLevelEnum.Unknown){
                             tsTypeValue.qualityControlLevelSpecified = true;
                            }
                        }
                        //}
                        tsTypeValue.sourceID = aRow.SourceID;
                        tsTypeValue.sourceIDSpecified = true;

                        if (!aRow.IsSampleIDNull())
                        {
                            tsTypeValue.sampleID = aRow.SampleID;
                            tsTypeValue.sampleIDSpecified = true;
                        }


                    }
                    catch (Exception e)
                    {
                        log.Debug("Error generating a value " + e.Message);
                        // non fatal exceptions
                    }

                    tsTypeList.Add(tsTypeValue);
                }
                catch (Exception e)
                {
                    //  ignore any value errors
                }

            }
            return tsTypeList;

        }

        public static void addCategoricalInformation( List<ValueSingleVariable> variables, int variableID, VariablesDataset vds)
        {
            
            foreach (ValueSingleVariable variable in variables)
            {
                string selectquery = String.Format("VariableID = {0} AND DataValue = {1}", variableID.ToString(),
                                                   variable.Value);
                DataRow[] rows =  vds.Categories.Select(selectquery);
                if (rows.Length >0 )
                {
                    variable.codedVocabulary = true;
                    variable.codedVocabularySpecified = true;
                    variable.codedVocabularyTerm = (string)rows[0]["CategoryDescription"];
                }

            }  

        }

       
        /// <summary>
        /// Method to generate a list of qualifiers in a ValuesDataSet
        /// This is done as a separate method since Values can could contain other VariableValue Types
        ///
        /// </summary>
        /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
        /// <returns></returns>
        public static List<qualifier> datasetQualifiers(ValuesDataSet ds)
        {
            /* generate a list
             * create a distinct DataSet
             * - new data view
             * - set filter (no nulls)
             * - use toTable with unique to get unique list
             * foreach to generate qualifiers
             * */

            List<qualifier> qualifiers = new List<qualifier>();
            try
            {
                DataView qview = new DataView(ds.DataValues);
                qview.RowFilter = "QualifierID is not Null";
                DataTable qids = qview.ToTable("qualifiers", true, new string[] { "QualifierID" });

                foreach (DataRow q in qids.Rows)
                {
                    try
                    {
                        Object qid = q["QualifierID"];

                        ValuesDataSet.QualifiersRow qual = ds.Qualifiers.FindByQualifierID((int)qid);
                        if (qual != null)
                        {
                            qualifier qt = new qualifier();
                            qt.qualifierID = qual.QualifierID.ToString();
                            
                            if (!qual.IsQualifierCodeNull()) qt.qualifierCode = qual.QualifierCode;
                            if (!String.IsNullOrEmpty(qual.QualifierDescription)) qt.Value = qual.QualifierDescription;
                            qualifiers.Add(qt);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("Error generating a qualifier " + q.ToString() + e.Message);
                    }
                }
                return qualifiers;
            }

            catch (Exception e)
            {
                log.Error("Error generating a qualifiers " + e.Message);
                // non fatal exceptions
                return null;
            }
        }

        /// <summary>
        /// Method to generate a list of qualifiers in a ValuesDataSet
        /// This is done as a separate method since Values can could contain other VariableValue Types
        ///
        /// </summary>
        /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
        /// <returns></returns>
        public static List<MethodType> datasetMethods(ValuesDataSet ds)
        {
            /* generate a list
             * create a distinct DataSet
             * - new data view
             * - set filter (no nulls)
             * - use toTable with unique to get unique list
             * foreach to generate qualifiers
             * */
            string COLUMN = "MethodID";
            string TABLENAME = "methods";
            List<MethodType> list = new List<MethodType>();
            try
            {
                DataView view = new DataView(ds.DataValues);
                view.RowFilter = COLUMN + " is not Null";
                DataTable ids = view.ToTable(TABLENAME, true, new string[] { COLUMN });

                foreach (DataRow r in ids.Rows)
                {
                    try
                    {
                        Object aId = r[COLUMN];
                        // edit here
                        ValuesDataSet.MethodsRow method = ds.Methods.FindByMethodID((int)aId);
                        if (method != null)
                        {
                            MethodType t = new MethodType();
                            t.methodID = method.MethodID;
                            t.methodIDSpecified = true;
                            if (!String.IsNullOrEmpty(method.MethodDescription)) t.MethodDescription = method.MethodDescription;
                            if (!method.IsMethodLinkNull()) t.MethodLink = method.MethodLink;
                            list.Add(t);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("Error generating a qualifier " + r.ToString() + e.Message);
                    }
                }
                return list;
            }

            catch (Exception e)
            {
                log.Error("Error generating a qualifiers " + e.Message);
                // non fatal exceptions
                return null;
            }
        }

        /// <summary>
        /// Method to generate a list of Sources in a ValuesDataSet
        /// This is done as a separate method since Values can could contain other VariableValue Types
        ///
        /// </summary>
        /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
        /// <returns></returns>
        public static List<SourceType> datasetSources(ValuesDataSet ds)
        {
            /* generate a list
             * create a distinct DataSet
             * - new data view
             * - set filter (no nulls)
             * - use toTable with unique to get unique list
             * foreach to generate qualifiers
             * */
            string COLUMN = "SourceID";
            string TABLENAME = "sources";
            List<SourceType> list = new List<SourceType>();
            try
            {
                DataView view = new DataView(ds.DataValues);
                view.RowFilter = COLUMN + " is not Null";
                DataTable ids = view.ToTable(TABLENAME, true, new string[] { COLUMN });

                foreach (DataRow r in ids.Rows)
                {
                    try
                    {
                        Object aId = r[COLUMN];
                        // edit here
                        ValuesDataSet.SourcesRow source = ds.Sources.FindBySourceID((int)aId);
                        if (source != null)
                        {
                            SourceType t = new SourceType();
                            t.sourceID = source.SourceID;
                            t.sourceIDSpecified = true;
                            if (!String.IsNullOrEmpty(source.Organization)) t.Organization = source.Organization;
                            t.SourceDescription = source.SourceDescription;
                            if (!source.IsSourceLinkNull()) t.SourceLink = source.SourceLink;
                            // create a contact
                            // only one for now

                            ContactInformationType contact = new ContactInformationType();
                            contact.TypeOfContact = "main";
                            if (!String.IsNullOrEmpty(source.ContactName)) contact.ContactName = source.ContactName;
                            if (!String.IsNullOrEmpty(source.Email)) contact.Email = source.Email;
                            if (!String.IsNullOrEmpty(source.Phone)) contact.Phone = source.Phone;
                            StringBuilder address = new StringBuilder();

                            if (!String.IsNullOrEmpty(source.Address)) address.Append(source.Address + System.Environment.NewLine);
                            if (!String.IsNullOrEmpty(source.City)
                                && !String.IsNullOrEmpty(source.State)
                                && !String.IsNullOrEmpty(source.ZipCode))
                                address.AppendFormat(",{0}, {1} {2}", source.City, source.State, source.ZipCode);


                            contact.Address = address.ToString();

                            //ContactInformationType[] contacts = new ContactInformationType[1];
                            // contacts[0] = contact;
                            // t.ContactInformation = contacts;
                            t.ContactInformation = contact;
                            list.Add(t);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("Error generating a qualifier " + r.ToString() + e.Message);
                    }
                }
                return list;
            }

            catch (Exception e)
            {
                log.Error("Error generating a qualifiers " + e.Message);
                // non fatal exceptions
                return null;
            }
        }

        /// <summary>
        /// Method to generate a list of offset (from OD OffsetTypes table) in a ValuesDataSet
        /// This is done as a separate method since Values can could contain other VariableValue Types
        ///
        /// </summary>
        /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
        /// <returns></returns>
        public static List<OffsetType> datasetOffsetTypes(ValuesDataSet ds)
        {
            /* generate a list
             * create a distinct DataSet
             * - new data view
             * - set filter (no nulls)
             * - use toTable with unique to get unique list
             * foreach to generate qualifiers
             * */
            string COLUMN = "OffsetTypeID";
            string TABLENAME = "offsetTypes";
            List<OffsetType> list = new List<OffsetType>();
            try
            {
                DataView view = new DataView(ds.DataValues);
                view.RowFilter = COLUMN + " is not Null";
                DataTable ids = view.ToTable(TABLENAME, true, new string[] { COLUMN });

                foreach (DataRow r in ids.Rows)
                {
                    try
                    {
                        Object aId = r[COLUMN];
                        // edit here
                        ValuesDataSet.OffsetTypesRow offset = ds.OffsetTypes.FindByOffsetTypeID((int)aId);
                        if (offset != null)
                        {
                            OffsetType t = new OffsetType();
                            t.offsetTypeID = offset.OffsetTypeID;
                            t.offsetTypeIDSpecified = true;

                            if (!String.IsNullOrEmpty(offset.OffsetDescription)) t.offsetDescription = offset.OffsetDescription;

                            ValuesDataSet.UnitsRow offUnit = ds.Units.FindByUnitsID(offset.OffsetUnitsID);
                            string offUnitsCode;
                            string offUnitsName = null;
                            string offUnitsAbbreviation = null;
                            if (!String.IsNullOrEmpty(offUnit.UnitsAbbreviation)) offUnitsAbbreviation = offUnit.UnitsAbbreviation;
                            if (!String.IsNullOrEmpty(offUnit.UnitsName)) offUnitsName = offUnit.UnitsName;
                            if (offUnit != null)
                                t.units = CuahsiBuilder.CreateUnitsElement(
                                    null, offUnit.UnitsID.ToString(), offUnitsAbbreviation, offUnitsName);

                            list.Add(t);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("Error generating a qualifier " + r.ToString() + e.Message);
                    }
                }
                return list;
            }

            catch (Exception e)
            {
                log.Error("Error generating a qualifiers " + e.Message);
                // non fatal exceptions
                return null;
            }
        }

    }
}
