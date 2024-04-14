using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreshFood
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Display = "";

            Display += "<tr><td class='thumbnail-img'><a href='#'>";
            Display += "<img class='img-fluid' src='images/img-pro-01.jpg' alt='' /></a></td>";
            Display += "<td class='name-pr'><a href='#'>Lorem ipsum dolor sit amet</a></td>";
            Display += "<td class='price-pr'><p>$ 80.0</p></td>";
            Display += "<td class='quantity-box'><input type='number' size='4' value='1' min='0' step='1' class='c-input-text qty text'></td>";
            Display += "<td class='total-pr'><p>$ 80.0</p></td>";
            Display += "<td class='remove-pr'><a href='#'><i class='fas fa-times'></i></a></td></tr>";
           
            tbody.InnerHtml = Display;
        }
    }
}