using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WaterOneFlow.Schema.v1;

namespace WaterOneFlow.Schema
{
    namespace v1
    {
        [XmlSchemaProvider("WaterMLSchema")]
        public partial class ValueSingleVariable : IXmlSerializable
        {
                       
            private const string TypeName = "ValueSingleVariable";
            public XmlSchema GetSchema()
            {
               // throw new NotImplementedException();
                Assembly asmb = Assembly.GetExecutingAssembly();
                string[] names = asmb.GetManifestResourceNames();
                Stream stream = asmb.GetManifestResourceStream("WaterOneFlowImpl.JustVariableValue.xsd");
                //string text =   new StreamReader(stream).ReadToEnd();
                //   stream.Position = 0;
                XmlSchema vsvSchema = XmlSchema.Read(stream, null);
                return vsvSchema;
        }
        //public XmlSchema GetSchema()
            //{

            //    //XmlSchema xs = Schema.GetSchema.SchemaV1_0();
            //    StringReader reader = new StringReader(ValuesSchema);
            //    XmlTextReader xmlReader = new XmlTextReader(reader);
            //    XmlSchema xs = XmlSchema.Read(reader, null);
               
            //    XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("ValueSingleVariable");
            //    XmlSchemaObject vsv = xs.Elements[xmlQualifiedName];

            //    XmlSchema vsvSchema = new XmlSchema();
            //    vsvSchema.Items.Add(vsv);
            //    return vsvSchema;
            //}

            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }

            public void WriteXml(XmlWriter writer)
            {
                
                writer.WriteStartAttribute("dateTime");
                writer.WriteRaw(dateTimeField.ToString("yyyy-MM-dd"));
                writer.WriteEndAttribute();

                if (sourceIDSpecified)
                {
                    writer.WriteStartAttribute("sourceID");
                    writer.WriteRaw(sourceIDField.ToString());
                    writer.WriteEndAttribute();
                }

                if (methodIDSpecified)
                {
                    writer.WriteStartAttribute("methodID");
                    writer.WriteRaw(methodIDField.ToString());
                    writer.WriteEndAttribute();
                }

                if (sampleIDFieldSpecified)
                {
                    writer.WriteStartAttribute("sampleID");
                    writer.WriteRaw(methodIDField.ToString());
                    writer.WriteEndAttribute();
                }

                writer.WriteValue(valueField);
            }


