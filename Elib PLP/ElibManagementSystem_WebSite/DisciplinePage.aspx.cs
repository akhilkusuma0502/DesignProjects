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
    /// Entity Class for DisciplinePage Inheriting from Page Class
    /// </summary>
    public partial class DisciplinePage : System.Web.UI.Page
    {
        //Declare An Global Object Of Type DisciplinesBLL
        DisciplinesBLL DisciplineBLLObj = new DisciplinesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event That Fires When The Button Upload is Clicked to Add Discipline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUploadDiscipline_Click(object sender, EventArgs e)
        {
            try
            {
                var DisciplineName = txtDisciplineNameUpload.Text;

                var IsAdded = DisciplineBLLObj.InsertDisciplines(DisciplineName);
                if (IsAdded)
                    Response.Write("<script>alert('Discipline Added Successfully')</script>");
                else
                    Response.Write("<script>alert('Sorry! Unable to add Discipline')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please Try Again')</script>");
            }
        }

        /// <summary>
        /// Event That Fires When Button Find is Clicked to Find Discipline 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                var DisciplineId = Convert.ToInt32(txtDisciplineId.Text);

                var DiscipineObj = DisciplineBLLObj.FindDisciplineById(DisciplineId);
                if (DiscipineObj.DisciplineName != null)
                    txtDisciplineNameUpdate.Text = DiscipineObj.DisciplineName;
                else
                    Response.Write("<script>alert('Sorry! Unable to find Discipline')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please Try Again')</script>");
            }
        }

        /// <summary>
        /// Event that fires when Button Update is Clicked to Update Disciplines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateDiscipline_Click(object sender, EventArgs e)
        {
            try
            {
                var DisciplineId = Convert.ToInt32(txtDisciplineId.Text);
                var DisciplineName = (txtDisciplineNameUpdate.Text);
                var IsUpdated = DisciplineBLLObj.UpdateDiscipline(DisciplineId, DisciplineName);
                if (IsUpdated)
                    Response.Write("<script>alert('Discipline Updated Successfully')</script>");
                else
                    Response.Write("<script>alert('Sorry! Unable to Update Discipline')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please Try Again')</script>");
            }
        }

        /// <summary>
        /// Event That Fires When FindDelete Button is Clicked Which Finds the Disciplines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFindDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var DisciplineId = Convert.ToInt32(txtDisciplineIdDelete.Text);

                var DiscipineObj = DisciplineBLLObj.FindDisciplineById(DisciplineId);
                if (DiscipineObj.DisciplineName != null)
                    txtDisciplineNameDelete.Text = DiscipineObj.DisciplineName;
                else
                    Response.Write("<script>alert('Sorry! Unable to find Discipline')</script>");
            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please Try Again')</script>");
            }
        }

        /// <summary>
        /// Event That Fires When Delete Button is Clicked Which Deletes the Discipline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var DisciplineId = Convert.ToInt32(txtDisciplineIdDelete.Text);
                var IsDeleted = DisciplineBLLObj.DeleteDiscipline(DisciplineId);
                if (IsDeleted)
                    Response.Write("<script>alert('Discipline Deleted Successfully')</script>");
                else
                    Response.Write("<script>alert('Sorry! Unable to find Discipline')</script>");

            }
            catch (ELibException ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Sorry! Please Try Again')</script>");
            }
        }
    }
}