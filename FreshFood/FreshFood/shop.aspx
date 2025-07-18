<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="FreshFood.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_1.jpg');">
      <div class="container">
        <div class="row no-gutters slider-text align-items-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center">
          	<p class="breadcrumbs"><span class="mr-2"><a href="index.aspx">Home</a></span> <span>Products</span></p>
            <h1 class="mb-0 bread">Products</h1>
          </div>
        </div>
      </div>
    </div>
    <section class="ftco-section">
    	<div class="container">
    		<div class="row justify-content-center">
    			<div class="col-md-10 mb-5 text-center">
    				<ul class="product-category">
    					<li><asp:LinkButton ID="btnAll" runat="server" OnClick="Category_Click">All</asp:LinkButton></li>
    					<li><asp:LinkButton ID="btnVegetables" runat="server" OnClick="Category_Click">Vegetables</asp:LinkButton></li>
    					<li><asp:LinkButton ID="btnFruits" runat="server" OnClick="Category_Click">Fruits</asp:LinkButton></li>
    					<li><asp:LinkButton ID="btnJuice" runat="server" OnClick="Category_Click">Juice</asp:LinkButton></li>
    					<li><asp:LinkButton ID="btnDried" runat="server" OnClick="Category_Click">Dried</asp:LinkButton></li>
    				</ul>
    			</div>
    		</div>
    		<div class="row" id="productRow" runat="server">
    			<asp:PlaceHolder ID="phProducts" runat="server"></asp:PlaceHolder>
    		</div>
    		<div class="row mt-5">
          <div class="col text-center">
            <div class="block-27">
              <ul>
                <li><a href="#">&lt;</a></li>
                <li class="active"><span>1</span></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li><a href="#">&gt;</a></li>
              </ul>
            </div>
          </div>
        </div>
    	</div>
    </section>

    
</asp:Content>
