using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DPur_PriceContract_SpGroup : DALBase
    {
        public DPur_PriceContract_SpGroup()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pur_PriceContract_SpGroup with (nolock)");
            strSql.Append(" where GpCode=@GpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@GpCode", SqlDbType.VarChar,10)			};
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
            var model = t as MPur_PriceContract_SpGroup;
            StringBuilder strSql = new StringBuilder();
            /////////////////////////////////////////
            strSql.Append("insert into Pur_PriceContract_SpGroup(");
            strSql.Append("GpCode,GpName)");
            strSql.Append(" values (");
            strSql.Append("@GpCode,@GpName)");
            SqlParameter[] parameters = {
					new SqlParameter("@GpCode", SqlDbType.VarChar,20),
					new SqlParameter("@GpName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.GpCode;
            parameters[1].Value = model.GpName;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MPur_PriceContract_SpGroup;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pur_PriceContract_SpGroup set ");
            strSql.Append("GpName=@GpName");
            strSql.Append(" where GpCode=@GpCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@GpName", SqlDbType.NVarChar,50),
					new SqlParameter("@GpCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.GpName;
            parameters[1].Value = model.GpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
