using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Material_Process : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Material_Process from B_Material_Process;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Material_Process where ProCode=@ProCode;");
                //
                strSql.Append("insert into #B_Material_Process(");
                strSql.Append("ProCode,ProName,ProClass,F_RX,F_ST)");
                strSql.Append(" values (");
                strSql.Append("@ProCode,@ProName,@ProClass,@F_RX,@F_ST)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ProCode", SqlDbType.VarChar,20),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProClass", SqlDbType.VarChar,10),
					new SqlParameter("@F_RX", SqlDbType.Bit,1),
					new SqlParameter("@F_ST", SqlDbType.Bit,1)};
                parameters[0].Value = dr["ProCode"].ToString().Trim();
                parameters[1].Value = dr["ProName"].ToString().Trim();
                parameters[2].Value = dr["ProClass"].ToString().Trim();
                parameters[3].Value = dr["F_RX"].ToString().Trim().GetBoolStr();
                parameters[4].Value = dr["F_ST"].ToString().Trim().GetBoolStr();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Material_Process;");
            strSql.Append("insert into B_Material_Process select * from #B_Material_Process;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}