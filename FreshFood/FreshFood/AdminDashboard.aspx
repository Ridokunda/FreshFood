<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FreshFood.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container">
        <div class="sidebar">
            <div class="Logo">
                <h3>FreshFood</h3>
            </div>
            <ul>
                <li><asp:LinkButton Text="Manage Products" runat="server" /></li>
                <li><asp:LinkButton Text="Manage Orders" runat="server" /></li>
                <li><asp:LinkButton Text="Manage Users" runat="server" /></li>
                <li><asp:LinkButton Text="" runat="server" /></li>
                <li><asp:LinkButton Text="Add Item" runat="server" /></li>
                <li><asp:LinkButton Text="Add Item" runat="server" /></li>
            </ul>
        </div>
        <div class="content">

        </div>
    </div>
    </form>
    
</body>
</html>
