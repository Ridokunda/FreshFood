using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;

namespace FreshFood
{
    public partial class cart : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int Customerid = int.Parse(Request.QueryString["CustomerID"]);
            int? userid = Session["CustomerID"] as int?;
            int UserID = (int)userid;

            dynamic list = sc.getItemsOnCart(UserID);
            string Display = "";
            foreach (Item item in list)
            {
                

                Display += "<tr><td class='thumbnail-img'><a href='#'>";
                Display += "<img class='img-fluid' src='"+item.Item_img+"' alt='' /></a></td>";
                Display += "<td class='name-pr'><a href='#'>"+item.Item_name+"</a></td>";
                Display += "<td class='price-pr'><p>"+item.Item_price+"</p></td>";
                Display += "<td class='quantity-box'><input type='number' size='4' value='1' min='0' step='1' class='c-input-text qty text'></td>";
                Display += "<td class='total-pr'><p>$ 80.0</p></td>";
                Display += "<td class='remove-pr'><a href='#'><i class='fas fa-times'></i></a></td></tr>";

                
            }
            tbody.InnerHtml = Display;

        }
    }
}