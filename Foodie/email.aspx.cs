using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Foodie
{
    public partial class email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential loginInfo;
                SmtpClient client;
                MailMessage mailMsg;

                loginInfo = new NetworkCredential(tFrom.Text, tPassword.Text);
                client = new SmtpClient(tSmptp.Text);
                client.Port=Convert.ToInt32(tPort.Text);
                client.EnableSsl = true;
                client.Credentials = loginInfo;

                mailMsg = new MailMessage();
                mailMsg.From=new MailAddress(tFrom.Text,"sharvanthikaks.22mca");
                mailMsg.To.Add(new MailAddress(tTo.Text));
                if(!string.IsNullOrEmpty(tCC.Text))
                    mailMsg.To.Add(new MailAddress(tCC.Text));

                mailMsg.Subject = tSubject.Text;
                mailMsg.Body = tMessage.Text;
                mailMsg.BodyEncoding=System.Text.Encoding.UTF8;
                mailMsg.IsBodyHtml = true;
                mailMsg.Priority=MailPriority.Normal;
                mailMsg.DeliveryNotificationOptions=DeliveryNotificationOptions.OnFailure;

                client.Send(mailMsg);

                lMsg.Text = "Your massage has been send succesfully";
            }
            catch(Exception ex)
            {
                lMsg.Text="Exception"+ex.Message; 
            }
        }
    }
}