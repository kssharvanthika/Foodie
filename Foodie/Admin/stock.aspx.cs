using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.Admin
{
    public partial class stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Display product details and stock status (this data should come from your storage mechanism)
                ProductNameTextBox.Text = "pizza";
                ProductStockTextBox.Text = "In Stock";
            }
        }

        protected void UpdateStockButton_Click(object sender, EventArgs e)
        {
            if (ProductStockTextBox.Text == "In Stock")
            {
                // Send email to customers
                SendEmailToCustomers();
            }

            // Display feedback message
            //FeedbackLiteral.Text = "Stock updated successfully.";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "showAlert('Success', 'Stock updated successfully and email is sent !.', 'success');", true);
        }

        protected void SendEmailToCustomers()
        {
            try
            {
                // Configure SMTP client
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("icecube122001@gmail.com", "reojszutmbrhsuvx");
                    smtpClient.EnableSsl = true;

                    // Create email message
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("icecube122001@gmail.com");
                    mailMessage.To.Add("kssharvanthika123@gmail.com");
                    mailMessage.To.Add("dharanisrip03@gmail.com");
                    // Add more customers as needed

                    mailMessage.Subject = "Product Back in Stock";
                    mailMessage.Body = "The product you were interested in is now back in stock. Place your order now!";
                    mailMessage.IsBodyHtml = true;

                    // Send email
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or display error message)
                //FeedbackLiteral.Text = "Error sending email: " + ex.Message;
            }
        }
    }
    
}