using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("ContactSp", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@Message", txtMessage.Text.Trim());
                
                cmd.CommandType = CommandType.StoredProcedure;
                
                    con.Open();
                    cmd.ExecuteNonQuery();
                string senderEmail = "icecube122001@gmail.com"; // Change this to your email address
                string recipientEmail = txtEmail.Text.Trim(); // Use the email provided by the user
                string subject = "New Contact Form Submission";
                string body = "Name: " + txtName.Text.Trim() + "<br/>" +
                              "Email: " + txtEmail.Text.Trim() + "<br/>" +
                              "Subject: " + txtSubject.Text.Trim() + "<br/>" +
                              "Message: " + txtMessage.Text.Trim();

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(senderEmail, recipientEmail, subject, body);
                mail.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Send(mail);

                lblMsg.Visible = true;
                    lblMsg.Text = "Thanks for reaching out will look into your query";
                    lblMsg.CssClass = "alert alert-success";
                    Clear();
                   

                }
                catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            finally { con.Close(); }

        }

        private void Clear()
        {
            txtName.Text=string.Empty;
            txtEmail.Text=string.Empty;
            txtSubject.Text=string.Empty;
            txtMessage.Text=string.Empty;
            
        }
    }
}