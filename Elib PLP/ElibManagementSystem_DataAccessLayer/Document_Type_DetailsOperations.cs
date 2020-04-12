using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_DataAccessLayer
{
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    public class Document_Type_DetailsOperations
    {
        public List<Document_Type_Details> GetDocumentTypeDetails()
        {
            List<Document_Type_Details> DocumentTypeDetailsListObj = null;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspSelectAllDocument_Type_Details", CommandType.StoredProcedure);

            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    DocumentTypeDetailsListObj = new List<Document_Type_Details>();
                    foreach (DataRow row in TableObj.Rows)
                    {
                  var DocumentTypeObj = new Document_Type_Details();
                        DocumentTypeObj.DocumentTypeId = (int)row[0];
                        DocumentTypeObj.DocumentTypeName = (string)row[1];

                        DocumentTypeDetailsListObj.Add(DocumentTypeObj);
                    }
                }
            }
            catch (DbException ex)
            {
                throw new ELibException("Error reading data", ex);
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }

            return DocumentTypeDetailsListObj;
        }
    
}
}
