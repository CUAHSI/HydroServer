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
    public partial class Groups : System.Web.UI.Page
    {
        int groupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addGroupButton.Visible = false;
                LoadGroups();
                if (GroupListBox.Items.Count > 0)
                {
                    GroupInfoLoad(GroupListBox.Items[0].ToString());
                    
                }
            }
        }

        private void LoadGroups()
        {
            DBLayer.UserGroup userGroupObj = new DBLayer.UserGroup();
            List<string> allGroups = new List<string>();
            allGroups = userGroupObj.GetAllGroupsList();
            foreach (string groupName in allGroups)
            {
                GroupListBox.Items.Add(groupName);
            }
        }

        private void GroupInfoLoad(string groupName)
        {
            GroupListBox.SelectedValue = groupName;
            DataTable dt = new DataTable();
            DBLayer.UserGroup userGroupObj = new UserGroup();
            dt = userGroupObj.GetGroupInfo(groupName);
            foreach (DataRow row in dt.Rows)
            {
                name.Text = row["name"].ToString();
                owner.Text = row["owner"].ToString();
                dateCreated.Text = row["datecreated"].ToString();
                groupId = Convert.ToInt16(row["id"].ToString());
            }

            DataTable userParticipation = new DataTable();
            UserInfo userInfoObj = new UserInfo();
            userParticipation = userInfoObj.GetUserGroupParticipation(groupId);
            groupUserGridView.DataSource = userParticipation;
            groupUserGridView.DataBind();
        }

        protected void GroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupInfoLoad(GroupListBox.SelectedValue.ToString());
        }

        protected void userAddButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "window.open('GroupUserSelectionPopUp.aspx?groupname=" + GroupListBox.SelectedValue.ToString() + "&task=add','1','height=500,width=500px');", true);
        }

        protected void userRemoveButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "window.open('GroupUserSelectionPopUp.aspx?groupname=" + GroupListBox.SelectedValue.ToString() + "&task=remove','1','height=500,width=500px');", true);
        }
    }
}
