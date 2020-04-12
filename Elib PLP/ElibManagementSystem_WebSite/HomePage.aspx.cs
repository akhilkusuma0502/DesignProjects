using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibManagementSystem_WebSite
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Exceptions;
    public partial class HomePage : System.Web.UI.Page
    {
        /// <summary>
        /// Checks for Sessions and Based On That Visibilities are Triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User_ID"]!=null)
            if(Session["User_Type"].ToString()=="Administrator")
            {
                lblGuestUser.Visible = false;
                lnkRegisterHere.Visible = false;

            }
            else
                {
                    lblGuestUser.Visible = false;
                    lnkRegisterHere.Visible = false;

                }
        }

        /// <summary>
        /// Event that Fires on Button Search Click Which Searches the List Of Documents Based On Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
            if (txtSearch.Text != "")
            {
                var SearchName = (txtSearch.Text);
                var DocumentDetailsBLLObj = new Document_DetailsBLL();
                var DocumentDetailsList = DocumentDetailsBLLObj.SearchByDocumentName(SearchName);
                    if (DocumentDetailsList != null)
                    {
                        Response.Redirect("~/SearchResultsPage.aspx?Search=" + txtSearch.Text);
                    }
                    else
                        Response.Write("<script>alert('No such Document exists.')</script>");
                }
         
            else
                    Response.Write("<script>alert('Enter Some Text')</script>");
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