using LookAndPlayForm.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.DataBase
{
    public sealed class SQLiteDataBase
    {
        /// Private Variables
        #region Private Variables

        /// <summary>
        /// 
        /// </summary>
        string dbConnection;

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// Default Constructor for SQLiteDataBase Class.
        /// </summary>
        private SQLiteDataBase()
        {
            dbConnection = string.Format("Data Source={0}", CData.DataBaseName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param Name="inputFile"></param>
        public SQLiteDataBase(string inputFile)
        {
            dbConnection = String.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        /// Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param Name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SQLiteDataBase(Dictionary<String, String> connectionOpts)
        {
            string str = "";
            foreach (KeyValuePair<String, String> row in connectionOpts)
            {
                str += String.Format("{0}={1}; ", row.Key, row.Value);
            }
            str = str.Trim().Substring(0, str.Length - 1);
            dbConnection = str;
        }

        #endregion

        /// Functions
        #region Functions

        /// <summary>
        /// Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param Name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
                {
                    if (cnn == null)
                        throw new SQLiteException("Can't create connection");
                    cnn.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(cnn);
                    if (mycommand == null)
                        throw new SQLiteException("Can't create command");
                    mycommand.CommandText = sql;
                    using (SQLiteDataReader reader = mycommand.ExecuteReader())
                    {
                        if (reader == null)
                            throw new SQLiteException("Can't create data reader");
                        dt.Load(reader);
                        mycommand.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            return dt;
        }

        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param Name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
                {
                    try
                    {
                        cnn.Open();
                        SQLiteCommand mycommand = cnn.CreateCommand();
                        SQLiteTransaction trans = cnn.BeginTransaction();

                        mycommand.Connection = cnn;
                        mycommand.Transaction = trans;
                        mycommand.CommandText = sql;

                        int rowsUpdated = mycommand.ExecuteNonQuery();
                        trans.Commit();
                        return rowsUpdated;
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ErrorCode != 1)
                        {
                            ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string GetLine(string sql)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
                {
                    cnn.Open();
                    SQLiteCommand mycommand = cnn.CreateCommand();
                    SQLiteTransaction trans = cnn.BeginTransaction();

                    try
                    {
                        mycommand.Connection = cnn;
                        mycommand.Transaction = trans;
                        mycommand.CommandText = sql;
                        StringBuilder SB = new StringBuilder();

                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {                            
                            reader.Read();
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.VisibleFieldCount - 1; i++)
                                    SB.AppendLine(reader.GetString(i));

                                if (reader.VisibleFieldCount >= 1)
                                    SB.Append(reader.GetString(reader.VisibleFieldCount - 1));
                            }
                        }
                        trans.Commit();

                        return SB.ToString();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ErrorCode != 1)
                        {
                            ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                        }
                        return "";
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            return "";
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
                {
                    cnn.Open();
                    SQLiteCommand mycommand = cnn.CreateCommand();
                    SQLiteTransaction trans = cnn.BeginTransaction();

                    try
                    {
                        mycommand.Connection = cnn;
                        mycommand.Transaction = trans;
                        mycommand.CommandText = sql;

                        object value = mycommand.ExecuteScalar();

                        trans.Commit();
                        if (value != null)
                            return value.ToString();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ErrorCode != 1)
                        {
                            ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                        }
                        return "";
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            return "";
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        public void CreateTable(string schema)
        {
            try
            {
                ExecuteNonQuery(schema);
            }
            catch (SQLiteException ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }        
        }

        #endregion
    }
}
