<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="Foodie.Admin.stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Include Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <!-- Include SweetAlert CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
            <!-- Product details -->
            <div class="form-group">
                <label for="ProductNameTextBox">Product Name:</label>
                <asp:TextBox ID="ProductNameTextBox" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ProductStockTextBox">Stock Status:</label>
                <asp:TextBox ID="ProductStockTextBox" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <asp:Button ID="UpdateStockButton" runat="server" Text="Update Stock" CssClass="btn btn-primary" OnClick="UpdateStockButton_Click" />
        </div>
    
    <!-- Include Bootstrap JS -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <!-- Include SweetAlert JS -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Your custom script -->
    <script>
        // Function to show SweetAlert with custom message
        function showAlert(title, message, type) {
            Swal.fire({
                title: title,
                text: message,
                icon: type,
                confirmButtonText: "OK"
            });
        }
    </script>
   
   
</asp:Content>
