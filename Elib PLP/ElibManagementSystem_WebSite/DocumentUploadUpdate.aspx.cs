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
    /// Entity CLass Called DocumentUploadUpdate inheriting from Page
    /// </summary>
    public partial class DocumentUploadUpdate : System.Web.UI.Page
    {
        string pathToCheckUpload, pathToCheck;
        HttpPostedFile fileUpload, fileUpdate;
        string extUpload, extUpdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Event That Fires on Upload Buttons Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumentNameUpload.Text != null && txtDocumentDescriptionUpload.Text != null && cmbDocumentTypeUpload.Text != null &&
                   cmbDisciplineNameUpload.Text != null && txtTitleUpload != null && txtAuthorUpload != null && txtPriceUpload != null
                   && lblPathUpload.Text != null)
                {

                    Document_Details DocumentObj = new Document_Details();
                    DocumentObj.DocumentName = txtDocumentNameUpload.Text;
                    DocumentObj.DocumentDescription = txtDocumentDescriptionUpload.Text;
                    DocumentObj.DocumentTypeId.DocumentTypeId = Convert.ToInt32(cmbDocumentTypeUpload.SelectedItem.Value);
                    DocumentObj.DisciplineId.DisciplineId = Convert.ToInt32(cmbDisciplineNameUpload.SelectedItem.Value);
                    DocumentObj.Title = txtTitleUpload.Text;
                    DocumentObj.Author = txtAuthorUpload.Text;
                    DocumentObj.Price = Convert.ToDecimal(txtPriceUpload.Text);
                    SaveFileUpload(fileUpload);
                    DocumentObj.DocumentPath = pathToCheckUpload;


                    var DocumentBLLObj = new Document_DetailsBLL();
                    var IsAdded = DocumentBLLObj.UploadDocument(DocumentObj);
                    if (IsAdded)
                    {
                        Response.Write("<script>alert('Document Details added')</script>");
                    }
                    else
                        Response.Write("<script>alert('Unable to upload document')</script>");
                }
            }
            catch (FormatException ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>"); Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please try again')</script>");
            }
        }

       
        /// <summary>
        /// Event That Fires on Find Button Click For Deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFindDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var DocumentBLLObj = new Document_DetailsBLL();
                var Id = Convert.ToInt32(txtDocumentIdDelete.Text);
                var DocumentObj = DocumentBLLObj.SearchByDocumentId(Id).First();

                txtDocumentNameDelete.Text = DocumentObj.DocumentName;
                txtDocumentDescriptionDelete.Text = DocumentObj.DocumentDescription;
                txtDocumentTypeDelete.Text = DocumentObj.DocumentTypeName;
                txtDisciplineNameDelete.Text = DocumentObj.DisciplineName;
                txtTitleDelete.Text = DocumentObj.Title;
                txtAuthorDelete.Text = DocumentObj.Author;
                txtPriceDelete.Text = Convert.ToString(DocumentObj.Price);
                lblPathDelete.Text = DocumentObj.DocumentPath;

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

        /// <summary>
        /// Event That Fires on Find Click For Updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFindUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var DocumentBLLObj = new Document_DetailsBLL();
                var Id = Convert.ToInt32(txtDocumentIdUpdate.Text);
                var DocumentObj = DocumentBLLObj.SearchByDocumentId(Id).First();

                txtDocumentNameUpdate.Text = DocumentObj.DocumentName;
                txtDocumentDescriptionUpdate.Text = DocumentObj.DocumentDescription;
                cmbDocumentTypeUpdate.Text = DocumentObj.DocumentTypeId.DocumentTypeName;
                cmbDisciplineNameUpdate.Text = DocumentObj.DisciplineId.DisciplineName;
                txtTitleUpdate.Text = DocumentObj.Title;
                txtAuthorUpdate.Text = DocumentObj.Author;
                txtPriceUpdate.Text = Convert.ToString(DocumentObj.Price);
                lblPathUpdate.Text = DocumentObj.DocumentPath;
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

        /// <summary>
        /// Event that Fores on Delete Click wich Deletes the Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteDocument_Click1(object sender, EventArgs e)
        {
            try
            {
                var Id = Convert.ToInt32(txtDocumentIdDelete.Text);
                var DocumentDetailsBLLObj = new Document_DetailsBLL();
                var IsDeleted = DocumentDetailsBLLObj.Delete(Id);
                if (IsDeleted)
                {
                    lblMessageDelete.Text = "Document deleted";
                    txtDocumentIdDelete.Text = string.Empty;
                    txtDocumentNameDelete.Text = string.Empty;
                    txtDocumentDescriptionDelete.Text = string.Empty;
                    txtDocumentTypeDelete.Text = string.Empty;
                    txtDisciplineNameDelete.Text = string.Empty;
                    txtTitleDelete.Text = string.Empty;
                    txtAuthorDelete.Text = string.Empty;
                    txtPriceDelete.Text = string.Empty;
                    lblPathDelete.Text = string.Empty;
                }
                else
                    Response.Write("<script>alert('Unable to delete document')</script>");
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

        /// <summary>
        /// Method Called SaveFileUpload for SaveFile
        /// </summary>
        /// <param name="file"></param>
        void SaveFileUpload(HttpPostedFile file)
        {
           
            try
            {
                // Specify the path to save the uploaded file to.
                string savePath = Server.MapPath(@"~\Documents\");

                // Get the name of the file to upload.
                string fileName = FileUpload1.FileName;
                //filePath = savePath + fileName;

                // Create the path and file name to check for duplicates.
                //pathToCheckUpload = savePath + fileName;
                extUpload = System.IO.Path.GetExtension(savePath + fileName);

                pathToCheckUpload = savePath + txtDocumentNameUpload.Text + extUpload;

                // Create a temporary file name to use for checking duplicates.
                string tempfileName = "";

                // Check to see if a file already exists with the
                // same name as the file to upload.        
                if (System.IO.File.Exists(pathToCheckUpload))
                {
                    int counter = 2;
                    while (System.IO.File.Exists(pathToCheckUpload))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = fileName + "(copy" + counter.ToString() + ")";
                        pathToCheckUpload = savePath + tempfileName;
                        pathToCheckUpload = savePath + txtDocumentNameUpload.Text;
                        counter++;

                    }
                    //pathToCheckUpload = savePath + txtDocumentNameUpload.Text;
                    fileName = tempfileName;

                    // Notify the user that the file name was changed.
                    lblPathUpload.Text = "A file with the same name already exists." +
                        "<br />Your file was saved as " + fileName;
                }
                else
                {
                    // Notify the user that the file was saved successfully.
                    lblPathUpload.Text = "Your file was uploaded successfully.";
                }

                // Append the name of the file to upload to the path.
                savePath += fileName;

                // Call the SaveAs method to save the uploaded
                // file to the specified directory.
                FileUpload1.SaveAs(pathToCheckUpload);
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
        /// <summary>
        /// Method Called SaveFileUpdate for SaveFile
        /// </summary>
        /// <param name="file"></param>
        void SaveFileUpdate(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePathUpdate = Server.MapPath(@"~\Documents\");

            // Get the name of the file to upload.
            string fileNameUpdate = FileUpload2.FileName;
            //  filePath = savePath + fileName;

            // Create the path and file name to check for duplicates.
            extUpdate = System.IO.Path.GetExtension(savePathUpdate + fileNameUpdate);
            pathToCheck = savePathUpdate + txtDocumentNameUpdate.Text + extUpdate;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = fileNameUpdate + "(copy" + counter.ToString() + ")";
                    pathToCheck = savePathUpdate + tempfileName;
                    counter++;
                }

                fileNameUpdate = tempfileName;

                // Notify the user that the file name was changed.
                lblPathUpload.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileNameUpdate;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                lblPathUpload.Text = "Your file was uploaded successfully.";
            }

            // Append the name of the file to upload to the path.
            savePathUpdate += fileNameUpdate;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload2.SaveAs(savePathUpdate);

        }

        /// <summary>
        /// Event That Fires on Update Buttons Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumentNameUpdate.Text != null && txtDocumentDescriptionUpdate.Text != null && cmbDocumentTypeUpdate.Text != null &&
                    cmbDisciplineNameUpdate.Text != null && txtTitleUpdate != null && txtAuthorUpdate != null && txtPriceUpdate != null
                    && lblPathUpdate.Text != null)
                {
                    Document_Details DocumentObj = new Document_Details();
                    DocumentObj.DocumentId = Convert.ToInt32(txtDocumentIdUpdate.Text);
                    DocumentObj.DocumentName = txtDocumentNameUpdate.Text;
                    DocumentObj.DocumentDescription = txtDocumentDescriptionUpdate.Text;
                    DocumentObj.DocumentTypeId.DocumentTypeId = Convert.ToInt32(cmbDocumentTypeUpdate.SelectedItem.Value);
                    DocumentObj.DisciplineId.DisciplineId = Convert.ToInt32(cmbDisciplineNameUpdate.SelectedItem.Value);
                    DocumentObj.Title = txtTitleUpdate.Text;
                    DocumentObj.Author = txtAuthorUpdate.Text;
                    DocumentObj.Price = Convert.ToDecimal(txtPriceUpdate.Text);
                    SaveFileUpdate(fileUpdate);
                    DocumentObj.DocumentPath = pathToCheck;

                    var DocumentBLLObj = new Document_DetailsBLL();
                    var IsAdded = DocumentBLLObj.UpdateDocument(DocumentObj);
                    if (IsAdded)
                    {
                        Response.Write("<script>alert('Document Details Updated!')</script>");

                    }
                    else
                        Response.Write("<script>alert('Unable to update document')</script>");
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