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
    public  class Document_DetailsOperations
    {



        public bool UploadDocument(Document_Details documentObj)
        {
            var IsAdded = false;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspInsertDocument_Details", CommandType.StoredProcedure);

            var Param1 = DatabaseConnection.CreateParameter(CommandObj, "@document_name", DbType.String);
            Param1.Value = documentObj.DocumentName;
            Param1.Size = 20;
            CommandObj.Parameters.Add(Param1);

            var Param2 = DatabaseConnection.CreateParameter(CommandObj, "@document_description", DbType.String);
            Param2.Value = documentObj.DocumentDescription;
            Param2.Size = 200;
            CommandObj.Parameters.Add(Param2);

            var Param3 = DatabaseConnection.CreateParameter(CommandObj, "@document_path", DbType.String);
            Param3.Value = documentObj.DocumentPath;
            Param3.Size = 50;
            CommandObj.Parameters.Add(Param3);

            var Param4 = DatabaseConnection.CreateParameter(CommandObj, "@document_type_id", DbType.String);
            Param4.Value = documentObj.DocumentTypeId.DocumentTypeId;
            //Param4.Size = 200;
            CommandObj.Parameters.Add(Param4);

            var Param5 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_id", DbType.String);
            Param5.Value = documentObj.DisciplineId.DisciplineId;
            //Param5.Size = 200;
            CommandObj.Parameters.Add(Param5);

            var Param6 = DatabaseConnection.CreateParameter(CommandObj, "@title", DbType.String);
            Param6.Value = documentObj.Title;
            Param6.Size = 30;
            CommandObj.Parameters.Add(Param6);

            var Param7 = DatabaseConnection.CreateParameter(CommandObj, "@author", DbType.String);
            Param7.Value = documentObj.Author;
            Param7.Size = 50;
            CommandObj.Parameters.Add(Param7);

            var Param8 = DatabaseConnection.CreateParameter(CommandObj, "@price", DbType.String);
            Param8.Value = documentObj.Price;
            CommandObj.Parameters.Add(Param8);
            try
            {
                DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsAdded = true;
            }

            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return IsAdded;
        }

        public bool Delete(int id)
        {
            var IsDeleted = false;
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspDeleteDocument_Details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@document_id", DbType.Int32);
            P1.Value = id;
            CommandObj.Parameters.Add(P1);

            try
            {
                var NoOfRowsAffected = DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsDeleted = NoOfRowsAffected == 1;
            }
            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return IsDeleted;

        }
        public List<Document_Details> BrowseDocuments(int disciplineIdSelected, int offsetPageNumber)
        {
            List<Document_Details> DisciplineDetailsListObj = null;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspBrowse_Document_Details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@Discipline_Id", DbType.Int32);
            P1.Value = disciplineIdSelected;
            CommandObj.Parameters.Add(P1);

            var P2 = DatabaseConnection.CreateParameter(CommandObj, "@OffsetPageNumber", DbType.Int32);
            P2.Value = offsetPageNumber;
            CommandObj.Parameters.Add(P2);
            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    DisciplineDetailsListObj = new List<Document_Details>();
                    foreach (DataRow row in TableObj.Rows)
                    {
                        var DocumentDetailsObj = new Document_Details();

                        DocumentDetailsObj.DocumentId = (int)row[0];
                        DocumentDetailsObj.DocumentName = (string)row[1];
                        DocumentDetailsObj.DocumentDescription = (string)row[2];
                        DocumentDetailsObj.DocumentPath = (string)row[3];
                        DocumentDetailsObj.DocumentTypeId.DocumentTypeId = (int)row[4];
                        DocumentDetailsObj.DisciplineId.DisciplineId = (int)row[5];
                        DocumentDetailsObj.Title = (string)row[6];
                        DocumentDetailsObj.Author = (string)row[7];
                        DocumentDetailsObj.UploadDate = (DateTime)row[8];
                        DocumentDetailsObj.Price = (decimal)row[9];

                        DisciplineDetailsListObj.Add(DocumentDetailsObj);
                    }
                }
            }
            catch (DbException ex)
            {
                throw new ELibException("There is an Error while fetching the document details from the database. Try again after some time", ex);
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }

            return DisciplineDetailsListObj;
        }


        public List<Document_Details> BrowseDocuments(int disciplineIdSelected)
        {
            List<Document_Details> DisciplineDetailsListObj = null;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspBrowse_Document_Details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@Discipline_Id", DbType.Int32);
            P1.Value = disciplineIdSelected;
            CommandObj.Parameters.Add(P1);


            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    DisciplineDetailsListObj = new List<Document_Details>();
                    foreach (DataRow row in TableObj.Rows)
                    {
                        var DocumentDetailsObj = new Document_Details();

                        DocumentDetailsObj.DocumentId = (int)row[0];
                        DocumentDetailsObj.DocumentName = (string)row[1];
                        DocumentDetailsObj.DocumentDescription = (string)row[2];
                        DocumentDetailsObj.DocumentPath = (string)row[3];
                        DocumentDetailsObj.DocumentTypeId.DocumentTypeId = (int)row[4];
                        DocumentDetailsObj.DisciplineId.DisciplineId = (int)row[5];
                        DocumentDetailsObj.Title = (string)row[6];
                        DocumentDetailsObj.Author = (string)row[7];
                        DocumentDetailsObj.UploadDate = (DateTime)row[8];
                        DocumentDetailsObj.Price = (decimal)row[9];

                        DisciplineDetailsListObj.Add(DocumentDetailsObj);
                    }
                }
            }
            catch (DbException ex)
            {
                throw new ELibException("There is an Error while fetching the document details from the database. Try again after some time", ex);
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }

            return DisciplineDetailsListObj;
        }

        public List<Document_Details> SearchDocumentByName(string documentname)
        {
            var DocumentsList = new List<Document_Details>();
            Document_Details DocumentDetailsObj = null;
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspSelectDocument_DetailsByName", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@document_name", DbType.String);
            P1.Size = 20;
            P1.Value = documentname;
            CommandObj.Parameters.Add(P1);

            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    foreach (DataRow row in TableObj.Rows)
                    {
                        DocumentDetailsObj = new Document_Details();
                        DocumentDetailsObj.DocumentId = (int)row[0];
                        DocumentDetailsObj.DocumentName = (string)row[1];
                        DocumentDetailsObj.DocumentDescription = (string)row[2];
                        DocumentDetailsObj.DocumentPath = (string)row[3];
                        DocumentDetailsObj.DocumentTypeId.DocumentTypeId = (int)row[4];
                        DocumentDetailsObj.DisciplineId.DisciplineId = (int)row[5];
                        DocumentDetailsObj.Title = (string)row[6];
                        DocumentDetailsObj.Author = (string)row[7];
                        DocumentDetailsObj.UploadDate = ((DateTime)row[8]).Date;
                        DocumentDetailsObj.Price = (decimal)row[9];
                        DocumentsList.Add(DocumentDetailsObj);
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

            return DocumentsList;
        }


        public List<Document_Details> SearchDocumentById(int id)
        {
            
            Document_Details DocumentDetailsObj = null;
            var DocumentsList = new List<Document_Details>();
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspSelectDocument_DetailsById", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@document_id", DbType.Int32);
          
            P1.Value = id;
            CommandObj.Parameters.Add(P1);

            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    foreach (DataRow row in TableObj.Rows)
                    {
                        DocumentDetailsObj = new Document_Details();
                        DocumentDetailsObj.DocumentId = (int)row[0];
                        DocumentDetailsObj.DocumentName = (string)row[1];
                        DocumentDetailsObj.DocumentDescription = (string)row[2];
                        DocumentDetailsObj.DocumentPath = (string)row[3];
                        DocumentDetailsObj.DocumentTypeId.DocumentTypeId = (int)row[4];
                        DocumentDetailsObj.DisciplineId.DisciplineId = (int)row[5];
                        DocumentDetailsObj.Title = (string)row[6];
                        DocumentDetailsObj.Author = (string)row[7];
                        DocumentDetailsObj.UploadDate = ((DateTime)row[8]).Date;
                        DocumentDetailsObj.Price = (decimal)row[9];
                        DocumentDetailsObj.DocumentTypeName = (string)row[10];
                        DocumentDetailsObj.DisciplineName = (string)row[11];
                        DocumentsList.Add(DocumentDetailsObj);
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

            return DocumentsList;
        }

        public bool UpdateDocument(Document_Details documentObj)
        {
            var IsUpdated = false;
            Document_Details newObj = new Document_Details();

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspUpdateDocument_Details", CommandType.StoredProcedure);

            var Param0 = DatabaseConnection.CreateParameter(CommandObj, "@document_id", DbType.String);
            Param0.Value = documentObj.DocumentId;
            //Param0.Size = 20;
            CommandObj.Parameters.Add(Param0);

            var Param1 = DatabaseConnection.CreateParameter(CommandObj, "@document_name", DbType.String);
            Param1.Value = documentObj.DocumentName;
            Param1.Size = 20;
            CommandObj.Parameters.Add(Param1);

            var Param2 = DatabaseConnection.CreateParameter(CommandObj, "@document_description", DbType.String);
            Param2.Value = documentObj.DocumentDescription;
            Param2.Size = 200;
            CommandObj.Parameters.Add(Param2);

            var Param3 = DatabaseConnection.CreateParameter(CommandObj, "@document_path", DbType.String);
            Param3.Value = documentObj.DocumentPath;
            Param3.Size = 50;
            CommandObj.Parameters.Add(Param3);

            var Param4 = DatabaseConnection.CreateParameter(CommandObj, "@document_type_id", DbType.String);
            Param4.Value = documentObj.DocumentTypeId.DocumentTypeId;
            //Param4.Size = 200;
            CommandObj.Parameters.Add(Param4);

            var Param5 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_id", DbType.String);
            Param5.Value = documentObj.DisciplineId.DisciplineId;
            //Param5.Size = 200;
            CommandObj.Parameters.Add(Param5);

            var Param6 = DatabaseConnection.CreateParameter(CommandObj, "@title", DbType.String);
            Param6.Value = documentObj.Title;
            Param6.Size = 30;
            CommandObj.Parameters.Add(Param6);

            var Param7 = DatabaseConnection.CreateParameter(CommandObj, "@author", DbType.String);
            Param7.Value = documentObj.Author;
            Param7.Size = 50;
            CommandObj.Parameters.Add(Param7);

            var Param8 = DatabaseConnection.CreateParameter(CommandObj, "@price", DbType.String);
            Param8.Value = documentObj.Price;
            CommandObj.Parameters.Add(Param8);
            try
            {
                DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsUpdated = true;
            }

            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return IsUpdated;
        }




        //public List<Document_Details> Browse(String Discipline)
        //{
        //    List<Document_Details> DisciplineDetailsListObj = null;

        //    var ConnectionObj = DatabaseConnection.CreateConnection();
        //    var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspBrowse_Document_Details", CommandType.StoredProcedure);

        //    var P1 = DatabaseConnection.CreateParameter(CommandObj, "@Id", DbType.String);
        //    P1.Value = Discipline;
        //    CommandObj.Parameters.Add(P1);
        //    try
        //    {
        //        DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
        //        if (TableObj != null && TableObj.Rows.Count > 0)
        //        {
        //            DisciplineDetailsListObj = new List<Document_Details>();
        //            foreach (DataRow row in TableObj.Rows)
        //            {
        //                var DocumentDetailsObj = new Document_Details();

        //                DocumentDetailsObj.DocumentId = (int)row[0];
        //                DocumentDetailsObj.DocumentName = (string)row[1];
        //                DocumentDetailsObj.DocumentDescription = (string)row[2];
        //                DocumentDetailsObj.DocumentPath = (string)row[3];
        //                DocumentDetailsObj.DocumentTypeId.DocumentTypeId = (int)row[4];
        //                DocumentDetailsObj.DisciplineId.DisciplineId = (int)row[5];
        //                DocumentDetailsObj.Title = (string)row[6];
        //                DocumentDetailsObj.Author = (string)row[7];
        //                DocumentDetailsObj.UploadDate = (DateTime)row[8];
        //                DocumentDetailsObj.Price = (decimal)row[9];

        //                DisciplineDetailsListObj.Add(DocumentDetailsObj);
        //            }
        //        }
        //    }
        //    catch (DbException ex)
        //    {
        //        throw new ELibException("There is an Error while fetching the document details from the database. Try again after some time", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ELibException("Unknown error", ex);
        //    }

        //    return DisciplineDetailsListObj;
        //}

    }
}