            public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
            {
                //// This method is called by the framework to get the schema for this type.
                //// We return an existing schema from disk.
                Assembly asmb = Assembly.GetExecutingAssembly();
                string[] names = asmb.GetManifestResourceNames();
                Stream stream = asmb.GetManifestResourceStream("WaterOneFlowImpl.JustVariableValue.xsd");
                //string text =   new StreamReader(stream).ReadToEnd();
                //   stream.Position = 0;
                XmlSchema vsvSchema = XmlSchema.Read(stream, null);

               
                xs.Add(vsvSchema);

                //XmlNameTable xmlNameTable = new NameTable();
                //XmlSchemaSet xmlSchemaSet = new XmlSchemaSet(xmlNameTable);
                //xmlSchemaSet.Add(vsvSchema);
                
                //vsvSchema.Namespaces.Add("wtr10", "http://www.cuahsi.org/waterML/1.0/");
                
                //XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(TypeName, "http://www.cuahsi.org/waterML/1.0/");
 
                ////  XmlSchemaObject vsv = vsvSchema.Elements[xmlQualifiedName];
                //XmlSchemaObject vsv = vsvSchema.SchemaTypes[xmlQualifiedName];

                ////XmlSchema vsvSchema2 = new XmlSchema();
                //vsvSchema2.Items.Add(vsv);
                //foreach (string VARIABLE in new String[]
                //                             {
                //                                 "CensorCodeEnum",
                //                                 "QualityControlLevelEnum",

                //                             })
                //{
                //    XmlQualifiedName qn = new XmlQualifiedName(VARIABLE, "http://www.cuahsi.org/waterML/1.0/");

                //    vsvSchema2.Items.Add(vsvSchema.SchemaTypes[qn]);
               
                //  }
                //foreach (var VARIABLE in new String[]
                //                             {
                                                 
                //                                 "ValueAttr","DbIdentifiers","offsetAttr"
 
                //                             })
                //{
                //    XmlQualifiedName qn = new XmlQualifiedName(VARIABLE, "http://www.cuahsi.org/waterML/1.0/");

                //    vsvSchema2.Items.Add(vsvSchema.AttributeGroups[qn]);
                //}

                //vsvSchema2.Namespaces.Add("", "http://www.cuahsi.org/waterML/1.0/");

                //xs.XmlResolver = new XmlUrlResolver();
                //xs.Add(vsvSchema2);

                return new XmlQualifiedName(TypeName, "http://www.cuahsi.org/waterML/1.0/");
            }
        }
    }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.cuahsi.org/waterML/1.0/")]
        public partial class ValueSingleVariable
        {

            private string qualifiersField;

            private CensorCodeEnum censorCodeField;

            private bool censorCodeFieldSpecified;

            private System.DateTime dateTimeField;

            private QualityControlLevelEnum qualityControlLevelField;

            private bool qualityControlLevelFieldSpecified;

            private int methodIDField;

            private bool methodIDFieldSpecified;

            private int sourceIDField;

            private bool sourceIDFieldSpecified;

            private double accuracyStdDevField;

            private bool accuracyStdDevFieldSpecified;

            private bool codedVocabularyField;

            private bool codedVocabularyFieldSpecified;

            private string codedVocabularyTermField;

            private int sampleIDField;

            private bool sampleIDFieldSpecified;

            private double offsetValueField;

            private bool offsetValueFieldSpecified;

            private int offsetTypeIDField;

            private bool offsetTypeIDFieldSpecified;

            private string offsetDescriptionField;

            private string offsetUnitsAbbreviationField;

            private string offsetUnitsCodeField;

            private string oidField;

            private System.DateTime metadataDateTimeField;

            private bool metadataDateTimeFieldSpecified;

            private decimal valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string qualifiers
            {
                get
                {
                    return this.qualifiersField;
                }
                set
                {
                    this.qualifiersField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public CensorCodeEnum censorCode
            {
                get
                {
                    return this.censorCodeField;
                }
                set
                {
                    this.censorCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool censorCodeSpecified
            {
                get
                {
                    return this.censorCodeFieldSpecified;
                }
                set
                {
                    this.censorCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public System.DateTime dateTime
            {
                get
                {
                    return this.dateTimeField;
                }
                set
                {
                    this.dateTimeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public QualityControlLevelEnum qualityControlLevel
            {
                get
                {
                    return this.qualityControlLevelField;
                }
                set
                {
                    this.qualityControlLevelField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool qualityControlLevelSpecified
            {
                get
                {
                    return this.qualityControlLevelFieldSpecified;
                }
                set
                {
                    this.qualityControlLevelFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int methodID
            {
                get
                {
                    return this.methodIDField;
                }
                set
                {
                    this.methodIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool methodIDSpecified
            {
                get
                {
                    return this.methodIDFieldSpecified;
                }
                set
                {
                    this.methodIDFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int sourceID
            {
                get
                {
                    return this.sourceIDField;
                }
                set
                {
                    this.sourceIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool sourceIDSpecified
            {
                get
                {
                    return this.sourceIDFieldSpecified;
                }
                set
                {
                    this.sourceIDFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public double accuracyStdDev
            {
                get
                {
                    return this.accuracyStdDevField;
                }
                set
                {
                    this.accuracyStdDevField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool accuracyStdDevSpecified
            {
                get
                {
                    return this.accuracyStdDevFieldSpecified;
                }
                set
                {
                    this.accuracyStdDevFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool codedVocabulary
            {
                get
                {
                    return this.codedVocabularyField;
                }
                set
                {
                    this.codedVocabularyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool codedVocabularySpecified
            {
                get
                {
                    return this.codedVocabularyFieldSpecified;
                }
                set
                {
                    this.codedVocabularyFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string codedVocabularyTerm
            {
                get
                {
                    return this.codedVocabularyTermField;
                }
                set
                {
                    this.codedVocabularyTermField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int sampleID
            {
                get
                {
                    return this.sampleIDField;
                }
                set
                {
                    this.sampleIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool sampleIDSpecified
            {
                get
                {
                    return this.sampleIDFieldSpecified;
                }
                set
                {
                    this.sampleIDFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public double offsetValue
            {
                get
                {
                    return this.offsetValueField;
                }
                set
                {
                    this.offsetValueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool offsetValueSpecified
            {
                get
                {
                    return this.offsetValueFieldSpecified;
                }
                set
                {
                    this.offsetValueFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int offsetTypeID
            {
                get
                {
                    return this.offsetTypeIDField;
                }
                set
                {
                    this.offsetTypeIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool offsetTypeIDSpecified
            {
                get
                {
                    return this.offsetTypeIDFieldSpecified;
                }
                set
                {
                    this.offsetTypeIDFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string offsetDescription
            {
                get
                {
                    return this.offsetDescriptionField;
                }
                set
                {
                    this.offsetDescriptionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string offsetUnitsAbbreviation
            {
                get
                {
                    return this.offsetUnitsAbbreviationField;
                }
                set
                {
                    this.offsetUnitsAbbreviationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string offsetUnitsCode
            {
                get
                {
                    return this.offsetUnitsCodeField;
                }
                set
                {
                    this.offsetUnitsCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
            public string oid
            {
                get
                {
                    return this.oidField;
                }
                set
                {
                    this.oidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public System.DateTime metadataDateTime
            {
                get
                {
                    return this.metadataDateTimeField;
                }
                set
                {
                    this.metadataDateTimeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool metadataDateTimeSpecified
            {
                get
                {
                    return this.metadataDateTimeFieldSpecified;
                }
                set
                {
                    this.metadataDateTimeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public decimal Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
    }

