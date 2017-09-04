using System;
using System.Data;
using System.Data.OleDb;

namespace ERP.Web.DBUtility
{
    public class DbHelperOledb
    {
        public DataSet ChangeExcelToDataSet(string opnFileName)
        {
            string dbName = "";
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + opnFileName + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = new DataSet();
            strExcel = "";
            try
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow row in schemaTable.Rows)
                {
                    dbName = ((string)row["TABLE_NAME"]).Trim();
                    if (dbName.Substring(dbName.Length - 1, 1) == "_")
                    {
                        continue;
                    }
                    strExcel = "select * from [" + dbName + "]";
                    myCommand = new OleDbDataAdapter(strExcel, strConn);
                    myCommand.Fill(ds, dbName);
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static int ExecuteSql(string SQLString, string connectionString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

    }
}
