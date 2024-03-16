using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class Success : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    lblOrderId.Text = Request.QueryString["orderId"];
        //    lblPaymentId.Text = Request.QueryString["paymentId"];

        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve orderId and paymentId from query string
                string orderId = Request.QueryString["orderId"];
                string paymentId = Request.QueryString["paymentId"];
               // int productid = Request.QueryString["ProductId"];
                // Store orderId and paymentId in the database
                StorePurchaseInformation(orderId, paymentId);

                // Display orderId and paymentId on the page
                lblOrderId.Text = orderId;
                lblPaymentId.Text = paymentId;
            }
        }

        private void StorePurchaseInformation(string orderId, string paymentId)
        {
            // Your connection string
            string connectionString = "Data Source=Lenovo\\SQLEXPRESS;Initial Catalog=FoodieDB;Integrated Security=True";

            // Your SQL query to insert data into the database
            string query = "INSERT INTO PurchaseInformation1 (OrderId, PaymentId) VALUES (@OrderId, @PaymentId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to avoid SQL injection
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@PaymentId", paymentId);

                    // Open the connection and execute the query
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
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

        protected void btnreview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewForm.aspx");
        }
    }

}

        
    
    
