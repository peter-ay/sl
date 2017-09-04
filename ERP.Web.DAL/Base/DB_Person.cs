using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;


namespace ERP.Web.DAL
{
    public partial class DB_Person : DALBase
    {
        public DB_Person()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Person with (nolock)");
            strSql.Append(" where PersonCode=@PersonCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonCode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "PersonCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Person;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Person(");
            strSql.Append("PersonCode,PersonName,DpCode,PersonProperty)");
            strSql.Append(" values (");
            strSql.Append("@PersonCode,@PersonName,@DpCode,@PersonProperty)");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonCode", SqlDbType.NVarChar,10),
					new SqlParameter("@PersonName", SqlDbType.VarChar,30),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@PersonProperty", SqlDbType.VarChar,30)};
            parameters[0].Value = model.PersonCode;
            parameters[1].Value = model.PersonName;
            parameters[2].Value = model.DpCode;
            parameters[3].Value = model.PersonProperty;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Person;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Person set ");
            strSql.Append("PersonName=@PersonName,");
            strSql.Append("DpCode=@DpCode,");
            strSql.Append("PersonProperty=@PersonProperty");
            strSql.Append(" where PersonCode=@PersonCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonName", SqlDbType.VarChar,30),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@PersonProperty", SqlDbType.VarChar,30),
					new SqlParameter("@PersonCode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.PersonName;
            parameters[1].Value = model.DpCode;
            parameters[2].Value = model.PersonProperty;
            parameters[3].Value = model.PersonCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
