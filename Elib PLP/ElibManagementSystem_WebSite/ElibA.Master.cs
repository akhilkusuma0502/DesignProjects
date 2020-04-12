using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ElibManagementSystem_WebSite
{
    public partial class ElibA : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Checks for Sessions And Performs Buttton Visibility Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] != null)
            {
                lblWelcome.Text = "Welcome " + Session["User_Name"].ToString();
                if (Session["User_Type"].ToString() == "Administrator")
                {
                    lblWelcome.Text = "Welcome Admin";
                    lnkEditProfile.Visible = false;
                    lnkRegister.Visible = false;
                }
                
                else
                {
                    lnkEditProfile.Visible = true;
                    lnkRegister.Visible = false;
                }
                    btnLogin.Visible = false;
                btnLogout.Visible = true;
            }
            else
            {
                lnkEditProfile.Visible = false;
                btnLogin.Visible = true;
                btnLogout.Visible = false;
            }
        }

        protected void lnkEditProfile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Redirects to Login Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        /// <summary>
        /// Clears Session and Redirects to Login Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("HomePage.aspx");

        }
    }
}