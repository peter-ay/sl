using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Customer_Acc : DALBase
    {
        public DB_Customer_Acc()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Customer_Acc");
            strSql.Append(" where AccCusCode=@AccCusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@AccCusCode", SqlDbType.VarChar,20)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "AccCusCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer_Acc;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Customer_Acc(");
            strSql.Append("AccCusCode,AccCusName,AccEndDate,AccLimit,PCode)");
            strSql.Append(" values (");
            strSql.Append("@AccCusCode,@AccCusName,@AccEndDate,@AccLimit,@PCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@AccCusCode", SqlDbType.VarChar,20),
					new SqlParameter("@AccCusName", SqlDbType.NVarChar,100),
					new SqlParameter("@AccEndDate", SqlDbType.Int,4),
					new SqlParameter("@AccLimit", SqlDbType.Decimal,9),
					new SqlParameter("@PCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.AccCusCode;
            parameters[1].Value = model.AccCusName;
            parameters[2].Value = model.AccEndDate;
            parameters[3].Value = model.AccLimit;
            parameters[4].Value = model.PCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer_Acc;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Customer_Acc set ");
            strSql.Append("AccCusName=@AccCusName,");
            strSql.Append("AccEndDate=@AccEndDate,");
            strSql.Append("AccLimit=@AccLimit,");
            strSql.Append("PCode=@PCode");
            strSql.Append(" where AccCusCode=@AccCusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@AccCusName", SqlDbType.NVarChar,100),
					new SqlParameter("@AccEndDate", SqlDbType.Int,4),
					new SqlParameter("@AccLimit", SqlDbType.Decimal,9),
					new SqlParameter("@PCode", SqlDbType.VarChar,20),
					new SqlParameter("@AccCusCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.AccCusName;
            parameters[1].Value = model.AccEndDate;
            parameters[2].Value = model.AccLimit;
            parameters[3].Value = model.PCode;
            parameters[4].Value = model.AccCusCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
