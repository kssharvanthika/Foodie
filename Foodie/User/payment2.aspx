<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="payment2.aspx.cs" Inherits="Foodie.User.payment2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div>
            <h2>Razorpay Payment Integration</h2>
            <button id="btnPay" runat="server" onserverclick="btnPay_ServerClick">Pay Now</button>
        </div>
    
</asp:Content>
