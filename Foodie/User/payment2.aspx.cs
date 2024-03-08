using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class payment2 : System.Web.UI.Page
    {
        protected string orderId;
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btnPay_ServerClick(object sender, EventArgs e)
        {


            string key = ConfigurationManager.AppSettings["RazorpayKey"]; // Your Key ID
            string secret = ConfigurationManager.AppSettings["RazorpaySecret"]; // Your Secret Key

            // Create a Razorpay client
            RazorpayClient client = new RazorpayClient(key, secret);

            // Prepare order details
            Dictionary<string, object> input = new Dictionary<string, object>
            {
                { "amount", 100 }, // Amount in paisa (e.g., 100 = ₹1.00)
                { "currency", "INR" },
                { "receipt", "order_receipt_123" },
                { "payment_capture", 1 }
            };

            try
            {
                // Create an order
                Razorpay.Api.Order order = client.Order.Create(input);

                // Retrieve the order ID
                string orderId = order["id"];

                // Redirect to Razorpay payment page
                Response.Redirect($"PaymentPage.aspx?orderId={orderId}");
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log or display an error message)
                Response.Write($"Error: {ex.Message}");
            }
          
        }
      

    }
       


    }



   
