using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace ERP.Web.DBUtility
{
    public class DbHelperSQL
    {
        private static SqlParameter sqlParameter;
        private string connectionString = "";
        public string ConnectionString
        {
            get { return connectionString; }
        }

        public DbHelperSQL(string dbCode = "master")
        {
            this.ResetConnectionString(dbCode);
        }

        private void ResetConnectionString(string dbCode)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(PubConstant.ConnectionString);
            string database = dbCode;
            //if (string.IsNullOrEmpty(database))
            //{
            //    if (HttpContext.Current.Session["DataBase"] == null || HttpContext.Current.Session["DataBase"].ToString() == "")
            //        throw new Exception("Session abort, please login again.");
            //    database = HttpContext.Current.Session["DataBase"].ToString();
            //}
            sb.IntegratedSecurity = false;
            sb.InitialCatalog = database;
            connectionString = sb.ConnectionString;
        }

        //Exist
        public bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        //SQL语句
        public int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.CommandTimeout = 200;
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 200;
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        public DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = 200;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        cmd.CommandTimeout = 200;
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ExecuteSqlTran(Hashtable SQLMainList, Hashtable SQLSubList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        cmd.CommandTimeout = 200;

                        foreach (DictionaryEntry myDE in SQLMainList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        foreach (DictionaryEntry myDE in SQLSubList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        //存储过程
        public void RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandTimeout = 200;
                command.ExecuteNonQuery();
            }
        }

        public void RunProcedureTran(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                        command.Transaction = trans;
                        command.CommandTimeout = 200;
                        command.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void BulkCopyByDatatable(string TableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters, bool isReturn = false)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    //
                    if (isReturn && parameter.Direction == ParameterDirection.Output)
                    {
                        sqlParameter = parameter;
                    }
                    //
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        //自定义方法
        //public string ExecuteSqlTranForAdd(Hashtable htID, Hashtable htBCode, Hashtable htMain, Hashtable htSub)
        //{
        //    string ID = "", BCode = "";
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.Transaction = trans;
        //            cmd.CommandTimeout = 200;
        //            try
        //            {
        //                //ID
        //                foreach (DictionaryEntry _DE in htID)
        //                {
        //                    string cmdText = _DE.Key.ToString();
        //                    cmd.CommandText = cmdText;
        //                    cmd.CommandType = CommandType.StoredProcedure;

        //                    SqlParameter[] cmdParms = (SqlParameter[])_DE.Value;
        //                    if (cmdParms != null)
        //                    {
        //                        foreach (SqlParameter parameter in cmdParms)
        //                        {
        //                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                                (parameter.Value == null))
        //                            {
        //                                parameter.Value = DBNull.Value;
        //                            }
        //                            cmd.Parameters.Add(parameter);
        //                        }
        //                    }
        //                    cmd.ExecuteNonQuery();
        //                    ID = cmd.Parameters[3].Value.ToString().Trim();
        //                    cmd.Parameters.Clear();
        //                }
        //                //BCode
        //                foreach (DictionaryEntry _DE in htBCode)
        //                {
        //                    string cmdText = _DE.Key.ToString();
        //                    cmd.CommandText = cmdText;
        //                    cmd.CommandType = CommandType.StoredProcedure;

        //                    SqlParameter[] cmdParms = (SqlParameter[])_DE.Value;
        //                    if (cmdParms != null)
        //                    {
        //                        foreach (SqlParameter parameter in cmdParms)
        //                        {
        //                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                                (parameter.Value == null))
        //                            {
        //                                parameter.Value = DBNull.Value;
        //                            }
        //                            cmd.Parameters.Add(parameter);
        //                        }
        //                    }
        //                    cmd.ExecuteNonQuery();
        //                    BCode = cmd.Parameters[3].Value.ToString().Trim();
        //                    cmd.Parameters.Clear();
        //                }
        //                //Main
        //                foreach (DictionaryEntry _DE in htMain)
        //                {
        //                    string cmdText = _DE.Key.ToString();
        //                    cmd.CommandText = cmdText;
        //                    cmd.CommandType = CommandType.Text;

        //                    SqlParameter[] cmdParms = (SqlParameter[])_DE.Value;
        //                    if (cmdParms != null)
        //                    {
        //                        foreach (SqlParameter parameter in cmdParms)
        //                        {
        //                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                                (parameter.Value == null))
        //                            {
        //                                parameter.Value = DBNull.Value;
        //                            }

        //                            cmd.Parameters.Add(parameter);
        //                        }
        //                    }
        //                    cmd.Parameters[0].Value = ID;
        //                    cmd.Parameters[1].Value = BCode;
        //                    cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }
        //                //Sub
        //                foreach (DictionaryEntry _DE in htSub)
        //                {
        //                    string cmdText = _DE.Key.ToString();
        //                    cmd.CommandText = cmdText;
        //                    cmd.CommandType = CommandType.Text;

        //                    SqlParameter[] cmdParms = (SqlParameter[])_DE.Value;
        //                    if (cmdParms != null)
        //                    {
        //                        foreach (SqlParameter parameter in cmdParms)
        //                        {
        //                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                                (parameter.Value == null))
        //                            {
        //                                parameter.Value = DBNull.Value;
        //                            }

        //                            cmd.Parameters.Add(parameter);
        //                        }
        //                    }
        //                    cmd.Parameters[0].Value = ID;
        //                    cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }

        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //    return ID;
        //}

        //public string ExecuteSqlTranForAdd(Hashtable htMain, Hashtable htSub)
        //{
        //    string ID = "";
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.Transaction = trans;
        //            cmd.CommandTimeout = 200;
        //            try
        //            {
        //                //ID
        //                string cmdText = "select HKOERP.dbo.SF_GetID()";
        //                cmd.CommandText = cmdText;
        //                cmd.CommandType = CommandType.Text;
        //                ID = cmd.ExecuteScalar().ToString();
        //                //Main
        //                foreach (DictionaryEntry _DE in htMain)
        //                {
        //                    string cmdTextMain = _DE.Key.ToString();
        //                    cmd.CommandText = cmdTextMain;
        //                    cmd.CommandType = CommandType.Text;

        //                    SqlParameter[] cmdParms = (SqlParameter[])_DE.Value;
        //                    if (cmdParms != null)
        //                    {
        //                        foreach (SqlParameter parameter in cmdParms)
        //                        {
        //                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                                (parameter.Value == null))
        //                            {
        //                                parameter.Value = DBNull.Value;
        //                            }

        //                            cmd.Parameters.Add(parameter);
        //                        }
        //                    }
        //                    cmd.Parameters[0].Value = ID;
        //                    cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }
        //                //Sub
        //                if (htSub.Count > 0)
        //                {

        //                }

        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //    return ID;
        //}

        //调用存储过程，返回一个泛型

        private static object returnValue;

        public T RunProcedureForReturnGenerics<T>(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters, true);
                command.CommandTimeout = 200;
                command.ExecuteNonQuery();
                returnValue = sqlParameter.Value;
                return (T)returnValue;
            }
        }

        //获取语言
        public string GetLanguageText(string code, int lgindex)
        {
            string rs = "";
            string str = "select Msg from HKOERP.dbo.U_Message E with (nolock) where E.MsgCode='" + code + "' and E.LgIndex=" + lgindex;
            var ds = this.Query(str);
            try
            {
                rs = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            return rs;
        }
    }
}
