using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;
using System.Reflection.Emit;

namespace Foodie.User
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            //    string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            //   // con = new SqlConnection(Connection.GetConnectionString());
            //    using (SqlConnection con = new SqlConnection(CS))
            //    {
            //        SqlCommand cmd = new SqlCommand("spResetPassword", con);
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        SqlParameter paramUsername = new SqlParameter("@UserName", txtUserName.Text);

            //        cmd.Parameters.Add(paramUsername);

            //        con.Open();
            //        SqlDataReader rdr = cmd.ExecuteReader();
            //        while (rdr.Read())
            //        {
            //            if (Convert.ToBoolean(rdr["ReturnCode"]))
            //            {
            //                SendPasswordResetEmail(rdr["Email"].ToString(), txtUserName.Text, rdr["UniqueId"].ToString());
            //                lblMessage.Text = "An email with instructions to reset your password is sent to your registered email";
            //            }
            //            else
            //            {
            //                lblMessage.ForeColor = System.Drawing.Color.Red;
            //                lblMessage.Text = "Username not found!";
            //            }
            //        }
            //    }
            //}


            //private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
            //{
            //    // MailMessage class is present is System.Net.Mail namespace
            //    MailMessage mailMessage = new MailMessage("icecube122001@gmail.com", ToEmail);


            //    // StringBuilder class is present in System.Text namespace
            //    StringBuilder sbEmailBody = new StringBuilder();
            //    sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            //    sbEmailBody.Append("Please click on the following link to reset your password");
            //    sbEmailBody.Append("<br/>"); 
            //    sbEmailBody.Append("http://localhost/User/ChangePassword.aspx?uid=" + UniqueId);

            //    sbEmailBody.Append("<br/><br/>");
            //    sbEmailBody.Append("<b>Ice Cube Cafe</b>");

            //    mailMessage.IsBodyHtml = true;

            //    mailMessage.Body = sbEmailBody.ToString();
            //    mailMessage.Subject = "Reset Your Password";
            //    // SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //    //smtpClient.Credentials = new System.Net.NetworkCredential()
            //    //{
            //    //    UserName = "icecube122001@gmail.com",
            //    //    Password = "dfzngfbaqiorvvmm"
            //    //};

            //    //smtpClient.EnableSsl = true;
            //    //smtpClient.UseDefaultCredentials = false;
            //    //smtpClient.Send(mailMessage);


            //    string smtpServer = "smtp.gmail.com";
            //    int smtpPort = 587;
            //    string smtpUsername = "icecube122001@gmail.com";
            //    string smtpPassword = "reojszutmbrhsuvx";

            //    using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            //    {
            //        client.EnableSsl = true;
            //        client.UseDefaultCredentials = false;
            //        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            //        //MailMessage message = new MailMessage("icecube122001@gmail.com", "kssharvanthika123@gmail.com", "OTP for Registration", "hai");

            //        client.Send(mailMessage);
            //    }
            //}

            String password;
            String mycon = " Data Source=Lenovo\\SQLEXPRESS;Initial Catalog=FoodieDB;Integrated Security=True";
            String myquery = "Select * from Users where Username='" + txtUserName.Text + "' and Email='" + txtemail.Text + "'";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Label3.Text = "Data Found";

                password = ds.Tables[0].Rows[0]["Password"].ToString();
                sendpassword(password, txtemail.Text);
                lblMessage.Text = "Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";

            }
            else
            {
                lblMessage.Text = "Your Username is Not Valid or Email Not Registered";

            }
            con.Close();

        }
        private void sendpassword(String password, String email)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("icecube122001@gmail.com", "reojszutmbrhsuvx");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Forgot Password ( IceCub)";
            msg.Body = "Dear " + txtUserName.Text + ", Your Password is  " + password + "\n\n\nThanks & Regards\nIceCube Cafe Team";
            string toaddress = txtemail.Text;
            msg.To.Add(toaddress);
            string fromaddress = "IceCube Cafe <icecube122001@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);


            }
            catch
            {
                throw;
            }
        }

    }
}