using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Data;
using System.Collections;


namespace HydroAdmin
{
    public partial class AuthorizationDrop : System.Web.UI.Page
    {
        public DataTable timeSeriesTable = new DataTable();
        public int userIdSelected;
        protected void Page_Load(object sender, EventArgs e)
        {
            odmInfoGridView.Width = 1200;
            if (!IsPostBack)
            {
                DbList_Load();
                userInfo_Load();
                userCheckBox.Checked = true;
                userCheckBox.Enabled = false;
                if (userGroupGridView.Rows.Count > 0)
                {
                    CheckBox box = (CheckBox)userGroupGridView.Rows[0].FindControl("selectUserGroupCheckBox");
                    box.Checked = true;
                }

            }
        }

        private void DbList_Load()
        {
            TimeSeriesResources dbObj = new TimeSeriesResources();
            List<string> dbList = new List<string>();
            dbList = dbObj.GetODMList();
            foreach (string s in dbList)
            {
                DbListBox.Items.Add(s);
            }
        }

        protected void DbListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();
            TimeSeriesResources tmResObj = new TimeSeriesResources();
            timeSeriesTable = tmResObj.GetTimeSeriesResources(DbListBox.SelectedValue.ToString());
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
            AccessDisplay();

            
            
        }

        protected void siteCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeSeriesTable = (DataTable)ViewState["mydata"];
            ViewState["mydata"] = null;
            DataTable dt = timeSeriesTable;
            for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["sitecode"].ToString();
                if (!sel.Equals(siteCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

        }

        protected void variableCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeSeriesTable = (DataTable)ViewState["mydata"];
            ViewState["mydata"] = null;
            DataTable dt = timeSeriesTable;
            for (int i = 0; i < timeSeriesTable.Rows.Count; i++)
            {
                DataRow row = timeSeriesTable.Rows[i];
                string sel = row["variablecode"].ToString();
                if (!sel.Equals(variableCodeDropDownList.SelectedValue.ToString()))
                {
                    timeSeriesTable.Rows[i].Delete();
                }
            }
            timeSeriesTable.AcceptChanges();
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";
        }

        protected void resetOdmInfoButton_Click(object sender, EventArgs e)
        {
            siteCodeDropDownList.Items.Clear();
            variableCodeDropDownList.Items.Clear();

            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            dt = odmInfo.GetODMInfo(DbListBox.SelectedValue.ToString());
            TimeSeriesResources tmResObj = new TimeSeriesResources();

            timeSeriesTable = tmResObj.GetTimeSeriesResources(DbListBox.SelectedValue.ToString());
            odmInfoGridView.DataSource = timeSeriesTable;
            odmInfoGridView.DataBind();
            ViewState["mydata"] = timeSeriesTable;
            recordCount.Text = timeSeriesTable.Rows.Count.ToString() + " records";

            List<string> siteCodeListObj = new List<string>();
            List<string> variableCodeListObj = new List<string>();
            foreach (DataRow row in timeSeriesTable.Rows)
            {
                siteCodeListObj.Add(row["sitecode"].ToString());
                variableCodeListObj.Add(row["variablecode"].ToString());
            }

            siteCodeDropDownList.DataSource = siteCodeListObj.Distinct().ToList();
            siteCodeDropDownList.DataBind();
            variableCodeDropDownList.DataSource = variableCodeListObj.Distinct().ToList();
            variableCodeDropDownList.DataBind();
        }

        protected void userInfo_Load()
        {
            UserInfo userObj = new UserInfo();
            DataTable userInfoTable = new DataTable();
            userInfoTable = userObj.GetUserInfoList();
            userGroupGridView.DataSource = userInfoTable;
            userGroupGridView.DataBind();
        }

