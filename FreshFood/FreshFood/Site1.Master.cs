using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreshFood
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CustomerID"] != null)
            {
                login.InnerHtml = "Logout";
                
               
                login.HRef = "index.aspx";
                
            }
        }
    }
}