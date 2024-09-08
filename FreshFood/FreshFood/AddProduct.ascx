<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.ascx.cs" Inherits="FreshFood.AddProduct" %>

<div class="add-product-form">
    <h2>Add Product</h2>
    <asp:Label ID="lblName" runat="server" Text="Product Name:"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />

    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />

    <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />

    <asp:Label ID="lblImage" runat="server" Text="Product Image:"></asp:Label>
    <asp:FileUpload ID="fileUploadImage" runat="server" /><br /><br />

    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
</div>