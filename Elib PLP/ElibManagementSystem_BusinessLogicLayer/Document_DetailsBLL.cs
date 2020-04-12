using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_BusinessLogicLayer
{ 
    using System.Text.RegularExpressions;
    using System.Collections;
    using ElibManagementSystem_DataAccessLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    public  class Document_DetailsBLL
    {
        private bool ValidateDocuments(Document_Details obj)
        {
            var IsValid = true;
            var ErrorMessage = new StringBuilder();
            if(string.IsNullOrEmpty(obj.DocumentName))
            {
                IsValid = false;
                ErrorMessage.AppendLine("Document Name Should Not be Epmty!");
            }
            if (string.IsNullOrEmpty(obj.DocumentDescription))
            {
                IsValid = false;
                ErrorMessage.AppendLine("Document Description Should Not be Epmty!");
            }
            if (obj.DocumentTypeId.DocumentTypeId!=1&&obj.DocumentTypeId.DocumentTypeId!=2)
            {
                IsValid = false;
                ErrorMessage.AppendLine("Document Type Name Should be Selected From DropDown List!");
            }
            if (obj.DisciplineId.DisciplineId<=0)
            {
                IsValid = false;
                ErrorMessage.AppendLine("Discipline Name Should be Selected From DropDown List!");
            }
            if (string.IsNullOrEmpty(obj.Title))
            {
                IsValid = false;
                ErrorMessage.AppendLine("Document Description Should Not be Epmty!");
            }
            if (string.IsNullOrEmpty(obj.Author))
            {
                IsValid = false;
                ErrorMessage.AppendLine("Author Should Not be Epmty!");
            }
            if (obj.Price<0)
            {
                IsValid = false;
                ErrorMessage.AppendLine("Price Should Not be Less Than 0 for Premium Documents!");
            }
            if (string.IsNullOrEmpty(obj.DocumentPath))
            {
                IsValid = false;
                ErrorMessage.AppendLine("Document Path Should Not be Epmty!");
            }
            if(!IsValid)
            {
                throw new ELibException(ErrorMessage.ToString());
            }
            return IsValid;
        }
        public bool UploadDocument(Document_Details documentObj)
        {
            var IsAdded = false;
            try
            {
                if (ValidateDocuments(documentObj))
                {
                    var DALObj = new Document_DetailsOperations();
                    IsAdded = DALObj.UploadDocument(documentObj);
                }

            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return IsAdded;
        }


        public List<Document_Details> SearchByDocumentName(string name)
        {
            var DocumentsList = new List<Document_Details>();
           
            try
            {
                if (name==null)
                    throw new ELibException("Name should not be null");

                var DocumentDetailsDALObj = new Document_DetailsOperations();
                DocumentsList = DocumentDetailsDALObj.SearchDocumentByName(name);

                if (DocumentsList.Count == 0)
                    throw new ELibException("No such Document exists");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Error searching Document", ex);
            }
            return DocumentsList;
        }

        public List<Document_Details> BrowseDocuments(int disciplineIdSelected, int pageNo)
        {
            var DocumentDetailsList = new List<Document_Details>();
            try
            {
                var ObjDAL = new Document_DetailsOperations();
                DocumentDetailsList = ObjDAL.BrowseDocuments(disciplineIdSelected, (pageNo - 1) * 10);
                if (DocumentDetailsList == null || DocumentDetailsList.Count == 0)
                    throw new ELibException("Document are not present");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return DocumentDetailsList;
        }
        public List<Document_Details> BrowseDocuments(int disciplineIdSelected)
        {
            var DocumentDetailsList = new List<Document_Details>();
            try
            {
                var ObjDAL = new Document_DetailsOperations();
                DocumentDetailsList = ObjDAL.BrowseDocuments(disciplineIdSelected);
                if (DocumentDetailsList == null || DocumentDetailsList.Count == 0)
                    throw new ELibException("Document are not present");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return DocumentDetailsList;
        }

        public List<Document_Details> SearchByDocumentId(int id)
        {
            var DocumentsList = new List<Document_Details>();
            try
            {
                if (id<= 0)
                    throw new ELibException("Id should be greater than 0");

                var DocumentDetailsDALObj = new Document_DetailsOperations();
               DocumentsList =DocumentDetailsDALObj.SearchDocumentById(id);

                if (DocumentsList == null)
                    throw new ELibException("No such Document exists");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Error searching Document", ex);
            }
            return DocumentsList;
        }

        public bool UpdateDocument(Document_Details DocumentObj)
        {
            var IsUpdated = false;
            try
            {
                if(ValidateDocuments(DocumentObj))
                { 
                var ObjDAL = new Document_DetailsOperations();

                IsUpdated = ObjDAL.UpdateDocument(DocumentObj);
            }
                }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Error editing Document details",ex);
            }
            return IsUpdated;
        }
        public bool Delete(int id)
        {
            var IsDeleted = false;
            try
            {
                if (id <= 0)
                    throw new ELibException("Id should be greater than 0");

                var ObjDAL = new Document_DetailsOperations();
                IsDeleted = ObjDAL.Delete(id);
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Failed to remove document", ex);
            }
            return IsDeleted;
        }

    }
}
