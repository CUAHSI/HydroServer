using System.Collections.Generic;
using System.Text;
using WaterOneFlowImpl;

namespace WaterOneFlow.odws
{
    public class OdValuesCommon
    {
        public static string CreateValuesWhereClause(VariableParam variable, int? VariableId)
        {
            string qualityControlId = null;
            string methodId = null;
            string sourceId = null;
            if (variable != null && variable.options != null && variable.options.Count > 0)
            {
                foreach (KeyValuePair<string, string> opt in variable.options)
                {
                    switch (opt.Key.ToUpperInvariant())
                    {
                        case "QUALITYCONTROLLEVEL":
                            // TODO Implement QUALITYCONTROLLEVEL Text Matching
                            break;
                        case "QUALITYCONTROLLEVELID":
                        case "QUALITYCONTROLID":
                        case "QUALITYCONTROLCODE":
                        case "QUALITYCONTROLLEVELCODE": 
                            if (!string.IsNullOrEmpty(opt.Value))
                                qualityControlId = opt.Value;
                            break;
                        case "METHOD":
                            // TODO Implement METHOD Text Matching
                            break;
                        case "METHODID":
                        case "METHODCODE": 
                            if (!string.IsNullOrEmpty(opt.Value))
                                methodId = opt.Value;
                            break;
                        case "SOURCE":
                            // TODO Implement SOURCE Text Matching
                            break;
                        case "SOURCEID":
                        case "SOURCECODE": 
                            if (!string.IsNullOrEmpty(opt.Value))
                                sourceId = opt.Value;
                            break;
                        case "ORGANIZATION":
                            // TODO Implement ORGANIZATION Text Matching
                            break;

                    }
                }
            }

            const string selectFormat = " {0}={1} ";
            StringBuilder select = new StringBuilder();
            if (VariableId.HasValue)
            {
                select.AppendFormat(selectFormat, "variableId", VariableId);
            }
            if (!string.IsNullOrEmpty(qualityControlId))
            {
                if (select.Length > 0) select.Append(" AND ");
                select.AppendFormat(selectFormat, "qualityControlLevelId", qualityControlId);
            }

            if (!string.IsNullOrEmpty(methodId))
            {
                if (select.Length > 0) select.Append(" AND ");
                select.AppendFormat(selectFormat, "methodId", methodId);
            }
            if (!string.IsNullOrEmpty(sourceId))
            {
                if (select.Length > 0) select.Append(" AND ");
                select.AppendFormat(selectFormat, "sourceId", sourceId);
            }
            return select.ToString();
        }
    }
}