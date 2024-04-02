using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodie.User
{
    public partial class SliderUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookseat.aspx");
        }

        //protected void btnvacancy_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("vaccancy.aspx");
        //}
    }
}