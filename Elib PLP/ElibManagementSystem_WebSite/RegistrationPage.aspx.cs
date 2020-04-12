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
    public partial class RegistrationPage : System.Web.UI.Page
    {
        /// <summary>
        /// On Page Load The PageLoad Event Sets The DateOf Regeistration to Current Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDateOfRegistration.Text = DateTime.Now.ToShortDateString();
            
        }
        /// <summary>
        /// Event That Fires on Button Register Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User_details userObj = new User_details();
                userObj.UserId = txtUserId.Text;
                userObj.FirstName = txtFirstName.Text;
                userObj.LastName = txtLastName.Text;
                userObj.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                userObj.Address = txtAddress.Text;
                userObj.LandLineNumber = txtLandlineNumber.Text;
                userObj.MobileNumber = txtMobileNumber.Text;
                string strCheckValue = "";

                for (int i = 0; i < chkAreaOfInterestList.Items.Count; i++)
                {
                    if (chkAreaOfInterestList.Items[i].Selected)
                    {
                        strCheckValue += chkAreaOfInterestList.Items[i].Value + ",";
                    }
                }
                strCheckValue = strCheckValue.TrimEnd(',');



                userObj.AreaOfInterest = strCheckValue;

                userObj.Gender = rdoGenderGroup.SelectedItem.Value.ToString();
                userObj.UserType = rdoUserTypeGroup.SelectedItem.Value.ToString();


                userObj.DateOfRegistration = Convert.ToDateTime(txtDateOfRegistration.Text);
                userObj.Password = txtPassword.Text;




                if (userObj.UserType == "Subscriber")
                {
                    Session["userObj"] = userObj;
                    Response.Redirect("SubscriberRegistrationPage.aspx");
                }
                else
                {
                    var userBLL = new User_detailsBLL();
                    var IsAddedUser = userBLL.Register(userObj);
                    if (IsAddedUser)
                    {
                        //lblRegistrationMessage.Text = "Registration Successful as " + userObj.UserType + "!!..Access Granted To documents!";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Registration Successful as" + userObj.UserType + "!!..Access Granted To documents!" + "');window.location='HomePage.aspx';", true);

                    }
                    else
                    {

                        Response.Write("<script>alert('Sorry!!!..Registration Failed.Try Again Later')</script>");
                    }
                }

            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Please Check The Details')</script>");


            }
        }
    }
}