using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Foodie.User
{
    public partial class vaccanyreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            // Save data into the database
            SaveRegistrationData(firstName, lastName, email, phone);

            // Send confirmation email
            SendConfirmationEmail(firstName, email);

            // Display success message
            pnlRegistration.Visible = false;
            pnlSuccessMessage.Visible = true;
        }

        private void SaveRegistrationData(string firstName, string lastName, string email, string phone)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO vacUsers (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SendConfirmationEmail(string firstName, string email)
        {
            // Configure SMTP settings
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587; // SMTP port number (e.g., 587 for Gmail)
            string smtpUsername = "icecube122001@gmail.com";
            string smtpPassword = "reojszutmbrhsuvx";

            // Create SMTP client
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            // Construct email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress("icecube122001@gmail.com");
            message.To.Add(email);
            message.Subject = "Registration Submitted successfully!";
            message.Body = $"Dear {firstName},\n\nThank you for registering on our company!Welcome to IceCube, where talent meets opportunity! We're thrilled to have you register with us\n\nBest regards,\nYour IceCube";

            // Send email
            smtpClient.Send(message);
        }
    }
}
    

    
