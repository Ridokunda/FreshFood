using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;

namespace FreshFood
{
    public partial class shop_detail : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int item_id = int.Parse(Request.QueryString["ID"]);
           
            Item item = sc.getItem(item_id);
            if (item != null)
            {
                String Display = "";

                Display += "<div class='col-xl-5 col-lg-5 col-md-6'>";
                Display += "<div id='carousel-example-1' class='single-product-slider carousel slide' data-ride='carousel'>";
                Display += "<img class='d-block w-100' src='images/big-img-02.jpg' alt='Item Image' runat='server'></div></div>";
                Display += "<div class='col-xl-7 col-lg-7 col-md-6'><div class='single-product-details'>";
                Display += "<h2>" + item.Item_name + "</h2><h5> <del>$ 60.00</del> $40.79</h5>";
                Display += "<p class='available-stock'><span> More than 20 available / <a href='#'>8 sold </a></span></p>";
                Display += "<h4>Short Description:</h4><p>Nam se accumsan. Ut semper in quamrcu. </p>";
                Display += "<ul><li><div class='form-group quantity-box'>";
                Display += "<label class='control-label'>Quantity</label><input class='form-control' value='0' min='0' max='20' type='number'>";
                Display += "</div></li></ul>";
                Display += "<div class='price-box-bar'><div class='cart-and-bay-btn'>";
                Display += "<a class='btn hvr-hover' data-fancybox-close='' href='#'>Buy New</a><a class='btn hvr-hover' data-fancybox-close='' href='#'>Add to cart</a>";
                Display += "</div></div><div class='add-to-btn'><div class='add-comp'>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fas fa-heart'></i> Add to wishlist</a>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fas fa-sync-alt'></i> Add to Compare</a></div>";
                Display += "<div class='share-bar'>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fab fa-facebook' aria-hidden='true'></i></a>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fab fa-google-plus' aria-hidden='true'></i></a>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fab fa-twitter' aria-hidden='true'></i></a>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fab fa-pinterest-p' aria-hidden='true'></i></a>";
                Display += "<a class='btn hvr-hover' href='#'><i class='fab fa-whatsapp' aria-hidden='true'></i></a>";
                Display += "</div></div></div></div></div>";


                row.InnerHtml += Display;
            }
            else
            {
                Response.Redirect("shop.aspx");
            }
            
        }
    }
}