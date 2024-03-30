<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="FreshFood.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .add-item-form{
            display:flex;
            flex-flow:column;
            padding: 10px;
            margin:100px;
            margin-left:33%;
            gap:5px;
            border: 1px solid darkgrey;
            border-radius:10px;
            box-shadow: 2px 3px 4px;
            width:fit-content
        }
        input{
            width:400px;
            border-radius:4px;
            border:1px solid grey;
        }
        h2{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="add-item-form">
       <h2>Add Item</h2>
       <input type="text" id="item_name" runat="server" placeholder="Item name" >
       <input type="number" id="item_price" runat="server" placeholder="Item Price" >
       <input  id="item_cat" list="cat" runat="server" placeholder="Item Category">
       <datalist id="cat">
           <option value="Fruit"/>
           <option value="Vegetable"/>
           <option value="Meat" />
       </datalist>
       <input type="text" id="item_img" runat="server" placeholder="Image name" >
       <asp:Button Text="Add Item" runat="server" />
   </div>
</asp:Content>
