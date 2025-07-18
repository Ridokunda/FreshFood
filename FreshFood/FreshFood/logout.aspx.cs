using System;
using System.Web.UI;

namespace FreshFood
{
    public partial class logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
} 