        protected void groupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            userCheckBox.Checked = false;
            userCheckBox.Enabled = true;
            groupCheckBox.Enabled = false;
            UserGroup userGroupObj = new UserGroup();
            DataTable userGroupTable = new DataTable();
            userGroupTable = userGroupObj.GetUserGroupInfoList();
            userGroupGridView.DataSource = userGroupTable;
            userGroupGridView.DataBind();


        }

        protected void userCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupCheckBox.Checked = false;
            groupCheckBox.Enabled = true;
            userCheckBox.Enabled = false;
            UserInfo userObj = new UserInfo();
            DataTable userInfoTable = new DataTable();
            userInfoTable = userObj.GetUserInfoList();
            userGroupGridView.DataSource = userInfoTable;
            userGroupGridView.DataBind();
        }

        protected void authorizationUpdate_Click(object sender, EventArgs e)
        {
            List<int> userIdList = new List<int>();
            List<int> userGroupList = new List<int>();
            List<KeyValuePair<string, int>> resourcePrivilegeList = new List<KeyValuePair<string, int>>();
            Privilege priv = new Privilege();
            int readPrivId = priv.GetPrivilegeId("read");
            int writePrivId = priv.GetPrivilegeId("write");
            int deletePrivId = priv.GetPrivilegeId("delete");
            int createPrivId = priv.GetPrivilegeId("create");
            
            
            if (userCheckBox.Checked)
            {
                foreach(GridViewRow row in userGroupGridView.Rows)
                {
                    CheckBox box = (CheckBox)row.FindControl("selectUserGroupCheckBox");
                    if (box.Checked)
                    {
                        int userid = Convert.ToInt16(row.Cells[1].Text.ToString());
                        userIdList.Add(userid);
                    }
                }

                foreach (int userId in userIdList)
                {
                    AccessControl accessObj = new AccessControl();
                    accessObj.ReleaseUserRows(userId,DbListBox.SelectedValue.ToString());
                }

                foreach (GridViewRow row in odmInfoGridView.Rows)
                {
                    CheckBox readbox = (CheckBox)row.FindControl("readStatusCheckBox");
                    if (readbox.Checked)
                    {
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[15].Text.ToString(), readPrivId));
                    }

                    CheckBox updateBox = (CheckBox)row.FindControl("updateStatusCheckBox");
                    if (updateBox.Checked)
                    {
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[15].Text.ToString(), writePrivId));
                    }

                    CheckBox deleteBox = (CheckBox)row.FindControl("deleteStatusCheckBox");

                    if (deleteBox.Checked)
                    {
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[15].Text.ToString(), deletePrivId));
                    }
                }
               

                foreach (int userId in userIdList)
                {
                    foreach (KeyValuePair<string, int> kvp in resourcePrivilegeList)
                    {
                        string resourceId = kvp.Key;
                        int privilegeId = kvp.Value;
                        AccessControl accessObj = new AccessControl();
                        accessObj.SetUserAccess(resourceId, userId, privilegeId);
                    }
                }

            }

            TemplateGridDisplay();

        }

        

        private void AccessDisplay()
        {
            Privilege priv = new Privilege();
            int readPrivId = priv.GetPrivilegeId("read");
            int writePrivId = priv.GetPrivilegeId("write");
            int deletePrivId = priv.GetPrivilegeId("delete");
            int createPrivId = priv.GetPrivilegeId("create");

            foreach (GridViewRow resRow in odmInfoGridView.Rows)
                {
                         CheckBox readbox = (CheckBox)resRow.FindControl("readStatusCheckBox");
                         readbox.Checked = false;
                        
                         CheckBox updateBox = (CheckBox)resRow.FindControl("updateStatusCheckBox");
                         readbox.Checked = false;
                       
                         CheckBox deleteBox = (CheckBox)resRow.FindControl("deleteStatusCheckBox");
                         readbox.Checked = false;
                 }
            
            foreach (GridViewRow row in userGroupGridView.Rows)
            {
              CheckBox box = (CheckBox)row.FindControl("selectUserGroupCheckBox");
              if (box.Checked)
              {
                  userIdSelected = Convert.ToInt16(row.Cells[1].Text.ToString());
              }
            }
            AccessControl accessObj = new AccessControl();
            DataTable accessTable = new DataTable();
            accessTable = accessObj.AccessData(userIdSelected);
            foreach (DataRow row in accessTable.Rows)
            {
                foreach (GridViewRow resRow in odmInfoGridView.Rows)
                {
                    string dbrow = row["resourcesid"].ToString();
                    string gridRow = resRow.Cells[15].Text.ToString();
                    if(row["resourcesid"].ToString() == resRow.Cells[15].Text.ToString())
                    {
                        if (row["privilegeid"].ToString() == readPrivId.ToString())
                        {
                            CheckBox readbox = (CheckBox)resRow.FindControl("readStatusCheckBox");
                            readbox.Checked = true;
                        }
                        if (row["privilegeid"].ToString() == writePrivId.ToString())
                        {
                            CheckBox readbox = (CheckBox)resRow.FindControl("updateStatusCheckBox");
                            readbox.Checked = true;
                        }
                        if (row["privilegeid"].ToString() == deletePrivId.ToString())
                        {
                            CheckBox readbox = (CheckBox)resRow.FindControl("deleteStatusCheckBox");
                            readbox.Checked = true;
                        }
                    }
                }
            }
        }

        protected void odmInfoGridView_PreRender(object sender, EventArgs e)
        {
            
             odmInfoGridView.Style["border-collapse"] = "seperate";
        }

        protected void odmInfoGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            for (int i = 15; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Visible = false;
            }
            e.Row.Cells[0].Width = 10;
            e.Row.Cells[1].Width = 10;
            e.Row.Cells[2].Width = 10;
            e.Row.Cells[3].Width = 10;
            e.Row.Cells[4].Width = 100;
            e.Row.Cells[5].Width = 70;
            e.Row.Cells[6].Width = 30;
            e.Row.Cells[7].Width = 30;
            e.Row.Cells[8].Width = 30;
            e.Row.Cells[9].Width = 30;
            e.Row.Cells[10].Width = 150;
            e.Row.Cells[11].Width = 70;
            e.Row.Cells[12].Width = 150;
            e.Row.Cells[13].Width = 30;
            e.Row.Cells[14].Width = 30;
            //e.Row.Cells[9].Width = 300;
            //e.Row.Cells[24].Width = 300;
            //e.Row.Cells[26].Width = 300;
            //e.Row.Cells[27].Width = 450;
            //e.Row.Cells[28].Width = 450;
        }

        protected void odmInfoGridView_DataBound(object sender, EventArgs e)
        {
            TemplateGridDisplay();
        }

        private void TemplateGridDisplay()
        {
            GridViewRow rowheader = odmInfoGridView.HeaderRow;
            //rowheader.Cells[4].Visible = false;

            foreach (GridViewRow gridrow in odmInfoGridView.Rows)
            {
                HyperLink odmLink = (HyperLink)gridrow.FindControl("odmInfoLink");
                odmLink.NavigateUrl = "#";
                odmLink.Attributes.Add("onclick", "window.open('TimeSeriesInformation.aspx?tm=" + gridrow.Cells[15].Text + "',null,'height=600, width=500,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                //gridrow.Cells[5].Visible = false;
                //odmLink.Text = gridrow.Cells[15].Text.ToString();

                Table sitecodeTable = (Table)gridrow.FindControl("sitecodetable");
                TableRow sitecodeRow = new TableRow();
                TableCell sitecodeCell = new TableCell();
                Table variablecodeTable = (Table)gridrow.FindControl("variablecodetable");
                TableRow variablecodeRow = new TableRow();
                TableCell variablecodeCell = new TableCell();
                Table generalcategoryTable = (Table)gridrow.FindControl("generalcategorytable");
                TableRow generalcategoryRow = new TableRow();
                TableCell generalcategoryCell = new TableCell();
                Table valuetypeTable = (Table)gridrow.FindControl("valuetypetable");
                TableRow valuetypeRow = new TableRow();
                TableCell valuetypeCell = new TableCell();
                Table samplemediumTable = (Table)gridrow.FindControl("samplemediumtable");
                TableRow samplemediumRow = new TableRow();
                TableCell samplemediumCell = new TableCell();
                Table qclevelTable = (Table)gridrow.FindControl("qcleveltable");
                TableRow qclevelRow = new TableRow();
                TableCell qclevelCell = new TableCell();
                Table methoddescriptionTable = (Table)gridrow.FindControl("methoddescriptiontable");
                TableRow methoddescriptionRow = new TableRow();
                TableCell methoddescriptionCell = new TableCell();
                Table organizationTable = (Table)gridrow.FindControl("organizationtable");
                TableRow organizationRow = new TableRow();
                TableCell organizationCell = new TableCell();
                Table sourcedescriptionTable = (Table)gridrow.FindControl("sourcedescriptiontable");
                TableRow sourcedescriptionRow = new TableRow();
                TableCell sourcedescriptionCell = new TableCell();
                Table datetimerangeTable = (Table)gridrow.FindControl("datetimerangetable");
                TableRow datetimerangeRow = new TableRow();
                TableCell datetimerangeCell = new TableCell();
                Table obervationsTable = (Table)gridrow.FindControl("observationstable");
                TableRow obervationsRow = new TableRow();
                TableCell obervationsCell = new TableCell(); 



                TimeSeriesResources tmObj = new TimeSeriesResources();
                DataTable dt = new DataTable();
                dt = tmObj.GetTimeSeriesInfo(gridrow.Cells[15].Text);
                foreach(DataRow row in dt.Rows)
                {
                    sitecodeCell.Text = row["sitecode"].ToString()+Environment.NewLine+row["sitename"].ToString();
                    variablecodeCell.Text = row["variablecode"].ToString() + " : " + row["variablename"].ToString();
                    generalcategoryCell.Text = row["generalcategory"].ToString();
                    valuetypeCell.Text = row["valuetype"].ToString();
                    samplemediumCell.Text = row["samplemedium"].ToString();
                    qclevelCell.Text = row["qualitycontrollevelcode"].ToString();
                    methoddescriptionCell.Text = row["methoddescription"].ToString();
                    organizationCell.Text = row["organization"].ToString();
                    sourcedescriptionCell.Text = row["sourcedescription"].ToString();
                    datetimerangeCell.Text = row["datecreated"].ToString();
                    obervationsCell.Text = row["valuecount"].ToString();
                }
                sitecodeRow.Cells.Add(sitecodeCell);
                sitecodeTable.Rows.Add(sitecodeRow);
                variablecodeRow.Cells.Add(variablecodeCell);
                variablecodeTable.Rows.Add(variablecodeRow);
                generalcategoryRow.Cells.Add(generalcategoryCell);
                generalcategoryTable.Rows.Add(generalcategoryRow);
                valuetypeRow.Cells.Add(valuetypeCell);
                valuetypeTable.Rows.Add(valuetypeRow);
                samplemediumRow.Cells.Add(samplemediumCell);
                samplemediumTable.Rows.Add(samplemediumRow);
                qclevelRow.Cells.Add(qclevelCell);
                qclevelTable.Rows.Add(qclevelRow);
                methoddescriptionRow.Cells.Add(methoddescriptionCell);
                methoddescriptionTable.Rows.Add(methoddescriptionRow);
                organizationRow.Cells.Add(organizationCell);
                organizationTable.Rows.Add(organizationRow);
                sourcedescriptionRow.Cells.Add(sourcedescriptionCell);
                sourcedescriptionTable.Rows.Add(sourcedescriptionRow);
                datetimerangeRow.Cells.Add(datetimerangeCell);
                datetimerangeTable.Rows.Add(datetimerangeRow);
                valuetypeRow.Cells.Add(valuetypeCell);
                valuetypeTable.Rows.Add(valuetypeRow);

            }
        }

    }
}
