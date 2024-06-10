using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;
namespace FreshFood
{
    public partial class shop : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            dynamic list = sc.getItems();
            foreach (Item item in list)
            {
                LoadItems(item);
            }
            
            

        }

        protected void LoadItems(Item item)
        {
            // Create a container for each product
            Panel productPanel = new Panel();
            productPanel.CssClass = "col-sm-6 col-md-6 col-lg-4 col-xl-4";

            // Product content
            Literal productHtmlStart = new Literal();
            productHtmlStart.Text = $@"
                <div class='products-single fix'>
                    <div class='box-img-hover'>
                        <div class='type-lb'>
                            <p class='sale'>Sale</p>
                        </div>
                        <img src='{item.Item_img}' class='img-fluid' alt='Image'>
                        <div class='mask-icon'>
                            <ul>
                                <li><a href='shop-detail.aspx?ID={item.Item_ID}' data-toggle='tooltip' data-placement='right' title='View'><i class='fas fa-eye'></i></a></li>
                                <li><a href='#' data-toggle='tooltip' data-placement='right' title='Compare'><i class='fas fa-sync-alt'></i></a></li>
                                <li><a href='#' data-toggle='tooltip' data-placement='right' title='Add to Wishlist'><i class='far fa-heart'></i></a></li>
                            </ul>";

            productPanel.Controls.Add(productHtmlStart);

            // Add the "Add to Cart" button
            LinkButton addToCartButton = new LinkButton();
            addToCartButton.CssClass = "cart";
            addToCartButton.CommandArgument = item.Item_ID.ToString();
            addToCartButton.Text = "Add to cart";
            addToCartButton.Click += new EventHandler(AddToCart_Click);

            productPanel.Controls.Add(addToCartButton);

            Literal productHtmlEnd = new Literal();
            productHtmlEnd.Text = @"
                        </div>
                    </div>
                    <div class='why-text'>
                        <h4>" + item.Item_name + @"</h4>
                        <h5>R" + item.Item_price + @"</h5>
                    </div>
                </div>";
            productPanel.Controls.Add(productHtmlEnd);

            // Add the panel to the display container
            Display.Controls.Add(productPanel);
        }
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int productId = int.Parse(button.CommandArgument);

            int? userid = Session["CustomerID"] as int?;
            int UserID = (int)userid;
            // Code to add the product to the cart
            sc.addItemonCart(UserID, productId, 1);

            // Optional: Redirect or provide feedback
            Response.Redirect("index.aspx");
        }

        private void AddToCart(int productId, int UserID)
        {
            // Implement your logic to add the product to the cart
            sc.addItemonCart(2, 2, 1);
        }

    }

}