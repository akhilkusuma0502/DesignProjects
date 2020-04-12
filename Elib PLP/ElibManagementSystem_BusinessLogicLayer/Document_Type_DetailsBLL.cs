using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_BusinessLogicLayer
{
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    using ElibManagementSystem_DataAccessLayer;
    public  class Document_Type_DetailsBLL
    {
        Document_Type_DetailsOperations DocumentTypeDetailsDALObj;
        public Document_Type_DetailsBLL()
        {
            DocumentTypeDetailsDALObj = new Document_Type_DetailsOperations();
        }
        public List<Document_Type_Details> GetAll()
        {
            var DocumentTypeDetailsList = new List<Document_Type_Details>();
            try
            {
                var ObjDAL = new Document_Type_DetailsOperations();
                DocumentTypeDetailsList = ObjDAL.GetDocumentTypeDetails();
                if (DocumentTypeDetailsList == null || DocumentTypeDetailsList.Count == 0)
                    throw new ELibException("Document Type Details not found");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return DocumentTypeDetailsList;
        }
    }
}
