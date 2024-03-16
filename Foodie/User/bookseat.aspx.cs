using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class bookseat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAvailableSeats();
            }
        }
        //protected void LoadAvailableSeats()
        //{
        //    List<int> availableSeats = GetAvailableSeats();
        //    ddlSeats.DataSource = availableSeats;
        //    ddlSeats.DataBind();
        //}

        protected void LoadAvailableSeats()
        {
            ddlSeats.Items.Clear(); // Clear existing items

            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SeatID, IsAvailable FROM Seats";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int seatID = reader.GetInt32(0);
                        bool isAvailable = reader.GetBoolean(1);

                        ListItem item = new ListItem($"Seat {seatID}", seatID.ToString());

                        // If seat is available, add it to the dropdown
                        if (isAvailable)
                        {
                            ddlSeats.Items.Add(item);
                        }
                        else
                        {
                            // If seat is booked, disable it and add it to the dropdown
                            item.Attributes.Add("disabled", "disabled");
                            ddlSeats.Items.Add(item);
                        }
                    }
                    reader.Close();
                }
            }
        }


        protected List<int> GetAvailableSeats()
        {
            List<int> availableSeats = new List<int>();

            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SeatID FROM Seats WHERE IsAvailable = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int seatID = (int)reader["SeatID"];
                            availableSeats.Add(seatID);
                        }
                    }
                }
            }
            return availableSeats;
        }
        protected void ddlSeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeatError.Visible = false;
        }
        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (ValidateBooking())
            {
                int selectedSeat = int.Parse(ddlSeats.SelectedValue);
                string customerName = txtCustomerName.Text;
                string email = txtEmail.Text; // New: Get email from textbox
                DateTime bookingDate = DateTime.Parse(txtBookingDate.Text);

                bool isSeatAvailable = CheckSeatAvailability(selectedSeat);

                if (isSeatAvailable)
                {
                    // Book the seat
                    BookSeat(selectedSeat, customerName,email, bookingDate);
                    lblMessage.Text = "Booking successful.";
                }
                else
                {
                    lblMessage.Text = "All seats are filled. Please try again later.";
                }

                LoadAvailableSeats();
                ClearFields();
            }
        }
        protected bool CheckSeatAvailability(int seatID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Seats WHERE SeatID = @SeatID AND IsAvailable = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SeatID", seatID);
                    connection.Open();
                    int availableSeatCount = (int)command.ExecuteScalar();
                    return availableSeatCount > 0;
                }
            }
        }

        protected void BookSeat(int seatID, string customerName, string email, DateTime bookingDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bookings (CustomerName, Email, SeatID, BookingDate) VALUES (@CustomerName, @Email, @SeatID, @BookingDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@Email", email); // New: Add email parameter
                    command.Parameters.AddWithValue("@SeatID", seatID);
                    command.Parameters.AddWithValue("@BookingDate", bookingDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                query = "UPDATE Seats SET IsAvailable = 0 WHERE SeatID = @SeatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SeatID",seatID);
                    command.ExecuteNonQuery();
                }
            }

            SendConfirmationEmail(customerName, email, seatID, bookingDate); // New: Send confirmation email
            lblMessage.Text = $"Seat {seatID} has been booked for {customerName} on {bookingDate.ToShortDateString()}. Confirmation email has been sent.";
            LoadAvailableSeats();
            //ClearFields();

        }
        //protected bool IsSeatAvailable(int seatID)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT IsAvailable FROM Seats WHERE SeatID = @SeatID";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@SeatID", seatID);
        //            connection.Open();
        //            object result = command.ExecuteScalar();
        //            return (result != null && (bool)result);
        //        }
        //    }
        //}

        protected bool ValidateBooking()
        {
            bool isValid = true;
            lblSeatError.Visible = false;
            lblNameError.Visible = false;
            lblDateError.Visible = false;
            lblEmailError.Visible = false;

            if (ddlSeats.SelectedIndex == -1)
            {
                lblSeatError.Text = "Please select a seat.";
                lblSeatError.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                lblNameError.Text = "Please enter customer name.";
                lblNameError.Visible = true;
                isValid = false;
            }

            DateTime bookingDate;
            if (!DateTime.TryParse(txtBookingDate.Text, out bookingDate))
            {
                lblDateError.Text = "Please enter a valid booking date.";
                lblDateError.Visible = true;
                isValid = false;
            }

            // New: Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                lblEmailError.Text = "Please enter a valid email address.";
                lblEmailError.Visible = true;
                isValid = false;
            }

            return isValid;
        }

        protected bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected void SendConfirmationEmail(string customerName, string email, int seatID, DateTime bookingDate)
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            string senderEmail = ConfigurationManager.AppSettings["SenderEmail"];

            string subject = "Icecube table Booking Confirmation";
            string body = $"Dear {customerName},\n\n";
            body += $"Your booking for seat {seatID} on {bookingDate.ToShortDateString()} has been confirmed.\n\n";
            body += "Thank you for choosing our Cafe!\n\n";
            body += "Regards,\nThe IceCube Team";

            MailMessage mail = new MailMessage(senderEmail, email, subject, body);
            mail.IsBodyHtml = false;

            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // Handle email sending errors
            }
        }

        protected void ClearFields()
        {
            ddlSeats.SelectedIndex = -1;
            txtCustomerName.Text = string.Empty;
            txtBookingDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void txtBookingDate_Load(object sender, EventArgs e)
        {
            // Retrieve booked dates from the database
            List<DateTime> bookedDates = GetBookedDatesFromDatabase();

            // Generate JavaScript to disable booked dates
            string script = "<script>";
            foreach (DateTime bookedDate in bookedDates)
            {
                // Convert the booked date to a string in the format yyyy-MM-dd
                string formattedDate = bookedDate.ToString("yyyy-MM-dd");

                // Append JavaScript to disable the date
                script += $"$('#{txtBookingDate.ClientID}').datepicker('setDate', '{formattedDate}'); $('#{txtBookingDate.ClientID}').datepicker('option', 'beforeShowDay', function(date) {{ var disabledDates = [";

                // Add the booked date to the array of disabled dates
                script += $"new Date('{formattedDate}'),";

                script += "];";
                script += "var string = jQuery.datepicker.formatDate('yy-mm-dd', date);";
                script += "return [disabledDates.indexOf(date.getTime()) === -1];";
                script += "});";
            }
            script += "</script>";

            // Register the JavaScript with the page
            ScriptManager.RegisterStartupScript(this, GetType(), "DisableBookedDates", script, false);
        }



        // Method to retrieve booked dates from the database
        protected List<DateTime> GetBookedDatesFromDatabase()
            {
            
                List<DateTime> bookedDates = new List<DateTime>();

                string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT BookingDate FROM Bookings";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime bookedDate = reader.GetDateTime(0); // Assuming BookingDate is the first column
                                bookedDates.Add(bookedDate.Date); // Add the booked date to the list
                            }
                        }
                    }
                }

                return bookedDates;
            }
        }

        
    
}

        