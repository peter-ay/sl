using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Customer_Main : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Customer_Main from B_Customer_Main;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Customer_Main where MainCusCode=@MainCusCode;");
                //
                strSql.Append("insert into #B_Customer_Main(");
                strSql.Append("MainCusCode,MainCusName)");
                strSql.Append(" values (");
                strSql.Append("@MainCusCode,@MainCusName)");
                parameters = new SqlParameter[] {
					new SqlParameter("@MainCusCode", SqlDbType.VarChar,20),
					new SqlParameter("@MainCusName", SqlDbType.NVarChar,100)};
                parameters[0].Value = dr["MainCusCode"].ToString().Trim();
                parameters[1].Value = dr["MainCusName"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Customer_Main;");
            strSql.Append("insert into B_Customer_Main select * from #B_Customer_Main;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}