using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblOrderId.Text = Request.QueryString["orderId"];
            lblPaymentId.Text = Request.QueryString["paymentId"];
        }
        protected void btnReorder_Click(object sender, EventArgs e)
        {
            // Implement the logic to reorder items here
            ReorderItems();
        }

        private void ReorderItems()
        {
            // Add your logic to retrieve and reorder items
            // For example, you can redirect to a new page with the reorder functionality
            Response.Redirect("Cart.aspx");
        }
    }

}
            //        string orderId = Request.QueryString["orderId"];
            //        string paymentId = Request.QueryString["paymentId"];

            //        string profileName = "John Doe"; // Replace with actual profile name
            //        string productName = "Product XYZ"; // Replace with actual product name
            //        int quantity = 2; // Replace with actual quantity
            //        decimal registrationAmount = 200.00m; // Replace with actual registration amount

            //         //Display OrderId and PaymentId in labels
            //        lblOrderId.Text = orderId;
            //        lblPaymentId.Text = paymentId;

            //        // Generate and download the invoice
            //        GenerateAndDownloadInvoice(orderId, paymentId, profileName, productName, quantity, registrationAmount);
            //    }

            //    private void GenerateAndDownloadInvoice(string orderId, string paymentId, string profileName, string productName, int quantity, decimal registrationAmount)
            //    {
            //        // Generate invoice content
            //        string invoiceContent = GenerateInvoiceContent(orderId, paymentId, profileName, productName, quantity, registrationAmount);

            //        // Save the invoice content to a temporary file
            //        string filePath = Server.MapPath("~/App_Data/Invoice.txt");
            //        File.WriteAllText(filePath, invoiceContent);

            //        // Provide the invoice file for download
            //        Response.Clear();
            //        Response.ContentType = "text/plain";
            //        Response.AddHeader("Content-Disposition", $"attachment; filename=Invoice_{orderId}.txt");
            //        Response.WriteFile(filePath);
            //        Response.End();

            //        // Delete the temporary file
            //        File.Delete(filePath);
            //    }

            //    private string GenerateInvoiceContent(string orderId, string paymentId, string profileName, string productName, int quantity, decimal registrationAmount)
            //    {
            //        // Customize this method to format the invoice content as needed
            //        string invoiceContent = $"Invoice Details\n\n";
            //        invoiceContent += $"Order ID: {orderId}\n";
            //        invoiceContent += $"Payment ID: {paymentId}\n";
            //        invoiceContent += $"Profile Name: {profileName}\n";
            //        invoiceContent += $"Product Name: {productName}\n";
            //        invoiceContent += $"Quantity: {quantity}\n";
            //        invoiceContent += $"Registration Amount: {registrationAmount}\n\n";
            //        invoiceContent += "Thank you for your payment!";

            //        return invoiceContent;
            //    }
            //}
        
    
    
