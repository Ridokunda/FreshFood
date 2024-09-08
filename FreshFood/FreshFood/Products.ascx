<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Products.ascx.cs" Inherits="FreshFood.Products" %>


    <div class="container-content">
        <div class="products_header">
            <div><h3>Products</h3></div>
            

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButtonAddProduct" runat="server" OnClick="LinkButtonAddProduct_Click">Add Product</asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div class="products-body">
            <div class="find">
                <div class="search-bar">
                    <input type="text" id="search" runat="server" />
                    <asp:Button ID="btnSearch" Text="Search" runat="server" />
                </div>
                <div class="filter-bar">
                    <select>
                        <option>ALL</option>
                        <option>ACTIVE</option>
                    </select>
                    <asp:Button ID="btnFilter" Text="Filter" runat="server" />
                </div>
            </div>
            <div class="products-table">
                <table>
                    <thead>
                        <tr>
                            <th>Product Image</th>
                            <th>Product Name</th>
                            <th>Product Quantity</th>
                            <th>Product Price</th>
                        </tr>
                    </thead>
                    <tbody id="itemsbody" runat="server">
                    
                    </tbody>
                </table>
            </div>
        </div>
    </div>

