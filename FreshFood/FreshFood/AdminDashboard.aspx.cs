using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreshFood
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load the default content on the first load
            if (!IsPostBack)
            {
                LoadUserControl("Dashboard.ascx");
            }
        }

        // Event handler for the Dashboard link
        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl("Dashboard.ascx");
        }

        // Event handler for the Orders link
        protected void LinkButtonOrders_Click(object sender, EventArgs e)
        {
            LoadUserControl("Orders.ascx");
        }

        // Event handler for the Inventory link
        protected void LinkButtonInventory_Click(object sender, EventArgs e)
        {
            LoadUserControl("Products.ascx");
           
        }
       
        // Event handler for the Payments link
        protected void LinkButtonPayments_Click(object sender, EventArgs e)
        {
            LoadUserControl("Payments.ascx");
        }

        // Event handler for the Customers link
        protected void LinkButtonCustomers_Click(object sender, EventArgs e)
        {
            LoadUserControl("Customers.ascx");
        }

        // Event handler for the Notifications link
        protected void LinkButtonNotifications_Click(object sender, EventArgs e)
        {
            LoadUserControl("Notifications.ascx");
        }

        // Event handler for the Help & Support link
        protected void LinkButtonHelpSupport_Click(object sender, EventArgs e)
        {
            LoadUserControl("HelpSupport.ascx");
        }

        // Event handler for the Settings link
        protected void LinkButtonSettings_Click(object sender, EventArgs e)
        {
            LoadUserControl("Settings.ascx");
        }

        // Method to dynamically load the User Control
        private void LoadUserControl(string controlPath)
        {
            // Load the user control and clear previous content
            Control ctrl = LoadControl(controlPath);
            DynamicContent.Controls.Clear();
            DynamicContent.Controls.Add(ctrl);

        }
    }
}