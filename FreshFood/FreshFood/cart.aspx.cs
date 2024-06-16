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
        private const Decimal V = (Decimal)0.14;
        Service1Client sc = new Service1Client();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            //int Customerid = int.Parse(Request.QueryString["CustomerID"]);
            int? userid = Session["CustomerID"] as int?;
            int UserID = (int)userid;

            dynamic list = sc.getOnCartItems(UserID);
            
            Decimal TotalSum = 0;
            foreach (onCart oncartitem in list)
            {
                Item item = sc.getItem(oncartitem.Item_ID);

                Panel cartPanel = new Panel();

                Literal cartHtml1 = new Literal();

                cartHtml1.Text = $@"<tr><td class='thumbnail-img'><a href='#'>
                                    <img class='img-fluid' src='" + item.Item_img + "' alt='' /></a></td>" +
                                    "<td class='name-pr'><a href='#'>" + item.Item_name + "</a></td>" +
                                    "<td class='price-pr'><p>R" + item.Item_price.ToString("F2") + "</p></td>" +
                                    "<td class='quantity-box'><input type='number' size='4' value='" + oncartitem.OnCart_qty + "' min='0' step='1' class='c-input-text qty text' runat='server'></td>" +
                                    "<td class='total-pr'><p>R" + (oncartitem.OnCart_qty * item.Item_price).ToString("F2") + "</p></td>" +
                                    "<td class='remove-pr'>"
                                    ;
                TotalSum = TotalSum + oncartitem.OnCart_qty * item.Item_price;
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

            Decimal Tax = V * TotalSum;

            Panel totalPanel = new Panel();

            Literal totalHtml = new Literal();

            totalHtml.Text = $@"
                            <h3>Order summary</h3>" +
                            "<div class='d-flex'>" +
                                "<h4>Sub Total</h4>" +
                                "<div class='ml-auto font-weight-bold'>R"+ TotalSum.ToString("F2")+" </div>" +
                            "</div>" +
                            "<div class='d-flex'>" +
                                "<h4>Discount</h4>" +
                                "<div class='ml-auto font-weight-bold'> R 0 </div>" +
                            "</div>" +
                             "<hr class='my-1'>" +
                            "<div class='d-flex'>" +
                                "<h4>Coupon Discount</h4>" +
                                "<div class='ml-auto font-weight-bold'> R 0 </div>" +
                            "</div>" +
                            "<div class='d-flex'>" +
                                "<h4>Tax</h4>" +
                                "<div class='ml-auto font-weight-bold'> R "+Tax.ToString("F2")+" </div>" +
                            "</div>" +
                            "<div class='d-flex'>" +
                                "<h4>Shipping Cost</h4>" +
                                "<div class='ml-auto font-weight-bold'> Free </div>" +
                            "</div>" +
                            "<hr>" +
                            "<div class='d-flex gr-total'>" +
                                "<h5>Grand Total</h5>" +
                                "<div class='ml-auto h5'> R"+(TotalSum+Tax).ToString("F2")+" </div>" +
                            "</div>" +
                            "<hr>";

                            
            totalPanel.Controls.Add(totalHtml);
            total.Controls.Add(totalPanel);

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