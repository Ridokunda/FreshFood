<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Products.ascx.cs" Inherits="FreshFood.Products" %>

<div class="container-content">
    <div class="products_header">
        <div><h3>Products</h3></div>
        <div><asp:LinkButton runat="server">Add Product</asp:LinkButton></div>

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
                        <th>Product name</th>
                        <th>Product Quantity</th>
                        <th>Product Status</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Carrots</td>
                        <td>20</td>
                        <td>Available</td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        

    </div>

</div>