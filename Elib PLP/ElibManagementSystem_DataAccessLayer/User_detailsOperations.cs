using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_DataAccessLayer
{
    using ElibManagementSystem_Exceptions;
    using ElibManagementSystem_Entities;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    public  class User_detailsOperations
    {
        public User_details LogIn(User_details DetailsObj)
        {
            User_details newObj = new User_details();

            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspLogInELIB",CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@User_Id", DbType.String);
            P1.Value = DetailsObj.UserId;
            P1.Size = 30;
            CommandObj.Parameters.Add(P1);

            var P2 = DatabaseConnection.CreateParameter(CommandObj, "@Password", DbType.String);
            P2.Value = DetailsObj.Password;
            P1.Size = 30;
            CommandObj.Parameters.Add(P2);

            
            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);

                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    foreach (DataRow row in TableObj.Rows)
                    {
                        newObj.UserId = (string)row[0];
                        newObj.FirstName = (string)row[1];
                        newObj.LastName = (string)row[2];
                        newObj.DateOfBirth = (DateTime)row[3];
                        newObj.Address = (string)row[4];
                        newObj.LandLineNumber = (string)row[5];
                        newObj.MobileNumber = (string)row[6];
                        newObj.AreaOfInterest = (string)row[7];
                        newObj.Gender = (string)row[8];
                        newObj.UserType = (string)row[9];
                        newObj.DateOfRegistration = (DateTime)row[10];
                        newObj.Password = (string)row[11];
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
            return newObj;
        }

        public bool Register(User_details DetailsObj)
        {
            var IsRegistered = false;
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspInsert_User_details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@User_ID", DbType.String);
            P1.Value = DetailsObj.UserId;
            P1.Size = 15;
            CommandObj.Parameters.Add(P1);

            var P2 = DatabaseConnection.CreateParameter(CommandObj, "@First_Name", DbType.String);
            P2.Value = DetailsObj.FirstName;
            P2.Size = 50;
            CommandObj.Parameters.Add(P2);

            var P3 = DatabaseConnection.CreateParameter(CommandObj, "@Last_Name", DbType.String);
            P3.Value = DetailsObj.LastName;
            P3.Size = 50;
            CommandObj.Parameters.Add(P3);

            var P4 = DatabaseConnection.CreateParameter(CommandObj, "@Date_Of_Birth", DbType.Date);
            P4.Value = DetailsObj.DateOfBirth;
            CommandObj.Parameters.Add(P4);

            var P5 = DatabaseConnection.CreateParameter(CommandObj, "@Address", DbType.String);
            P5.Value = DetailsObj.Address;
            P5.Size = 1000;
            CommandObj.Parameters.Add(P5);

            var P6 = DatabaseConnection.CreateParameter(CommandObj, "@Land_Line_Number", DbType.String);
            P6.Value = DetailsObj.LandLineNumber;
            P6.Size = 15;
            CommandObj.Parameters.Add(P6);

            var P7 = DatabaseConnection.CreateParameter(CommandObj, "@Mobile_Number", DbType.String);
            P7.Value = DetailsObj.MobileNumber;
            P7.Size = 15;
            CommandObj.Parameters.Add(P7);

            var P8 = DatabaseConnection.CreateParameter(CommandObj, "@Area_Of_Interests", DbType.String);
            P8.Value = DetailsObj.AreaOfInterest;
            P8.Size = 100;
            CommandObj.Parameters.Add(P8);

            var P9 = DatabaseConnection.CreateParameter(CommandObj, "@Gender", DbType.String);
            P9.Value = DetailsObj.Gender;
            P9.Size = 1;
            CommandObj.Parameters.Add(P9);

            var P10 = DatabaseConnection.CreateParameter(CommandObj, "@User_Type", DbType.String);
            P10.Value = DetailsObj.UserType;
            P10.Size = 30;
            CommandObj.Parameters.Add(P10);

            var P11 = DatabaseConnection.CreateParameter(CommandObj, "@Date_Of_Registration", DbType.Date);
            P11.Value = DetailsObj.DateOfRegistration;
            CommandObj.Parameters.Add(P11);

            var P12 = DatabaseConnection.CreateParameter(CommandObj, "@Password", DbType.String);
            P12.Value = DetailsObj.Password;
            P12.Size = 50;
            CommandObj.Parameters.Add(P12);
            try
            {
                DatabaseConnection.ExecuteNonQuery(CommandObj);
                IsRegistered = true;
            }
            catch (DbException ex)
            {
                throw new ELibException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ELibException(ex.Message);
            }
            return IsRegistered;
        }

        public User_details FindbyID(string userId)
        {
            User_details DetailsObj = new User_details();
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspFind_User_details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@User_ID", DbType.String);
            P1.Value = userId;
            P1.Size = 15;
            CommandObj.Parameters.Add(P1);

            try
            {
                DataTable TableObj = DatabaseConnection.ExecuteReader(CommandObj);
                if (TableObj != null && TableObj.Rows.Count > 0)
                {
                    foreach (DataRow row in TableObj.Rows)
                    {
                        DetailsObj.UserId = (string)row[0];
                        DetailsObj.FirstName = (string)row[1];
                        DetailsObj.LastName = (string)row[2];
                        DetailsObj.DateOfBirth = (DateTime)row[3];
                        DetailsObj.Address = (string)row[4];
                        DetailsObj.LandLineNumber = (string)row[5];
                        DetailsObj.MobileNumber = (string)row[6];
                        DetailsObj.AreaOfInterest = (string)row[7];
                        DetailsObj.Gender = (string)row[8];
                        DetailsObj.UserType = (string)row[9];
                        DetailsObj.DateOfRegistration = (DateTime)row[10];
                        DetailsObj.Password = (string)row[11];
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


            return DetailsObj;
        }

        public bool UpdateUserDetails(User_details DetailsObj)
        {
            var IsUpdated = false;
            var ConnectionObj = DatabaseConnection.CreateConnection();
            var CommandObj = DatabaseConnection.CreateCommand(ConnectionObj, "ELIB_Management_System.uspUpdate_User_details", CommandType.StoredProcedure);

            var P1 = DatabaseConnection.CreateParameter(CommandObj, "@User_ID", DbType.String);
            P1.Value = DetailsObj.UserId;
            P1.Size = 15;
            CommandObj.Parameters.Add(P1);

            var P2 = DatabaseConnection.CreateParameter(CommandObj, "@First_Name", DbType.String);
            P2.Value = DetailsObj.FirstName;
            P2.Size = 50;
            CommandObj.Parameters.Add(P2);

            var P3 = DatabaseConnection.CreateParameter(CommandObj, "@Last_Name", DbType.String);
            P3.Value = DetailsObj.LastName;
            P3.Size = 50;
            CommandObj.Parameters.Add(P3);

            var P4 = DatabaseConnection.CreateParameter(CommandObj, "@Date_Of_Birth", DbType.Date);
            P4.Value = DetailsObj.DateOfBirth;
            CommandObj.Parameters.Add(P4);

            var P5 = DatabaseConnection.CreateParameter(CommandObj, "@Address", DbType.String);
            P5.Value = DetailsObj.Address;
            P5.Size = 1000;
            CommandObj.Parameters.Add(P5);

            var P6 = DatabaseConnection.CreateParameter(CommandObj, "@Land_Line_Number", DbType.String);
            P6.Value = DetailsObj.LandLineNumber;
            P6.Size = 15;
            CommandObj.Parameters.Add(P6);

            var P7 = DatabaseConnection.CreateParameter(CommandObj, "@Mobile_Number", DbType.String);
            P7.Value = DetailsObj.MobileNumber;
            P7.Size = 15;
            CommandObj.Parameters.Add(P7);

            var P8 = DatabaseConnection.CreateParameter(CommandObj, "@Area_Of_Interests", DbType.String);
            P8.Value = DetailsObj.AreaOfInterest;
            P8.Size = 100;
            CommandObj.Parameters.Add(P8);

            var P9 = DatabaseConnection.CreateParameter(CommandObj, "@Gender", DbType.String);
            P9.Value = DetailsObj.Gender;
            P9.Size = 1;
            CommandObj.Parameters.Add(P9);

            var P10 = DatabaseConnection.CreateParameter(CommandObj, "@User_Type", DbType.String);
            P10.Value = DetailsObj.UserType;
            P10.Size = 30;
            CommandObj.Parameters.Add(P10);


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
    }
}


    

