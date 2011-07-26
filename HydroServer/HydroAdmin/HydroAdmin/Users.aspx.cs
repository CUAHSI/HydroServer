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
                DataTable userSelectionTable = new DataTable();
                DBLayer.UserGroup ug = new UserGroup();
                userSelectionTable = ug.GetUserGroupList(Convert.ToInt16(row["id"]));
                userGroup.DataSource = userSelectionTable;
                userGroup.DataBind();
                userId = Convert.ToInt16(row["id"]);

            }
        }

        

       

        protected void userGroup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[2].Width = 250;
            //e.Row.Cells[3].Width = 150;
            //e.Row.Cells[4].Width = 150;
        }

        protected void groupAddButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "window.open('UserGroupSelectionPopUp.aspx?username="+ UserListBox.SelectedValue.ToString()+"&task=add','1','height=500,width=500px');", true);
        }

        protected void groupRemoveButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "window.open('UserGroupSelectionPopUp.aspx?username=" + UserListBox.SelectedValue.ToString() + "&task=remove','1','height=500,width=500px');", true);
        }
    }
}
