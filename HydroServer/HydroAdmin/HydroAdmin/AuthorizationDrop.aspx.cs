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
            odmInfoGridView.Width = 6000;
            if (!IsPostBack)
            {
                DbList_Load();
                userInfo_Load();
                userCheckBox.Checked = true;
                userCheckBox.Enabled = false;
                CheckBox box = (CheckBox)userGroupGridView.Rows[0].FindControl("selectUserGroupCheckBox");
                box.Checked = true;

                

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
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[4].Text.ToString(), 2));
                    }

                    CheckBox updateBox = (CheckBox)row.FindControl("updateStatusCheckBox");
                    if (updateBox.Checked)
                    {
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[4].Text.ToString(), 3));
                    }

                    CheckBox deleteBox = (CheckBox)row.FindControl("deleteStatusCheckBox");

                    if (deleteBox.Checked)
                    {
                        resourcePrivilegeList.Add(new KeyValuePair<string, int>(row.Cells[4].Text.ToString(), 5));
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

        }

        

        private void AccessDisplay()
        {
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
                    string gridRow = resRow.Cells[4].Text.ToString();
                    if(row["resourcesid"].ToString() == resRow.Cells[4].Text.ToString())
                    {
                        if (row["privilegeid"].ToString() == "2")
                        {
                            CheckBox readbox = (CheckBox)resRow.FindControl("readStatusCheckBox");
                            readbox.Checked = true;
                        }
                        if (row["privilegeid"].ToString() == "3")
                        {
                            CheckBox readbox = (CheckBox)resRow.FindControl("updateStatusCheckBox");
                            readbox.Checked = true;
                        }
                        if (row["privilegeid"].ToString() == "5")
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
            e.Row.Cells[9].Width = 300;
            e.Row.Cells[24].Width = 300;
            e.Row.Cells[26].Width = 300;
            e.Row.Cells[27].Width = 450;
            e.Row.Cells[28].Width = 450;
        }

        protected void odmInfoGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow rowheader = odmInfoGridView.HeaderRow;
            rowheader.Cells[4].Visible = false;

            foreach (GridViewRow row in odmInfoGridView.Rows)
            {
                HyperLink odmLink = (HyperLink)row.FindControl("odmInfoLink");
                odmLink.NavigateUrl = "#";
                odmLink.Attributes.Add("onclick", "window.open('TimeSeriesInformation.aspx?tm=" + row.Cells[4].Text + "',null,'height=600, width=500,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no');");
                row.Cells[4].Visible = false;
                odmLink.Text = row.Cells[4].Text.ToString();

            }
        }

    }
}
