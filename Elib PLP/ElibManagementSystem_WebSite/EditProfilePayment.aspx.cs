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
    public partial class EditProfilePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            User_details Obj = (User_details)Session["UpdteObj"];
            var IsAdded = false;
            try
            {
                var subscriberBll = new User_detailsBLL();
                if (ValidateCard())
                {
                    IsAdded = subscriberBll.UpdateUserDetails(Obj);
                    if (IsAdded)
                    {

                        // lblEditProfileMessage.Text = "Thank you for Subscribing!You are a Subsciber";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Thank you for Subscribing!You are a Subscriber" + Obj.UserType + "!!..Access Granted To documents!" + "');window.location='HomePage.aspx';", true);
                        //        Response.Write("<script>alert('Thank you for Subscribing!You are a Subscriber')</script>");
                        // Response.Redirect("HomePage.aspx");
                        //MessageBox.Show("Thankyou Subscribing!You are a Subsciber");
                    }
                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Sorry,Subscription Failed');window.location='HomePage.aspx';", true);
                        //lblEditProfileMessage.Text = "Sorry,Subscription Failed";
                        //  Response.Write("<script>alert('Sorry,Subscription Failed')</script>");
                        // Response.Redirect("HomePage.aspx");
                        // MessageBox.Show("Sorry,Subscription Failed");

                    }
                }
                else
                {
                    Obj.UserType = "Non_Subscriber";
                    IsAdded = subscriberBll.Register(Obj);
                    if (IsAdded)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Subscription Failed');window.location='HomePage.aspx';", true);

                        //lblEditProfileMessage.Text = "You are a Non Subsciber";
                        //    Response.Write("<script>alert('You are a Non Subsciber')</script>");
                        //   Response.Redirect("HomePage.aspx");
                        //MessageBox.Show("You are a Non Subsciber");



                    }
                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Subscription Failed');window.location='HomePage.aspx';", true);
                        //lblEditProfileMessage.Text = "Sorry,Subscription Failed";
                        // Response.Write("<script>alert('Sorry,Subscription Failed')</script>");
                        // Response.Redirect("HomePage.aspx");
                        //MessageBox.Show("Sorry,Subscription Failed");
                    }
                }

            }
            catch (ELibException )
            {
                Response.Write("<script>alert('Please Check the details')</script>");
                //MessageBox.Show(ex.Message);
            }
            catch (Exception )
            {
                Response.Write("<script>alert('Sorry! Try again later.')</script>");
                //MessageBox.Show(ex.Message);
            }
        }
    }
}