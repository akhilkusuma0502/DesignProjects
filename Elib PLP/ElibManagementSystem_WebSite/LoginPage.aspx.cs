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
    using System.Web.UI;
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Event that Fires on Button Login Click and Directs to HomePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User_details userObj = new User_details();
                userObj.UserId = txtUserID.Text;
                userObj.Password = txtPassword.Text;
                var userBLL = new User_detailsBLL();
                var Obj = userBLL.LogIn(userObj);
                if (Obj.UserType == "Administrator")
                {
                    Session["User_Type"] = Obj.UserType;
                    Session["User_ID"] = userObj.UserId;
                    Session["User_Name"] = Obj.FirstName + " " + Obj.LastName;
                    Response.Redirect("DocumentUploadUpdate.aspx");
                    lblLoginMessage.Text = Obj.FirstName + " " + Obj.LastName + " is " + Obj.UserType;
                }
                else if (Obj.UserType == "Subscriber" || Obj.UserType == "Non_Subscriber")
                {
                    Session["User_Type"] = Obj.UserType;
                    Session["User_ID"] = userObj.UserId;
                    Session["User_Name"] = Obj.FirstName + " " + Obj.LastName;
                    Response.Redirect("HomePage.aspx");
                    lblLoginMessage.Text = Obj.FirstName + " " + Obj.LastName + " is " + Obj.UserType;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Proper Credentials')</script>");
                }
            }
            catch (FormatException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

    }
  }