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
    public class DisciplinesOperations
    {
        public List<Disciplines> GetDisciplines()
        {
            List<Disciplines> DisciplinesListObj = null;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspSelectAllDisciplines", CommandType.StoredProcedure);

            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    DisciplinesListObj = new List<Disciplines>();
                    foreach (DataRow row in TableObj.Rows)
                    {
                        var DisciplineObj = new Disciplines();
                        DisciplineObj.DisciplineId = (int)row[0];
                        DisciplineObj.DisciplineName = (string)row[1];

                        DisciplinesListObj.Add(DisciplineObj);
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

            return DisciplinesListObj;
        }


        public bool InsertDisciplines(string discipline)
        {
            var IsAdded = false;
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspInsertDisciplines", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_name", DbType.String);
            P1.Value = discipline;
            P1.Size = 20;
            CommandObj.Parameters.Add(P1);
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

        public Disciplines FindDisciplineById(int id)
        {
            Disciplines DisciplineObj = new Disciplines();
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspSelectDisciplineById", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_id", DbType.Int32);
            P1.Value = id;
            CommandObj.Parameters.Add(P1);
            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {

                    foreach (DataRow row in TableObj.Rows)
                    {


                        DisciplineObj.DisciplineId = (int)row[0];
                        DisciplineObj.DisciplineName = (string)row[1];


                    }
                }
            }
            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return DisciplineObj;
        }

        public bool DeleteDiscipline(int id)
        {
            var IsDeleted = false;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspDeleteDisciplines", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_id", DbType.Int32);
            P1.Value = id;
            CommandObj.Parameters.Add(P1);
            try
            {
                DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsDeleted = true;
            }
            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return IsDeleted;
        }

        public bool UpdateDiscipline(int id, string disciplinename)
        {
            var IsUpdate = false;

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspUpdateDisciplines", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_id", DbType.Int32);
            P1.Value = id;
            CommandObj.Parameters.Add(P1);

            var P2 = DatabaseConnection.CreateParameter(CommandObj, "@discipline_name", DbType.String);
            P2.Value = disciplinename;
            P2.Size = 20;
            CommandObj.Parameters.Add(P2);
            try
            {
                DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsUpdate = true;
            }
            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return IsUpdate;
        }

    }
}
