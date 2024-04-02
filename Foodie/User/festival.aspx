<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="festival.aspx.cs" Inherits="Foodie.User.festival" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .product-card {
            border: 1px solid #ddd;
            border-radius: 10px;
            transition: box-shadow 0.3s ease-in-out;
        }

        .product-card:hover {
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        .product-image {
            max-width: 100%;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
            <h1 class="mt-5 mb-4">Festival Combo Offers</h1>
            <div class="row">
                <asp:Repeater ID="ProductRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card product-card">
                                <%--<img src='<%# Eval("ImageUrl") %>' class="card-img-top product-image" alt='<%# Eval("ProductName") %>' />--%>
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("ProductName") %></h5>
                                    <p class="card-text"><%# Eval("Description") %></p>
                                    <p class="card-text">Price: ₹<%# Eval("Price") %></p>
                                    <p class="card-text">Discounted Price: ₹<%# Eval("DiscountedPrice") %></p>
                                    
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-6 offset-md-3 text-center">
                    <h3>Total Price: ₹<asp:Literal ID="TotalPriceLiteral" runat="server"></asp:Literal></h3>
                </div>
                <a href="Payment1.aspx" class="btn btn-primary">Buy Now</a>
            </div>
        </div>
</asp:Content>
