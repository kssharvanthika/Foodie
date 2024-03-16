using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

using AjaxControlToolkit;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //        if (!IsPostBack)
            //        {
            //            // Retrieve the product ID from the query string
            //            if (Request.QueryString["ProductId"] != null)
            //            {
            //                int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            //                // Implement your logic to fetch and display product details
            //                DisplayProductDetails(productId);
            //            }
            //            else
            //            {
            //                // Handle the case when ProductId is not provided in the query string
            //                ltProductDetails.Text = "Product ID not specified.";
            //            }
            //        }
            //    }
            //    private void DisplayProductDetails(int productId)
            //    {
            //        // Implement your logic to fetch product details based on productId
            //        // For example, you might fetch data from a database or another source
            //        // Here, we'll use a placeholder string as an example
            //        string productDetails = $"Product ID: {productId}<br />Product Name: Sample Product<br />Price: $19.99";

            //        // Display product details in the Literal control
            //        ltProductDetails.Text = productDetails;
            //    }
            //}

            if (!IsPostBack)
            {
                // Perform initialization logic on the initial page load
                // For example, populate dropdowns, load initial data, etc.
                lblProductDetails.Text = "Welcome to Pizza Details!";
                
            }

            // Check for product ID in the query string
            if (!string.IsNullOrEmpty(Request.QueryString["productId"]))
            {
                int productId;
                if (int.TryParse(Request.QueryString["productId"], out productId))
                {
                    // Set the selected product ID in the dropdown
                    ddlProductId.SelectedValue = productId.ToString();
                }
            }
           
        }
        private DataTable GetData(string query)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        protected void btnDisplayDetails_Click(object sender, EventArgs e)
        {
            DisplayProductDetails();
        }

        private void DisplayProductDetails()
        {
            int productId;
            if (int.TryParse(ddlProductId.SelectedValue, out productId))
            {
                string pizzaSize = ddlPizzaSize.SelectedValue;
                string productDetails = GetPizzaDetails(productId, pizzaSize);
                ltProductDetails.Text = productDetails;
            }
            else
            {
                ltProductDetails.Text = "Invalid product ID. Please select a valid product.";
            }
        }

        private string GetPizzaDetails(int productId, string pizzaSize)
        {
            Dictionary<int, PizzaDetails> productDetails = new Dictionary<int, PizzaDetails>
    {
        { 8, new PizzaDetails("Schezwan Margherita", "Classic pepperoni goodness.", 140.20m) },
        { 9, new PizzaDetails("Mazedar Makhni Panner", "Fresh tomatoes, mozzarella, and basil.", 122.20m) },
        { 10, new PizzaDetails("Awesome American Cheesy", "A combination of various toppings.", 160.20m) },
        { 11, new PizzaDetails("Tandoori Paneer", "Loaded with veggies.", 130.50m) },
        { 12, new PizzaDetails("Dhabe Da Keema", "Pineapple, ham, and cheese.", 135.75m) },
        { 13, new PizzaDetails("Triple Chicken Feast", "Grilled chicken with BBQ sauce.", 150.80m) },
        { 14, new PizzaDetails("Sizzling Schezwan Chicken", "For the carnivores!", 165.90m) },
        // Add more product IDs and details as needed
    };

            if (productDetails.ContainsKey(productId))
            {
                PizzaDetails pizza = productDetails[productId];

                Dictionary<string, decimal> pizzaPrices = new Dictionary<string, decimal>
        {
            { "Personal", 140.20m },
            { "Small", 122.20m },
            { "Large", 160.20m },
            // Add more sizes and prices as needed
        };

                // Check if pizzaSize is valid
                if (pizzaPrices.ContainsKey(pizzaSize))
                {
                    decimal pizzaPrice = pizzaPrices[pizzaSize];
                    return $"Product ID: {productId}<br />Product Name: {pizza.Name}<br />Description: {pizza.Description}<br />Price: ₹{pizzaPrice}";
                }
                else
                {
                    return $"Invalid pizza size: {pizzaSize}";
                }
            }
            else
            {
                return "Invalid product ID. Please select a valid product.";
            }
        }

       

        // Define a class to hold additional details about each pizza
        public class PizzaDetails
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal BasePrice { get; set; }

            public PizzaDetails(string name, string description, decimal basePrice)
            {
                Name = name;
                Description = description;
                BasePrice = basePrice;
            }
        }

       
    }

}
