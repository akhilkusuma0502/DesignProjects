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
    /// <summary>
    /// Entity Class Download premium inheriting from page Class
    /// </summary>
    public partial class DownloadPremium : System.Web.UI.Page
    {
        /// <summary>
        /// Stores Sessions on Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var UserType = Session["User_Type"].ToString();
                var obj = (Document_Details)Session["DocumentObj"];
                if (UserType == "Subscriber")
                {
                    lblPrice.Text = Convert.ToString(obj.Price - (0.20m * obj.Price));
                }
                else
                {
                    lblPrice.Text = Convert.ToString(obj.Price);
                }
            }
            catch (ELibException)
            {
                Response.Write("<script>alert('Sorry! Try Reloading Page')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please try Again')</script>");
            }
            
            
            
        }
        /// <summary>
        /// Method ValidateCard Validates the Credit Card Details
        /// </summary>
        /// <returns></returns>
        private bool ValidateCard()
        {
            var IsValid = true;
            try
            {

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
            }
            catch (ELibException)
            {
                Response.Write("<script>alert('Sorry! Enter Valid Credit Card details.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            return IsValid;
        }

        /// <summary>
        /// Event That Fires on Submit Click Which Downloads The File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCard())
                {
                    Document_Details DocumentObj = (Document_Details)Session["DocumentObj"];
                    // var name = DocumentObj.DocumentPath;
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + DocumentObj.DocumentName + ".pdf");
                    Response.TransmitFile(Server.MapPath("~/Documents/" + DocumentObj.DocumentName + ".pdf"));
                    //  Response.TransmitFile(Server.MapPath("~/Documents/" + DocumentObj.DocumentPath + ".pdf"));
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('Sorry! InValid Credit Card details.')</script>");
                }
            }
            catch(ELibException ex)
            {
                Response.Write("<script>alert("+ex.Message+")</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
    }
}