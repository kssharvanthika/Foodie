<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Foodie.User.ProductDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div>
            <h2>Product Details</h2>
            <div>
                <!-- Display product details here based on the code-behind logic -->
                <asp:Literal runat="server" ID="ltProductDetails" EnableViewState="false"></asp:Literal>
            </div>
        </div>--%>
    <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh; background-color: #f8f9fa;">
    <div class="text-center" style="background-color: #ffffff; padding: 20px; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
        <h2 style="color: #007bff;">Pizza Details</h2>
        <asp:Label ID="lblProductDetails" runat="server" Text="" style="color: #28a745;"></asp:Label>
        <br />

        <label for="ddlProductId" style="color: #343a40;">Select Product ID:</label>
        <asp:DropDownList ID="ddlProductId" runat="server" CssClass="form-control">
            <asp:ListItem Text="8" Value="8" />
            <asp:ListItem Text="9" Value="9" />
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="11" Value="11" />
            <asp:ListItem Text="12" Value="12" />
            <asp:ListItem Text="13" Value="13" />
            <asp:ListItem Text="14" Value="14" />
        </asp:DropDownList>
        <br />

        <label for="ddlPizzaSize" style="color: #343a40;">Select Pizza Size:</label>
        <asp:DropDownList ID="ddlPizzaSize" runat="server" CssClass="form-control">
            <asp:ListItem Text="Personal" Value="Personal" />
            <asp:ListItem Text="Small" Value="Small" />
            <asp:ListItem Text="Large" Value="Large" />
        </asp:DropDownList>
        <br />

        <asp:Button ID="btnDisplayDetails" runat="server" Text="Display Details" OnClick="btnDisplayDetails_Click" CssClass="btn btn-primary" />
        <br />

        <hr />

        <h3 style="color: #dc3545;">Product Details:</h3>
        <asp:Literal ID="ltProductDetails" runat="server" ></asp:Literal>
    </div>
</div>




</asp:Content>
