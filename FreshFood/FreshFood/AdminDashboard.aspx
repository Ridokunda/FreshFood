<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FreshFood.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="/css/custom.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="admin-body">
            <!-- Sidebar -->
            <div class="sidebar">
                <div class="sidebar-header">
                    
                    <a class="navbar-brand" href="index.html">FreshFood</a>
                </div>
                <ul class="sidebar-menu">
                    <li>
                        <asp:LinkButton ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click">Dashboard</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonOrders" runat="server" OnClick="LinkButtonOrders_Click">Orders</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonInventory" runat="server" OnClick="LinkButtonInventory_Click">Products</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonPayments" runat="server" OnClick="LinkButtonPayments_Click">Payments</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonCustomers" runat="server" OnClick="LinkButtonCustomers_Click">Customers</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonNotifications" runat="server" OnClick="LinkButtonNotifications_Click">Notifications</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonHelpSupport" runat="server" OnClick="LinkButtonHelpSupport_Click">Help & Support</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButtonSettings" runat="server" OnClick="LinkButtonSettings_Click">Settings</asp:LinkButton>
                    </li>
                </ul>
                <div class="sidebar-footer">
                    <p>Olivia Williams</p>
                </div>
            </div>

            <div id="main-content">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanelMainContent" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="DynamicContent" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                   
                </asp:UpdatePanel>
            </div>
        </div>
        
    </form>
</body>
</html>
