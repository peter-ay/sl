using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Material_LensClass_Index:ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Material_LensClass_Index from B_Material_LensClass_Index;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Material_LensClass_Index where KeyCode=@KeyCode;");
                //
                strSql.Append("insert into #B_Material_LensClass_Index(");
                strSql.Append("KeyCode,KeyName,SN)");
                strSql.Append(" values (");
                strSql.Append("@KeyCode,@KeyName,@SN)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@KeyCode", SqlDbType.VarChar,10),
					new SqlParameter("@KeyName", SqlDbType.NVarChar,30),
					new SqlParameter("@SN", SqlDbType.Int,4)};
                parameters[0].Value = dr["KeyCode"].ToString().Trim();
                parameters[1].Value = dr["KeyName"].ToString().Trim();
                parameters[2].Value = dr["SN"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Material_LensClass_Index;");
            strSql.Append("insert into B_Material_LensClass_Index select * from #B_Material_LensClass_Index;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}