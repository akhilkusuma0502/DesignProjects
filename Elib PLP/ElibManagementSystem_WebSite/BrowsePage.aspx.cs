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
    /// <summary>
    /// Class for BrowsePage Which is Inheriting From Page Class
    /// </summary>
    public partial class BrowsePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event That Fires On List Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDisciplinesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var Id = Convert.ToInt32(gvDisciplinesList.SelectedDataKey.Value);      //Converts the Selected Value To Int and Store in Id
                var DocumentBLLObj = new Document_DetailsBLL();
                var DocumentListObj = DocumentBLLObj.BrowseDocuments(Id);
                if (DocumentListObj.Count == 0)                                             //Checks If Documenrt List with 0 records   
                    Response.Write("<script>alert('No Documents')</script>");
                else
                {
                    gvDocumentDetailsList.DataSource = DocumentListObj;
                    gvDocumentDetailsList.DataBind();
                }
            }
          
            catch (ELibException ex)                                                    //Custom Exception
            {
                Response.Write("<script>alert('"+ex.Message+")</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops!! Error ,Please Try Again')</script>");
            }
        }
    }
}