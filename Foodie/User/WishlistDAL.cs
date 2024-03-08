using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Foodie.User
{


    public class WishlistDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cs"].ToString();

        public List<Product> GetWishlistItems(int userId)
        {
            List<Product> wishlistItems = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Products.name FROM Wishlist " +
                                   "INNER JOIN Products ON Wishlist.ProductsId = Products.ProductsId " +
                                   "WHERE Wishlist.UserId = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    ProductName = Convert.ToString(reader["name"])
                                };

                                wishlistItems.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
            }

            return wishlistItems;
        }

        public void AddToWishlist(int userId, int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Wishlist (UserId, ProductsId) VALUES (@UserId, @ProductId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@ProductId", productId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
            }
        }
    }

}
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    // Add other user-related properties as needed
}

// Product.cs
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    // Add other product-related properties as needed
}





