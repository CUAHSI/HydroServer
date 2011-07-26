using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBLayer;

namespace HydroAdmin
{
    public partial class UserGroupSelectionPopUp : System.Web.UI.Page
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cancelActionButton.Attributes.Add("onclick", "JavaScript:window.close(); return false;");
                string username = Context.Request.QueryString["username"];
                string task = Context.Request.QueryString["task"];
                DataTable userInfo = new DataTable();
                DBLayer.UserInfo userObj = new DBLayer.UserInfo();
                userInfo = userObj.GetUserInfo(username);
                foreach (DataRow row in userInfo.Rows)
                {
                    userid = Convert.ToInt16(row["id"]);
                }

                if (task == "add")
                {
                    DataTable userSelectedGroup = new DataTable();
                    DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
                    userSelectedGroup = userGroupObj.GetUserGroupNotSelectedList(userid);
                    userGroupSelectionGridview.DataSource = userSelectedGroup;
                    userGroupSelectionGridview.DataBind();
                    groupRemoveButton.Visible = false;
                }

                if (task == "remove")
                {
                    DataTable userSelectedGroup = new DataTable();
                    DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
                    userSelectedGroup = userGroupObj.GetUserGroupList(userid);
                    userGroupSelectionGridview.DataSource = userSelectedGroup;
                    userGroupSelectionGridview.DataBind();
                    groupAddButton.Visible = false;
                }
            }

        }

        protected void cancelActionButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void groupAddButton_Click(object sender, EventArgs e)
        {
            string username = Context.Request.QueryString["username"];
            DataTable userInfo = new DataTable();
            DBLayer.UserInfo userObj = new DBLayer.UserInfo();
            userInfo = userObj.GetUserInfo(username);
            foreach (DataRow row in userInfo.Rows)
            {
                userid = Convert.ToInt16(row["id"]);
            }


            foreach (GridViewRow row in userGroupSelectionGridview.Rows)
            {
                CheckBox sel = (CheckBox)row.FindControl("CheckBox1");
                if (sel.Checked)
                {
                    DBLayer.UserGroup userGroupObj = new UserGroup();
                    userGroupObj.UserGroupAdd(userid, Convert.ToInt16(row.Cells[1].Text));
                }
            }
            DataTable userSelectedGroup = new DataTable();
            DBLayer.UserGroup userGroupTempObj = new DBLayer.UserGroup();
            userSelectedGroup = userGroupTempObj.GetUserGroupNotSelectedList(userid);
            userGroupSelectionGridview.DataSource = userSelectedGroup;
            userGroupSelectionGridview.DataBind();

        }

        protected void groupRemoveButton_Click(object sender, EventArgs e)
        {
            string username = Context.Request.QueryString["username"];
            DataTable userInfo = new DataTable();
            DBLayer.UserInfo userObj = new DBLayer.UserInfo();
            userInfo = userObj.GetUserInfo(username);
            foreach (DataRow row in userInfo.Rows)
            {
                userid = Convert.ToInt16(row["id"]);
            }

            DBLayer.UserGroup userGroupAllDrop = new UserGroup();
            userGroupAllDrop.ReleaseGroupRows(userid);

            foreach (GridViewRow row in userGroupSelectionGridview.Rows)
            {
                CheckBox sel = (CheckBox)row.FindControl("CheckBox1");
                if (!sel.Checked)
                {
                    DBLayer.UserGroup userGroupObj = new UserGroup();
                    userGroupObj.UserGroupAdd(userid, Convert.ToInt16(row.Cells[1].Text));
                }
            }


            DataTable userSelectedGroup = new DataTable();
            DBLayer.UserGroup userGroupTempObj = new DBLayer.UserGroup();
            userSelectedGroup = userGroupTempObj.GetUserGroupList(userid);
            userGroupSelectionGridview.DataSource = userSelectedGroup;
            userGroupSelectionGridview.DataBind();
        }
    }
}
