using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Customer_Main : DALBase
    {
        public DB_Customer_Main()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Customer_Main with (nolock)");
            strSql.Append(" where MainCusCode=@MainCusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@MainCusCode", SqlDbType.NVarChar,50)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "MainCusCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer_Main;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Customer_Main(");
            strSql.Append("MainCusCode,MainCusName)");
            strSql.Append(" values (");
            strSql.Append("@MainCusCode,@MainCusName)");
            SqlParameter[] parameters = {
					new SqlParameter("@MainCusCode", SqlDbType.VarChar,20),
					new SqlParameter("@MainCusName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.MainCusCode;
            parameters[1].Value = model.MainCusName;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer_Main;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Customer_Main set ");
            strSql.Append("MainCusName=@MainCusName");
            strSql.Append(" where MainCusCode=@MainCusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@MainCusName", SqlDbType.NVarChar,100),
					new SqlParameter("@MainCusCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.MainCusName;
            parameters[1].Value = model.MainCusCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
