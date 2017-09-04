using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Department : DALBase
    {
        public DB_Department()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Department with (nolock)");
            strSql.Append(" where DpCode=@DpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DpCode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "DpCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Department;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select @BrowseRight;");
            /////////////////////////////////////////////////////////////
            strSql.Append("insert into B_Department(");
            strSql.Append("DpCode,DpName,PCode,DpProperty,Incharge,Tel,DpAddress,Remark,BrowseRight,F_CX)");
            strSql.Append(" values (");
            strSql.Append("@DpCode,@DpName,@PCode,@DpProperty,@Incharge,@Tel,@DpAddress,@Remark,@BrowseRight,@F_CX)");
            SqlParameter[] parameters = {
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
            parameters[0].Value = model.DpCode;
            parameters[1].Value = model.DpName;
            parameters[2].Value = model.PCode;
            parameters[3].Value = model.DpProperty;
            parameters[4].Value = model.Incharge;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.DpAddress;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.BrowseRight;
            parameters[9].Value = model.F_CX;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Department;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Department set ");
            strSql.Append("DpName=@DpName,");
            strSql.Append("PCode=@PCode,");
            strSql.Append("DpProperty=@DpProperty,");
            strSql.Append("Incharge=@Incharge,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("DpAddress=@DpAddress,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("BrowseRight=@BrowseRight,");
            strSql.Append("F_CX=@F_CX");
            strSql.Append(" where DpCode=@DpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DpName", SqlDbType.NVarChar,30),
					new SqlParameter("@PCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpProperty", SqlDbType.NVarChar,30),
					new SqlParameter("@Incharge", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@DpAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000),
					new SqlParameter("@F_CX", SqlDbType.Bit,1),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.DpName;
            parameters[1].Value = model.PCode;
            parameters[2].Value = model.DpProperty;
            parameters[3].Value = model.Incharge;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.DpAddress;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.BrowseRight;
            parameters[8].Value = model.F_CX;
            parameters[9].Value = model.DpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
