using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Customer_Acc : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Customer_Acc from B_Customer_Acc;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Customer_Acc where AccCusCode=@AccCusCode;");
                //
                strSql.Append("insert into #B_Customer_Acc(");
                strSql.Append("AccCusCode,AccCusName,AccEndDate,AccLimit,PCode)");
                strSql.Append(" values (");
                strSql.Append("@AccCusCode,@AccCusName,@AccEndDate,@AccLimit,@PCode)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@AccCusCode", SqlDbType.VarChar,20),
					new SqlParameter("@AccCusName", SqlDbType.NVarChar,100),
					new SqlParameter("@AccEndDate", SqlDbType.Int,4),
					new SqlParameter("@AccLimit", SqlDbType.Decimal,9),
					new SqlParameter("@PCode", SqlDbType.VarChar,20)};
                parameters[0].Value = dr["AccCusCode"].ToString().Trim();
                parameters[1].Value = dr["AccCusName"].ToString().Trim();
                parameters[2].Value = dr["AccEndDate"].ToString().Trim().GetIntStr();
                parameters[3].Value = dr["AccLimit"].ToString().Trim();
                parameters[4].Value = dr["PCode"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Customer_Acc;");
            strSql.Append("insert into B_Customer_Acc select * from #B_Customer_Acc;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}