using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DS_Log : DALBase
    {
        public DS_Log()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return false;
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MS_Log model = t as MS_Log;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Log ");
            strSql.Append("where LogTime<=DATEADD(mm,-1,GETDATE());");
            strSql.Append("insert into S_Log(");
            strSql.Append("ID,LogTime,FunCode,UserCode,DBCode,IP,ClientID)");
            strSql.Append(" values (");
            strSql.Append("@ID,@LogTime,@FunCode,@UserCode,@DBCode,@IP,@ClientID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@FunCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@DBCode", SqlDbType.VarChar,50),
					new SqlParameter("@IP", SqlDbType.VarChar,50),
					new SqlParameter("@ClientID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = model.FunCode;
            parameters[3].Value = model.UserCode;
            parameters[4].Value = model.DBCode;
            parameters[5].Value = model.IP;
            parameters[6].Value = model.ClientID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {

        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
