<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Foodie.User.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h5 class="mb-0">Reset My Password</h5>
                    </div>
                    <div class="card-body">
                        <%--<form>--%>
                        <div class="form-group row">
                            <label for="txtUserName" class="col-sm-4 col-form-label">User Name</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <!----email-->
                        <div class="form-group row">
                            <label for="txtemail" class="col-sm-4 col-form-label">Registered Email</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtemail" runat="server" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-8 offset-sm-4">
                                <asp:Button ID="btnResetPassword" runat="server"
                                    Width="170px" Text="send the Password" CssClass="btn btn-primary" OnClick="btnResetPassword_Click" />
                            </div>
                        </div>
                        <%--</form>--%>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
