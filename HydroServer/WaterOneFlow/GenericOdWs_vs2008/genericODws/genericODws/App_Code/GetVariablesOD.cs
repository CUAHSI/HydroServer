using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using WaterOneFlowImpl;

/// <summary>
/// Summary description for GetVariablesOD
/// </summary>
namespace WaterOneFlow.odws
{
    using CuahsiBuilder = WaterOneFlowImpl.v1_0.CuahsiBuilder;
    using WaterOneFlow.Schema.v1;

    using WaterOneFlow.odm.v1_1;

    public class GetVariablesOD
    {
        private static VariablesDataset Variables;

        public GetVariablesOD()
        {
            //
            // TODO: Add constructor logic here
            //
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

            if (Response.queryInfo == null)
            {
                Response.queryInfo = new QueryInfoType();
                Response.queryInfo.criteria = new QueryInfoTypeCriteria();
            }
            Response.queryInfo.creationTime = DateTime.UtcNow;
            Response.queryInfo.creationTimeSpecified = true;
            if (String.IsNullOrEmpty(Variable))
            {
                Response.queryInfo.criteria.variableParam = "NULL (Request for all variables";
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