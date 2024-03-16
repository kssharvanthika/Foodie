using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "showConfetti", "showConfetti();", true);
        }

        protected void btnApplyCoupon_Click(object sender, EventArgs e)
        {
            //string enteredCouponCode = txtCouponCode.Text;
            string selectedCouponCode = ddlCouponCodes.SelectedValue;

            // Database connection string
            string connectionString = "Data Source=Lenovo\\SQLEXPRESS;Initial Catalog=FoodieDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query the database to get coupon details
                string query = "SELECT DiscountPercentage, ExpirationDate FROM Coupons WHERE CouponCode = @CouponCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CouponCode", selectedCouponCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double discountPercentage = Convert.ToDouble(reader["DiscountPercentage"]);
                            DateTime expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                            if (expirationDate == DateTime.MinValue || expirationDate >= DateTime.Now)
                            {
                                // Check if the original total is greater than or equal to a certain condition before applying discount
                                double originalTotal = Convert.ToDouble(Session["grandTotalPrice"]);
                                double condition = 200.0; // Define your condition here, for example, $100

                                if (originalTotal >= condition)
                                {
                                    // Apply discount if the original total meets the condition
                                    double discountedTotal = originalTotal - (originalTotal * (discountPercentage / 100));

                                    // Display the discounted total to the user or update the order details
                                    lblDiscountedTotal.Text = $"Discounted Total: {discountedTotal:C}";
                                    Session["grandTotalPrice1"] = discountedTotal;
                                }
                                else
                                {
                                    // Display a message indicating that the original total doesn't meet the condition for the discount
                                    lblDiscountedTotal.Text = $"Coupon is not applicable for orders less than {condition:C}.";
                                }
                            }
                            else
                            {
                                // Display an error message indicating that the coupon is expired
                                lblDiscountedTotal.Text = "Coupon is expired.";
                            }
                        }
                        else
                        {
                            // Display an error message indicating that the coupon code is not valid
                            lblDiscountedTotal.Text = "Invalid Coupon Code.";
                        }
                    }
                }

            }
        }
                
            
        

        protected void btnpaynow_Click(object sender, EventArgs e)
        {
           Response.Redirect("Payment1.aspx");  
            //Response.Redirect("Payment.aspx");
        }
    }
    
}