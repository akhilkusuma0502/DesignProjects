using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_DataAccessLayer
{
 
         using System.Data;
    using System.Data.Common;
    using System.Configuration;
    internal class DatabaseConnection
    {
        public static DbConnection CreateConnection()
        {
            DbProviderFactory FactoryObj = DbProviderFactories.GetFactory(Configuration.ProviderName);
            DbConnection ConnectionObj = FactoryObj.CreateConnection();
            ConnectionObj.ConnectionString =Configuration.ConnectionString;
            return ConnectionObj;
        }

        public static DbCommand CreateCommand(DbConnection connectionObj, string commandText, CommandType commandType = CommandType.Text)
        {
            DbCommand CommandObj = connectionObj.CreateCommand();
            CommandObj.Connection = connectionObj;
            CommandObj.CommandText = commandText;
            CommandObj.CommandType = commandType;
            return CommandObj;
        }

        public static DbParameter CreateParameter(DbCommand commandObj, string parameterName, DbType type, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            DbParameter ParameterObj = commandObj.CreateParameter();
            ParameterObj.ParameterName = parameterName;
            ParameterObj.DbType = type;
            ParameterObj.Direction = parameterDirection;
            return ParameterObj;
        }

        public static int ExecuteNonQuery(DbCommand commandObj)
         {
            int RowsAffected = -1;
            try
            {
                commandObj.Connection.Open();
                RowsAffected = commandObj.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (commandObj.Connection.State == ConnectionState.Open)
                    commandObj.Connection.Close();
            }
            return RowsAffected;
        }

        public static object ExecuteScalar(DbCommand commandObj)
        {
            object Value = null;
            try
            {
                commandObj.Connection.Open();
                Value = commandObj.ExecuteScalar();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (commandObj.Connection.State == ConnectionState.Open)
                    commandObj.Connection.Close();
            }
            return Value;
        }

        public static DataTable ExecuteReader(DbCommand commandObj)
        {
            DataTable TableObj = null;
            try
            {
                commandObj.Connection.Open();
                DbDataReader ReaderObj = commandObj.ExecuteReader();
                if (ReaderObj.HasRows)
                {
                    TableObj = new DataTable();
                    TableObj.Load(ReaderObj);
                    ReaderObj.Close();
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (commandObj.Connection.State == ConnectionState.Open)
                    commandObj.Connection.Close();
            }
            return TableObj;
        }
    }
}
