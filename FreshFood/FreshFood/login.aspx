<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FreshFood.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #regform{
            display:flex;
            align-content: center;
            flex-direction:column;
            justify-content:space-around;
            gap:10px;
            margin:100px;
            margin-left:450px;
            padding: 20px;
            border: 1px solid darkgrey;
            border-radius:10px;
            box-shadow:2px 3px 4px;
            width:fit-content;
        }
        input{
            width:400px;
            border:1px solid grey;
            border-radius:5px;
        }
        h2{
            text-align:center;
        }
        #btnSubmit{
            background-color:greenyellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="regform" id="regform" >
      <h2>Log in</h2>
      
      <input type="email" id="email" placeholder="Email" runat="server">
      <input type="password" id="password" placeholder="Enter Password" runat="server">
      
      <asp:Button Text="Log in" id="btnLogin" runat="server" OnClick="btnLogin_Click"  />
        <div id ="msg" runat="server" style="color: red;"></div>
  </div>
</asp:Content>
