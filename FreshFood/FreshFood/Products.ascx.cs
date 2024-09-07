using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshFood.ServiceReference1;

namespace FreshFood
{
    public partial class Products : System.Web.UI.UserControl
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
  
            // Product content
            Literal productHtmlStart = new Literal();
            productHtmlStart.Text = $@"
                <tr>
                        <td><img src='{item.Item_img}' style='height: 60px;' alt='Image'></td>
                        <td>{item.Item_name}</td>
                        <td>{item.item_qty}</td>
                        <td>{item.Item_price}</td>
                    </tr>
                ";

            productPanel.Controls.Add(productHtmlStart);
         
            // Add the panel to the display container
            itemsbody.Controls.Add(productPanel);
        }
    }
}