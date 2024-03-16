<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="vaccanyreg.aspx.cs" Inherits="Foodie.User.vaccanyreg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-container {
            text-align: center;
        }

        .registration-form {
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    



      <div class="container">
        <div class="row">
            <div class="col-md-6">
                <!-- Registration Form -->
                <h2>Registration Form</h2>
                
                
                <asp:Panel ID="pnlRegistration" runat="server">
                    <div class="form-group">
                        <label for="txtFirstName">First Name:</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtLastName">Last Name:</label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtPhone">Phone Number:</label>
                        <asp:TextBox ID="txtPhone" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                </asp:Panel>
                <asp:Panel ID="pnlSuccessMessage" runat="server" Visible="false">
                    <div class="alert alert-success">
                        Registration Successful! An email has been sent to your registered email address.
                    </div>
                </asp:Panel>
            
        </div>
    
            <div class="col-md-6">
                <!-- Image -->
                <div class="image-container">
                    <img src="../Images/hiring.png" class="img-fluid" alt="Image">
                </div>
            </div>
        
    </div>
          </div>
</asp:Content>
