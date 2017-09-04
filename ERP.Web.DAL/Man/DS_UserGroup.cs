using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DS_UserGroup : DALBase
    {
        public DS_UserGroup()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_UserGroup with (nolock)");
            strSql.Append(" where GpCode=@GpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@GpCode", SqlDbType.NVarChar,7)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "GpCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MS_UserGroup;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_UserGroup(");
            strSql.Append("GpCode,GpName,GpExplain,GpID,DBCode,F_RBCusCode,F_RBWhCode,F_RUWhCode,F_RBDpCode,F_RBSpCode)");
            strSql.Append(" values (");
            strSql.Append("@GpCode,@GpName,@GpExplain,@GpID,@DBCode,@F_RBCusCode,@F_RBWhCode,@F_RUWhCode,@F_RBDpCode,@F_RBSpCode);");
            //////////////////////Get GpID////////////////
            //strSql.Append("update S_UserGroup set ");
            //strSql.Append("GpID=HKOERP.dbo.SF_GetGpIDMapping(@GpCode)");
            //strSql.Append(" where GpCode=@GpCode; ");
            //////////////////////Check GpID//////////////// 
            //strSql.Append("if exists(select * from S_UserGroup A1 with(nolock) where A1.GpCode=@GpCode and isnull(A1.GpID,-1)=-1) ");
            //strSql.Append("raiserror('GpID',16,1)");
            SqlParameter[] parameters = {
					new SqlParameter("@GpCode", SqlDbType.VarChar,10),
					new SqlParameter("@GpName", SqlDbType.NVarChar,30),
					new SqlParameter("@GpExplain", SqlDbType.NVarChar,50),
					new SqlParameter("@GpID", SqlDbType.Int,4),
					new SqlParameter("@DBCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_RBCusCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBWhCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RUWhCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBDpCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBSpCode", SqlDbType.Bit,1)};
            parameters[0].Value = model.GpCode;
            parameters[1].Value = model.GpName;
            parameters[2].Value = model.GpExplain;
            parameters[3].Value = model.GpID;
            parameters[4].Value = model.DBCode;
            parameters[5].Value = model.F_RBCusCode;
            parameters[6].Value = model.F_RBWhCode;
            parameters[7].Value = model.F_RUWhCode;
            parameters[8].Value = model.F_RBDpCode;
            parameters[9].Value = model.F_RBSpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MS_UserGroup;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_UserGroup set ");
            strSql.Append("GpName=@GpName,");
            strSql.Append("GpExplain=@GpExplain,");
            //strSql.Append("GpID=@GpID,");
            strSql.Append("DBCode=@DBCode,");
            strSql.Append("F_RBCusCode=@F_RBCusCode,");
            strSql.Append("F_RBWhCode=@F_RBWhCode,");
            strSql.Append("F_RUWhCode=@F_RUWhCode,");
            strSql.Append("F_RBDpCode=@F_RBDpCode,");
            strSql.Append("F_RBSpCode=@F_RBSpCode");
            strSql.Append(" where GpCode=@GpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@GpName", SqlDbType.NVarChar,30),
					new SqlParameter("@GpExplain", SqlDbType.NVarChar,50),
                    //new SqlParameter("@GpID", SqlDbType.Int,4),
					new SqlParameter("@DBCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_RBCusCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBWhCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RUWhCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBDpCode", SqlDbType.Bit,1),
					new SqlParameter("@F_RBSpCode", SqlDbType.Bit,1),
					new SqlParameter("@GpCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.GpName;
            parameters[1].Value = model.GpExplain;
            //parameters[2].Value = model.GpID;
            parameters[2].Value = model.DBCode;
            parameters[3].Value = model.F_RBCusCode;
            parameters[4].Value = model.F_RBWhCode;
            parameters[5].Value = model.F_RUWhCode;
            parameters[6].Value = model.F_RBDpCode;
            parameters[7].Value = model.F_RBSpCode;
            parameters[8].Value = model.GpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
