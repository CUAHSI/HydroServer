using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Data;

namespace HydroAdmin
{
    public partial class Users : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadUser();
                UserGroup userGroupObj = new UserGroup();
                DataTable dt = new DataTable();
                dt = userGroupObj.GetUserGroupInfoList();
                userGroup.DataSource = dt;
                userGroup.DataBind();
                UserInfoLoad(UserListBox.Items[0].Text);
                GroupSelectedDisplay(UserListBox.Items[0].Text);
            }

        }


        private void LoadUser()
        {
            UserListBox.Items.Clear();
            UserInfo userInfoObj = new UserInfo();
            List<string> userListObj = new List<string>();
            userListObj = userInfoObj.GetUserList();
            foreach (string s in userListObj)
            {
                UserListBox.Items.Add(s);
            }
        }


        protected void UserListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserInfoLoad(UserListBox.SelectedValue.ToString());
            GroupSelectedDisplay(UserListBox.SelectedValue.ToString());
        }

        protected void UserInfoLoad(string userName)
        {
            UserListBox.SelectedValue = userName;
            UserInfo userInfoObj = new UserInfo();
            DataTable dt = new DataTable();
            dt = userInfoObj.GetUserInfo(userName);
            foreach (DataRow row in dt.Rows)
            {
                
                name.Text = row["name"].ToString();
                emailId.Text = row["emailid"].ToString();
                organization.Text = row["organization"].ToString();
                country.Text = row["country"].ToString();
            }
        }

        protected void GroupSelectedDisplay(string userName)
        {
            foreach (GridViewRow gridRow in userGroup.Rows)
            {
                    CheckBox groupCheckBox = (CheckBox)gridRow.FindControl("selectGroup");
                    groupCheckBox.Checked = false;
            }
            UserInfo userObj = new UserInfo();
            DataTable dt = new DataTable();
            dt = userObj.GetUserInfo(userName);
            foreach (DataRow row in dt.Rows)
            {
                userId = Convert.ToInt16( row["Id"].ToString());
            }
            UserGroup groupObj = new UserGroup();
            DataTable groupTable = new DataTable();
            groupTable = groupObj.GetUserGroupList(userId);

            foreach (DataRow row in groupTable.Rows)
            {
                foreach (GridViewRow gridRow in userGroup.Rows)
                {
                    if (row["usergroupid"].ToString() == gridRow.Cells[1].Text.ToString())
                    {
                        CheckBox groupCheckBox = (CheckBox)gridRow.FindControl("selectGroup");
                        groupCheckBox.Checked = true;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserInfo userObj = new UserInfo();
            DataTable dt = new DataTable();
            dt = userObj.GetUserInfo(UserListBox.SelectedValue.ToString());
            foreach (DataRow row in dt.Rows)
            {
                userId = Convert.ToInt16(row["Id"].ToString());
            }
            UserGroup groupObj = new UserGroup();
            groupObj.ReleaseGroupRows(userId);

            foreach (GridViewRow row in userGroup.Rows)
            {
                CheckBox groupCheckBox = (CheckBox)row.FindControl("selectGroup");
                if (groupCheckBox.Checked)
                {
                    groupObj.UserGroupAdd(userId, Convert.ToInt16(row.Cells[1].Text.ToString()));
                }
            }
        }

        protected void userGroup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Width = 250;
            e.Row.Cells[3].Width = 150;
            //e.Row.Cells[4].Width = 150;
        }
    }
}
