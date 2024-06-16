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

                Panel cartPanel = new Panel();

                Literal cartHtml1 = new Literal();

                cartHtml1.Text = $@"<tr><td class='thumbnail-img'><a href='#'>
                                    <img class='img-fluid' src='" + item.Item_img + "' alt='' /></a></td>" +
                                    "<td class='name-pr'><a href='#'>" + item.Item_name + "</a></td>" +
                                    "<td class='price-pr'><p>" + item.Item_price + "</p></td>" +
                                    "<td class='quantity-box'><input type='number' size='4' value='" + oncartitem.OnCart_qty + "' min='0' step='1' class='c-input-text qty text' runat='server'></td>" +
                                    "<td class='total-pr'><p>" + oncartitem.OnCart_qty * item.Item_price + "</p></td>" +
                                    "<td class='remove-pr'>"
                                    ;

                cartPanel.Controls.Add(cartHtml1);

                
                LinkButton removeLink = new LinkButton();
                removeLink.CssClass = "fas fa-times";
                removeLink.CommandArgument = item.Item_ID.ToString();
                
                removeLink.Click += new EventHandler(removeItem_Click);

                cartPanel.Controls.Add(removeLink);
                Literal cartHtml2 = new Literal();
               

                cartHtml2.Text = $@"</td></tr>";
                cartPanel.Controls.Add(cartHtml2);
                //Display += "<td class='remove-pr'><a href='#'><i class='fas fa-times'></i></a></td></tr>";

                tbody.Controls.Add(cartPanel);
            }
            

        }
        protected void removeItem_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int? Userid = Session["CustomerID"] as int?;
            int userid = (int)Userid;
            int itemid = int.Parse(button.CommandArgument);

            sc.removeItemOnCart(userid, itemid);
            Response.Redirect(Request.RawUrl);
        }

        protected void Update_Cart_Click(object sender, EventArgs e)
        {

        }
    }
}