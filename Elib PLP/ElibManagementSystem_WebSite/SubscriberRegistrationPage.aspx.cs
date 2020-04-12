using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibManagementSystem_WebSite
{

    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    using System.Text.RegularExpressions;
    using System.Text;
    public partial class SubscriberRegistrationPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// MEthod Which Validates Card Details
        /// </summary>
        /// <returns></returns>

        private bool ValidateCard()
        {
            var IsValid = true;
            var ErrorMessages = new StringBuilder();
            var RegExObj = new Regex("^[0-9]{15}$");
            var RegexCVV = new Regex("^[0-9]{3}");
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtCreditCardNumber.Text) || !RegExObj.IsMatch(txtCreditCardNumber.Text))
            {
                IsValid = false;
            }

            if (ddlMonthExpiration.SelectedItem.Value == null)
            {
                IsValid = false;
            }
            if (ddlYearExpiration.SelectedItem.Value == null)
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtCVV.Text) || !RegexCVV.IsMatch(txtCVV.Text))
            {
                IsValid = false;
            }
            if (rdoPaymentModeGroup.SelectedItem.Value == null)
            {
                IsValid = false;
            }

            return IsValid;
        }

        /// <summary>
        /// Event That Fires on Submit Button Click Which Registers as Subscriber or Else NoN_Subscriber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User_details Obj = (User_details)Session["userObj"];
            var IsAdded = false;
            try
            {
                var subscriberBll = new User_detailsBLL();
                if (ValidateCard())
                {
                    IsAdded = subscriberBll.Register(Obj);
                    if (IsAdded)
                    {
                        // lblPaymentMessage.Text = "Thank you for Subscribing!You are a Subsciber";

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Registration Successful as " + Obj.UserType + "!!..Access Granted To documents!" + "');window.location='HomePage.aspx';", true);
                        //Response.Write("<script>alert('Thank you for Subscribing!You are a Subscriber')</script>");
                        //MessageBox.Show("Thankyou Subscribing!You are a Subsciber");
                    }
                    else
                    {
                        // lblPaymentMessage.Text = "Sorry,Subscription Failed";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Sorry!! Subscription Failed ');window.location='HomePage.aspx';", true);
                        //  Response.Redirect("HomePage.aspx");
                        //   Response.Write("<script>alert('Sorry,Subscription Failed')</script>");
                        // MessageBox.Show("Sorry,Subscription Failed");

                    }
                }
                else
                {
                    Obj.UserType = "Non_Subscriber";
                    IsAdded = subscriberBll.Register(Obj);
                    if (IsAdded)
                    {
                        // lblPaymentMessage.Text = "You are a Non Subsciber";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You are a Non-Subscriber');window.location='HomePage.aspx';", true);
                        //Response.Redirect("HomePage.aspx");
                        //     Response.Write("<script>alert('You are a Non Subsciber')</script>");
                        //MessageBox.Show("You are a Non Subsciber");



                    }
                    else
                    {
                        //  lblPaymentMessage.Text = "Sorry,Subscription Failed";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Sorry!! Subscription Failed ');window.location='HomePage.aspx';", true);
                        // Response.Redirect("HomePage.aspx");
                        //  Response.Write("<script>alert('Sorry,Subscription Failed')</script>");
                        //MessageBox.Show("Sorry,Subscription Failed");

                    }
                }
               // Response.Redirect("HomePage.aspx");
            }
            catch (ELibException)
            {
                Response.Write("<script>alert('Please check the details')</script>");
                //MessageBox.Show(ex.Message);
            }
            catch (Exception )
            {
                Response.Write("<script>alert('Sorry!Try again later')</script>");
                //MessageBox.Show(ex.Message);
            }
        }
    }
}