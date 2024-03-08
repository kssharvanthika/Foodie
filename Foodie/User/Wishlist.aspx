<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="Foodie.User.Wishlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .heart-icon {
        cursor: pointer;
        color: red;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
            <h2>Wishlist</h2>
            <asp:Repeater ID="rptWishlist" runat="server">
                <ItemTemplate>
                    <div>
                        <span><%# Eval("Name") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinkButton ID="lnkAddToWishlist" runat="server" OnClick="lnkAddToWishlist_Click">
                <span class="heart-icon">❤</span>
            </asp:LinkButton>
        </div>
</asp:Content>
