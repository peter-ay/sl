using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.Web.DBUtility;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ERP.Web.DomainService.Common
{
    public abstract class ImportBase
    {
        public int Import(string dbCode, int lgIndex, string fileName)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);
            DbHelperSQL _DbH = new DbHelperSQL(dbCode);
            using (SqlConnection conn = new SqlConnection(_DbH.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = 200;
                    try
                    {
                        this.PrepareImport(cmd, ds);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return ds.Tables[0].Rows.Count;
        }

        protected abstract void PrepareImport(SqlCommand cmd, DataSet ds);
    }
}