using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;

namespace FreshFood
{
    public partial class login : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User loguser = sc.Login(email.Value, password.Value);
            if (loguser != null)
            {
                Session["CustomerID"] = loguser.Id;
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}