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
            foreach(Item item in list)
            {
                LoadItems(item);
            }
            
        }

        protected void LoadItems(Item item)
        {
            String display = "";

            display += "<div class='col-sm-6 col-md-6 col-lg-4 col-xl-4'>";
            display += "<div class='products-single fix'>";
            display += "<div class='box-img-hover'>";
            display += "<div class='type-lb'>";
            display += "<p class='sale'>Sale</p></div>";
            display += "<img src='"+item.Item_img+"' class='img-fluid' alt='Image'>";
            display += "<div class='mask-icon'>";
            display += "<ul><li><a href='#' data-toggle='tooltip' data-placement='right' title='View'><i class='fas fa-eye'></i></a></li>";
            display += "<li><a href='#' data-toggle='tooltip' data-placement='right' title='Compare'><i class='fas fa-sync-alt'></i></a></li>";
            display += "<li><a href='#' data-toggle='tooltip' data-placement='right' title='Add to Wishlist'><i class='far fa-heart'></i></a></li></ul>";
            display += "<a class='cart' href='#'>Add to Cart</a>";
            display += "</div></div>";
            display += "<div class='why-text'>";
            display += "<h4>"+item.Item_name+"</h4>";
            display += "<h5>R"+ item.Item_price + "</h5>";
            display += "</div></div></div>";
            Display.InnerHtml += display;
        }
    }
}