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
    public partial class ODMUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                automatedDOICheckBox.Checked = true;
                loadODMList();
                if (odmList.Items.Count > 0)
                {
                    ODMInfoload(odmList.Items[0].ToString());
                }
            }

        }

        protected void odmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            string s = odmList.SelectedItem.ToString();
            dt = odmInfo.GetODMInfo(odmList.SelectedValue.ToString());
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
                waterOneWSDL.Text = row["wateroneflowwsdl"].ToString();
            }
        }

        private void ODMInfoload(string odmName)
        {
            odmList.SelectedValue = odmName;
            ODM odmInfo = new ODM();
            DataTable dt = new DataTable();
            string s = odmList.SelectedItem.ToString();
            dt = odmInfo.GetODMInfo(odmName);
            foreach (DataRow row in dt.Rows)
            {
                Title.Text = row["title"].ToString();
                serverName.Text = row["serveraddress"].ToString();
                Topic.Text = row["topiccategory"].ToString();
                abstractODM.Text = row["abstract"].ToString();
                citation.Text = row["citation"].ToString();
                waterOneWSDL.Text = row["wateroneflowwsdl"].ToString();
            }
        }

        

        private void loadODMList()
        {
            odmList.Items.Clear();
            TimeSeriesResources tmRes = new TimeSeriesResources();
            List<string> loadedODMList = tmRes.GetODMList();
            ODM odmObj = new ODM();
            List<string> loadList = odmObj.GetODMList();
            foreach (string s in loadedODMList)
            {
                loadList.Remove(s);
            }

            foreach (string s in loadList)
            {
                odmList.Items.Add(s);

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (automatedDOICheckBox.Checked)
            {
                ODM odmObj = new ODM();
                odmObj.LoadODM(odmList.SelectedValue.ToString());
                odmList.Items.Clear();
                loadODMList();
            }
            else
            {
                Response.Redirect("customdoi.aspx?odmname="+odmList.SelectedValue.ToString());
            }
        }

        protected void automatedDOICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customDOICheckBox.Checked = false;
        }

        protected void customDOICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            automatedDOICheckBox.Checked = false;
        }

    }
}
