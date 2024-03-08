<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Foodie.User.checkout" %>
<%@ Import Namespace="Foodie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function showConfetti() {
        confetti({
            particleCount: 430,  // Number of confetti particles
            spread: 350,         // Spread of confetti particles
            origin: { y: 0.6 }   // Origin point (where confetti falls from)
        });
        return false;  // Prevent postback
    }
    </script>
     <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.6.0/dist/confetti.browser.min.js"></script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Include your other checkout page elements here --%>
    <!-- Add this to the <head> section of your ASP.NET page -->
<%--<script src="https://cdn.jsdelivr.net/npm/confetti-js@1.0.0/dist/index.js"></script>--%>
   


<div class="container mt-4">
    <div class="row">
        <div class="col-md-6">
            <div class="input-group mb-3">
                <%--<asp:TextBox ID="txtCouponCode" runat="server" CssClass="form-control" placeholder="Enter Coupon Code"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlCouponCodes" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Select Coupon Code --" Value=""></asp:ListItem>
                <asp:ListItem Text="SAVE30" Value="SAVE30"></asp:ListItem>
                <asp:ListItem Text="HALFOFFF" Value="HALFOFFF"></asp:ListItem>
                <asp:ListItem Text="FESTIVE10" Value="FESTIVE10"></asp:ListItem>
                     <asp:ListItem Text="DRINKANDEAT60" Value="DRINKANDEAT60"></asp:ListItem>
                
            </asp:DropDownList>
                <div class="input-group-append">
                    <asp:Button ID="btnApplyCoupon" runat="server" CssClass="btn btn-primary" Text="Apply Coupon" 
                         OnClick="btnApplyCoupon_Click" />
                    <%--<asp:Button ID="btnShowConfetti" runat="server" Text="Show Confetti" OnClientClick="return showConfetti();" CssClass="btn btn-primary" />--%>
                     <%--OnClientClick="return showConfetti();"--%>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="lblDiscountedTotal" runat="server" CssClass="h5 text-success" Text=""></asp:Label>
        </div>
    </div>
     <asp:Button ID="btnpaynow" runat="server" CssClass="btn btn-primary" Text="pAY NOW" OnClick="btnpaynow_Click" />
     <%--<asp:Button ID="btnpaynow" runat="server" CssClass="btn btn-primary" Text="pAY NOW" OnClick="btnpaynow_Click" />--%>


</div>


</asp:Content>
