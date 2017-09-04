using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Process
    {
        public int Import(string dbCode, int lgIndex, string fileName)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSql = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("Delete B_Process where ProcessCode=@ProcessCode and ProcessName=@ProcessName;");
                strSql.Append("insert into B_Process(");
                strSql.Append("ProcessCode,ProcessName,Remark,CF_Flag,KF_Flag)");
                strSql.Append(" values (");
                strSql.Append("@ProcessCode,@ProcessName,@Remark,@CF_Flag,@KF_Flag)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ProcessCode", SqlDbType.NVarChar,20),
					new SqlParameter("@ProcessName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@CF_Flag", SqlDbType.Bit,1),
					new SqlParameter("@KF_Flag", SqlDbType.Bit,1)};
                parameters[0].Value = dr["ProcessCode"].ToString().Trim();
                parameters[1].Value = dr["ProcessName"].ToString().Trim();
                parameters[2].Value = dr["Remark"].ToString().Trim();
                parameters[3].Value = Convert.ToBoolean(dr["CF_Flag"].ToString() == "" ? false : dr["CF_Flag"]);
                parameters[4].Value = Convert.ToBoolean(dr["KF_Flag"].ToString() == "" ? false : dr["KF_Flag"]);

                strSql.Append("--" + i++.ToString());
                htstrSql.Add(strSql.ToString(), parameters);
                strSql.Clear();
            }
            DbHelperSQL u = new DbHelperSQL(dbCode);
            u.ExecuteSqlTran(htstrSql);
            return htstrSql.Count;
        }
    }
}