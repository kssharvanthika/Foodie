using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.Url.AbsoluteUri.ToString().Contains("Default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");
            }
            else

            {
                form1.Attributes.Remove("class");
                //load the control
                Control sliderUserControl = (Control)Page.LoadControl("SliderUserControl1.ascx");
                //add the control to the panel
                pnSliderUC.Controls.Add(sliderUserControl);
            }
            if (Session["userId"]!=null)
            {
                lbloginOrLogout.Text = "Logout";
               Utils utils = new Utils();
                Session["cartCount"] = utils.cartCount(Convert.ToInt32(Session["userId"])).ToString(); 
            }
            else
            {
                lbloginOrLogout.Text = "Login";
                Session["cartCount"] = "0";
            }
        
       }

        protected void lbloginOrLogout_Click(object sender, EventArgs e)
        {
            if (Session["userId"]== null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        protected void lblRegisterOrProfie_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                lblRegisterOrProfie.ToolTip = "User Profile";
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lblRegisterOrProfie.ToolTip = "User Registration";
                Response.Redirect("Registration.aspx");
            }
        }
    }
}