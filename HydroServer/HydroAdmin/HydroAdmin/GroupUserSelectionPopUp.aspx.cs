using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HydroAdmin
{
    public partial class GroupUserSelectionPopUp : System.Web.UI.Page
    {
        int groupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cancelActionButton.Attributes.Add("onclick", "JavaScript:window.close(); return false;");
                string groupname = Context.Request.QueryString["groupname"];
                string task = Context.Request.QueryString["task"];
                DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
                DataTable groupIdTable = new DataTable();
                groupIdTable = userGroupObj.GetGroupInfo(groupname);
                foreach (DataRow row in groupIdTable.Rows)
                {
                    groupId = Convert.ToInt16(row["id"].ToString());
                }

                if (task == "add")
                {
                    DataTable userParticipationTable = new DataTable();
                    DBLayer.UserInfo userInfoObj = new DBLayer.UserInfo();
                    userParticipationTable = userInfoObj.GetUserGroupNotParticipation(groupId);
                    GroupUserSelectionGridview.DataSource = userParticipationTable;
                    GroupUserSelectionGridview.DataBind();
                    userRemoveButton.Visible = false;
                }

                if (task == "remove")
                {
                    DataTable userParticipationTable = new DataTable();
                    DBLayer.UserInfo userInfoObj = new DBLayer.UserInfo();
                    userParticipationTable = userInfoObj.GetUserGroupParticipation(groupId);
                    GroupUserSelectionGridview.DataSource = userParticipationTable;
                    GroupUserSelectionGridview.DataBind();
                    userAddButton.Visible = false;
                }
            }
        }

        protected void userAddButton_Click(object sender, EventArgs e)
        {
            string groupname = Context.Request.QueryString["groupname"];
            string task = Context.Request.QueryString["task"];
            DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
            DataTable groupIdTable = new DataTable();
            groupIdTable = userGroupObj.GetGroupInfo(groupname);
            foreach (DataRow row in groupIdTable.Rows)
            {
                groupId = Convert.ToInt16(row["id"].ToString());
            }

            foreach (GridViewRow row in GroupUserSelectionGridview.Rows)
            {
                CheckBox sel = (CheckBox)row.FindControl("CheckBox1");
                if (sel.Checked)
                {
                    DBLayer.UserInfo userInfoObj = new DBLayer.UserInfo();
                    userInfoObj.GroupUserAdd(Convert.ToInt16(row.Cells[1].Text), groupId);
                }
            }
            DataTable userParticipationTable = new DataTable();
            DBLayer.UserInfo userInfoTempObj = new DBLayer.UserInfo();
            userParticipationTable = userInfoTempObj.GetUserGroupNotParticipation(groupId);
            GroupUserSelectionGridview.DataSource = userParticipationTable;
            GroupUserSelectionGridview.DataBind();
            userRemoveButton.Visible = false;

        }

        protected void userRemoveButton_Click(object sender, EventArgs e)
        {
            string groupname = Context.Request.QueryString["groupname"];
            string task = Context.Request.QueryString["task"];
            DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
            DataTable groupIdTable = new DataTable();
            groupIdTable = userGroupObj.GetGroupInfo(groupname);
            foreach (DataRow row in groupIdTable.Rows)
            {
                groupId = Convert.ToInt16(row["id"].ToString());
            }

            DBLayer.UserInfo userInfoAllDrop = new DBLayer.UserInfo();
            userInfoAllDrop.ReleaseUserRows(groupId);

            foreach (GridViewRow row in GroupUserSelectionGridview.Rows)
            {
                CheckBox sel = (CheckBox)row.FindControl("CheckBox1");
                if (!sel.Checked)
                {
                    DBLayer.UserInfo userInfoObj = new DBLayer.UserInfo();
                    userInfoObj.GroupUserAdd(Convert.ToInt16(row.Cells[1].Text), groupId);
                }
            }

            DataTable userParticipationTable = new DataTable();
            DBLayer.UserInfo userInfoTempObj = new DBLayer.UserInfo();
            userParticipationTable = userInfoTempObj.GetUserGroupParticipation(groupId);
            GroupUserSelectionGridview.DataSource = userParticipationTable;
            GroupUserSelectionGridview.DataBind();
            userAddButton.Visible = false;
        }
    }
}
