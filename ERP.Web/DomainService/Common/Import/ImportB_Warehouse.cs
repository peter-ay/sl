using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Warehouse : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Warehouse from B_Warehouse;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Warehouse where WhCode=@WhCode;");
                //
                strSql.Append("insert into #B_Warehouse(");
                strSql.Append("WhCode,WhName,WhAddress,DpCode,Tel,ManageMan,Remark,Priority,F_Stop,BrowseRight,UseRight)");
                strSql.Append(" values (");
                strSql.Append("@WhCode,@WhName,@WhAddress,@DpCode,@Tel,@ManageMan,@Remark,@Priority,@F_Stop,@BrowseRight,@UseRight)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@WhName", SqlDbType.NVarChar,30),
					new SqlParameter("@WhAddress", SqlDbType.NVarChar,30),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@ManageMan", SqlDbType.NVarChar,30),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@Priority", SqlDbType.TinyInt,1),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000),
					new SqlParameter("@UseRight", SqlDbType.VarChar,1000)};
                parameters[0].Value = dr["WhCode"].ToString().Trim();
                parameters[1].Value = dr["WhName"].ToString().Trim();
                parameters[2].Value = dr["WhAddress"].ToString().Trim();
                parameters[3].Value = dr["DpCode"].ToString().Trim();
                parameters[4].Value = dr["Tel"].ToString().Trim();
                parameters[5].Value = dr["ManageMan"].ToString().Trim();
                parameters[6].Value = dr["Remark"].ToString().Trim();
                parameters[7].Value = dr["Priority"].ToString().Trim().GetIntStr();
                parameters[8].Value = dr["F_Stop"].ToString().Trim().GetBoolStr();
                parameters[9].Value = dr["BrowseRight"].ToString().Trim();
                parameters[10].Value = dr["UseRight"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Warehouse;");
            strSql.Append("insert into B_Warehouse select * from #B_Warehouse;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}