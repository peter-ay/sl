using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Warehouse : DALBase
    {
        public DB_Warehouse()
        { }
        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_WareHouse with (nolock)");
            strSql.Append(" where WhCode=@WhCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@WhCode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "WhCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Warehouse;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select @BrowseRight;");
            strSql.Append("select @UseRight;");
            //////////////////////////////////////////////////
            strSql.Append("insert into B_Warehouse(");
            strSql.Append("WhCode,WhName,WhAddress,DpCode,Tel,ManageMan,Remark,Priority,F_Stop,BrowseRight,UseRight)");
            strSql.Append(" values (");
            strSql.Append("@WhCode,@WhName,@WhAddress,@DpCode,@Tel,@ManageMan,@Remark,@Priority,@F_Stop,HKOERP.dbo.SF_GetRightDefaultValue(),HKOERP.dbo.SF_GetRightDefaultValue())");
            SqlParameter[] parameters = {
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
            parameters[0].Value = model.WhCode;
            parameters[1].Value = model.WhName;
            parameters[2].Value = model.WhAddress;
            parameters[3].Value = model.DpCode;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.ManageMan;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.Priority;
            parameters[8].Value = model.F_Stop;
            parameters[9].Value = model.BrowseRight;
            parameters[10].Value = model.UseRight;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Warehouse;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Warehouse set ");
            strSql.Append("WhName=@WhName,");
            strSql.Append("WhAddress=@WhAddress,");
            strSql.Append("DpCode=@DpCode,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("ManageMan=@ManageMan,");
            strSql.Append("F_Stop=@F_Stop,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where WhCode=@WhCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@WhName", SqlDbType.NVarChar,30),
					new SqlParameter("@WhAddress", SqlDbType.NVarChar,30),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@ManageMan", SqlDbType.NVarChar,30),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.WhName;
            parameters[1].Value = model.WhAddress;
            parameters[2].Value = model.DpCode;
            parameters[3].Value = model.Tel;
            parameters[4].Value = model.ManageMan;
            parameters[5].Value = model.F_Stop;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.WhCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
