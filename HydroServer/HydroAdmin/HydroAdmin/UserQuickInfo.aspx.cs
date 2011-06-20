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
    public partial class UserQuickInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.QueryString["user"];
            UserInfo userObj = new UserInfo();
            DataTable dt = new DataTable();
            dt = userObj.GetUserInfo(userName);
            UserDetailsView.DataSource = dt;
            UserDetailsView.DataBind();
        }
    }
}
