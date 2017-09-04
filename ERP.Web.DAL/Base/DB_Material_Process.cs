using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;


namespace ERP.Web.DAL
{
    public partial class DB_Material_Process : DALBase
    {
        public DB_Material_Process()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Material_Process with (nolock)");
            strSql.Append(" where ProCode=@ProCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProCode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "ProCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Material_Process;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Material_Process(");
            strSql.Append("ProCode,ProName,ProClass,F_RX,F_ST)");
            strSql.Append(" values (");
            strSql.Append("@ProCode,@ProName,@ProClass,@F_RX,@F_ST)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProCode", SqlDbType.VarChar,20),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProClass", SqlDbType.VarChar,10),
					new SqlParameter("@F_RX", SqlDbType.Bit,1),
					new SqlParameter("@F_ST", SqlDbType.Bit,1)};
            parameters[0].Value = model.ProCode;
            parameters[1].Value = model.ProName;
            parameters[2].Value = model.ProClass;
            parameters[3].Value = model.F_RX;
            parameters[4].Value = model.F_ST;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Material_Process;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Material_Process set ");
            strSql.Append("ProName=@ProName,");
            strSql.Append("ProClass=@ProClass,");
            strSql.Append("F_RX=@F_RX,");
            strSql.Append("F_ST=@F_ST");
            strSql.Append(" where ProCode=@ProCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProClass", SqlDbType.VarChar,10),
					new SqlParameter("@F_RX", SqlDbType.Bit,1),
					new SqlParameter("@F_ST", SqlDbType.Bit,1),
					new SqlParameter("@ProCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ProName;
            parameters[1].Value = model.ProClass;
            parameters[2].Value = model.F_RX;
            parameters[3].Value = model.F_ST;
            parameters[4].Value = model.ProCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
