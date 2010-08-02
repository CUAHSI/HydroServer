using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WaterOneFlow.Schema.v1_1;

using WaterOneFlowImpl;
using WaterOneFlow.odm.v1_1;

/// <summary>
/// Summary description for GetVariablesOD
/// </summary>
namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_1.CuahsiBuilder;
    namespace v1_1
    {
        public class GetVariablesOD
        {
            private static VariablesDataset Variables;

            public GetVariablesOD()
            {
               
                Variables = ODvariables.GetVariableDataSet();
            }
            public VariablesResponseType GetVariableInfo(string Variable)
            {


                VariableInfoType[] variableList;
                if (String.IsNullOrEmpty(Variable))
                {
                    variableList = ODvariables.getVariables(new VariableParam[0], Variables);

                }
                else
                {
                    VariableParam vp;
                    vp = new VariableParam(Variable);
                    variableList = ODvariables.getVariable(vp, Variables);
                }

                if (variableList == null)
                {
                    throw new WaterOneFlowException("Variable Not Found");
                }
                VariablesResponseType Response = new VariablesResponseType();
                Response.variables = variableList;

                Response.queryInfo = CuahsiBuilder.CreateQueryInfoType("GetVariableInfo", null, null,
                                                                       new string[] {Variable}, null, null);
              
                if (String.IsNullOrEmpty(Variable))
                {
                  CuahsiBuilder.addNote(Response.queryInfo.note,
                      CuahsiBuilder.createNote("(Request for all variables")) ;
                }
                else
                {
                    Response.queryInfo.criteria.variableParam = Variable;
                }
                NoteType sourceNote = CuahsiBuilder.createNote("OD Web Service");
                Response.queryInfo.note = CuahsiBuilder.addNote(Response.queryInfo.note,
                                                                sourceNote);

                return Response;

            }
        }
    }
}