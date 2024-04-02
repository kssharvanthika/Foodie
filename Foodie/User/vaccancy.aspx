<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vaccancy.aspx.cs" Inherits="Foodie.User.vaccancy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <!-- Include SweetAlert CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">
</head>
<body onload="showSweetAlert()">
    <form id="form1" runat="server">
        <div>
            <h1>hai</h1>
        </div>
    </form>

    <!-- Include Bootstrap JS -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <!-- Include SweetAlert JS -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script type="text/javascript">
        function showSweetAlert() {
            Swal.fire({
                title: "<strong>STAFF WANTED <u></u></strong>",
                icon: "info",
                html: `
                    We are hiring <b>!</b> <br>
                    <a href="vaccanyreg.aspx">Register now </a><br>
                    <i>APPLY WITHIN-</i><b>icecube122001@gmail.com</b><br>
                    <strong>Call Us <u>8778955509</u></strong>
                `,
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText: `
                    <i class="fa fa-thumbs-up"></i> Great!
                `,
                confirmButtonAriaLabel: "Thumbs up, great!",
                cancelButtonText: `
                    <i class="fa fa-thumbs-down"></i>
                `,
                cancelButtonAriaLabel: "Thumbs down"
            });
        }
    </script>
</body>
    </html>