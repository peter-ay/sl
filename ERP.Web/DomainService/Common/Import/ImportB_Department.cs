using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Department : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Department from B_Department;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Department where DpCode=@DpCode;");
                //
                strSql.Append("insert into #B_Department(");
                strSql.Append("DpCode,DpName,PCode,DpProperty,Incharge,Tel,DpAddress,Remark,BrowseRight,F_CX)");
                strSql.Append(" values (");
                strSql.Append("@DpCode,@DpName,@PCode,@DpProperty,@Incharge,@Tel,@DpAddress,@Remark,@BrowseRight,@F_CX)");
                parameters = new SqlParameter[] {
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpName", SqlDbType.NVarChar,30),
					new SqlParameter("@PCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpProperty", SqlDbType.NVarChar,30),
					new SqlParameter("@Incharge", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@DpAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000),
					new SqlParameter("@F_CX", SqlDbType.Bit,1)};
                parameters[0].Value = dr["DpCode"].ToString().Trim();
                parameters[1].Value = dr["DpName"].ToString().Trim();
                parameters[2].Value = dr["PCode"].ToString().Trim();
                parameters[3].Value = dr["DpProperty"].ToString().Trim();
                parameters[4].Value = dr["Incharge"].ToString().Trim();
                parameters[5].Value = dr["Tel"].ToString().Trim();
                parameters[6].Value = dr["DpAddress"].ToString().Trim();
                parameters[7].Value = dr["Remark"].ToString().Trim();
                parameters[8].Value = dr["BrowseRight"].ToString().Trim();
                parameters[9].Value = dr["F_CX"].ToString().Trim().GetBoolStr();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Department;");
            strSql.Append("insert into B_Department select * from #B_Department;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}