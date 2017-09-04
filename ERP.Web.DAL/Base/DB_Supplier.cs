using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Supplier : DALBase
    {
        public DB_Supplier()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Supplier with (nolock)");
            strSql.Append(" where SpCode=@SpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@SpCode", SqlDbType.VarChar,10)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "SpCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Supplier;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select @BrowseRight;");
            ///////////////////////////////////////////////////
            strSql.Append("insert into B_Supplier(");
            strSql.Append("SpCode,SpName,SpAddress,Email,Fax,ContactPerson,Phone,AreaCode,F_Semifinished,F_Garages,F_Cutting_Type,F_Stock,F_Comprehensive,Default_Priority,F_Stop,BrowseRight)");
            strSql.Append(" values (");
            strSql.Append("@SpCode,@SpName,@SpAddress,@Email,@Fax,@ContactPerson,@Phone,@AreaCode,@F_Semifinished,@F_Garages,@F_Cutting_Type,@F_Stock,@F_Comprehensive,@Default_Priority,@F_Stop,HKOERP.dbo.SF_GetRightDefaultValue())");
            SqlParameter[] parameters = {
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
            parameters[0].Value = model.SpCode;
            parameters[1].Value = model.SpName;
            parameters[2].Value = model.SpAddress;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Fax;
            parameters[5].Value = model.ContactPerson;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.AreaCode;
            parameters[8].Value = model.F_Semifinished;
            parameters[9].Value = model.F_Garages;
            parameters[10].Value = model.F_Cutting_Type;
            parameters[11].Value = model.F_Stock;
            parameters[12].Value = model.F_Comprehensive;
            parameters[13].Value = model.Default_Priority;
            parameters[14].Value = model.F_Stop;
            parameters[15].Value = model.BrowseRight;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Supplier;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Supplier set ");
            strSql.Append("SpName=@SpName,");
            strSql.Append("SpAddress=@SpAddress,");
            strSql.Append("Email=@Email,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("AreaCode=@AreaCode,");
            strSql.Append("F_Semifinished=@F_Semifinished,");
            strSql.Append("F_Garages=@F_Garages,");
            strSql.Append("F_Cutting_Type=@F_Cutting_Type,");
            strSql.Append("F_Stock=@F_Stock,");
            strSql.Append("F_Comprehensive=@F_Comprehensive,");
            strSql.Append("Default_Priority=@Default_Priority,");
            strSql.Append("F_Stop=@F_Stop");
            strSql.Append(" where SpCode=@SpCode ");
            SqlParameter[] parameters = {
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
					new SqlParameter("@SpCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.SpName;
            parameters[1].Value = model.SpAddress;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Fax;
            parameters[4].Value = model.ContactPerson;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.AreaCode;
            parameters[7].Value = model.F_Semifinished;
            parameters[8].Value = model.F_Garages;
            parameters[9].Value = model.F_Cutting_Type;
            parameters[10].Value = model.F_Stock;
            parameters[11].Value = model.F_Comprehensive;
            parameters[12].Value = model.Default_Priority;
            parameters[13].Value = model.F_Stop;
            parameters[14].Value = model.SpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
