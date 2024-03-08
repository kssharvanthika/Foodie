<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Foodie.User.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
</asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Success</h1>
<div class="row">
    <div class="col-md-offset-1 col-md-8">
        <asp:Label runat="server" Text="Your payment against the registration is successful. Please note the OrderId for future reference" />
    </div>
</div>
<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Order Id</label>
    </div>
    <div class="col-md-3">
        <asp:Label runat="server" ID="lblOrderId" Font-Bold="true" />
    </div>
</div>
<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Payment Id</label>
    </div>
    <div class="col-md-3">
        <asp:Label runat="server" ID="lblPaymentId" Font-Bold="true" />
    </div>
</div>
   
        <div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">The only way to do great work is to love what you do</label>
    </div>
    <div class="col-md-3">
        <asp:Button ID="btnReorder" runat="server" Text="Reorder" OnClick="btnReorder_Click" CssClass="btn btn-primary" />

    </div>
</div>
   

    <%--<div class="container mt-5">
        <div class="row">
            <div class="col-md-12 text-center">
                <h1 class="display-4">Payment Success!</h1>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-offset-1 col-md-10">
                <div class="card">
                    <div class="card-header">
                        <h3>Order Details</h3>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-3">
                                <strong>Order ID:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblOrderId" CssClass="font-weight-bold" />
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-3">
                                <strong>Payment ID:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblPaymentId" CssClass="font-weight-bold" />
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-3">
                                <strong>Profile Name:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblProfileName" CssClass="font-weight-bold" />
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-3">
                                <strong>Product Name:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblProductName" CssClass="font-weight-bold" />
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-3">
                                <strong>Quantity:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblQuantity" CssClass="font-weight-bold" />
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-3">
                                <strong>Registration Amount:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="lblRegistrationAmount" CssClass="font-weight-bold" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
