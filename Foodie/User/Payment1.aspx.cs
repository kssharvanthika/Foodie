using EO.WebBrowser;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class Payment1 : System.Web.UI.Page
    {
        private const string _key = "rzp_test_jq6ngtwXE6BeH0";
        private const string _secret = "FZpFs1GRpkCTRiDcBBLh9lUK";
        // private const decimal registrationAmount = 100;
        private decimal registrationAmount;
        //private readonly decimal registrationAmount = (decimal)HttpContext.Current.Session["grandTotalPrice1"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Assuming "grandTotalPrice1" is a decimal in the session
                if (Session["grandTotalPrice1"] != null && decimal.TryParse(Session["grandTotalPrice1"].ToString(), out decimal sessionAmount))
                {
                    registrationAmount = sessionAmount;
                    ViewState["RegistrationAmount"] = registrationAmount;
                    Console.WriteLine("Session Value (Decimal): " + sessionAmount);
                }
                else
                {
                    registrationAmount = (decimal)Convert.ToDouble(Session["grandTotalPrice"]);
                    // Default value if session variable is not available or not valid
                    //registrationAmount = (decimal)Convert.ToDouble(Session["TotalPrice"]);
                    ViewState["RegistrationAmount"] = registrationAmount;
                }
                Console.WriteLine("Registration Amount (After Session): " + registrationAmount);
                txtAmount.Text = registrationAmount.ToString();
            }
            else
            {
                registrationAmount = (decimal)ViewState["RegistrationAmount"];
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            decimal amountinSubunits = registrationAmount * 100;
            Console.WriteLine("amountinSubunits Amount : " + amountinSubunits);
            string currency = "INR";
            string name = (string)Session["username"];
            string description = "Razorpay Payment Gateway Demo";
            string imageLogo = "";
            string profileName = txtName.Text;
           string profileMobile = txtMobile.Text;
            string profileEmail = txtEmail.Text;
            Dictionary<string, string> notes = new Dictionary<string, string>()
            {
                { "note 1", "this is a payment note" }, { "note 2", "here another note, you can add max 15 notes" }
            };

            string orderId = CreateOrder(amountinSubunits, currency, notes);

            //string redirectUrl = $"Success.aspx?orderId={orderId}";
            //Response.Redirect(redirectUrl);
            //$"&paymentId={response.razorpay_payment_id}&profileName={profileName}&productName={productName}&quantity={quantity}&registrationAmount={registrationAmount}";
            string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "', '" + JsonConvert.SerializeObject(notes) + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);

           
        }

        

        private string CreateOrder(decimal amountInSubunits, string currency, Dictionary<string, string> notes)
        {
            try
            {
                int paymentCapture = 1;

                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", amountInSubunits);
                options.Add("currency", currency);
                options.Add("payment_capture", paymentCapture);
                options.Add("notes", notes);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.Expect100Continue = false;

                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    
}