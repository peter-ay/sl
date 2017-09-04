using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Supplier : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Supplier from B_Supplier;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Supplier where SpCode=@SpCode;");
                //
                strSql.Append("insert into #B_Supplier(");
                strSql.Append("SpCode,SpName,SpAddress,Email,Fax,ContactPerson,Phone,AreaCode,F_Semifinished,F_Garages,F_Cutting_Type,F_Stock,F_Comprehensive,Default_Priority,F_Stop,BrowseRight)");
                strSql.Append(" values (");
                strSql.Append("@SpCode,@SpName,@SpAddress,@Email,@Fax,@ContactPerson,@Phone,@AreaCode,@F_Semifinished,@F_Garages,@F_Cutting_Type,@F_Stock,@F_Comprehensive,@Default_Priority,@F_Stop,@BrowseRight)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@SpCode", SqlDbType.VarChar,10),
					new SqlParameter("@SpName", SqlDbType.NVarChar,30),
					new SqlParameter("@SpAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Fax", SqlDbType.NVarChar,30),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@F_Semifinished", SqlDbType.Bit,1),
					new SqlParameter("@F_Garages", SqlDbType.Bit,1),
					new SqlParameter("@F_Cutting_Type", SqlDbType.Bit,1),
					new SqlParameter("@F_Stock", SqlDbType.Bit,1),
					new SqlParameter("@F_Comprehensive", SqlDbType.Bit,1),
					new SqlParameter("@Default_Priority", SqlDbType.Int,4),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000)};
                parameters[0].Value = dr["SpCode"].ToString().Trim();
                parameters[1].Value = dr["SpName"].ToString().Trim();
                parameters[2].Value = dr["SpAddress"].ToString().Trim();
                parameters[3].Value = dr["Email"].ToString().Trim();
                parameters[4].Value = dr["Fax"].ToString().Trim();
                parameters[5].Value = dr["ContactPerson"].ToString().Trim();
                parameters[6].Value = dr["Phone"].ToString().Trim();
                parameters[7].Value = dr["AreaCode"].ToString().Trim();
                parameters[8].Value = dr["F_Semifinished"].ToString().Trim().GetBoolStr();
                parameters[9].Value = dr["F_Garages"].ToString().Trim().GetBoolStr();
                parameters[10].Value = dr["F_Cutting_Type"].ToString().Trim().GetBoolStr();
                parameters[11].Value = dr["F_Stock"].ToString().Trim().GetBoolStr();
                parameters[12].Value = dr["F_Comprehensive"].ToString().Trim().GetBoolStr();
                parameters[13].Value = dr["Default_Priority"].ToString().Trim().GetIntStr();
                parameters[14].Value = dr["F_Stop"].ToString().Trim().GetBoolStr();
                parameters[15].Value = dr["BrowseRight"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Supplier;");
            strSql.Append("insert into B_Supplier select * from #B_Supplier;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}