<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="bookseat.aspx.cs" Inherits="Foodie.User.bookseat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .seat-button {
            margin: 5px;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }

        .error-message {
            color: red;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <h1>Restaurant Booking</h1>
    <div class="form-group">
        <label for="ddlSeats">Select a seat:</label>
        <asp:DropDownList ID="ddlSeats" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSeats_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="lblSeatError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtCustomerName">Customer Name:</label>
        <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblNameError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
        <asp:Label ID="lblEmailError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtBookingDate">Booking Date:</label>
        <asp:TextBox ID="txtBookingDate" runat="server" CssClass="form-control" TextMode="Date" OnLoad="txtBookingDate_Load"></asp:TextBox>
        <asp:Label ID="lblDateError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    </div>
    <asp:Button ID="btnBook" runat="server" Text="Book Seat" OnClick="btnBook_Click" CssClass="seat-button" />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
</div>

</asp:Content>
