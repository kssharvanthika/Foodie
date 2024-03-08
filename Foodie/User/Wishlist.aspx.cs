using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class Wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWishlist();
            }
        }
        private void LoadWishlist()
        {
            WishlistDAL wishlistDAL = new WishlistDAL();
            int userId = 1; // Replace with your actual user ID

            List<Product> wishlistItems = wishlistDAL.GetWishlistItems(userId);
            rptWishlist.DataSource = wishlistItems;
            rptWishlist.DataBind();
        }
        protected void lnkAddToWishlist_Click(object sender, EventArgs e)
        {
            int productId = 101; // Replace with your actual product ID

            WishlistDAL wishlistDAL = new WishlistDAL();
            int userId = 1; // Replace with your actual user ID

            wishlistDAL.AddToWishlist(userId, productId);

            // Reload the wishlist items
            LoadWishlist();
        }
    }
}