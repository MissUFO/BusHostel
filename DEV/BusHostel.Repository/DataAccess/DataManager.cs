using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Principal;
using System.Text;
using System.Xml;

namespace BusHostel.Repository.DataAccess
{
    /// <summary>
    /// Database Manager (Version 2.0 [.net version 4.0])
    /// </summary>    
    public class DataManager : IDataManager, IDisposable
    {
        private readonly string ConnectionString;
        private SqlCommand dbCommand;

        /// <summary>
        /// DataManager constructor 
        /// </summary>
        /// <param name="executeString">string to be executed</param>
        public DataManager(string connectionString)
        {
            dbCommand = new SqlCommand();
            this.ConnectionString = connectionString;
        }

        public DataManager(string connectionString, int commandTimeout)
        {
            dbCommand = new SqlCommand();
            this.ConnectionString = connectionString;
            dbCommand.CommandTimeout = commandTimeout;
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~DataManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the resources used by the Component.
        /// </summary>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            dbCommand.Parameters.Clear();
            if (dbCommand.Connection != null)
            {
                if (dbCommand.Connection.State == System.Data.ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                }
            }
            dbCommand.Dispose();
        }

        /// <summary>
        /// Releases the resources used by the Component.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    
        /// <summary>
        /// SP for execute
        /// </summary>
        public string ExecuteString { get; set; }

        /// <summary>
        /// Adds parameter name, datatype and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), ParameterDirection.Input, value);
        }

