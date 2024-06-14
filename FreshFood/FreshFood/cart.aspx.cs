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

            dynamic list = sc.getOnCartItems(UserID);
            string Display = "";
            foreach (onCart oncartitem in list)
            {
                Item item = sc.getItem(oncartitem.Item_ID);

                Display += "<tr><td class='thumbnail-img'><a href='#'>";
                Display += "<img class='img-fluid' src='"+item.Item_img+"' alt='' /></a></td>";
                Display += "<td class='name-pr'><a href='#'>"+item.Item_name+"</a></td>";
                Display += "<td class='price-pr'><p>"+item.Item_price+"</p></td>";
                Display += "<td class='quantity-box'><input type='number' size='4' value='"+oncartitem.OnCart_qty+"' min='0' step='1' class='c-input-text qty text' runat='server'></td>";
                Display += "<td class='total-pr'><p>"+oncartitem.OnCart_qty*item.Item_price+"</p></td>";
                Display += "<td class='remove-pr'><a href='#'><i class='fas fa-times'></i></a></td></tr>";

                
            }
            tbody.InnerHtml = Display;

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }
    }
}