<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml.Serialization" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Xml.Schema" %>
<%@ Import Namespace="System.Web.Services.Description" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Resources" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Data" %>

<html>

    <script language="C#" runat="server" trace="true">

    // set this to true if you want to see a POST test form instead of a GET test form
    //bool showPost = false;

    // set this to true if you want to see the raw XML as outputted from the XmlWriter (useful for debugging)
    bool dontFilterXml = false;
    
    // set this higher or lower to adjust the depth into your object graph of the sample messages
    int maxObjectGraphDepth = 10;

    // set this higher or lower to adjust the number of array items in sample messages
    int maxArraySize = 2;

    // set this to true to see debug output in sample messages
    bool debug = false;
    
    string soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
    string soapEncNs = "http://schemas.xmlsoap.org/soap/encoding/";
    string msTypesNs = "http://microsoft.com/wsdl/types/";
    string wsdlNs = "http://schemas.xmlsoap.org/wsdl/";

    string urType = "anyType";

    ServiceDescriptionCollection serviceDescriptions;
        ServiceCollection _replacedServices;
    XmlSchemas schemas;
    string operationName;
    OperationBinding soapOperationBinding;
    Operation soapOperation;
    OperationBinding httpGetOperationBinding;
    Operation httpGetOperation;
    OperationBinding httpPostOperationBinding;
    Operation httpPostOperation;
    StringWriter writer;
    MemoryStream xmlSrc;
    XmlTextWriter xmlWriter;
    Uri getUrl, postUrl;
    Queue referencedTypes;
    int hrefID;
    bool operationExists = false;
    int nextPrefix = 1;
    static readonly char[] hexTable = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    string OperationName {
        get { return operationName; }
    }
    
    string ServiceName { 
        get {
            if (_replacedServices == null) {
                if (serviceDescriptions[0].Services.Count == 0) {
                    return "";
                }
                else {
                    return serviceDescriptions[0].Services[0].Name;
                }
            }
            else {
                return _replacedServices[0].Name;
            }
        }
    }

    string ServiceNamespace {
        get { return serviceDescriptions[0].TargetNamespace; }
    }

    string ServiceDocumentation { 
        get {
            if (_replacedServices == null) {
                return serviceDescriptions[0].Services[0].Documentation;
            }
            else {
                return _replacedServices[0].Name;
            }
            
        }
    }

    string FileName {
        get { 
            return Path.GetFileName(Request.Path);
        }
    }

    string RelativePath {
        get { 
            return Request.ServerVariables["APPL_PHYSICAL_PATH"];
        }
    }
    
    string Url {
        get { 
			return Request.ServerVariables["URL"];
        }
    }
    
    string EscapedFileName {
        get { 
            return HttpUtility.UrlEncode(FileName, Encoding.UTF8);
        }
    }

    bool ShowingMethodList {
        get { return operationName == null; }
    }

    bool OperationExists {
        get { return operationExists; }
    }

    // encodes a Unicode string into utf-8 bytes then copies each byte into a new Unicode string,
    // escaping bytes > 0x7f, per the URI escaping rules
    static string UTF8EscapeString(string source) {
        byte[] bytes = Encoding.UTF8.GetBytes(source);
        StringBuilder sb = new StringBuilder(bytes.Length); // start out with enough room to hold each byte as a char
        for (int i = 0; i < bytes.Length; i++) {
            byte b = bytes[i];
            if (b > 0x7f) {
                sb.Append('%');
                sb.Append(hexTable[(b >> 4) & 0x0f]);
                sb.Append(hexTable[(b     ) & 0x0f]);
            }
            else
                sb.Append((char)b);
        }
        return sb.ToString();
    }

    string EscapeParam(string param) {
        return HttpUtility.UrlEncode(param, Request.ContentEncoding);
    }

    XmlQualifiedName XmlEscapeQName(XmlQualifiedName qname) {
        return new XmlQualifiedName(XmlConvert.EncodeLocalName(qname.Name), qname.Namespace);
    }

    string SoapOperationInput {
        get { 
            if (SoapOperationBinding == null) return "";
            WriteBegin();

            Port port = FindPort(SoapOperationBinding.Binding);
            if (port == null) {
                Response.Write("<!--No port found.-->");
                Response.End(); 
            }
            SoapAddressBinding soapAddress = (SoapAddressBinding)port.Extensions.Find(typeof(SoapAddressBinding));

            string action = UTF8EscapeString(((SoapOperationBinding)SoapOperationBinding.Extensions.Find(typeof(SoapOperationBinding))).SoapAction);

            Uri uri = new Uri(soapAddress.Location, false);

            Write("POST ");
            Write(uri.AbsolutePath);
            Write(" HTTP/1.1");
            WriteLine();

            Write("Host: ");
            Write(uri.Host);
            WriteLine();

            Write("Content-Type: text/xml; charset=utf-8");
            WriteLine();

            Write("Content-Length: ");
            WriteValue("length");
            WriteLine();

            Write("SOAPAction: \"");
            Write(action);
            Write("\"");
            WriteLine();

            WriteLine();
            
            WriteSoapMessage(SoapOperationBinding.Input, serviceDescriptions.GetMessage(SoapOperation.Messages.Input.Message));
            return WriteEnd();
        }
    }
    
    string SoapOperationOutput {
        get { 
            if (SoapOperationBinding == null) return "";
            WriteBegin();
            if (SoapOperationBinding.Output == null) {
                Write("HTTP/1.1 202 Accepted");
                WriteLine();
            }
            else {
                Write("HTTP/1.1 200 OK");
                WriteLine();
                Write("Content-Type: text/xml; charset=utf-8");
                WriteLine();
                Write("Content-Length: ");
                WriteValue("length");
                WriteLine();
                WriteLine();

                WriteSoapMessage(SoapOperationBinding.Output, serviceDescriptions.GetMessage(SoapOperation.Messages.Output.Message));
            }
            return WriteEnd();
        }
    }

    OperationBinding SoapOperationBinding {
        get { 
            if (soapOperationBinding == null)
                soapOperationBinding = FindBinding(typeof(SoapBinding));
            return soapOperationBinding;
        }
    }

    Operation SoapOperation {
        get { 
            if (soapOperation == null)
                soapOperation = FindOperation(SoapOperationBinding);
            return soapOperation;
        }
    }

    bool ShowingSoap {
        get { 
            return SoapOperationBinding != null; 
        }
    }

    private static string GetEncodedNamespace(string ns) {
        if (ns.EndsWith("/"))
            return ns + "encodedTypes";
        else return ns + "/encodedTypes";
    }

    void WriteSoapMessage(MessageBinding messageBinding, Message message) {
        SoapOperationBinding soapBinding = (SoapOperationBinding)SoapOperationBinding.Extensions.Find(typeof(SoapOperationBinding));
        SoapBodyBinding soapBodyBinding = (SoapBodyBinding)messageBinding.Extensions.Find(typeof(SoapBodyBinding));
        bool rpc = soapBinding != null && soapBinding.Style == SoapBindingStyle.Rpc;
        bool encoded = soapBodyBinding.Use == SoapBindingUse.Encoded;

        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("soap", "Envelope", soapNs);
        DefineNamespace("xsi", XmlSchema.InstanceNamespace);
        DefineNamespace("xsd", XmlSchema.Namespace);
        if (encoded) {
            DefineNamespace("soapenc", soapEncNs);
            string targetNamespace = message.ServiceDescription.TargetNamespace;
            DefineNamespace("tns", targetNamespace);
            DefineNamespace("types", GetEncodedNamespace(targetNamespace));
        }

        SoapHeaderBinding[] headers = (SoapHeaderBinding[])messageBinding.Extensions.FindAll(typeof(SoapHeaderBinding));
        if (headers.Length > 0) {
            xmlWriter.WriteStartElement("Header", soapNs);
            foreach (SoapHeaderBinding header in headers) {
                Message headerMessage = serviceDescriptions.GetMessage(header.Message);
                if (headerMessage != null) {
                    MessagePart part = headerMessage.Parts[header.Part];
                    if (part != null) {
                        if (encoded)
                            WriteType(part.Type, part.Type, XmlSchemaForm.Qualified, -1, 0, false);
                        else
                            WriteTopLevelElement(XmlEscapeQName(part.Element), 0);
                    }
                }
            }
            if (encoded)
                WriteQueuedTypes();
            xmlWriter.WriteEndElement();
        }
        
        xmlWriter.WriteStartElement("Body", soapNs);
        if (soapBodyBinding.Encoding != null && soapBodyBinding.Encoding != String.Empty)
            xmlWriter.WriteAttributeString("encodingStyle", soapNs, soapBodyBinding.Encoding);

        if (rpc) {
            string messageName = SoapOperationBinding.Output == messageBinding ? SoapOperation.Name + "Response" : SoapOperation.Name;
            if (encoded) {
                string prefix = null;
                if (soapBodyBinding.Namespace.Length > 0) {
                    prefix = xmlWriter.LookupPrefix(soapBodyBinding.Namespace);
                    if (prefix == null)
                        prefix = "q" + nextPrefix++;
                }
                xmlWriter.WriteStartElement(prefix, messageName, soapBodyBinding.Namespace);
            }
            else
                xmlWriter.WriteStartElement(messageName, soapBodyBinding.Namespace);
        }
        foreach (MessagePart part in message.Parts) {
            if (encoded) {
                if (rpc)
                    WriteType(new XmlQualifiedName(part.Name, soapBodyBinding.Namespace), part.Type, XmlSchemaForm.Unqualified, 0, 0, true);
                else
                    WriteType(part.Type, part.Type, XmlSchemaForm.Qualified, -1, 0, true); // id == -1 writes the definition without writing the id attr
            }
            else {
                if (!part.Element.IsEmpty)
                    WriteTopLevelElement(XmlEscapeQName(part.Element), 0);
                else
                    WriteXmlValue("xml");
            }
        }
        if (rpc) {
            xmlWriter.WriteEndElement();
        }
        if (encoded) {
            WriteQueuedTypes();
        }            
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndElement();
    }
	
    XmlSchemaType GetPartType(MessagePart part) {
        if (part.Element != null && !part.Element.IsEmpty) {
            XmlSchemaElement element = (XmlSchemaElement)schemas.Find(part.Element, typeof(XmlSchemaElement));
            if (element != null) return element.SchemaType;
            return null;
        }
        else if (part.Type != null && !part.Type.IsEmpty) {
            XmlSchemaType xmlSchemaType = (XmlSchemaType)schemas.Find(part.Type, typeof(XmlSchemaSimpleType));
            if (xmlSchemaType != null) return xmlSchemaType;
            xmlSchemaType = (XmlSchemaType)schemas.Find(part.Type, typeof(XmlSchemaComplexType));
            return xmlSchemaType;
        }
        return null;
    }

    void WriteTopLevelElement(XmlQualifiedName name, int depth) {
        WriteTopLevelElement((XmlSchemaElement)schemas.Find(name, typeof(XmlSchemaElement)), name.Namespace, depth);
    }

    void WriteTopLevelElement(XmlSchemaElement element, string ns, int depth) {
        WriteElement(element, ns, XmlSchemaForm.Qualified, false, 0, depth, false);
    }

    class QueuedType {
        internal XmlQualifiedName name;
        internal XmlQualifiedName typeName;
        internal XmlSchemaForm form;
        internal int id;
        internal int depth;
        internal bool writeXsiType;
    }

    void WriteQueuedTypes() {
        while (referencedTypes.Count > 0) {
            QueuedType q = (QueuedType)referencedTypes.Dequeue();
            WriteType(q.name, q.typeName, q.form, q.id, q.depth, q.writeXsiType);
        }
    }

    void AddQueuedType(XmlQualifiedName name, XmlQualifiedName type, int id, int depth, bool writeXsiType) {
        AddQueuedType(name, type, XmlSchemaForm.Unqualified, id, depth, writeXsiType);
    }

    void AddQueuedType(XmlQualifiedName name, XmlQualifiedName typeName, XmlSchemaForm form, int id, int depth, bool writeXsiType) {
        QueuedType q = new QueuedType();
        q.name = name;
        q.typeName = typeName;
        q.form = form;
        q.id = id;
        q.depth = depth;
        q.writeXsiType = writeXsiType;
        referencedTypes.Enqueue(q);
    }

    void WriteType(XmlQualifiedName name, XmlQualifiedName typeName, int id, int depth, bool writeXsiType) {
        WriteType(name, typeName, XmlSchemaForm.None, id, depth, writeXsiType);
    }
    
    void WriteType(XmlQualifiedName name, XmlQualifiedName typeName, XmlSchemaForm form, int id, int depth, bool writeXsiType) {
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = name.Name;
        element.MaxOccurs = 1;
        element.Form = form;
        element.SchemaTypeName = typeName;
        WriteElement(element, name.Namespace, true, id, depth, writeXsiType);
    }
    
    void WriteElement(XmlSchemaElement element, string ns, bool encoded, int id, int depth, bool writeXsiType) {
        XmlSchemaForm form = element.Form;
        if (form == XmlSchemaForm.None) {
            XmlSchema schema = schemas[ns];
            if (schema != null) form = schema.ElementFormDefault;
        }
        WriteElement(element, ns, form, encoded, id, depth, writeXsiType);
    }
    
    void WriteElement(XmlSchemaElement element, string ns, XmlSchemaForm form, bool encoded, int id, int depth, bool writeXsiType) {
        if (element == null) return;
        int count = element.MaxOccurs > 1 ? maxArraySize : 1;

        for (int i = 0; i < count; i++) {
            XmlQualifiedName elementName = (element.QualifiedName == null || element.QualifiedName.IsEmpty ? new XmlQualifiedName(element.Name, ns) : element.QualifiedName);
            if (encoded && count > 1) {
                elementName = new XmlQualifiedName("Item", null);
            }

            if (IsRef(element.RefName)) {
                WriteTopLevelElement(XmlEscapeQName(element.RefName), depth);
                continue;
            }
            
            if (encoded) {
                string prefix = null;
                if (form != XmlSchemaForm.Unqualified && elementName.Namespace.Length > 0) {
                    prefix = xmlWriter.LookupPrefix(elementName.Namespace);
                    if (prefix == null)
                        prefix = "q" + nextPrefix++;
                }
                
                if (id != 0) { // intercept array definitions
                    XmlSchemaComplexType ct = null;
                    if (IsStruct(element, out ct)) {
                        XmlQualifiedName typeName = element.SchemaTypeName;
                        XmlQualifiedName baseTypeName = GetBaseTypeName(ct);
                        if (baseTypeName != null && IsArray(baseTypeName))
                            typeName = baseTypeName;
                        if (typeName != elementName) {
                            WriteType(typeName, element.SchemaTypeName, form, id, depth, writeXsiType);
                            return;
                        }
                    }
                }
                xmlWriter.WriteStartElement(prefix, elementName.Name, form != XmlSchemaForm.Unqualified ? elementName.Namespace : "");
            }
            else
                xmlWriter.WriteStartElement(elementName.Name, form != XmlSchemaForm.Unqualified ? elementName.Namespace : "");

            XmlSchemaSimpleType simpleType = null;
            XmlSchemaComplexType complexType = null;

            if (IsPrimitive(element.SchemaTypeName)) {
                if (writeXsiType) WriteTypeAttribute(element.SchemaTypeName);
                WritePrimitive(element.SchemaTypeName);
            }
            else if (IsEnum(element.SchemaTypeName, out simpleType)) {
                if (writeXsiType) WriteTypeAttribute(element.SchemaTypeName);
                WriteEnum(simpleType);
            }
            else if (IsStruct(element, out complexType)) {
                if (depth >= maxObjectGraphDepth)
                    WriteNullAttribute(encoded);
                else if (encoded) {
                    if (id != 0) {
                        // id == -1 means write the definition without writing the id
                        if (id > 0) {
                            WriteIDAttribute(id);
                        }
                        WriteComplexType(complexType, ns, encoded, depth, writeXsiType);
                    }
                    else {
                        int href = hrefID++;
                        WriteHref(href);
                        AddQueuedType(elementName, element.SchemaTypeName, XmlSchemaForm.Qualified, href, depth, true);
                    }
                }
                else {
                    WriteComplexType(complexType, ns, encoded, depth, false);
                }
            }
            else if (IsByteArray(element, out simpleType)) {
                WriteByteArray(simpleType);
            }
            else if (IsSchemaRef(element.RefName)) {
                WriteXmlValue("schema");
            }
            else if (IsUrType(element.SchemaTypeName)) {
                WriteTypeAttribute(new XmlQualifiedName(GetXmlValue("type"), null));
            }
            else {
                if (debug) {
                    WriteDebugAttribute("error", "Unknown type");
                    WriteDebugAttribute("elementName", element.QualifiedName.ToString());
                    WriteDebugAttribute("typeName", element.SchemaTypeName.ToString());
                    WriteDebugAttribute("type", element.SchemaType != null ? element.SchemaType.ToString() : "null");
                }
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Formatting = Formatting.Indented;
        }
    }
    
    bool IsArray(XmlQualifiedName typeName) {
        return (typeName.Namespace == soapEncNs && typeName.Name == "Array");
    }

    bool IsPrimitive(XmlQualifiedName typeName) {
        return (!typeName.IsEmpty && 
                (typeName.Namespace == XmlSchema.Namespace || typeName.Namespace == msTypesNs) &&
                typeName.Name != urType);
    }

    bool IsRef(XmlQualifiedName refName) {
        return refName != null && !refName.IsEmpty && !IsSchemaRef(refName);
    }

    bool IsSchemaRef(XmlQualifiedName refName) {
        return refName != null && refName.Name == "schema" && refName.Namespace == XmlSchema.Namespace;
    }

    bool IsUrType(XmlQualifiedName typeName) {
        return (!typeName.IsEmpty && typeName.Namespace == XmlSchema.Namespace && typeName.Name == urType);
    }

    bool IsEnum(XmlQualifiedName typeName, out XmlSchemaSimpleType type) {
        XmlSchemaSimpleType simpleType = null;
        if (typeName != null && !typeName.IsEmpty) {
            simpleType = (XmlSchemaSimpleType)schemas.Find(typeName, typeof(XmlSchemaSimpleType));
            if (simpleType != null) {
                type = simpleType;
                return true;
            }
        }
        type = null;
        return false;
    }

    bool IsStruct(XmlSchemaElement element, out XmlSchemaComplexType type) {
        XmlSchemaComplexType complexType = null;

        if (!element.SchemaTypeName.IsEmpty) {
            complexType = (XmlSchemaComplexType)schemas.Find(element.SchemaTypeName, typeof(XmlSchemaComplexType));
            if (complexType != null) {
                type = complexType;
                return true;
            }
        }
        if (element.SchemaType != null && element.SchemaType is XmlSchemaComplexType) {
            complexType = element.SchemaType as XmlSchemaComplexType;
            if (complexType != null) {
                type = complexType;
                return true;
            }
        }
        type = null;
        return false;
    }

    bool IsByteArray(XmlSchemaElement element, out XmlSchemaSimpleType type) {
        if (element.SchemaTypeName.IsEmpty && element.SchemaType is XmlSchemaSimpleType) {
            type = element.SchemaType as XmlSchemaSimpleType;
            return true;
        }
        type = null;
        return false;
    }
    
    XmlQualifiedName ArrayItemType(string typeDef) {
        string ns;
        string name;

        int nsLen = typeDef.LastIndexOf(':');

        if (nsLen <= 0) {
            ns = "";
        }
        else {
            ns = typeDef.Substring(0, nsLen);
        }
        int nameLen = typeDef.IndexOf('[', nsLen + 1);

        if (nameLen <= nsLen) {
            return new XmlQualifiedName(urType, XmlSchema.Namespace);
        }
        name = typeDef.Substring(nsLen + 1, nameLen - nsLen - 1);

        return new XmlQualifiedName(name, ns);
    }

    void WriteByteArray(XmlSchemaSimpleType dataType) {
        WriteXmlValue("bytes");
    }

    void WriteEnum(XmlSchemaSimpleType dataType) {
        if (dataType.Content is XmlSchemaSimpleTypeList) { // "flags" enum -- appears inside a list
            XmlSchemaSimpleTypeList list = (XmlSchemaSimpleTypeList)dataType.Content;
            dataType = list.ItemType;
        }

        bool first = true;
        if (dataType.Content is XmlSchemaSimpleTypeRestriction) {
            XmlSchemaSimpleTypeRestriction restriction = (XmlSchemaSimpleTypeRestriction)dataType.Content;
            foreach (XmlSchemaFacet facet in restriction.Facets) {
                if (facet is XmlSchemaEnumerationFacet) {
                    if (!first) xmlWriter.WriteString(" or "); else first = false;
                    WriteXmlValue(facet.Value);
                }
            }
        }
    }
    
    void WriteArrayTypeAttribute(XmlQualifiedName type, int maxOccurs) {
        StringBuilder sb = new StringBuilder(type.Name);
        sb.Append("[");
        sb.Append(maxOccurs.ToString());
        sb.Append("]");
        string prefix = DefineNamespace("q1", type.Namespace);
        XmlQualifiedName typeName = new XmlQualifiedName(sb.ToString(), prefix);
        xmlWriter.WriteAttributeString("arrayType", soapEncNs, typeName.ToString());
    }

    void WriteTypeAttribute(XmlQualifiedName type) {
        string prefix = DefineNamespace("s0", type.Namespace);
        xmlWriter.WriteStartAttribute("type", XmlSchema.InstanceNamespace);
        xmlWriter.WriteString(new XmlQualifiedName(type.Name, prefix).ToString());
        xmlWriter.WriteEndAttribute();
    }

    void WriteNullAttribute(bool encoded) {
        if (encoded)
            xmlWriter.WriteAttributeString("null", XmlSchema.InstanceNamespace, "1");
        else
            xmlWriter.WriteAttributeString("nil", XmlSchema.InstanceNamespace, "true");
    }

    void WriteIDAttribute(int href) {
        xmlWriter.WriteAttributeString("id", "id" + href.ToString());
    }

    void WriteHref(int href) {
        xmlWriter.WriteAttributeString("href", "#id" + href.ToString());
    }

    void WritePrimitive(XmlQualifiedName name) {
        if (name.Namespace == XmlSchema.Namespace && name.Name == "QName") {
            DefineNamespace("q1", "http://tempuri.org/SampleNamespace");
            WriteXmlValue("q1:QName");
        }
        else
            WriteXmlValue(name.Name);
    }
        
    XmlQualifiedName GetBaseTypeName(XmlSchemaComplexType complexType) {
        if (complexType.ContentModel is XmlSchemaComplexContent) {
            XmlSchemaComplexContent content = (XmlSchemaComplexContent)complexType.ContentModel;
            if (content.Content is XmlSchemaComplexContentRestriction) {
                XmlSchemaComplexContentRestriction restriction = (XmlSchemaComplexContentRestriction)content.Content;
                return restriction.BaseTypeName;
            }
        }
        return null;
    }

    internal class TypeItems {
        internal XmlSchemaObjectCollection Attributes = new XmlSchemaObjectCollection();
        internal XmlSchemaAnyAttribute AnyAttribute;
        internal XmlSchemaObjectCollection Items = new XmlSchemaObjectCollection();
        internal XmlQualifiedName baseSimpleType;
    }

    TypeItems GetTypeItems(XmlSchemaComplexType type) {
        TypeItems items = new TypeItems();
        if (type == null)
            return items;

        XmlSchemaParticle particle = null;
        if (type.ContentModel != null) {
            XmlSchemaContent content = type.ContentModel.Content;
            if (content is XmlSchemaComplexContentExtension) {
                XmlSchemaComplexContentExtension extension = (XmlSchemaComplexContentExtension)content;
                items.Attributes = extension.Attributes;
                items.AnyAttribute = extension.AnyAttribute;
                particle = extension.Particle;
            }
            else if (content is XmlSchemaComplexContentRestriction) {
                XmlSchemaComplexContentRestriction restriction = (XmlSchemaComplexContentRestriction)content;
                items.Attributes = restriction.Attributes;
                items.AnyAttribute = restriction.AnyAttribute;
                particle = restriction.Particle;
            }
            else if (content is XmlSchemaSimpleContentExtension) {
                XmlSchemaSimpleContentExtension extension = (XmlSchemaSimpleContentExtension)content;
                items.Attributes = extension.Attributes;
                items.AnyAttribute = extension.AnyAttribute;
                items.baseSimpleType = extension.BaseTypeName;
            }
            else if (content is XmlSchemaSimpleContentRestriction) {
                XmlSchemaSimpleContentRestriction restriction = (XmlSchemaSimpleContentRestriction)content;
                items.Attributes = restriction.Attributes;
                items.AnyAttribute = restriction.AnyAttribute;
                items.baseSimpleType = restriction.BaseTypeName;
            }
        }
        else {
            items.Attributes = type.Attributes;
            items.AnyAttribute = type.AnyAttribute;
            particle = type.Particle;
        }
        if (particle != null) {
            if (particle is XmlSchemaGroupRef) {
                XmlSchemaGroupRef refGroup = (XmlSchemaGroupRef)particle;

                XmlSchemaGroup group = (XmlSchemaGroup)schemas.Find(refGroup.RefName, typeof(XmlSchemaGroup));
                if (group != null) {
                    items.Items = group.Particle.Items;
                }
            }
            else if (particle is XmlSchemaGroupBase) {
                items.Items = ((XmlSchemaGroupBase)particle).Items;
            }
        }
        return items;
    }

    void WriteComplexType(XmlSchemaComplexType type, string ns, bool encoded, int depth, bool writeXsiType) {
        bool wroteArrayType = false;
        bool isSoapArray = false;
        TypeItems typeItems = GetTypeItems(type);
        if (encoded) {
            /*
              Check to see if the type looks like the new WSDL 1.1 array delaration:

              <xsd:complexType name="ArrayOfInt">
                <xsd:complexContent mixed="false">
                  <xsd:restriction base="soapenc:Array">
                    <xsd:attribute ref="soapenc:arrayType" wsdl:arrayType="xsd:int[]" />
                  </xsd:restriction>
                </xsd:complexContent>
              </xsd:complexType>

            */

            XmlQualifiedName itemType = null;
            XmlQualifiedName topItemType = null;
            string brackets = "";
            XmlSchemaComplexType t = type;
            XmlQualifiedName baseTypeName = GetBaseTypeName(t);
            TypeItems arrayItems = typeItems;
            while (t != null) {
                XmlSchemaObjectCollection attributes = arrayItems.Attributes;
                t = null; // if we don't set t after this stop looping
                if (baseTypeName != null && IsArray(baseTypeName) && attributes.Count > 0) {
                    XmlSchemaAttribute refAttr = attributes[0] as XmlSchemaAttribute;
                    if (refAttr != null) {
                        XmlQualifiedName qnameArray = refAttr.RefName;
                        if (qnameArray.Namespace == soapEncNs && qnameArray.Name == "arrayType") {
                            isSoapArray = true;
                            XmlAttribute typeAttribute = refAttr.UnhandledAttributes[0];
                            if (typeAttribute.NamespaceURI == wsdlNs && typeAttribute.LocalName == "arrayType") {
                                itemType = ArrayItemType(typeAttribute.Value);
                                if (topItemType == null)
                                    topItemType = itemType;
                                else
                                    brackets += "[]";

                                if (!IsPrimitive(itemType)) {
                                    t = (XmlSchemaComplexType)schemas.Find(itemType, typeof(XmlSchemaComplexType));
                                    arrayItems = GetTypeItems(t);
                                }
                            }
                        }
                    }
                }
            }
            if (itemType != null) {
                wroteArrayType = true;
                if (IsUrType(itemType))
                    WriteArrayTypeAttribute(new XmlQualifiedName(GetXmlValue("type") + brackets, null), maxArraySize);
                else
                    WriteArrayTypeAttribute(new XmlQualifiedName(itemType.Name + brackets, itemType.Namespace), maxArraySize);
                
                for (int i = 0; i < maxArraySize; i++) {
                    WriteType(new XmlQualifiedName("Item", null), topItemType, 0, depth+1, false);
                }
            }
        }

        if (writeXsiType && !wroteArrayType) {
            WriteTypeAttribute(type.QualifiedName);
        }

        /*****************************
         * Modified to handle XmlSchemaAttributeGroupRef
         * 
         */
        if (!isSoapArray) {
            foreach (Object aObj in typeItems.Attributes) {
                if (aObj.GetType().Equals(typeof(XmlSchemaAttribute)))
                {
                    XmlSchemaAttribute attr = (XmlSchemaAttribute) aObj;
                    if (attr != null && attr.Use != XmlSchemaUse.Prohibited)
                    {
                        if (attr.QualifiedName != null && attr.QualifiedName.Namespace != String.Empty && attr.QualifiedName.Namespace != ns)
                            xmlWriter.WriteStartAttribute(attr.Name, attr.QualifiedName.Namespace);
                        else
                            xmlWriter.WriteStartAttribute(attr.Name, null);

                        XmlSchemaSimpleType dataType = null;

                        // special code for the QNames
                        if (attr.SchemaTypeName.Namespace == XmlSchema.Namespace && attr.SchemaTypeName.Name == "QName")
                        {
                            WriteXmlValue("q1:QName");
                            xmlWriter.WriteEndAttribute();
                            DefineNamespace("q1", "http://tempuri.org/SampleNamespace");
                        }
                        else
                        {
                            if (IsPrimitive(attr.SchemaTypeName))
                                WriteXmlValue(attr.SchemaTypeName.Name);
                            else if (IsEnum(attr.SchemaTypeName, out dataType))
                                WriteEnum(dataType);
                            xmlWriter.WriteEndAttribute();
                        }
                    }
                  
                } else
                    if (aObj.GetType().Equals(typeof(XmlSchemaAttributeGroupRef)))
                    {
                        XmlSchemaAttributeGroupRef attrs = (XmlSchemaAttributeGroupRef)aObj;
                        //attrs.RefName. 
                        
                    }
            }
        }

        XmlSchemaObjectCollection items = typeItems.Items;
        foreach (object item in items) {
            if (item is XmlSchemaElement) {
                WriteElement((XmlSchemaElement)item, ns, encoded, 0, depth + 1, encoded);
            }
            else if (item is XmlSchemaAny) {
                XmlSchemaAny any = (XmlSchemaAny)item;
                XmlSchema schema = schemas[any.Namespace];
                if (schema == null) {
                    WriteXmlValue("xml");
                }
                else {
                    foreach (object schemaItem in schema.Items) {
                        if (schemaItem is XmlSchemaElement) {
                            if (IsDataSetRoot((XmlSchemaElement)schemaItem))
                                WriteXmlValue("dataset");
                            else
                                WriteTopLevelElement((XmlSchemaElement)schemaItem, any.Namespace, depth + 1);
                        }
                    }
                }
            }
        }
    }

    bool IsDataSetRoot(XmlSchemaElement element) {
        if (element.UnhandledAttributes == null) return false;
        foreach (XmlAttribute a in element.UnhandledAttributes) {
            if (a.NamespaceURI == "urn:schemas-microsoft-com:xml-msdata" && a.LocalName == "IsDataSet")
                return true;
        }
        return false;
    }

    void WriteBegin() {
        writer = new StringWriter();
        xmlSrc = new MemoryStream();
        xmlWriter = new XmlTextWriter(xmlSrc, new UTF8Encoding(false));
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.Indentation = 2;
        referencedTypes = new Queue();
        hrefID = 1;
    }

    string WriteEnd() {
        xmlWriter.Flush();
        xmlSrc.Position = 0;
        StreamReader reader = new StreamReader(xmlSrc, Encoding.UTF8);
        writer.Write(HtmlEncode(reader.ReadToEnd()));
        return writer.ToString();
    }

    string HtmlEncode(string text) {
        StringBuilder sb = new StringBuilder();
        for (int i=0; i<text.Length; i++) {
            char c = text[i];
            if (c == '&') {
                string special = ReadComment(text, i);
                if (special.Length > 0) {
                    sb.Append(Server.HtmlDecode(special));
                    i += (special.Length + "&lt;!--".Length + "--&gt;".Length - 1);
                }
                else
                    sb.Append("&amp;");
            }
            else if (c == '<')
                sb.Append("&lt;");
            else if (c == '>')
                sb.Append("&gt;");
            else
                sb.Append(c);
        }
        return sb.ToString();
    }

    string ReadComment(string text, int index) {
        if (dontFilterXml) return String.Empty;
        if (String.Compare(text, index, "&lt;!--", 0, "&lt;!--".Length) == 0) {
            int start = index + "&lt;!--".Length;
            int end = text.IndexOf("--&gt;", start);
            if (end < 0) return String.Empty;
            return text.Substring(start, end-start);
        }
        return String.Empty;
    }

    void Write(string text) {
        writer.Write(text);
    }

    void WriteLine() {
        writer.WriteLine();
    }

    void WriteValue(string text) {
        Write("<font class=value>" + text + "</font>");
    }

    void WriteStartXmlValue() {
        xmlWriter.WriteString("<!--<font class=value>");
    }

    void WriteEndXmlValue() {
        xmlWriter.WriteString("</font>-->");
    }

    void WriteDebugAttribute(string text) {
        WriteDebugAttribute("debug", text);
    }

    void WriteDebugAttribute(string id, string text) {
        xmlWriter.WriteAttributeString(id, text);
    }

    string GetXmlValue(string text) {
        return "<!--<font class=value>" + text + "</font>-->";
    }
    
    void WriteXmlValue(string text) {
        xmlWriter.WriteString(GetXmlValue(text));
    }

    string DefineNamespace(string prefix, string ns) {
        if (ns == null || ns == String.Empty) return null;
        string existingPrefix = xmlWriter.LookupPrefix(ns);
        if (existingPrefix != null && existingPrefix.Length > 0)
            return existingPrefix;
        xmlWriter.WriteAttributeString("xmlns", prefix, null, ns);
        return prefix;
    }

    Port FindPort(Binding binding) {
        Response.Write("<!--Looking for binding name " + binding.Name + ", target namespace: " + binding.ServiceDescription.TargetNamespace + "<BR>-->");
        foreach (ServiceDescription description in serviceDescriptions) {
            if (description.Services.Count == 0) {
                Response.Write("<!-- No services found in description collection.<BR>-->");
                if (_replacedServices == null) {
                    Response.Write("<!--Ending because no services found.<BR>-->");
                    Response.End();
                    return null;
                }
                //handle when the import service description is used, pull service info from replacement object
                foreach (Port port in this._replacedServices) {
                    if (port.Binding.Name == binding.Name &&
                        port.Binding.Namespace == binding.ServiceDescription.TargetNamespace) {
                        return port;
                    }
                }
            }
            else {
                Response.Write("<!--Checking services found in description collection.<BR>-->");
                foreach (Service service in description.Services) {
                    Response.Write("<!--Checking " + service.Ports.Count + " ports.<BR>-->");
                    foreach (Port port in service.Ports) {
                        Response.Write("<!--Port binding name " + port.Binding.Name + ", port binding namespace: " + port.Binding.Namespace + "<BR>-->");
                        if (port.Binding.Name == binding.Name &&
                            port.Binding.Namespace == binding.ServiceDescription.TargetNamespace) {
                            return port;
                        }
                    }
                }
            }
        }
        return null;
    }

    OperationBinding FindBinding(Type bindingType) {
        foreach (ServiceDescription description in serviceDescriptions) {
            foreach (Binding binding in description.Bindings) {
                if (binding.Extensions.Find(bindingType) == null) continue;
                foreach (OperationBinding operationBinding in binding.Operations) {
                    string messageName = operationBinding.Input.Name;
                    if (messageName == null || messageName.Length == 0) 
                        messageName = operationBinding.Name;
                    if (messageName == operationName) 
                        return operationBinding;
                }
            }
        }
        return null;
    }

    Operation FindOperation(OperationBinding operationBinding) {
        PortType portType = serviceDescriptions.GetPortType(operationBinding.Binding.Type);
        foreach (Operation operation in portType.Operations) {
            if (operation.IsBoundBy(operationBinding)) {
                return operation;
            }
        }
        return null;
    }

    string TextFont {
        get { return GetLocalizedText("FontFamilyText"); }
    }
    
    string PreFont {
        get { return GetLocalizedText("FontFamilyPre"); }
    }
    
    string HeaderFont {
        get { return GetLocalizedText("FontFamilyHeader"); }
    }

    string GetLocalizedText(string name) {
      return GetLocalizedText(name, new object[0]);
    }

    string GetLocalizedText(string name, object[] args) {
      ResourceManager rm = (ResourceManager)Application["RM"];
      string val = rm.GetString("HelpGenerator" + name);
      if (val == null) return String.Empty;
      return String.Format(val, args);
    }

	private void WriteToFile(string detail) {
		StreamWriter writer = null;
		writer = new StreamWriter("C:\\Temp\\log.txt", true);
		writer.WriteLine(detail);
		writer.Close();
	}
		
    void Page_Load(object sender, EventArgs e) {
        if (Application["RM"] == null) {
            lock (this.GetType()) {
                if (Application["RM"] == null) {
                    Application["RM"] = new ResourceManager("System.Web.Services", typeof(System.Web.Services.WebService).Assembly);
                }
            }
        }

        operationName = Request.QueryString["op"];

        Response.Write("<!--Custom!<BR>-->");
       // Obtain WSDL contract from Http Context
       serviceDescriptions = (ServiceDescriptionCollection) Context.Items["wsdls"];
       if (serviceDescriptions == null) {
           Response.Write("<!--No wsdls in context.<BR>-->");
           Response.End();
       }

        schemas = new XmlSchemas();     
        foreach (ServiceDescription description in serviceDescriptions) {
            foreach (XmlSchema schema in description.Types.Schemas) {
                schemas.Add(schema);
            }
        }
        
		DataTable methodsTbl = new DataTable("methodsTbl");
		DataColumn colMethodName = new DataColumn("MethodName", Type.GetType("System.String"));
		colMethodName.Unique = true;
		DataColumn colMethodDescription = new DataColumn("MethodDescription", Type.GetType("System.String"));
		methodsTbl.Columns.Add(colMethodName);
		methodsTbl.Columns.Add(colMethodDescription);
		DataRow NewRow;
			
		operationExists = false;

        System.Collections.Hashtable replacements = new System.Collections.Hashtable();
        foreach (ServiceDescription description in serviceDescriptions) {
            Response.Write("<!--Name: " + description.Name + ", TargetNamespace: " + description.TargetNamespace + ", Services.Count=" + description.Services.Count + "<BR>-->");
            if (description.Imports.Count > 0) {
                //load the import service description only if the namespace is blank, otherwise it is an import for a type that we don't need to render for the test doc
                if (description.Imports[0].Namespace.Length == 0) {
                    //load the import servicedescription
                    string dirpath = HttpContext.Current.Request.MapPath(HttpContext.Current.Request.Path);
                    dirpath = dirpath.Substring(0, dirpath.LastIndexOf("\\") + 1) + description.Imports[0].Location;
                    Response.Write("<!--dirpath: " + dirpath + "<BR>-->");

                    ServiceDescription impsd = ServiceDescription.Read(dirpath);
                    //Console.WriteLine("Import Name: " + impsd.Name + ", TargetNamespace: " + impsd.TargetNamespace);
                    //if there is an import populate the attribs for it on the sd
                    replacements.Add(description, impsd);
                    Response.Write("<!--There are " + impsd.Services.Count + " services defined in impsd.<BR>-->");
                    if (impsd.Services.Count == 0) {
                        impsd.Services.Add(description.Services[0]);
                    }
                    _replacedServices = description.Services;

                }
            }
        }
        if (replacements.Count > 0) {
            Response.Write("<!--Replacing a service description.  -->");
            foreach (ServiceDescription k in replacements.Keys) {
                //replace the items in the collection
                Response.Write("<!--Removing target namespace: " + k.TargetNamespace + ",  -->");
                serviceDescriptions.Remove(k);
                serviceDescriptions.Add((ServiceDescription)replacements[k]);
                Response.Write("<!--Adding target namespace: " + ((ServiceDescription)replacements[k]).TargetNamespace + ".<BR>-->");

            }
        }

		foreach (ServiceDescription description in serviceDescriptions) {
            foreach (PortType portType in description.PortTypes) {
                foreach (Operation operation in portType.Operations) {
                    string messageName = operation.Messages.Input.Name;
                    if (messageName == null || messageName.Length == 0) 
                        messageName = operation.Name;
                    if (messageName == operationName) 
                        operationExists = true;
                    if (messageName == null)
                        messageName = String.Empty;
                       
					NewRow = methodsTbl.NewRow();
					NewRow["MethodName"] = messageName.ToString();
					NewRow["MethodDescription"] = operation.Documentation.ToString();
					
					try {
                        if (methodsTbl.Select(" MethodName Like '" + NewRow["MethodName"] +"'").Length == 0)
                        {
                        methodsTbl.Rows.Add(NewRow);
                        }
					}
					catch(Exception exc) {
						// this is ok, just don't let this value append to the data table
					}
                }
            }
            
        }

		DataView methodsView = new DataView(methodsTbl);
		methodsView.Sort = "MethodName";
		MethodList.DataSource = methodsView;

        Context.Items["wsdls"] = serviceDescriptions;
        
        // Databind all values within the page
        Page.DataBind();
    }




    string SoapOperationInput2 {
        get { 
            if (SoapOperationBinding == null) return "";
            WriteBegin();

            Port port = FindPort(SoapOperationBinding.Binding);
            if (port == null) {
                Response.Write("<!--No port found.-->");
                Response.End();
            }
            SoapAddressBinding soapAddress = (SoapAddressBinding)port.Extensions.Find(typeof(SoapAddressBinding));

            string action = UTF8EscapeString(((SoapOperationBinding)SoapOperationBinding.Extensions.Find(typeof(SoapOperationBinding))).SoapAction);

            Uri uri = new Uri(soapAddress.Location, false);

            /*Write("POST ");
            Write(uri.AbsolutePath);
            Write(" HTTP/1.1");
            WriteLine();

            Write("Host: ");
            Write(uri.Host);
            WriteLine();

            Write("Content-Type: text/xml; charset=utf-8");
            WriteLine();

            Write("Content-Length: ");
            WriteValue("length");
            WriteLine();

            Write("SOAPAction: \"");
            Write(action);
            Write("\"");
            WriteLine();

            WriteLine();*/
            
            WriteSoapMessage2(SoapOperationBinding.Input, serviceDescriptions.GetMessage(SoapOperation.Messages.Input.Message));
            return WriteEnd();
        }
    }

    void WriteSoapMessage2(MessageBinding messageBinding, Message message) {
        SoapOperationBinding soapBinding = (SoapOperationBinding)SoapOperationBinding.Extensions.Find(typeof(SoapOperationBinding));
        SoapBodyBinding soapBodyBinding = (SoapBodyBinding)messageBinding.Extensions.Find(typeof(SoapBodyBinding));
        bool rpc = soapBinding != null && soapBinding.Style == SoapBindingStyle.Rpc;
        bool encoded = soapBodyBinding.Use == SoapBindingUse.Encoded;

        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("soap", "Envelope", soapNs);
        DefineNamespace("xsi", XmlSchema.InstanceNamespace);
        DefineNamespace("xsd", XmlSchema.Namespace);
        if (encoded) {
            DefineNamespace("soapenc", soapEncNs);
            string targetNamespace = message.ServiceDescription.TargetNamespace;
            DefineNamespace("tns", targetNamespace);
            DefineNamespace("types", GetEncodedNamespace(targetNamespace));
        }

        SoapHeaderBinding[] headers = (SoapHeaderBinding[])messageBinding.Extensions.FindAll(typeof(SoapHeaderBinding));
        if (headers.Length > 0) {
            xmlWriter.WriteStartElement("Header", soapNs);
            foreach (SoapHeaderBinding header in headers) {
                Message headerMessage = serviceDescriptions.GetMessage(header.Message);
                if (headerMessage != null) {
                    MessagePart part = headerMessage.Parts[header.Part];
                    if (part != null) {
                        if (encoded)
                            WriteType2(part.Type, part.Type, XmlSchemaForm.Qualified, -1, 0, false);
                        else
                            WriteTopLevelElement2(XmlEscapeQName(part.Element), 0);
                    }
                }
            }
            if (encoded)
                WriteQueuedTypes2();
            xmlWriter.WriteEndElement();
        }
        
        xmlWriter.WriteStartElement("Body", soapNs);
        if (soapBodyBinding.Encoding != null && soapBodyBinding.Encoding != String.Empty)
            xmlWriter.WriteAttributeString("encodingStyle", soapNs, soapBodyBinding.Encoding);

        if (rpc) {
            string messageName = SoapOperationBinding.Output == messageBinding ? SoapOperation.Name + "Response" : SoapOperation.Name;
            if (encoded) {
                string prefix = null;
                if (soapBodyBinding.Namespace.Length > 0) {
                    prefix = xmlWriter.LookupPrefix(soapBodyBinding.Namespace);
                    if (prefix == null)
                        prefix = "q" + nextPrefix++;
                }
                xmlWriter.WriteStartElement(prefix, messageName, soapBodyBinding.Namespace);
            }
            else
                xmlWriter.WriteStartElement(messageName, soapBodyBinding.Namespace);
        }
        foreach (MessagePart part in message.Parts) {
            if (encoded) {
                if (rpc)
                    WriteType2(new XmlQualifiedName(part.Name, soapBodyBinding.Namespace), part.Type, XmlSchemaForm.Unqualified, 0, 0, true);
                else
                    WriteType2(part.Type, part.Type, XmlSchemaForm.Qualified, -1, 0, true); // id == -1 writes the definition without writing the id attr
            }
            else {
                if (!part.Element.IsEmpty)
                    WriteTopLevelElement2(XmlEscapeQName(part.Element), 0);
                else
                    WriteXmlValue2("xml");
            }
        }
        if (rpc) {
            xmlWriter.WriteEndElement();
        }
        if (encoded) {
            WriteQueuedTypes2();
        }            
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndElement();
    }

    void WriteXmlValue2(string text) {
        xmlWriter.WriteString(GetXmlValue2(text));
    }
    
    void WriteType2(XmlQualifiedName name, XmlQualifiedName typeName, int id, int depth, bool writeXsiType) {
        WriteType2(name, typeName, XmlSchemaForm.None, id, depth, writeXsiType);
    }

    void WriteType2(XmlQualifiedName name, XmlQualifiedName typeName, XmlSchemaForm form, int id, int depth, bool writeXsiType) {
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = name.Name;
        element.MaxOccurs = 1;
        element.Form = form;
        element.SchemaTypeName = typeName;
        WriteElement2(element, name.Namespace, true, id, depth, writeXsiType);
    }
    
    void WriteElement2(XmlSchemaElement element, string ns, bool encoded, int id, int depth, bool writeXsiType) {
        XmlSchemaForm form = element.Form;
        if (form == XmlSchemaForm.None) {
            XmlSchema schema = schemas[ns];
            if (schema != null) form = schema.ElementFormDefault;
        }
        WriteElement2(element, ns, form, encoded, id, depth, writeXsiType);
    }

    void WriteElement2(XmlSchemaElement element, string ns, XmlSchemaForm form, bool encoded, int id, int depth, bool writeXsiType) {
        if (element == null) return;
        int count = element.MaxOccurs > 1 ? maxArraySize : 1;

        for (int i = 0; i < count; i++) {
            XmlQualifiedName elementName = (element.QualifiedName == null || element.QualifiedName.IsEmpty ? new XmlQualifiedName(element.Name, ns) : element.QualifiedName);
            if (encoded && count > 1) {
                elementName = new XmlQualifiedName("Item", null);
            }

            if (IsRef(element.RefName)) {
                WriteTopLevelElement2(XmlEscapeQName(element.RefName), depth);
                continue;
            }
            
            if (encoded) {
                string prefix = null;
                if (form != XmlSchemaForm.Unqualified && elementName.Namespace.Length > 0) {
                    prefix = xmlWriter.LookupPrefix(elementName.Namespace);
                    if (prefix == null)
                        prefix = "q" + nextPrefix++;
                }
                
                if (id != 0) { // intercept array definitions
                    XmlSchemaComplexType ct = null;
                    if (IsStruct(element, out ct)) {
                        XmlQualifiedName typeName = element.SchemaTypeName;
                        XmlQualifiedName baseTypeName = GetBaseTypeName(ct);
                        if (baseTypeName != null && IsArray(baseTypeName))
                            typeName = baseTypeName;
                        if (typeName != elementName) {
                            WriteType2(typeName, element.SchemaTypeName, form, id, depth, writeXsiType);
                            return;
                        }
                    }
                }
                xmlWriter.WriteStartElement(prefix, elementName.Name, form != XmlSchemaForm.Unqualified ? elementName.Namespace : "");
            }
            else
                xmlWriter.WriteStartElement(elementName.Name, form != XmlSchemaForm.Unqualified ? elementName.Namespace : "");

            XmlSchemaSimpleType simpleType = null;
            XmlSchemaComplexType complexType = null;

            if (IsPrimitive(element.SchemaTypeName)) {
                if (writeXsiType) WriteTypeAttribute2(element.SchemaTypeName);
                WritePrimitive2(element.SchemaTypeName);
            }
            else if (IsEnum(element.SchemaTypeName, out simpleType)) {
                if (writeXsiType) WriteTypeAttribute2(element.SchemaTypeName);
                WriteEnum2(simpleType);
            }
            else if (IsStruct(element, out complexType)) {
                if (depth >= maxObjectGraphDepth)
                    WriteNullAttribute2(encoded);
                else if (encoded) {
                    if (id != 0) {
                        // id == -1 means write the definition without writing the id
                        if (id > 0) {
                            WriteIDAttribute2(id);
                        }
                        WriteComplexType2(complexType, ns, encoded, depth, writeXsiType);
                    }
                    else {
                        int href = hrefID++;
                        WriteHref2(href);
                        AddQueuedType(elementName, element.SchemaTypeName, XmlSchemaForm.Qualified, href, depth, true);
                    }
                }
                else {
                    WriteComplexType2(complexType, ns, encoded, depth, false);
                }
            }
            else if (IsByteArray(element, out simpleType)) {
                WriteByteArray2(simpleType);
            }
            else if (IsSchemaRef(element.RefName)) {
                WriteXmlValue2("schema");
            }
            else if (IsUrType(element.SchemaTypeName)) {
                WriteTypeAttribute2(new XmlQualifiedName(GetXmlValue2("type"), null));
            }
            else {
                if (debug) {
                    WriteDebugAttribute("error", "Unknown type");
                    WriteDebugAttribute("elementName", element.QualifiedName.ToString());
                    WriteDebugAttribute("typeName", element.SchemaTypeName.ToString());
                    WriteDebugAttribute("type", element.SchemaType != null ? element.SchemaType.ToString() : "null");
                }
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Formatting = Formatting.Indented;
        }
    }

    void WriteEnum2(XmlSchemaSimpleType dataType) {
        if (dataType.Content is XmlSchemaSimpleTypeList) { // "flags" enum -- appears inside a list
            XmlSchemaSimpleTypeList list = (XmlSchemaSimpleTypeList)dataType.Content;
            dataType = list.ItemType;
        }

        bool first = true;
        if (dataType.Content is XmlSchemaSimpleTypeRestriction) {
            XmlSchemaSimpleTypeRestriction restriction = (XmlSchemaSimpleTypeRestriction)dataType.Content;
            foreach (XmlSchemaFacet facet in restriction.Facets) {
                if (facet is XmlSchemaEnumerationFacet) {
                    if (!first) xmlWriter.WriteString(" or "); else first = false;
                    WriteXmlValue2(facet.Value);
                }
            }
        }
    }
    
    string GetXmlValue2(string text) {
        return text;
    }
    
    string getAction() {
    	try {
    		
    		if (SoapOperationBinding != null) {
	    		return UTF8EscapeString(((SoapOperationBinding)SoapOperationBinding.Extensions.Find(typeof(SoapOperationBinding))).SoapAction);
	    	}
	    	else {
	    		return "";
	    	}
    	}
    	catch (Exception e) {
    		return "";
    	}
    
    }
    
    void WriteTopLevelElement2(XmlQualifiedName name, int depth) {
        WriteTopLevelElement2((XmlSchemaElement)schemas.Find(name, typeof(XmlSchemaElement)), name.Namespace, depth);
    }

    void WriteTopLevelElement2(XmlSchemaElement element, string ns, int depth) {
        WriteElement2(element, ns, XmlSchemaForm.Qualified, false, 0, depth, false);
    }

    void WriteByteArray2(XmlSchemaSimpleType dataType) {
        WriteXmlValue2("bytes");
    }

    void WriteComplexType2(XmlSchemaComplexType type, string ns, bool encoded, int depth, bool writeXsiType) {
        bool wroteArrayType = false;
        bool isSoapArray = false;
        TypeItems typeItems = GetTypeItems(type);
        if (encoded) {
            /*
              Check to see if the type looks like the new WSDL 1.1 array delaration:

              <xsd:complexType name="ArrayOfInt">
                <xsd:complexContent mixed="false">
                  <xsd:restriction base="soapenc:Array">
                    <xsd:attribute ref="soapenc:arrayType" wsdl:arrayType="xsd:int[]" />
                  </xsd:restriction>
                </xsd:complexContent>
              </xsd:complexType>

            */

            XmlQualifiedName itemType = null;
            XmlQualifiedName topItemType = null;
            string brackets = "";
            XmlSchemaComplexType t = type;
            XmlQualifiedName baseTypeName = GetBaseTypeName(t);
            TypeItems arrayItems = typeItems;
            while (t != null) {
                XmlSchemaObjectCollection attributes = arrayItems.Attributes;
                t = null; // if we don't set t after this stop looping
                if (baseTypeName != null && IsArray(baseTypeName) && attributes.Count > 0) {
                    XmlSchemaAttribute refAttr = attributes[0] as XmlSchemaAttribute;
                    if (refAttr != null) {
                        XmlQualifiedName qnameArray = refAttr.RefName;
                        if (qnameArray.Namespace == soapEncNs && qnameArray.Name == "arrayType") {
                            isSoapArray = true;
                            XmlAttribute typeAttribute = refAttr.UnhandledAttributes[0];
                            if (typeAttribute.NamespaceURI == wsdlNs && typeAttribute.LocalName == "arrayType") {
                                itemType = ArrayItemType(typeAttribute.Value);
                                if (topItemType == null)
                                    topItemType = itemType;
                                else
                                    brackets += "[]";

                                if (!IsPrimitive(itemType)) {
                                    t = (XmlSchemaComplexType)schemas.Find(itemType, typeof(XmlSchemaComplexType));
                                    arrayItems = GetTypeItems(t);
                                }
                            }
                        }
                    }
                }
            }
            if (itemType != null) {
                wroteArrayType = true;
                if (IsUrType(itemType))
                    WriteArrayTypeAttribute2(new XmlQualifiedName(GetXmlValue("type") + brackets, null), maxArraySize);
                else
                    WriteArrayTypeAttribute2(new XmlQualifiedName(itemType.Name + brackets, itemType.Namespace), maxArraySize);
                
                for (int i = 0; i < maxArraySize; i++) {
                    WriteType2(new XmlQualifiedName("Item", null), topItemType, 0, depth+1, false);
                }
            }
        }

        if (writeXsiType && !wroteArrayType) {
            WriteTypeAttribute2(type.QualifiedName);
        }

        if (!isSoapArray) {
            foreach (XmlSchemaAttribute attr in typeItems.Attributes) {
                if (attr != null && attr.Use != XmlSchemaUse.Prohibited) {
                    if (attr.QualifiedName != null && attr.QualifiedName.Namespace != String.Empty && attr.QualifiedName.Namespace != ns)
                        xmlWriter.WriteStartAttribute(attr.Name, attr.QualifiedName.Namespace);
                    else
                        xmlWriter.WriteStartAttribute(attr.Name, null);

                    XmlSchemaSimpleType dataType = null;

                    // special code for the QNames
                    if (attr.SchemaTypeName.Namespace == XmlSchema.Namespace && attr.SchemaTypeName.Name == "QName") {
                        WriteXmlValue2("q1:QName");
                        xmlWriter.WriteEndAttribute();
                        DefineNamespace("q1", "http://tempuri.org/SampleNamespace");
                    }
                    else {
                        if (IsPrimitive(attr.SchemaTypeName)) 
                            WriteXmlValue2(attr.SchemaTypeName.Name);
                        else if (IsEnum(attr.SchemaTypeName, out dataType))
                            WriteEnum2(dataType);
                        xmlWriter.WriteEndAttribute();
                    }
                }
            }
        }

        XmlSchemaObjectCollection items = typeItems.Items;
        foreach (object item in items) {
            if (item is XmlSchemaElement) {
                WriteElement2((XmlSchemaElement)item, ns, encoded, 0, depth + 1, encoded);
            }
            else if (item is XmlSchemaAny) {
                XmlSchemaAny any = (XmlSchemaAny)item;
                XmlSchema schema = schemas[any.Namespace];
                if (schema == null) {
                    WriteXmlValue2("xml");
                }
                else {
                    foreach (object schemaItem in schema.Items) {
                        if (schemaItem is XmlSchemaElement) {
                            if (IsDataSetRoot((XmlSchemaElement)schemaItem))
                                WriteXmlValue2("dataset");
                            else
                                WriteTopLevelElement2((XmlSchemaElement)schemaItem, any.Namespace, depth + 1);
                        }
                    }
                }
            }
        }
    }

    void WriteQueuedTypes2() {
        while (referencedTypes.Count > 0) {
            QueuedType q = (QueuedType)referencedTypes.Dequeue();
            WriteType2(q.name, q.typeName, q.form, q.id, q.depth, q.writeXsiType);
        }
    }

    void WriteArrayTypeAttribute2(XmlQualifiedName type, int maxOccurs) {
        StringBuilder sb = new StringBuilder(type.Name);
        sb.Append("[");
        sb.Append(maxOccurs.ToString());
        sb.Append("]");
        string prefix = DefineNamespace("q1", type.Namespace);
        XmlQualifiedName typeName = new XmlQualifiedName(sb.ToString(), prefix);
        xmlWriter.WriteAttributeString("arrayType", soapEncNs, typeName.ToString());
    }

    void WriteTypeAttribute2(XmlQualifiedName type) {
        string prefix = DefineNamespace("s0", type.Namespace);
        xmlWriter.WriteStartAttribute("type", XmlSchema.InstanceNamespace);
        xmlWriter.WriteString(new XmlQualifiedName(type.Name, prefix).ToString());
        xmlWriter.WriteEndAttribute();
    }

    void WriteNullAttribute2(bool encoded) {
        if (encoded)
            xmlWriter.WriteAttributeString("null", XmlSchema.InstanceNamespace, "1");
        else
            xmlWriter.WriteAttributeString("nil", XmlSchema.InstanceNamespace, "true");
    }

    void WriteIDAttribute2(int href) {
        xmlWriter.WriteAttributeString("id", "id" + href.ToString());
    }

    void WriteHref2(int href) {
        xmlWriter.WriteAttributeString("href", "#id" + href.ToString());
    }

    void WritePrimitive2(XmlQualifiedName name) {
        if (name.Namespace == XmlSchema.Namespace && name.Name == "QName") {
            DefineNamespace("q1", "http://tempuri.org/SampleNamespace");
            WriteXmlValue2("q1:QName");
        }
        else
            WriteXmlValue2(name.Name);
    }
  </script>

  <head>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="alternate" type="text/xml" href="<%#FileName%>?disco"/>

    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: <%#TextFont%>; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: <%#TextFont%>; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: <%#PreFont%>; font-size: x-small; margin-top: -5px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: <%#TextFont%>; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: -15px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul, ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		.heading1 { color: #ffffff; font-family: <%#HeaderFont%>; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: <%#TextFont%>; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: <%#TextFont%>; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: <%#TextFont%>; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: <%#TextFont%>; font-size: 1em; }
		.intro { margin-left: -15px; }
           
    </style>

    <title><%#ServiceName + " " + GetLocalizedText("WebService")%></title>

      <script language="javascript" type="text/javascript">
		
		function ShowTestSection() {
			document.getElementById("soaptemplaterequest").style.display = "block";
			document.getElementById("soapsamplerequest").style.display = "none";
			document.getElementById("soapsampleresponse").style.display = "none";
			document.getElementById("testhref").style.display = "none";
			document.getElementById("samplehref").style.display = "block";
			document.getElementById("soapsampletitle").style.display = "none";
			document.getElementById("soaptesttitle").style.display = "block";
		}
		
		function ShowTemplateSection() {
			document.getElementById("soaptemplaterequest").style.display = "none";
			document.getElementById("soapsamplerequest").style.display = "block";
			document.getElementById("soapsampleresponse").style.display = "block";
			document.getElementById("samplehref").style.display = "none";
			document.getElementById("testhref").style.display = "block";
			document.getElementById("soapsampletitle").style.display = "block";
			document.getElementById("soaptesttitle").style.display = "none";
		}

		function SendSoapRequest_onclick(SoapRequest, MethodName, Url) {
		// clear any old message 
		
       document.getElementById("note").firstChild.nodeValue ="";
		// SoapRequst Javascript not working in FF
		SoapRequest = document.getElementById("txasoaptemplaterequest").value;
			var xmlhttp;
			if (window.XMLHttpRequest)
              {// code for all new browsers
              xmlhttp=new XMLHttpRequest();
              } else if (window.ActiveXObject)
              {// code for IE5 and IE6
              xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
              }
            if (xmlhttp!=null)
              {	
	            // Function.
	            xmlhttp.onreadystatechange=function() {
                     if (xmlhttp.readyState==4)
                     {
                         if (xmlhttp.status == 200) {
                          // alert(xmlhttp.responseText)	
   		                    document.getElementById("tempsoaprequest").value = document.getElementById("txasoaptemplaterequest").value;
			                document.getElementById("txasoaptemplaterequest").value = xmlhttp.responseText;
			                document.getElementById("backhref").style.display = "block";
			                document.getElementById("posthref").style.display = "none";
    			        
                         } else {
    		              document.getElementById("tempsoaprequest").value = document.getElementById("txasoaptemplaterequest").value;
                         
                          document.getElementById("note").style.visibility = "visible";
                         document.getElementById("note").firstChild.nodeValue ="ERROR" ;
                         }
                         // done. turn off status
                        document.getElementById("Status").style.visibility = "hidden";

                     }
                 }
	        xmlhttp.open('POST', Url, true);
			xmlhttp.setRequestHeader('Content-Type', 'text/xml; charset="UTF-8"');
			xmlhttp.setRequestHeader('SOAPAction', '<%#getAction()%>');
			
			document.getElementById("Status").style.visibility = "visible";
			
			xmlhttp.send(SoapRequest);

          }
            else
              {
              alert("Your browser does not support XMLHTTP.");
              }
		}

		function GoBackToRequest_onclick() {
			document.getElementById("txasoaptemplaterequest").value = document.getElementById("tempsoaprequest").value;
			document.getElementById("backhref").style.display = "none";
			document.getElementById("posthref").style.display = "block";
		}
      </script>

  </head>

<body>
<div id="content">

	<p class="heading1"><%#ServiceName%></p>
	<br>
	
	<span visible='<%#ShowingMethodList%>' runat=server ID="Span1">
		<p class="intro"><%#GetLocalizedText("OperationsIntro",	new	object[] { Request.RawUrl + "?WSDL" })%></p>
		<asp:repeater id="MethodList" runat=server>
			<headertemplate>
				<ul>
			</headertemplate>
			<itemtemplate>
				<li>
					<a href="<%#EscapedFileName%>?op=<%#DataBinder.Eval(Container.DataItem, "MethodName")%>"><%#DataBinder.Eval(Container.DataItem, "MethodName")%></a>
					<span visible='<%#((string)DataBinder.Eval(Container.DataItem, "MethodDescription")).Length>0%>' runat=server ID="Span2">
						<br><%#DataBinder.Eval(Container.DataItem, "MethodDescription")%>
					</span>
				</li>
				<p />
			</itemtemplate>
			<footertemplate>
				</ul>
			</footertemplate>
		</asp:repeater>
	</span>

	<span visible='<%#!ShowingMethodList &&	OperationExists%>' runat=server ID="Span3" >
		<p class="intro"><%#GetLocalizedText("LinkBack", new object[] {	EscapedFileName	})%></p>
		<h2><%#OperationName%></h2>
		<p class="intro"><%#SoapOperationBinding ==	null ? "" :	SoapOperation.Documentation%></p>
		<div visible='<%#ShowingSoap%>' runat=server ID="Span4" >
			<h3	id="testhref">
				<a href="javascript:ShowTestSection();">Test this	call...</a>
			</h3>
			<h3	id="samplehref"	style="display:none;"><a href="javascript:ShowTemplateSection();">Show sample request/response...</a>
			</h3>
			<p id="soaptesttitle" style="display:none;">&nbsp;</p>
			<p id="soapsampletitle"><%#GetLocalizedText("SoapText")%></p>
			<div id="soaptemplaterequest" style="display:none;">
			    <form>
			        <textarea	id="txasoaptemplaterequest" style="background-color:#e5e5cc;width:80em;height:40em;font-family:monospace;white-space: pre;"><%#SoapOperationInput2%></textarea>
			        <div id="posthref" style="font-size:1.1em;color:#000000;margin-top:10px;margin-bottom:10px;">
			             <a	href="javascript:SendSoapRequest_onclick(document.getElementById('txasoaptemplaterequest').innerText,	'<%#OperationName%>', '<%=Request.FilePath%>');"	>Post template...</a>
			        
			        </div>
                    <div id="note" style="font-size:0.8em;color:#ff0000;margin-top:10px;margin-bottom:10px;">
                       &amp;
                    </div>
                    <div id="backhref" style="display:none;font-size:1.1em;color:#000000;margin-top:10px;margin-bottom:10px;"><a href="javascript:GoBackToRequest_onclick();" >GO back to request template...</a>
                        <br />
                    </div>
                    <input id="tempsoaprequest" type="hidden"	/>
                </form>
            </div>
		    <div id="soapsamplerequest"	style="background-color:#e5e5cc;width:80em;height:40em;font-family:monospace;white-space: pre;"><%#SoapOperationInput%></div>
			<div id="soapsampleresponse" style="background-color:#e5e5cc;;font-family:monospace;white-space: pre;"><%#SoapOperationOutput%></div>
		</div>
	</span>
</div>
<div id="Status" style="visibility:hidden;z-index:1;position:absolute;left:50%;top:50%;border:thick double #00FF00;" >
Running
</div>
</body>
</html>
