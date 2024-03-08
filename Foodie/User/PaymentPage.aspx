<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="Foodie.User.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       // Set the delay (in milliseconds) before redirecting
       var delay = 20000; // 5000 milliseconds = 5 seconds

       // Function to redirect after the specified delay
       function redirect() {
           // Replace "NextPage.aspx" with the actual page you want to redirect to
           window.location.href = 'Invoice.aspx';
       }

       // Call the redirect function after the specified delay
       setTimeout(redirect, delay);
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script>
            var orderId = '<%= Request.QueryString["orderId"] %>';

            var options = {
                "key": "rzp_test_jq6ngtwXE6BeH0",
                "amount": 100, // Amount in paisa (e.g., 100 = ₹1.00)
                "currency": "INR",
                "name": "Your Merchant Name",
                "description": "Purchase Description",
                "order_id": orderId,
                "handler": function (response) {
                    // Handle successful payment (you may want to redirect or perform other actions)
                    alert('Payment successful! Payment ID: ' + response.razorpay_payment_id);
                },
                "prefill": {
                    "name": "Customer Name",
                    "email": "customer@example.com",
                    "contact": "+919876543210"
                },
                "notes": {
                    "address": "Customer Address"
                },
                "theme": {
                    "color": "#F37254"
                }
            };

            var rzp = new Razorpay(options);
            rzp.on('payment.failed', function (response) {
                // Handle payment failure
                alert('Payment failed! Error: ' + response.error.description);
            });

            rzp.open();
        </script>
     
</asp:Content>
