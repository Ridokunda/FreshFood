using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;
namespace FreshFood
{
    public partial class register : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            object reg = sc.register(CName.Value,CSurname.Value, Cemail.Value,Cpassword.Value);
            
            msg.InnerText = reg.ToString();
        }
    }
}