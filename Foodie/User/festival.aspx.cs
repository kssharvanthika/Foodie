using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class festival : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulated data for New Year festival offers
                List<Product> products = new List<Product>
                {
                    new Product { ProductName = "New Year Party Pack", Description = "Celebrate New Year with this party pack including hats, balloons, and streamers.", Price = 50, DiscountedPrice = 40 },
                    new Product { ProductName = "New Year Special Dinner Set", Description = "Host a special dinner with this elegant dinner set including plates, glasses, and cutlery.", Price = 100, DiscountedPrice = 80},
                    new Product { ProductName = "New Year Decorations Bundle", Description = "Make your home festive with this decorations bundle including banners, lights, and confetti.", Price = 80, DiscountedPrice = 65 }
                    // Add more products as needed
                };

                // Bind the data to the repeater
                ProductRepeater.DataSource = products;
                ProductRepeater.DataBind();

                // Calculate total price
                decimal totalPrice = 0;
                foreach (Product product in products)
                {
                    totalPrice += product.DiscountedPrice;
                }

                // Store total price in session variable
                Session["grandTotalPrice"] = totalPrice;

                // Display total price with currency symbol
                TotalPriceLiteral.Text = totalPrice.ToString("0.00");
            }
        }
    }

    // Product class to hold product information
    public class Product
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}

        
    
