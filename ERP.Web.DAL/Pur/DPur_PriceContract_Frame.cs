using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DPur_PriceContract_Frame : DALBase
    {
        public DPur_PriceContract_Frame()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pur_PriceContract_Frame with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MPur_PriceContract_Frame;
            StringBuilder strSql = new StringBuilder();
            //////////////////////////////////////////
            strSql.Append("delete Pur_PriceContract_Frame ");
            strSql.Append("where BID=@BID and FrameCode=@FrameCode ;");
            /////////////////////////////////////////
            strSql.Append("insert into Pur_PriceContract_Frame(");
            strSql.Append("ID,BID,FrameCode,Price,InvTitle)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@FrameCode,@Price,@InvTitle)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BID;
            parameters[2].Value = model.FrameCode;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.InvTitle;
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
