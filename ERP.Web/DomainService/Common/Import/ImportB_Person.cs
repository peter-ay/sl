using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Person : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Person from B_Person;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Person where PersonCode=@PersonCode;");
                //
                strSql.Append("insert into #B_Person(");
                strSql.Append("PersonCode,PersonName,DpCode,PersonProperty)");
                strSql.Append(" values (");
                strSql.Append("@PersonCode,@PersonName,@DpCode,@PersonProperty)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@PersonCode", SqlDbType.VarChar,10),
					new SqlParameter("@PersonName", SqlDbType.NVarChar,20),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@PersonProperty", SqlDbType.NVarChar,30)};
                parameters[0].Value = dr["PersonCode"].ToString().Trim();
                parameters[1].Value = dr["PersonName"].ToString().Trim();
                parameters[2].Value = dr["DpCode"].ToString().Trim();
                parameters[3].Value = dr["PersonProperty"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Person;");
            strSql.Append("insert into B_Person select * from #B_Person;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}