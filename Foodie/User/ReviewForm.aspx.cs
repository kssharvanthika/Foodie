using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class ReviewForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int rating = int.Parse(ddlRating.SelectedValue);
                string comment = txtComment.Text;
                string photoFileName = "";

                // Check if a file was uploaded
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    HttpPostedFile uploadedFile = Request.Files[0];
                    string fileName = Path.GetFileName(uploadedFile.FileName);

                    // Save the file to the server
                    string uploadFolder = Server.MapPath("../Images/review/");
                    string filePath = Path.Combine(uploadFolder, fileName);
                    uploadedFile.SaveAs(filePath);
                    photoFileName = fileName;

                    imgPreview.ImageUrl = "../Images/review/" + fileName; // Assuming imgPreview is an ASP.NET Image control
                    //lblFileName.Text = "Selected File: " + fileName;
                }

                // Save review to database
                string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                string insertQuery = "INSERT INTO Reviews (Rating, Comment, PhotoFileName) VALUES (@Rating, @Comment, @PhotoFileName)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.Parameters.AddWithValue("@PhotoFileName", photoFileName);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "Review submitted successfully!";
                lblMessage.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

    }
}