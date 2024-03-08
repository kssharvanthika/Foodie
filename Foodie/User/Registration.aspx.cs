using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;

namespace Foodie.User
{
    public partial class Registration : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    getUserDetails();
                }
                else if (Session["userId"]!=null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, FileExtension = string.Empty;
            bool isValidToExecute = false;
            int userId = Convert.ToInt32(Request.QueryString["id"]);
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("User_Crud", con);
            cmd.Parameters.AddWithValue("@Action", userId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@PostCode", txtPostCode.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            if (fuUserImage.HasFile)
            {
                if (Utils.IsValidExtension(fuUserImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    FileExtension = Path.GetExtension(fuUserImage.FileName);
                    imagePath = "Images/User/" + obj.ToString() + FileExtension;
                    fuUserImage.PostedFile.SaveAs(Server.MapPath("~/Images/Product/") + obj.ToString() + FileExtension);
                    cmd.Parameters.AddWithValue("@ImageUrl", imagePath);
                    isValidToExecute = true;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please select .jpg or .jpeg or .png image";
                    lblMsg.CssClass = "alert alert-danger";
                    isValidToExecute = false;
                }
            }
            else
            {
                isValidToExecute = true;
            }

            if (isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = userId == 0 ?
                        "registration is successfull !<b><a href='Login.aspx'>Click here</a></b> to do login" :
                        "details updated sucessfully !<b><a href='Profile.aspx'>Can check here</a></b>";
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b>" + actionName;
                    lblMsg.CssClass = "alert alert-success";
                    if (userId != 0)
                    {
                        Response.AddHeader("REFRESH", "1;URL=Profile.aspx");
                    }
                    Clear();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "<b>" + txtUserName.Text.Trim()+"</b> Username already exist, try new one..!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error - " + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    con.Close();
                }
            }
        }
        void getUserDetails()
        {
            con=new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("User_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda=new SqlDataAdapter(cmd);
            dt=new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtUserName.Text = dt.Rows[0]["Username"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
                txtPostCode.Text = dt.Rows[0]["PostCode"].ToString();
                imgUser.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["ImageUrl"].ToString())
                    ? "../Images/No_image.png" : "../" +dt.Rows[0]["ImageUrl"].ToString();
                imgUser.Height = 200;
                imgUser.Width = 200;
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtPassword.ReadOnly = true;
                txtPassword.Text = dt.Rows[0]["password"].ToString();
            }
            lblHeaderMsg.Text = "<h2>Edit Profile</h2>";
            btnRegister.Text = "Update";
            lblAlreadyUser.Text = "";
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

        

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
           


            
                string userEmail = txtEmail.Text;

                // TODO: Validate email format and check if it's a registered email

                // Generate OTP
                string otp = GenerateOTP();

                // Send OTP to the user's email
                SendEmail(userEmail, "OTP for Registration (ICE CUBE)", $"Your OTP is: {otp}");

                // Store OTP in session or database for verification
                Session["UserOTP"] = otp;

                lblMessage.Text = "OTP has been sent to your email.";
            }

            protected void btnVerifyOTP_Click(object sender, EventArgs e)
            {
                string enteredOTP = txtEnteredOTP.Text;

                if (Session["UserOTP"] != null)
                {
                    string storedOTP = Session["UserOTP"].ToString();

                    if (enteredOTP == storedOTP)
                    {
                        lblMessage.Text = "OTP verification successful. User registered!";
                        // TODO: Implement user registration logic
                    }
                    else
                    {
                        lblMessage.Text = "Incorrect OTP. Please try again.";
                    }

                    // Clear the stored OTP after verification
                    Session.Remove("UserOTP");
                }
                else
                {
                    lblMessage.Text = "OTP session expired. Please request a new OTP.";
                }
            }

            private string GenerateOTP()
            {
                // TODO: Implement your OTP generation logic (e.g., using Random class)
                //return "123456"; // For simplicity, return a hardcoded value in this example
            
                 Random r = new Random();

                 string otp = r.Next(10001, 99999).ToString();
            return otp;
        }

        private void SendEmail(string to, string subject, string body)
            {
                // TODO: Update email settings with your SMTP server details
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
            string smtpUsername = "icecube122001@gmail.com";
                string smtpPassword = "dfzngfbaqiorvvmm";

                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                //MailMessage message = new MailMessage("icecube122001@gmail.com", "kssharvanthika123@gmail.com", "OTP for Registration", "hai");
                MailMessage message = new MailMessage("icecube122001@gmail.com", to, subject, body);
                client.Send(message);
                }
            }
        }
    }


    
    
