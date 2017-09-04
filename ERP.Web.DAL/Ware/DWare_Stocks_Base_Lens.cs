using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;
using System.Collections;
using ERP.Web.Common;
using ERP.Web.DBUtility;

namespace ERP.Web.DAL
{
    public partial class DWare_Stocks_Base_Lens : DALBase
    {
        public DWare_Stocks_Base_Lens()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ware_Stocks_Base_Lens A1 with (nolock)");
            strSql.Append(" where A1.WhCode+A1.LensCode+A1.F_LR=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Stocks_Base_Lens model = t as MWare_Stocks_Base_Lens;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Stocks_Base_Lens(");
            strSql.Append("ID,BCode,WhCode,LensCode,F_LR,BDate,BType,Maker,MName,MDate,Checker,ChName,ChDate,StCode,Remark,SumQty,F_Del,Deler,DelName,DelDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@WhCode,@LensCode,@F_LR,@BDate,@BType,@Maker,@MName,@MDate,@Checker,@ChName,@ChDate,@StCode,@Remark,@SumQty,@F_Del,@Deler,@DelName,@DelDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,30),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,10),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@Checker", SqlDbType.NVarChar,10),
					new SqlParameter("@ChName", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDate", SqlDbType.DateTime),
					new SqlParameter("@StCode", SqlDbType.VarChar,6),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@SumQty", SqlDbType.Int,4),
					new SqlParameter("@F_Del", SqlDbType.Bit,1),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.WhCode;
            parameters[3].Value = model.LensCode;
            parameters[4].Value = model.F_LR;
            parameters[5].Value = model.BDate;
            parameters[6].Value = model.BType;
            parameters[7].Value = model.Maker;
            parameters[8].Value = model.MName;
            parameters[9].Value = System.DateTime.Now;//model.MDate;
            parameters[10].Value = "";//model.Checker;
            parameters[11].Value = "";//model.ChName;
            parameters[12].Value = System.DBNull.Value;//model.ChDate;
            parameters[13].Value = model.StCode;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.SumQty;
            parameters[16].Value = 0;// model.F_Del;
            parameters[17].Value = "";//model.Deler;
            parameters[18].Value = "";// model.DelName;
            parameters[19].Value = System.DBNull.Value;// model.DelDate;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Stocks_Base_Lens model = t as MWare_Stocks_Base_Lens;
            this.PrepareDetail(lgIndex, cmd, model);
        }

        private void PrepareDetail(int lgIndex, SqlCommand cmd, MWare_Stocks_Base_Lens model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            ///////////////////////////////////////////////////////////////////////////////////////
            foreach (var model_Detail in model.Sub_Detail)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Stocks_Base_Lens_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model_Detail.SubID;
                parameters[2].Value = model_Detail.SPH;
                parameters[3].Value = model_Detail.CYL;
                parameters[4].Value = model_Detail.X_ADD;
                parameters[5].Value = model_Detail.Qty;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Stocks_Base_Lens;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Stocks_Base_Lens set ");
            strSql.Append("WhCode=@WhCode,");
            strSql.Append("LensCode=@LensCode,");
            strSql.Append("F_LR=@F_LR,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("SumQty=@SumQty");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
                    new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@SumQty", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.WhCode;
            parameters[1].Value = model.LensCode;
            parameters[2].Value = model.F_LR;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.SumQty;
            parameters[5].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Stocks_Base_Lens;
            this.UpdateDetail(lgIndex, cmd, model);
            //this.PrepareSaveVerify(lgIndex, cmd, model);
        }

        private void UpdateDetail(int lgIndex, SqlCommand cmd, MWare_Stocks_Base_Lens model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            ///////////////////////////////////////////////////////////////////////////////////////
            strSql.Clear();
            strSql.Append("delete Ware_Stocks_Base_Lens_Detail");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var model_Detail in model.Sub_Detail)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Stocks_Base_Lens_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model_Detail.SubID;
                parameters[2].Value = model_Detail.SPH;
                parameters[3].Value = model_Detail.CYL;
                parameters[4].Value = model_Detail.X_ADD;
                parameters[5].Value = model_Detail.Qty;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Stocks_Base_Lens;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Stocks_Base_Lens set ");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = { 
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.Remark;
            parameters[1].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }
    }
}