        /// <summary>
        /// Adds parameter name, datatype, size and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>        
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), ParameterDirection.Input, value);
        }

        /// <summary>
        /// Adds parameter name, datatype and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction = ParameterDirection.Output)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction);
        }

        /// <summary>
        /// Adds parameter name, datatype, size and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction) // DONT ASSIGNE TO DEFAULT PARAMATERS.
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction);
        }

        /// <summary>
        /// Adds parameter name, datatype and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction, value);
        }

        /// <summary>
        /// Adds parameter name, datatype, size and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction, value);
        }

        /// <summary>
        /// Adds parameter name, datatype, size and direction for the stored procedures. Parameter name will be same as found in stored procedures
        /// </summary>
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, byte precision, byte scale, ParameterDirection direction, object value = null)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType) { Precision = precision, Scale = scale }, direction, value);
        }

        /// <summary>
        ///  Adds SqlParameter object 
        /// </summary>
        public SqlParameter Add(SqlParameter SqlPar, ParameterDirection direction = ParameterDirection.Input, object value = null)
        {
            if (dbCommand.CommandType != CommandType.StoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;
            SqlPar.Value = value ?? DBNull.Value;
            SqlPar.Direction = direction;
            if (SqlPar.DbType == DbType.Xml && value != null)
                SqlPar.Value = new SqlXml(new XmlTextReader(value.ToString(), XmlNodeType.Document, null));
            if (!dbCommand.Parameters.Contains(SqlPar))
                dbCommand.Parameters.Add(SqlPar);
            dbCommand.Parameters[SqlPar.ParameterName] = SqlPar;
            return SqlPar;
        }
      
        /// <summary>
        /// Removes all Parameter added.
        /// </summary>
        public void Clear()
        {
            dbCommand.Parameters.Clear();
        }
      
        /// <summary>
        /// Gets a value indicating whether a SqlParameter exists in the collection
        /// </summary>        
        public bool Contains(object value)
        {
            return dbCommand.Parameters.Contains(value);
        }

        /// <summary>
        /// Gets a value indicating whether a SqlParameter with the specified parameter name exists in the collection.
        /// </summary>        
        public bool Contains(string value)
        {
            return dbCommand.Parameters.Contains(value);
        }
       
        public System.Collections.IEnumerator GetEnumerator()
        {
            return dbCommand.Parameters.GetEnumerator();
        }
      
        /// <summary>
        /// Gets the location of a SqlParameter in the collection.
        /// </summary>        
        public int IndexOf(object value)
        {
            return dbCommand.Parameters.IndexOf(value);
        }

        /// <summary>
        /// Gets the location of the SqlParameter in the collection with a specific parameter name.
        /// </summary>       
        public int IndexOf(string parameterName)
        {
            return dbCommand.Parameters.IndexOf(parameterName);
        }
       
        /// <summary>
        /// Inserts a SqlParameter into the collection at the specified index.
        /// </summary>        
        public void Insert(int index, object value)
        {
            dbCommand.Parameters.Insert(index, value);
        }
     
        /// <summary>
        /// Removes the specified SqlParameter from the collection.
        /// </summary>      
        public void Remove(object value)
        {           
            dbCommand.Parameters.Remove(value);
        }
      
        /// <summary>
        /// Removes the specified SqlParameter from the collection using the parameter name.
        /// </summary>      
        public void RemoveAt(string parameterName)
        {           
            dbCommand.Parameters.RemoveAt(parameterName);
        }

        /// <summary>
        /// Removes the specified SqlParameter from the collection using a specific index.
        /// </summary>        
        public void RemoveAt(int index)
        {
            dbCommand.Parameters.RemoveAt(index);
        }
      
        /// <summary>
        /// Gets the number of SqlParameter objects in the collection.
        /// </summary>
        public int Count
        {
            get { return dbCommand.Parameters.Count; }
        }
       
        /// <summary>
        /// The parameters of the Transact-SQL statement or stored procedure. The default is an empty collection.
        /// </summary>
        public SqlParameter this[int index]
        {
            get { return dbCommand.Parameters[index]; }
            set { dbCommand.Parameters[index] = value; }
        }

        /// <summary>
        /// The parameters of the Transact-SQL statement or stored procedure. The default is an empty collection.
        /// </summary>
        public SqlParameter this[string parameterName]
        {
            get { return dbCommand.Parameters[parameterName]; }
            set { dbCommand.Parameters[parameterName] = value; }
        }

        public CommandType CommandType
        {
            get { return dbCommand.CommandType; }
            set { dbCommand.CommandType = value; }
        }
       
        /// <summary>
        /// Returns the value from Stored Procedures
        /// </summary>
        public int ReturnValue
        {
            get
            {
                if (this["@ReturnValue"].Value == DBNull.Value)
                    return int.MinValue;
                return (int)this["@ReturnValue"].Value;
            }
        }
      
        private SqlConnection PrepareExecution(string ExecuteString)
        {
            if (dbCommand == null)
            {
                dbCommand = new SqlCommand();
            }
            if (dbCommand.Connection == null)
            {
                dbCommand.Connection = new SqlConnection(ConnectionString);
            }
            else if (dbCommand.Connection.ConnectionString.Length == 0)
            {
                dbCommand.Connection.ConnectionString = ConnectionString;
            }
            if (dbCommand.Connection.State != System.Data.ConnectionState.Open)
            {
                dbCommand.Connection.Open();
            }
            dbCommand.CommandText = ExecuteString;
            if (dbCommand.CommandType == CommandType.StoredProcedure)
            {
                Add("@ReturnValue", SqlDbType.Int, ParameterDirection.ReturnValue);
            }           
            return dbCommand.Connection;
        }
      
        private void CheckDBError()
        {
            if (this.Contains("@ReturnValue"))
            {
                if ((ReturnValue != 0) && (ReturnValue != -2147483648)) { throw new Exception(ReturnValue.ToString()); }
            }
        }
      
        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>       
        public int ExecuteNonQuery()
        {
            using (PrepareExecution(ExecuteString))
            {
                int returnValue = dbCommand.ExecuteNonQuery();
                CheckDBError();
                return returnValue;
            }
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
        /// </summary>       
        public object ExecuteScalar()
        {
            using (PrepareExecution(ExecuteString))
            {
                object returnValue = dbCommand.ExecuteScalar();
                CheckDBError();
                return returnValue;
            }
        }
      
        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns provides a stream of XML data which is forward-only, read-only access.
        /// </summary>        
        public XmlReader ExecuteXmlReader()
        {
            PrepareExecution(ExecuteString);
            XmlReader returnValue = dbCommand.ExecuteXmlReader();
            CheckDBError();
            return returnValue;
        }
       
        public string ExecuteXmlString()
        {
            using (PrepareExecution(ExecuteString))
            {
                using (XmlReader reader = dbCommand.ExecuteXmlReader())
                {
                    CheckDBError();
                    StringBuilder builder = new StringBuilder();
                    if (reader.Read())
                    {
                        string text = null;
                        while (!string.IsNullOrEmpty((text = reader.ReadOuterXml())))
                            builder.Append(text);
                    }
                    return builder.ToString();
                }
            }
        }
      
        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns a stream of (reading &amp; forward-only) rows from a SQL Server database.
        /// </summary>       
        public SqlDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            PrepareExecution(ExecuteString);
            SqlDataReader returnValue = dbCommand.ExecuteReader(behavior);
            CheckDBError();
            return returnValue;
        }
     
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>        
        public IEnumerable<T> GetList<T>(Func<IDataRecord, T> current)
        {
            using (PrepareExecution(ExecuteString))
            {
                IList<T> list = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    CheckDBError();
                    while (reader.Read()) { list.Add(current(reader)); }
                }
                return list;
            }
        }
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>       
        public IEnumerable<T> GetList<T>(IListSetting setting, Func<IDataRecord, T> current)
        {
            AddListingParameters(setting);
            using (PrepareExecution(ExecuteString))
            {
                IList<T> list = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    CheckDBError();
                    while (reader.Read()) { list.Add(current(reader)); }
                }
               
                return list;
            }
        }
        
        /// <summary>
        ///  This will add default Paramater in the store procedue this is maily used for 
        /// </summary>       
        private void AddListingParameters(IListSetting setting)
        {
            Add("@SortColumnIndex", SqlDbType.TinyInt, (object)setting.SortColumnIndex);
            Add("@SortDirection", SqlDbType.Bit, (object)(byte)setting.SortDirection);
            Add("@CurrentPageNumber", SqlDbType.Int, (object)setting.CurrentPageNumber);
            Add("@RecordsPerPage", SqlDbType.Int, (object)setting.RecordsPerPage);
            Add("@TotalNumberOfRecords", SqlDbType.Int);
        }
               
        DbDataReader IDataManager.ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            return this.ExecuteReader(behavior);
        }
      
        DbParameter IDataManager.this[int index]
        {
            get
            {
                return this[index];
            }
        }
       
        DbParameter IDataManager.this[string parameterName]
        {
            get
            {
                return this[parameterName];
            }
        }
    }
}