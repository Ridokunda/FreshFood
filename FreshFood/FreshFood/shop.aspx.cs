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
            if (!IsPostBack)
            {
                BindProducts(null);
            }
        }

        protected void Category_Click(object sender, EventArgs e)
        {
            string category = null;
            var btn = sender as LinkButton;
            if (btn != null)
            {
                switch (btn.ID)
                {
                    case "btnVegetables": category = "Vegetables"; break;
                    case "btnFruits": category = "Fruits"; break;
                    case "btnJuice": category = "Juice"; break;
                    case "btnDried": category = "Dried"; break;
                    default: category = null; break;
                }
            }
            BindProducts(category);
        }

        private void BindProducts(string category)
        {
            phProducts.Controls.Clear();
            var items = sc.getItems();
            IEnumerable<Item> filtered = items;
            if (!string.IsNullOrEmpty(category))
            {
                filtered = items.Where(i => i.Item_Cat != null && i.Item_Cat.Equals(category, StringComparison.OrdinalIgnoreCase));
            }
            foreach (Item item in filtered)
            {
                Panel productPanel = new Panel();
                productPanel.CssClass = "col-md-6 col-lg-3 ftco-animate";
                string saleSpan = item.Item_price < 100 ? "<span class='status'>Sale</span>" : "";
                string priceHtml = item.Item_price < 100 ? $"<span class='mr-2 price-dc'>$120.00</span><span class='price-sale'>${item.Item_price:0.00}</span>" : $"<span>${item.Item_price:0.00}</span>";
                Literal productHtml = new Literal();
                productHtml.Text = $@"
                    <div class='product'>
                        <a href='shop-detail.aspx?ID={item.Item_ID}' class='img-prod'><img class='img-fluid' src='{item.Item_img}' alt='Product Image'>
                            {saleSpan}
                            <div class='overlay'></div>
                        </a>
                        <div class='text py-3 pb-4 px-3 text-center'>
                            <h3><a href='shop-detail.aspx?ID={item.Item_ID}'>{item.Item_name}</a></h3>
                            <div class='d-flex'>
                                <div class='pricing'>
                                    <p class='price'>{priceHtml}</p>
                                </div>
                            </div>
                            <div class='bottom-area d-flex px-3'>
                                <div class='m-auto d-flex'>
                                    <a href='shop-detail.aspx?ID={item.Item_ID}' class='add-to-cart d-flex justify-content-center align-items-center text-center'>
                                        <span><i class='ion-ios-menu'></i></span>
                                    </a>
                                    <a href='#' class='buy-now d-flex justify-content-center align-items-center mx-1'>
                                        <span><i class='ion-ios-cart'></i></span>
                                    </a>
                                    <a href='#' class='heart d-flex justify-content-center align-items-center '>
                                        <span><i class='ion-ios-heart'></i></span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>";
                productPanel.Controls.Add(productHtml);
                phProducts.Controls.Add(productPanel);
            }
        }
        

    }

}