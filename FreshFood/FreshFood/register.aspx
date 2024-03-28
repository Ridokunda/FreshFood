<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FreshFood.register" %>
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
      <h2>Register an Account</h2>
      <input type="text" id="CName" placeholder="Name" runat="server">
      <input type="text" id="CSurname" placeholder="Surname" runat="server">
      <input type="email" id="Cemail" placeholder="Email" runat="server">
      <input type="password" id="Fpassword" placeholder="Enter Password" runat="server">
      <input type="password" id="Cpassword" placeholder="Confirm Password" runat="server">
      <asp:Button Text="Register" id="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
  </div>
</asp:Content>
