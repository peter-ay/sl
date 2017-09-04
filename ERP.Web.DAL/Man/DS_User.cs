using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DS_User : DALBase
    {
        public DS_User()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_User with (nolock)");
            strSql.Append(" where UserCode=@UserCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserCode", SqlDbType.NVarChar,7)};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "UserCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MS_User;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select @UserRight ;");/////////////////HKOERP.dbo.SF_GetRightDefaultValue()
            /////////////////////////////////////////////////////////
            strSql.Append("insert into S_User(");
            strSql.Append("UserCode,UserName,UserExplain,UserPassword,UserRight,MakeDate,F_Admin,F_Super,F_Stop,LastLoginDate,LoginDate,UserImage)");
            strSql.Append(" values (");
            strSql.Append("@UserCode,@UserName,@UserExplain,@UserPassword,HKOERP.dbo.SF_GetRightDefaultValue(),@MakeDate,@F_Admin,@F_Super,@F_Stop,@LastLoginDate,@LoginDate,@UserImage)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.NVarChar,7),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserExplain", SqlDbType.NVarChar,200),
					new SqlParameter("@UserPassword", SqlDbType.NVarChar,200),
					new SqlParameter("@UserRight", SqlDbType.NVarChar,1000),
					new SqlParameter("@MakeDate", SqlDbType.Date,3),
					new SqlParameter("@F_Admin", SqlDbType.Bit,1),
                    new SqlParameter("@F_Super", SqlDbType.Bit,1),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LoginDate", SqlDbType.DateTime),
					new SqlParameter("@UserImage", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserExplain;
            parameters[3].Value = model.UserPassword;
            parameters[4].Value = "";
            parameters[5].Value = System.DateTime.Now;
            parameters[6].Value = false;
            parameters[7].Value = false;
            parameters[8].Value = model.F_Stop;
            parameters[9].Value = model.LastLoginDate > Convert.ToDateTime("2000-1-1") ? model.LastLoginDate : Convert.ToDateTime("2000-1-1");
            parameters[10].Value = model.LoginDate > Convert.ToDateTime("2000-1-1") ? model.LoginDate : Convert.ToDateTime("2000-1-1");
            parameters[11].Value = model.UserImage;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MS_User;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserExplain=@UserExplain,");
            strSql.Append("F_Stop=@F_Stop");
            strSql.Append(" where UserCode=@UserCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserExplain", SqlDbType.NVarChar,200), 
					new SqlParameter("@F_Stop", SqlDbType.Bit,1), 
					new SqlParameter("@UserCode", SqlDbType.NVarChar,7)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserExplain;
            parameters[2].Value = model.F_Stop;
            parameters[3].Value = model.UserCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
