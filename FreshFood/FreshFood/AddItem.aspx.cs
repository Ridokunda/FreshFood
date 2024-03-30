using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;

namespace FreshFood
{
    
    public partial class AddItem : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdditem_Click(object sender, EventArgs e)
        {
            var item = new Item
            {
                Item_name = item_name.Value,
                Item_price = decimal.Parse(item_price.Value),
                item_qty = int.Parse(item_qty.Value),
                Item_Cat = item_cat.Value,
                Item_img = "/images/items/"+item_img.Value+".jpg",
            };
            bool add = sc.addItem(item);
            if (add)
            {
                Response.Redirect("ManageProducts.aspx");
            }
            else
            {
                Response.Redirect("AddItem.aspx");
            }
            
        }
    }
}