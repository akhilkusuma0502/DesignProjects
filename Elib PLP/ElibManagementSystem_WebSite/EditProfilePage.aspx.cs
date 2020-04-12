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
    public partial class EditProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event That Fires On Update Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                User_details UpdteObj = new User_details();
                UpdteObj.UserId = Session["User_ID"].ToString();
                UpdteObj.FirstName = txtFirstName.Text;
                UpdteObj.LastName = txtLastName.Text;
                UpdteObj.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                UpdteObj.Address = txtAddress.Text;
                UpdteObj.LandLineNumber = txtLandlineNumber.Text;
                UpdteObj.MobileNumber = txtMobileNumber.Text;
                string strCheckValue = "";

                for (int i = 0; i < chkAreaOfInterestList.Items.Count; i++)
                {
                    if (chkAreaOfInterestList.Items[i].Selected)
                    {
                        strCheckValue += chkAreaOfInterestList.Items[i].Value + ",";
                    }
                }
                strCheckValue = strCheckValue.TrimEnd(',');

                UpdteObj.AreaOfInterest = strCheckValue;

                UpdteObj.Gender = rdoGenderGroup.SelectedItem.Value.ToString();
                UpdteObj.UserType = rdoUserTypeGroup.SelectedItem.Value.ToString();

                if (UpdteObj.UserType == "Subscriber" && type == "Non_Subscriber")
                {
                    Session["UpdteObj"] = UpdteObj;
                    Response.Redirect("EditProfilePayment.aspx");
                }
                //if(UpdteObj.UserType == "Non_Subscriber" && type == "Subscriber")
                else
                {

                    var userBLL = new User_detailsBLL();
                    var IsAddedUser = userBLL.UpdateUserDetails(UpdteObj);
                    if (IsAddedUser)
                    {
                        Session["User_Name"] = UpdteObj.FirstName + " " + UpdteObj.LastName;
                        Response.Write("<script>alert('Details Updated')</script>");

                        // Response.Write("<script>alert('Updated!!!! ')</script>");

                    }
                    else
                    {
                      //  lblUpdateMessage.Text = "Sorry!!!..Updation Failed.Try Again Later";
                         Response.Write("<script>alert('Sorry!!!..Updation Failed.Try Again Later')</script>");               
                    }
                    //Session["userObj"] = UpdteObj;
                    //Response.Redirect("SubscriberRegistrationPage.aspx");
                }
            }
            catch(ELibException)
            {
                Response.Write("<script>alert('Please enter valid details.')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Try again later.')</script>");
            }
        }
        static string type;         //Global Variable 


        /// <summary>
        /// Event that Fires on Button Edit Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["User_ID"] != null)
                {
                    User_details NewObj = new User_details();
                    NewObj.UserId = Session["User_ID"].ToString();
                    var editObj = new User_detailsBLL();
                    var DetailsObj = editObj.FindbyID(NewObj.UserId);
                    txtFirstName.Text = DetailsObj.FirstName;
                    txtLastName.Text = DetailsObj.LastName;
                    txtDateOfBirth.Text = DetailsObj.DateOfBirth.ToString("yyyy-MM-dd");
                    txtAddress.Text = DetailsObj.Address;
                    txtLandlineNumber.Text = DetailsObj.LandLineNumber;
                    txtMobileNumber.Text = DetailsObj.MobileNumber;
                    var a = DetailsObj.AreaOfInterest;
                    chkAreaOfInterestList.DataBind();
                    //var b=chkAreaOfInterestList.Items;
                    if (a.Contains("Engineering"))
                    {
                        chkAreaOfInterestList.Items[0].Selected = true;
                    }
                    if (a.Contains("Medical"))
                    {

                        chkAreaOfInterestList.Items[1].Selected = true;
                    }
                    if (a.Contains("Law"))
                    {
                        chkAreaOfInterestList.Items[2].Selected = true;
                    }

                    if (DetailsObj.Gender == "M")
                        rdoGenderGroup.Items[0].Selected = true;
                    else
                        rdoGenderGroup.Items[1].Selected = true;

                    if (DetailsObj.UserType == "Subscriber")
                    {
                        rdoUserTypeGroup.Items[0].Selected = true;
                        type = "Subscriber";
                    }
                    else
                    {
                        rdoUserTypeGroup.Items[1].Selected = true;
                        type = "Non_Subscriber";
                    }
                }
                else
                    Response.Redirect("HomePage.aspx");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        
    }
    }
}