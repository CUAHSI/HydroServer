using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text;
using log4net;
using WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_1;
using tableSpace = WaterOneFlow.odm.v1_1.ValuesDataSetTableAdapters;
using VariableParam = WaterOneFlowImpl.VariableParam;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    using DataValuesTableAdapter = tableSpace.DataValuesTableAdapter;
    using UnitsTableAdapter = tableSpace.UnitsTableAdapter;
    using OffsetTypesTableAdapter = tableSpace.OffsetTypesTableAdapter;
    using QualityControlLevelsTableAdapter = tableSpace.QualityControlLevelsTableAdapter;
    using MethodsTableAdapter = tableSpace.MethodsTableAdapter;
    using SamplesTableAdapter = tableSpace.SamplesTableAdapter;
    using SourcesTableAdapter = tableSpace.SourcesTableAdapter;


    namespace v1_1
    {
        /// <summary>
        /// Summary description for ODValues
        /// </summary>
        public class ODValues
        {
            private static readonly ILog log = LogManager.GetLogger(typeof (ODValues));

            public ODValues()
            {
                //
                // TODO: Add constructor logic here
                //
            }


            public static ValuesDataSet GetValuesDataSet(int siteID)
            {
                ValuesDataSet ds = basicValuesDataSet();

                DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
                valuesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                try
                {
                    valuesTableAdapter.FillBySiteID(ds.DataValues, siteID);
                }
                catch (Exception e)
                {
                    log.Fatal("Cannot retrieve information from database: " + e.Message);
                        //+ valuesTableAdapter.Connection.DataSource
                }


                return ds;
            }

            public static ValuesDataSet GetValuesDataSet(int siteID, W3CDateTime BeginDateTime, W3CDateTime EndDateTime)
            {
                ValuesDataSet ds = basicValuesDataSet();

                DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
                valuesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                try
                {
                    valuesTableAdapter.FillBySiteIDBetweenDates(ds.DataValues, siteID, BeginDateTime.DateTime,
                                                                EndDateTime.DateTime);
                }
                catch (Exception e)
                {
                    log.Fatal("Cannot retrieve information from database: " + e.Message);
                        //+ valuesTableAdapter.Connection.DataSource
                }


                return ds;
            }

            public static ValuesDataSet GetValuesDataSet(int? siteID, int? VariableID)
            {
                ValuesDataSet ds = basicValuesDataSet();
                if (!siteID.HasValue || !VariableID.HasValue) return ds;
                DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
                valuesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                valuesTableAdapter.FillBySiteIDVariableID(ds.DataValues, siteID.Value, VariableID.Value);

                return ds;
            }

            public static ValuesDataSet GetValuesDataSet(int? siteID, int? VariableID, W3CDateTime BeginDateTime,
                                                         W3CDateTime EndDateTime)
            {
                ValuesDataSet ds = basicValuesDataSet();
                if (!siteID.HasValue || !VariableID.HasValue) return ds;
                DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
                valuesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                valuesTableAdapter.FillBySiteIdVariableIDBetweenDates(ds.DataValues, siteID.Value, VariableID.Value,
                                                                      BeginDateTime.DateTime, EndDateTime.DateTime);

                return ds;
            }

            #region odm 1 series based

            public static ValuesDataSet GetValueDataSet(int? siteID, int? VariableID, int? MethodID, int? SourceID,
                                                        int? QualityControlLevelID, W3CDateTime BeginDateTime,
                                                        W3CDateTime EndDateTime)
            {
                ValuesDataSet ds = basicValuesDataSet();
                if (!siteID.HasValue || !VariableID.HasValue) return ds;
                DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();
                valuesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                valuesTableAdapter.FillBySiteIdVariableIDBetweenDates(ds.DataValues, siteID.Value, VariableID.Value,
                                                                      BeginDateTime.DateTime, EndDateTime.DateTime);

                return ds;
            }

            //public static ValuesDataSet GetValueDataSet(int? siteID, int? VariableID, int? MethodID, int? SourceID, int? QualityControlLevelID)
            //{
            //    ValuesDataSet ds = basicValuesDataSet();
            //    if (!siteID.HasValue || !VariableID.HasValue) return ds;
            //    ValuesDataSetTableAdapters.DataValuesTableAdapter valuesTableAdapter = new DataValuesTableAdapter();

            //    valuesTableAdapter.FillBySiteIdVariableIDBetweenDates(ds.DataValues, siteID.Value, VariableID.Value, BeginDateTime.DateTime, EndDateTime.DateTime);

            //    return ds;
            //}

            #endregion

            // fills dataset with basic tables
            private static ValuesDataSet basicValuesDataSet()
            {
                ValuesDataSet ds = new ValuesDataSet();

                UnitsTableAdapter unitsTableAdapter =
                    new UnitsTableAdapter();
                unitsTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                OffsetTypesTableAdapter offsetTypesTableAdapter =
                    new OffsetTypesTableAdapter();
                offsetTypesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                QualityControlLevelsTableAdapter qualityControlLevelsTableAdapter =
                    new QualityControlLevelsTableAdapter();
                qualityControlLevelsTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                MethodsTableAdapter methodsTableAdapter =
                    new MethodsTableAdapter();
                methodsTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                SamplesTableAdapter samplesTableAdapter =
                    new SamplesTableAdapter();
                samplesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();


                SourcesTableAdapter sourcesTableAdapter =
                    new SourcesTableAdapter();
                sourcesTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                QualifiersTableAdapter qualifiersTableAdapter =
                    new QualifiersTableAdapter();
                qualifiersTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                CensorCodeCVTableAdapter censorCodeCvTableAdapter =
                    new CensorCodeCVTableAdapter();
                censorCodeCvTableAdapter.Connection.ConnectionString = odws.Config.ODDB();

                ISOMetadataTableAdapter IsoMetadataTableAdapter =
     new ISOMetadataTableAdapter();
                IsoMetadataTableAdapter.Connection.ConnectionString = odws.Config.ODDB();


                unitsTableAdapter.Fill(ds.Units);
                offsetTypesTableAdapter.Fill(ds.OffsetTypes);
                qualityControlLevelsTableAdapter.Fill(ds.QualityControlLevels);
                methodsTableAdapter.Fill(ds.Methods);
                samplesTableAdapter.Fill(ds.Samples);
                sourcesTableAdapter.Fill(ds.Sources);
                qualifiersTableAdapter.Fill(ds.Qualifiers);
                censorCodeCvTableAdapter.Fill(ds.CensorCodeCV);
                IsoMetadataTableAdapter.Fill(ds.ISOMetadata);

                return ds;
            }


            public static IEnumerable<ValueSingleVariable> dataset2ValuesList(ValuesDataSet ds, VariableParam variable, int? VariableId, VariablesDataset variablesDs)
            {
                Boolean variableIsCategorical = false;
                VariableInfoType variableInfoType = ODvariables.GetVariableByID(VariableId, variablesDs);
                if (variableInfoType != null && variableInfoType.dataType.Equals("Categorical"))
                {
                    variableIsCategorical = true;
                }

                /* logic
                 * if there is a variable that has options, then get a set of datarows
                 * using a select clause
                 * use an enumerator, since it is generic
                 * */

                IEnumerator dataValuesEnumerator; // = ds.DataValues.GetEnumerator();

                ValuesDataSet.DataValuesRow[] dvRows; // if we find options, we need to use this.

                String select = OdValuesCommon.CreateValuesWhereClause(variable, VariableId);

                if (select.Length > 0)
                {
                    dvRows = (ValuesDataSet.DataValuesRow[]) ds.DataValues.Select(select.ToString());

                    dataValuesEnumerator = dvRows.GetEnumerator();
                }
                else
                {
                    dataValuesEnumerator = ds.DataValues.GetEnumerator();
                }

                while (dataValuesEnumerator.MoveNext())
                {
                    ValuesDataSet.DataValuesRow aRow = (ValuesDataSet.DataValuesRow) dataValuesEnumerator.Current;
                    ValueSingleVariable tsTypeValue = new ValueSingleVariable();
                    Boolean goodValue = false;
                    try
                    {
                        tsTypeValue.dateTime = Convert.ToDateTime(aRow.DateTime);
                        
                        DateTime temprealdate;

                        TimeSpan zone = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                        Double offset = Convert.ToDouble(aRow.UTCOffset);
                        if (zone.TotalHours.Equals(offset))
                        {
                            temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTime),
                                                                DateTimeKind.Local);
                        }
                        else
                        {
                            temprealdate = DateTime.SpecifyKind(Convert.ToDateTime(aRow.DateTime), DateTimeKind.Utc);

                            temprealdate = temprealdate.AddHours(offset);
                        }
                        temprealdate = Convert.ToDateTime(aRow.DateTime);
                        tsTypeValue.dateTime = temprealdate;


                        tsTypeValue.dateTimeUTC = aRow.DateTimeUTC;
                        tsTypeValue.dateTimeUTCSpecified = true;
                        tsTypeValue.timeOffset = OffsetDoubleToHoursMinutesString(aRow.UTCOffset);
                       
                        //tsTypeValue.dateTime = new DateTimeOffset(temprealdate);
                        //tsTypeValue.dateTimeSpecified = true;


                        if (string.IsNullOrEmpty(aRow.Value.ToString()))
                            continue;
                        else
                            tsTypeValue.Value = Convert.ToDecimal(aRow.Value);

                        try
                        {
                            tsTypeValue.censorCode =
                                aRow.CensorCode;
                            if (!aRow.IsOffsetTypeIDNull())
                            {
                                //tsTypeValue.offsetTypeID = aRow.OffsetTypeID.ToString();
                               tsTypeValue.offsetTypeCode = aRow.OffsetTypeID.ToString();
 
                                // HIS-97 moved to OffsetUnitsType
                            //      ValuesDataSet.OffsetTypesRow off =
                            //        ds.OffsetTypes.FindByOffsetTypeID(aRow.OffsetTypeID);
                            //    ValuesDataSet.UnitsRow offUnit = ds.Units.FindByUnitsID(off.OffsetUnitsID);
                            //    tsTypeValue.offsetUnitsCode = offUnit.UnitsID.ToString();
                            //    tsTypeValue.offsetUnitsAbbreviation = offUnit.UnitsAbbreviation;
                            }
                        
                            // offset value may be separate from the units... anticpating changes for USGS
                            if (!aRow.IsOffsetValueNull())
                            {
                                tsTypeValue.offsetValue = aRow.OffsetValue;
                                tsTypeValue.offsetValueSpecified = true;
                            }

                            ValuesDataSet.MethodsRow meth = ds.Methods.FindByMethodID(aRow.MethodID);
                           // tsTypeValue.methodID = aRow.MethodID.ToString();
                            tsTypeValue.methodCode = aRow.MethodID.ToString();

                            // qualifiers
                            if (!aRow.IsQualifierIDNull())
                            {
                                ValuesDataSet.QualifiersRow qual = ds.Qualifiers.FindByQualifierID(aRow.QualifierID);
                                if (qual != null)
                                {
                                    tsTypeValue.qualifiers = qual.QualifierCode;
                                }
                            }
                            
                            //  quality control level 
 
                            ValuesDataSet.QualityControlLevelsRow qcl =
                                ds.QualityControlLevels.FindByQualityControlLevelID(aRow.QualityControlLevelID);
                            string qlName = qcl.Definition.Replace(" ", "");
                            tsTypeValue.qualityControlLevelCode = qcl.QualityControlLevelCode;
                            //if (!String.IsNullOrEmpty(qlName))
                            //{
                            //    tsTypeValue.qualityControlLevel = qlName;
                            //}

                            
                           // tsTypeValue.sourceID = aRow.SourceID.ToString();
                             tsTypeValue.sourceCode = aRow.SourceID.ToString();

                            if (!aRow.IsSampleIDNull())
                            {
                                //tsTypeValue.sampleID = aRow.SampleID.ToString();
                                ValuesDataSet.SamplesRow lsc = ds.Samples.FindBySampleID(aRow.SampleID);
                                tsTypeValue.labSampleCode = lsc.LabSampleCode;
                            }

                            // categorical
                            if (variableIsCategorical && VariableId.HasValue)
                            {
                                  tsTypeValue.codedVocabularyTerm = ODvariables.GetCategoryTerm(VariableId.Value, tsTypeValue.Value, variablesDs);
                                  if (!String.IsNullOrEmpty(tsTypeValue.codedVocabularyTerm) )
                                  {
                                      tsTypeValue.codedVocabulary = true;
                                  }
                                tsTypeValue.codedVocabularySpecified = true;

                            }
                        }
                        catch (Exception e)
                        {
                            log.Debug("Error generating a value " + e.Message);
                            // non fatal exceptions
                        }
                        goodValue = true;

                    }
                    catch (Exception e)
                    {
                        goodValue = false;
                        // If there is an error, we do not add it.
                    }

                    if (goodValue)
                    {
                        yield return tsTypeValue;
                    }
                }

            }
            
            private static string OffsetDoubleToHoursMinutesString(double offset)
            {
                double hours = System.Math.Floor(offset);
                double minutes = System.Math.Floor((offset - hours)*60);
                String hhmm = String.Format("{0:+00;-00;+00}:{1:00}", hours, minutes);
                return hhmm;
            }


            /// <summary>
            /// Method to generate a list of qualifiers in a ValuesDataSet
            /// This is done as a separate method since Values can could contain other VariableValue Types
            ///
            /// </summary>
            /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
            /// <param name="valuesWhereClause"></param>
            /// <returns></returns>
            public static List<QualifierType> datasetQualifiers(ValuesDataSet ds, string valuesWhereClause)
            {
                /* generate a list
                 * create a distinct DataSet
                 * - new data view
                 * - set filter (no nulls)
                 * - use toTable with unique to get unique list
                 * foreach to generate qualifiers
                 * */

                List<QualifierType> qualifiers = new List<QualifierType>();
                try
                {
                    DataView qview = new DataView(ds.DataValues);
                    qview.RowFilter = valuesWhereClause;
                    
                    DataTable qids = qview.ToTable("Qualifiers", true, new string[] {"QualifierID"});

                    foreach (DataRow q in qids.Rows)
                    {
                        try
                        {


                            if (q["QualifierID"]==DBNull.Value)
                            {
                                continue;
                            }
                            int? qid = Convert.ToInt32(q["QualifierID"]);
                            ValuesDataSet.QualifiersRow qual = ds.Qualifiers.FindByQualifierID((int) qid.Value);
                            if (qual != null)
                            {
                                QualifierType qt = new QualifierType();
                                qt.qualifierID = qual.QualifierID;
                                if (!qual.IsQualifierCodeNull())
                                {
                                    qt.qualifierCode = qual.QualifierCode;
                                } else
                                {
                                    qt.qualifierCode = qual.QualifierID.ToString();
                                }
                                if (!String.IsNullOrEmpty(qual.QualifierDescription))
                                    qt.qualifierDescription = qual.QualifierDescription;
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
            /// <param name="valuesWhereClause"></param>
            /// <returns></returns>
            public static List<MethodType> datasetMethods(ValuesDataSet ds, string valuesWhereClause)
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
                    view.RowFilter = valuesWhereClause;
                    
                    DataTable ids = view.ToTable(TABLENAME, true, new string[] {COLUMN});

                    foreach (DataRow r in ids.Rows)
                    {
                        try
                        {
                            //Object aId = r[COLUMN];

                            if (r[COLUMN] == DBNull.Value)
                            {
                                continue;
                            } 
                            int? aId = Convert.ToInt32(r[COLUMN]);
                            // edit here
                            ValuesDataSet.MethodsRow method = ds.Methods.FindByMethodID((int) aId.Value);
                            if (method != null)
                            {
                                MethodType t = new MethodType();
                                t.methodID = method.MethodID;
                                t.methodIDSpecified = true;

                                t.methodCode = method.MethodID.ToString();

                                if (!String.IsNullOrEmpty(method.MethodDescription))
                                    t.methodDescription = method.MethodDescription;
                                if (!method.IsMethodLinkNull()) t.methodLink = method.MethodLink;
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
            ///  generate a list of CensorCodes 
            /// This is done as a separate method since Values can could contain other VariableValue Types
            ///
            /// </summary>
            /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
            /// <param name="valuesWhereClause"></param>
            /// <returns></returns>
            public static IEnumerable<CensorCodeType> datasetCensorCodes(ValuesDataSet ds, string valuesWhereClause)
            {
                /* generate a list
                 * create a distinct DataSet
                 * - new data view
                 * - set filter (no nulls)
                 * - use toTable with unique to get unique list
                 * foreach to generate qualifiers
                 * */
                string COLUMN = "CensorCode";
                string TABLENAME = "CensorCodeCV";
                DataView view = new DataView(ds.DataValues);
                view.RowFilter = valuesWhereClause;

                DataTable ids = view.ToTable(TABLENAME, true, new string[] { COLUMN });
                foreach (DataRow r in ids.Rows)
                {
                          //Object aId = r[COLUMN];

                        if (r[COLUMN] == DBNull.Value)
                        {
                            continue;
                        }
                        string aId = (string)r[COLUMN];
                        // edit here
                        ValuesDataSet.CensorCodeCVRow codeCvRow = ds.CensorCodeCV.FindByTerm(aId);
                        if (codeCvRow != null)
                        {
                            CensorCodeType t = new CensorCodeType();
                            t.censorCode = codeCvRow.Term;

                            if (!codeCvRow.IsDefinitionNull() && !String.IsNullOrEmpty(codeCvRow.Definition))
                            {
                                t.censorCodeDescription = codeCvRow.Definition;
                            }

                            yield return t;
                        }
               }
                //foreach (ValuesDataSet.CensorCodeCVRow r in ds.CensorCodeCV.Rows)
                //{
                //    CensorCodeType t = new CensorCodeType();
                //    t.censorCode = r.Term;
                    
                //    if (!r.IsDefinitionNull() && !String.IsNullOrEmpty(r.Definition))
                //    {
                //          t.censorCodeDescription = r.Definition;
                //    }
                      
                //   yield return t;
                //}
            }
            /// <summary>
            /// Method to generate a list of Sources in a ValuesDataSet
            /// This is done as a separate method since Values can could contain other VariableValue Types
            ///
            /// </summary>
            /// <param name="ds">ValuesDataSet with the values used in the timeSeries</param>
            /// <returns></returns>
            public static List<SourceType> datasetSources(ValuesDataSet ds, string valuesWhereClause)
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
                    view.RowFilter = valuesWhereClause;
             
                    DataTable ids = view.ToTable(TABLENAME, true, new string[] {COLUMN});

                    foreach (DataRow r in ids.Rows)
                    {
                        try
                        {
                            //Object aId = r[COLUMN];
                            
                            if (r[COLUMN] == DBNull.Value)
                            {
                                continue;
                            }
                            int? aId = Convert.ToInt32(r[COLUMN]);
                            ValuesDataSet.SourcesRow source = ds.Sources.FindBySourceID((int) aId.Value);
                            if (source != null)
                            {
                                SourceType t = new SourceType();
                                t.sourceID = source.SourceID;
                                t.sourceIDSpecified = true;

                                t.sourceCode = source.SourceID.ToString();

                                if (!String.IsNullOrEmpty(source.Organization)) t.organization = source.Organization;
                                t.sourceDescription = source.SourceDescription;
                                if (!source.IsSourceLinkNull())
                                {
                                    t.sourceLink = new string[] {source.SourceLink};
                                }

                                // create a contact
                                // only one for now
                                ContactInformationType contact = new ContactInformationType();
                                contact.typeOfContact = "main";
                                if (!String.IsNullOrEmpty(source.ContactName)) contact.contactName = source.ContactName;
                                if (!String.IsNullOrEmpty(source.Email))
                                {
                                    contact.email = new string[] {source.Email};
                                }
                                if (!String.IsNullOrEmpty(source.Phone))
                                {
                                    contact.phone = new string[] {source.Phone};
                                }
                                StringBuilder address = new StringBuilder();

                                if (!String.IsNullOrEmpty(source.Address))
                                    address.Append(source.Address + System.Environment.NewLine);
                                if (!String.IsNullOrEmpty(source.City)
                                    && !String.IsNullOrEmpty(source.State)
                                    && !String.IsNullOrEmpty(source.ZipCode))
                                    address.AppendFormat(",{0}, {1} {2}", source.City, source.State, source.ZipCode);


                                contact.address = new string[] {address.ToString()};
                                t.contactInformation = new ContactInformationType[] {contact};

                                if (!String.IsNullOrEmpty(source.Citation))
                                {
                                    t.citation = source.Citation;
                                }

                                if (source.MetadataID != 0 && source.ISOMetadataRow != null)
                                {
                                    MetaDataType m= new MetaDataType();
                                    m.topicCategory = source.ISOMetadataRow.TopicCategory;
                                    m.title = source.ISOMetadataRow.Title;
                                    m.@abstract = source.ISOMetadataRow.Abstract;
                                    m.profileVersion = source.ISOMetadataRow.ProfileVersion;
                                    if (!source.ISOMetadataRow.IsMetadataLinkNull())
                                    {
                                        m.metadataLink = source.ISOMetadataRow.MetadataLink;

                                    }
                                    t.metadata = m;
                                }
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
            public static List<OffsetType> datasetOffsetTypes(ValuesDataSet ds, string valuesWhereClause)
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
                    view.RowFilter = valuesWhereClause;
                 
                    DataTable ids = view.ToTable(TABLENAME, true, new string[] {COLUMN});

                    foreach (DataRow r in ids.Rows)
                    {
                        try
                        {
                            //Object aId = r[COLUMN];

                            if (r[COLUMN] == DBNull.Value)
                            {
                                continue;
                            }
int? aId = Convert.ToInt32(r[COLUMN]);
                            // edit here
                            ValuesDataSet.OffsetTypesRow offset = ds.OffsetTypes.FindByOffsetTypeID((int) aId.Value);
                            if (offset != null)
                            {
                                OffsetType t = new OffsetType();
                                t.offsetTypeID = offset.OffsetTypeID;
                                t.offsetTypeIDSpecified = true;

                                t.offsetTypeCode = t.offsetTypeID.ToString();

                                if (!String.IsNullOrEmpty(offset.OffsetDescription))
                                    t.offsetDescription = offset.OffsetDescription;

                                ValuesDataSet.UnitsRow offUnit = ds.Units.FindByUnitsID(offset.OffsetUnitsID);
                                string offUnitsCode;
                                
                                string offUnitsName = null;
                                string offUnitsAbbreviation = null;
                                if (!String.IsNullOrEmpty(offUnit.UnitsAbbreviation))
                                    offUnitsAbbreviation = offUnit.UnitsAbbreviation;
                                if (!String.IsNullOrEmpty(offUnit.UnitsName)) offUnitsName = offUnit.UnitsName;
                                if (offUnit != null)
                                    t.unit = CuahsiBuilder.CreateUnitsElement(
                                        offUnit.UnitsType, offUnit.UnitsID.ToString(), offUnitsAbbreviation,
                                        offUnitsName);

                                list.Add(t);
                            }
                        }
                        catch (Exception e)
                        {
                            log.Error("Error generating a offsetTypes " + r.ToString() + e.Message);
                        }
                    }
                    return list;
                }

                catch (Exception e)
                {
                    log.Error("Error generating a offsetTypes " + e.Message);
                    // non fatal exceptions
                    return null;
                }
            }

            public static List<SampleType> datasetSamples(ValuesDataSet ds, string valuesWhereClause)
            {
                /* generate a list
                 * create a distinct DataSet
                 * - new data view
                 * - set filter (no nulls)
                 * - use toTable with unique to get unique list
                 * foreach to generate qualifiers
                 * */
                string COLUMN = "SampleID";
                string TABLENAME = "Sample";
                List<SampleType> list = new List<SampleType>();
                try
                {
                    DataView view = new DataView(ds.DataValues);
                    view.RowFilter = valuesWhereClause;
                   
                    DataTable ids = view.ToTable(TABLENAME, true, new string[] {COLUMN});

                    foreach (DataRow r in ids.Rows)
                    {
                        try
                        {
                            //Object aId = r[COLUMN];

                            if (r[COLUMN] == DBNull.Value)
                            {
                                continue;
                            }
                            int? aId = Convert.ToInt32(r[COLUMN]);
                            // edit here
                            ValuesDataSet.SamplesRow samples = ds.Samples.FindBySampleID((int) aId.Value);
                            if (samples != null)
                            {
                                SampleType t = new SampleType();
                                t.sampleID = samples.SampleID;
                                t.sampleIDSpecified = true;
                                t.labSampleCode = samples.LabSampleCode;
                                if (!String.IsNullOrEmpty(samples.SampleType)) t.sampleType = samples.SampleType;

                                LabMethodType labMethod = new LabMethodType();

                                labMethod.labMethodName = samples.LabMethodName;
                                labMethod.labName = samples.LabName;
                                labMethod.labOrganization = samples.LabOrganization;
                                labMethod.labCode = samples.LabSampleCode;
                                labMethod.labMethodDescription = samples.LabMethodDescription;
                                if (!samples.IsLabMethodLinkNull())
                                {
                                    labMethod.labMethodLink = samples.LabMethodLink;
                                }

                                t.labMethod = labMethod;


                                list.Add(t);
                            }
                        }
                        catch (Exception e)
                        {
                            log.Error("Error generating a Samples " + r.ToString() + e.Message);
                        }
                    }
                    return list;
                }

                catch (Exception e)
                {
                    log.Error("Error generating a Samples " + e.Message);
                    // non fatal exceptions
                    return null;
                }
            }

            public static List<QualityControlLevelType> DatasetQCLevels(ValuesDataSet ds, string valuesWhereClause)
            {
                /* generate a list
                 * create a distinct DataSet
                 * - new data view
                 * - set filter (no nulls)
                 * - use toTable with unique to get unique list
                 * foreach to generate qualifiers
                 * */
                string COLUMN = "QualityControlLevelID";
                string TABLENAME = "QualityControlLevels";
                List<QualityControlLevelType> list = new List<QualityControlLevelType>();
                try
                {
                    DataView view = new DataView(ds.DataValues);
                    view.RowFilter = valuesWhereClause;
                  
                    DataTable ids = view.ToTable(TABLENAME, true, new string[] {COLUMN});

                    foreach (DataRow r in ids.Rows)
                    {
                        try
                        {
                           // Object aId = r[COLUMN];

                            if (r[COLUMN] == DBNull.Value)
                            {
                                continue;
                            }
                            int? aId = Convert.ToInt32(r[COLUMN]);
                            // edit here
                            ValuesDataSet.QualityControlLevelsRow qcLevels =
                                ds.QualityControlLevels.FindByQualityControlLevelID((int) aId.Value);
                            if (qcLevels != null)
                            {
                                QualityControlLevelType t = new QualityControlLevelType();
                                t.qualityControlLevelID = qcLevels.QualityControlLevelID;
                                t.qualityControlLevelIDSpecified = true;
                                t.qualityControlLevelCode = qcLevels.QualityControlLevelCode;
                                t.definition = qcLevels.Definition;
                                t.explanation = qcLevels.Explanation;


                                list.Add(t);
                            }
                        }
                        catch (Exception e)
                        {
                            log.Error("Error generating a QualityControlLevels " + r.ToString() + e.Message);
                        }
                    }
                    return list;
                }

                catch (Exception e)
                {
                    log.Error("Error generating a QualityControlLevels " + e.Message);
                    // non fatal exceptions
                    return null;
                }
            }
        }
    }
}