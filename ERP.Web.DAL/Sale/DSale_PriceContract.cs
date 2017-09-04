using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;
using ERP.Web.DBUtility;

namespace ERP.Web.DAL
{
    public partial class DSale_PriceContract : DALBase
    {
        public DSale_PriceContract()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sale_PriceContract with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MSale_PriceContract model = t as MSale_PriceContract;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sale_PriceContract(");
            strSql.Append("ID,BCode,OBCode,BDate,BType,PriCode,StCode,BegDate,EndDate,CusGroup,Remark,Maker,MName,MDate,Checker,ChName,ChDate,F_Del,Deler,DelName,DelDate,GpNameNew)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@OBCode,@BDate,@BType,@PriCode,@StCode,@BegDate,@EndDate,@CusGroup,@Remark,@Maker,@MName,@MDate,@Checker,@ChName,@ChDate,@F_Del,@Deler,@DelName,@DelDate,@GpNameNew)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,30),
					new SqlParameter("@OBCode", SqlDbType.VarChar,30),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,6),
					new SqlParameter("@PriCode", SqlDbType.TinyInt,1),
					new SqlParameter("@StCode", SqlDbType.VarChar,6),
					new SqlParameter("@BegDate", SqlDbType.Date,3),
					new SqlParameter("@EndDate", SqlDbType.Date,3),
					new SqlParameter("@CusGroup", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@Checker", SqlDbType.VarChar,10),
					new SqlParameter("@ChName", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDate", SqlDbType.DateTime),
					new SqlParameter("@F_Del", SqlDbType.Bit,1),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime),
					new SqlParameter("@GpNameNew", SqlDbType.VarChar,30)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.OBCode;
            parameters[3].Value = model.BDate;
            parameters[4].Value = model.BType;
            parameters[5].Value = model.PriCode;
            parameters[6].Value = model.StCode;
            parameters[7].Value = model.BegDate;
            parameters[8].Value = model.EndDate;
            parameters[9].Value = model.CusGroup;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Maker;
            parameters[12].Value = model.MName;
            parameters[13].Value = System.DateTime.Now;
            parameters[14].Value = "";
            parameters[15].Value = "";
            parameters[16].Value = System.DBNull.Value;
            parameters[17].Value = 0;
            parameters[18].Value = "";
            parameters[19].Value = "";
            parameters[20].Value = System.DBNull.Value;
            parameters[21].Value = model.GpNameNew;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //this.PrepareSaveVerify(lgIndex, cmd, model);
        }

        private void PrepareSaveVerify(int lgIndex, SqlCommand cmd, MSale_PriceContract model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append("SP_Sale_PriceContract_SaveVerify");
            parameters = new SqlParameter[] {
					new SqlParameter("@LgIndex", SqlDbType.Int),
                    new SqlParameter("@PKCode", SqlDbType.VarChar,25)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = model.ID;
            cmd.ExecuteMySPQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_PriceContract;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_PriceContract set ");
            strSql.Append("OBCode=@OBCode,");
            strSql.Append("PriCode=@PriCode,");
            strSql.Append("BegDate=@BegDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("CusGroup=@CusGroup,");
            strSql.Append("Remark=@Remark ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OBCode", SqlDbType.VarChar,30),
					new SqlParameter("@PriCode", SqlDbType.TinyInt,1),
					new SqlParameter("@BegDate", SqlDbType.Date,3),
					new SqlParameter("@EndDate", SqlDbType.Date,3),
					new SqlParameter("@CusGroup", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.OBCode;
            parameters[1].Value = model.PriCode;
            parameters[2].Value = model.BegDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.CusGroup;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //this.PrepareSaveVerify(lgIndex, cmd, model);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_PriceContract;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_PriceContract set ");
            strSql.Append("OBCode=@OBCode,");
            strSql.Append("Remark=@Remark ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OBCode", SqlDbType.VarChar,30),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.OBCode;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }
    }
}
