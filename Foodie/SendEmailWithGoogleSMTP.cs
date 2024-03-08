using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Foodie
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fromMail = "icecube122001@gmail.com";
            string fromPassword = "cxfaxqqttqsnrcee";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("kssharvanthika123@gmail.com"));
            message.Body = "<html><body> Dear [Customer's Name],\r\n\r\nWe hope this message finds you well and craving something delightful! As a valued customer of [Your Restaurant Name], we are excited to extend an exclusive offer to express our gratitude for your continued support.\r\n\r\n🌟 Your Special Offer: [Offer Details] 🌟\r\n\r\n" +
                "Discount: [Percentage or Amount Off]\r\n" +
                "Promo Code: [Unique Promo Code]\r\n" +
                "Validity: Expires on [Expiration Date]" +
                "Thank you for being a part of our culinary journey!</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}