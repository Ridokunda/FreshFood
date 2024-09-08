using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreshFood
{
    public partial class AddProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);

            if (fileUploadImage.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadImage.PostedFile.FileName);
                string filePath = Server.MapPath("~/Images/") + fileName;
                fileUploadImage.SaveAs(filePath);

                // Save the product details to the database
                SaveProduct(name, quantity, price, "~/Images/" + fileName);
            }
        }

        private void SaveProduct(string name, int quantity, decimal price, string imageUrl)
        {
            // Implement database save logic here
        }
    }
}