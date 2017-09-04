using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DSale_PriceContract_FrameSet : DALBase
    {
        public DSale_PriceContract_FrameSet()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sale_PriceContract_FrameSet with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        } 

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_PriceContract_FrameSet;
            StringBuilder strSql = new StringBuilder();
            //////////////////////////////////////////
            strSql.Append("delete Sale_PriceContract_FrameSet ");
            strSql.Append("where BID=@BID and FrameCode=@FrameCode and FQty=@FQty ");
            strSql.Append("and LensCode=@LensCode and LQty=@LQty ;");
            /////////////////////////////////////////
            strSql.Append("insert into Sale_PriceContract_FrameSet(");
            strSql.Append("ID,BID,FrameCode,FQty,LensCode,LQty,Price,Price_ProCost,PriceJM,Price_ProCostJM,InvTitle)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@FrameCode,@FQty,@LensCode,@LQty,@Price,@Price_ProCost,@PriceJM,@Price_ProCostJM,@InvTitle)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
					new SqlParameter("@FQty", SqlDbType.Int,4),
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@LQty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Price_ProCost", SqlDbType.Decimal,9),
                    new SqlParameter("@PriceJM", SqlDbType.Decimal,9),
					new SqlParameter("@Price_ProCostJM", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BID;
            parameters[2].Value = model.FrameCode;
            parameters[3].Value = model.FQty;
            parameters[4].Value = model.LensCode;
            parameters[5].Value = model.LQty;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Price_ProCost;
            parameters[8].Value = model.PriceJM;
            parameters[9].Value = model.Price_ProCostJM;
            parameters[10].Value = model.InvTitle;
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
