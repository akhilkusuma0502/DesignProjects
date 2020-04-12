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
    /// Entity Class For DocumentDetailsPage Inheriting from Page Class
    /// </summary>
    public partial class DocumentDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event That Fires on Button DownLoad Button Click Based On User Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var DocumentId = Convert.ToInt32(Request.QueryString["DocumentId"]);
                var DocumentBLLObj = new Document_DetailsBLL();
                var DocumentObj = DocumentBLLObj.SearchByDocumentId(DocumentId).First();
                //subscriber--NonSubscriber--Administrator
                if (Session["User_ID"] != null)
                {
                    Session["DocumentObj"] = DocumentObj;
                    if (DocumentObj.DocumentTypeId.DocumentTypeId == 1)
                    {
                        Response.Redirect("~/DownloadPremium.aspx?DocumentId=" + DocumentId);

                    }
                    else
                    {
                        var name = DocumentObj.DocumentPath;
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + DocumentObj.DocumentName + ".pdf");
                        Response.TransmitFile(Server.MapPath("~/Documents/" + DocumentObj.DocumentName + ".pdf"));
                        Response.End();
                    }
                }
                //Guest-freebie Document
                else if (DocumentObj.DocumentTypeId.DocumentTypeId == 2)
                {
                    var name = DocumentObj.DocumentPath;
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + DocumentObj.DocumentName + ".pdf");
                    Response.TransmitFile(Server.MapPath("~/Documents/" + DocumentObj.DocumentName + ".pdf"));
                    Response.End();
                }
                //guest-Premium Document
                else
                {
                    Response.Write("<script>alert('Sorry!Please Login to Download Premium Documents')</script>");
                }
            }
            catch (ELibException)
            {
                Response.Write("<script>alert('Sorry!!!..Please try Again')</script>");
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Sorry!!!..Please try Again')</script>");
            }
        }
    }
}