using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public class DWare
    {
        #region Exists

        public bool Exists(string dbCode, int lgIndex, string table, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + table + " with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        #endregion

        #region Add

        public void AddWare_Bill(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill(");
            strSql.Append("ID,BCode,BDate,BType,FBCode,F_IO,MType,F_SD,WhCode,CusCode,SpCode,Remark,Maker,MName,BarCodeSOPre,BarCodeR,BarCodeL)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@BDate,@BType,@FBCode,@F_IO,@MType,@F_SD,@WhCode,@CusCode,@SpCode,@Remark,@Maker,@MName,@BarCodeSOPre,@BarCodeR,@BarCodeL)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,30),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,10),
					new SqlParameter("@FBCode", SqlDbType.VarChar,50),
					new SqlParameter("@F_IO", SqlDbType.Bit,1),
					new SqlParameter("@MType", SqlDbType.VarChar,10),
					new SqlParameter("@F_SD", SqlDbType.Bit,1),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
					new SqlParameter("@SpCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@BarCodeSOPre", SqlDbType.VarChar,25),
					new SqlParameter("@BarCodeR", SqlDbType.VarChar,25),
					new SqlParameter("@BarCodeL", SqlDbType.VarChar,25)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.BDate;
            parameters[3].Value = model.BType;
            parameters[4].Value = model.FBCode;
            parameters[5].Value = model.F_IO;
            parameters[6].Value = model.MType;
            parameters[7].Value = model.F_SD;
            parameters[8].Value = model.WhCode;
            parameters[9].Value = model.CusCode ?? "";
            parameters[10].Value = model.SpCode ?? "";
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.Maker;
            parameters[13].Value = model.MName;
            parameters[14].Value = model.BarCodeSOPre ?? "";
            parameters[15].Value = model.BarCodeR ?? "";
            parameters[16].Value = model.BarCodeL ?? "";
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //
            strSql.Clear();
            strSql.Append("insert into Ware_Bill_ADD(");
            strSql.Append("ID,StCode,MDate,Checker,ChName,ChDate,Deler,DelName,DelDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@StCode,@MDate,@Checker,@ChName,@ChDate,@Deler,@DelName,@DelDate)");
            parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@StCode", SqlDbType.VarChar,10),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@Checker", SqlDbType.VarChar,10),
					new SqlParameter("@ChName", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDate", SqlDbType.DateTime),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = "DSH";// model.StCode;
            parameters[2].Value = System.DateTime.Now;// model.MDate;
            parameters[3].Value = "";// model.Checker;
            parameters[4].Value = "";// model.ChName;
            parameters[5].Value = System.DBNull.Value;// model.ChDate;
            parameters[6].Value = "";// model.Deler;
            parameters[7].Value = "";//model.DelName;
            parameters[8].Value = System.DBNull.Value;//model.DelDate;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddWare_Bill_Transfer(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill_Transfer(");
            strSql.Append("ID,BCode,BDate,BType,MType,StCode,WhCodeIn,WhCodeOut,Remark,Maker,MName,MDate,F_Chk,CheckerIn,ChNameIn,ChDateIn,CheckerOut,ChNameOut,ChDateOut,F_Del,Deler,DelName,DelDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@BDate,@BType,@MType,@StCode,@WhCodeIn,@WhCodeOut,@Remark,@Maker,@MName,@MDate,@F_Chk,@CheckerIn,@ChNameIn,@ChDateIn,@CheckerOut,@ChNameOut,@ChDateOut,@F_Del,@Deler,@DelName,@DelDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,30),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,10),
					new SqlParameter("@MType", SqlDbType.VarChar,10),
					new SqlParameter("@StCode", SqlDbType.VarChar,10),
					new SqlParameter("@WhCodeIn", SqlDbType.VarChar,10),
					new SqlParameter("@WhCodeOut", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@F_Chk", SqlDbType.Bit,1),
					new SqlParameter("@CheckerIn", SqlDbType.VarChar,10),
					new SqlParameter("@ChNameIn", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDateIn", SqlDbType.DateTime),
					new SqlParameter("@CheckerOut", SqlDbType.VarChar,10),
					new SqlParameter("@ChNameOut", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDateOut", SqlDbType.DateTime),
					new SqlParameter("@F_Del", SqlDbType.Bit,1),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.BDate;
            parameters[3].Value = model.BType;
            parameters[4].Value = model.MType;
            parameters[5].Value = model.StCode;
            parameters[6].Value = model.WhCodeIn;
            parameters[7].Value = model.WhCodeOut;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Maker;
            parameters[10].Value = model.MName;
            parameters[11].Value = System.DateTime.Now;//model.MDate;
            parameters[12].Value = false;//model.F_Chk;
            parameters[13].Value = "";//model.CheckerIn;
            parameters[14].Value = "";//model.ChNameIn;
            parameters[15].Value = System.DBNull.Value;//model.ChDateIn;
            parameters[16].Value = "";//model.CheckerOut;
            parameters[17].Value = "";//model.ChNameOut;
            parameters[18].Value = System.DBNull.Value;//model.ChDateOut;
            parameters[19].Value = false;//model.F_Del;
            parameters[20].Value = "";//model.Deler;
            parameters[21].Value = "";// model.DelName;
            parameters[22].Value = System.DBNull.Value;//model.DelDate;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddWare_Bill_Count(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill_Count(");
            strSql.Append("ID,BCode,BDate,BType,MType,StCode,WhCode,FBCode,Remark,KJYear,Period,Maker,MName,MDate,Starter,StartName,StartTime,Ender,EndName,EndTime,F_Del,Deler,DelName,DelDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@BDate,@BType,@MType,@StCode,@WhCode,@FBCode,@Remark,@KJYear,@Period,@Maker,@MName,@MDate,@Starter,@StartName,@StartTime,@Ender,@EndName,@EndTime,@F_Del,@Deler,@DelName,@DelDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,30),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,10),
					new SqlParameter("@MType", SqlDbType.VarChar,10),
					new SqlParameter("@StCode", SqlDbType.VarChar,10),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@FBCode", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@KJYear", SqlDbType.Int,4),
					new SqlParameter("@Period", SqlDbType.Int,4),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@Starter", SqlDbType.VarChar,10),
					new SqlParameter("@StartName", SqlDbType.NVarChar,30),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Ender", SqlDbType.VarChar,10),
					new SqlParameter("@EndName", SqlDbType.NVarChar,30),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@F_Del", SqlDbType.Bit,1),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.BDate;
            parameters[3].Value = model.BType;
            parameters[4].Value = model.MType;
            parameters[5].Value = model.StCode;
            parameters[6].Value = model.WhCode;
            parameters[7].Value = model.FBCode;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.KJYear;
            parameters[10].Value = model.Period;
            parameters[11].Value = model.Maker;
            parameters[12].Value = model.MName;
            parameters[13].Value = System.DateTime.Now;//model.MDate;
            parameters[14].Value = "";//model.Starter;
            parameters[15].Value = ""; //model.StartName;
            parameters[16].Value = System.DBNull.Value;// model.StartTime;
            parameters[17].Value = "";//model.Ender;
            parameters[18].Value = "";//model.EndName;
            parameters[19].Value = System.DBNull.Value;//model.EndTime;
            parameters[20].Value = false;// model.F_Del;
            parameters[21].Value = "";// model.Deler;
            parameters[22].Value = ""; //model.DelName;
            parameters[23].Value = System.DBNull.Value;//model.DelDate;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddWare_Bill_SD(int lgIndex, SqlCommand cmd, List<MWare_Bill_SD> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelSD in modelList)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Bill_SD(");
                strSql.Append("ID,F_LR,LensCode,SPH,CYL,X_ADD,Qty,Price,ProCost)");
                strSql.Append(" values (");
                strSql.Append("@ID,@F_LR,@LensCode,@SPH,@CYL,@X_ADD,@Qty,@Price,@ProCost)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@ProCost", SqlDbType.Decimal,9)};
                parameters[0].Value = modelSD.ID;
                parameters[1].Value = modelSD.F_LR;
                parameters[2].Value = modelSD.LensCode;
                parameters[3].Value = modelSD.SPH;
                parameters[4].Value = modelSD.CYL;
                parameters[5].Value = modelSD.X_ADD;
                parameters[6].Value = modelSD.Qty;
                parameters[7].Value = modelSD.Price;
                parameters[8].Value = modelSD.ProCost;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void AddWare_Bill_PD(int lgIndex, SqlCommand cmd, MWare_Bill_PD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill_PD(");
            strSql.Append("ID,LensCode,F_LR)");
            strSql.Append(" values (");
            strSql.Append("@ID,@LensCode,@F_LR)");
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LensCode;
            parameters[2].Value = model.F_LR;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddWare_Bill_PD_Detail(int lgIndex, SqlCommand cmd, List<MWare_Bill_PD_Detail> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelPD_Detail in modelList)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Bill_PD_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@Price)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = modelPD_Detail.ID;
                parameters[1].Value = modelPD_Detail.SubID;
                parameters[2].Value = modelPD_Detail.SPH;
                parameters[3].Value = modelPD_Detail.CYL;
                parameters[4].Value = modelPD_Detail.X_ADD;
                parameters[5].Value = modelPD_Detail.Qty;
                parameters[6].Value = modelPD_Detail.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void AddWare_Bill_Count_PD_Detail2(int lgIndex, SqlCommand cmd, List<MWare_Bill_Count_PD_Detail2> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelPD_Detail in modelList)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Bill_Count_PD_Detail2(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@Price)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = modelPD_Detail.ID;
                parameters[1].Value = modelPD_Detail.SubID;
                parameters[2].Value = modelPD_Detail.SPH;
                parameters[3].Value = modelPD_Detail.CYL;
                parameters[4].Value = modelPD_Detail.X_ADD;
                parameters[5].Value = modelPD_Detail.Qty;
                parameters[6].Value = modelPD_Detail.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void AddWare_Bill_Extend(int lgIndex, SqlCommand cmd, MWare_Bill_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill_Extend(");
            strSql.Append("ID,SCode,SumQty,SumMoney,LensCodeR,LensCodeL,SPHR,SPHL,CYLR,CYLL,X_ADDR,X_ADDL,QtyR,QtyL,PriceR,PriceL,ProCostR,ProCostL)");
            strSql.Append(" values (");
            strSql.Append("@ID,@SCode,@SumQty,@SumMoney,@LensCodeR,@LensCodeL,@SPHR,@SPHL,@CYLR,@CYLL,@X_ADDR,@X_ADDL,@QtyR,@QtyL,@PriceR,@PriceL,@ProCostR,@ProCostL)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SCode", SqlDbType.VarChar,200),
					new SqlParameter("@SumQty", SqlDbType.Int,4),
                    new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeL", SqlDbType.VarChar,50),
					new SqlParameter("@SPHR", SqlDbType.Int,4),
					new SqlParameter("@SPHL", SqlDbType.Int,4),
					new SqlParameter("@CYLR", SqlDbType.Int,4),
					new SqlParameter("@CYLL", SqlDbType.Int,4),
					new SqlParameter("@X_ADDR", SqlDbType.Int,4),
					new SqlParameter("@X_ADDL", SqlDbType.Int,4),
					new SqlParameter("@QtyR", SqlDbType.Int,4),
					new SqlParameter("@QtyL", SqlDbType.Int,4),
					new SqlParameter("@PriceR", SqlDbType.Decimal,9),
					new SqlParameter("@PriceL", SqlDbType.Decimal,9),
					new SqlParameter("@ProCostR", SqlDbType.Decimal,9),
					new SqlParameter("@ProCostL", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SCode;
            parameters[2].Value = model.SumQty;
            parameters[3].Value = model.SumMoney;
            parameters[4].Value = model.LensCodeR;
            parameters[5].Value = model.LensCodeL;
            parameters[6].Value = model.SPHR;
            parameters[7].Value = model.SPHL;
            parameters[8].Value = model.CYLR;
            parameters[9].Value = model.CYLL;
            parameters[10].Value = model.X_ADDR;
            parameters[11].Value = model.X_ADDL;
            parameters[12].Value = model.QtyR;
            parameters[13].Value = model.QtyL;
            parameters[14].Value = model.PriceR;
            parameters[15].Value = model.PriceL;
            parameters[16].Value = model.ProCostR;
            parameters[17].Value = model.ProCostL;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddWare_Bill_Count_Extend(int lgIndex, SqlCommand cmd, MWare_Bill_Count_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ware_Bill_Count_Extend(");
            strSql.Append("ID,SumQty1,SumQty2,SumQty)");
            strSql.Append(" values (");
            strSql.Append("@ID,@SumQty1,@SumQty2,@SumQty)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SumQty1", SqlDbType.Int,4),
					new SqlParameter("@SumQty2", SqlDbType.Int,4),
					new SqlParameter("@SumQty", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SumQty1;
            parameters[2].Value = model.SumQty2;
            parameters[3].Value = model.SumQty;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        #endregion

        #region Edit

        public void UpdateWare_Bill(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters;
            /////////////////修改,撤销预扣//////////////////////////////
            //strSql.Append("SP_Ware_Bill_EditVerify");
            //parameters = new SqlParameter[] {
            //        new SqlParameter("@LgIndex", SqlDbType.Int),
            //        new SqlParameter("@PKCode", SqlDbType.VarChar,25)};
            //parameters[0].Value = lgIndex;
            //parameters[1].Value = model.ID;
            //cmd.ExecuteMySPQuery(strSql.ToString(), parameters);
            /////////////////////////////////////////////////////////////////
            strSql.Clear();
            strSql.Append("update Ware_Bill set ");
            strSql.Append("CusCode=@CusCode,");
            strSql.Append("SpCode=@SpCode,");
            strSql.Append("WhCode=@WhCode,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[] {
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
                    new SqlParameter("@SpCode", SqlDbType.VarChar,10),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.CusCode ?? "";
            parameters[1].Value = model.SpCode ?? "";
            parameters[2].Value = model.WhCode;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateWare_Bill_Transfer(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters;
            /////////////////修改,撤销预扣//////////////////////////////
            strSql.Append("SP_Ware_Bill_Transfer_EditVerify");
            parameters = new SqlParameter[] {
					new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@PKCode", SqlDbType.VarChar,25)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = model.ID;
            cmd.ExecuteMySPQuery(strSql.ToString(), parameters);
            /////////////////////////////////////////////////////////////////
            strSql.Clear();
            strSql.Append("update Ware_Bill_Transfer set ");
            strSql.Append("WhCodeOut=@WhCodeOut,");
            strSql.Append("WhCodeIn=@WhCodeIn,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[] {
					new SqlParameter("@WhCodeOut", SqlDbType.VarChar,10),
					new SqlParameter("@WhCodeIn", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.WhCodeOut;
            parameters[1].Value = model.WhCodeIn;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateWare_Bill_Count(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters;
            ///////////////////////////////////////////////
            strSql.Append("SP_Ware_Bill_Count_EditVerify");
            parameters = new SqlParameter[] {
					new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@PKCode", SqlDbType.VarChar,25)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = model.ID;
            cmd.ExecuteMySPQuery(strSql.ToString(), parameters);
            /////////////////////////////////////////////////////////////////
            strSql.Clear();
            strSql.Append("update Ware_Bill_Count set ");
            strSql.Append("WhCode=@WhCode,");
            strSql.Append("FBCode=@FBCode,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[] {
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@FBCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.WhCode;
            parameters[1].Value = model.FBCode;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateEditWare_Bill(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill set ");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = { 
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.Remark;
            parameters[1].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateEditWare_Bill_Transfer(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill_Transfer set ");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = { 
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.Remark;
            parameters[1].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateEditWare_Bill_Count(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill_Count set ");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = { 
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.Remark;
            parameters[1].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateWare_Bill_SD(int lgIndex, SqlCommand cmd, List<MWare_Bill_SD> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            ////////////////////////////////////////////////////////////////
            foreach (var modelSD in modelList)
            {
                strSql.Clear();
                strSql.Append("update Ware_Bill_SD set ");
                strSql.Append("LensCode=@LensCode,");
                strSql.Append("SPH=@SPH,");
                strSql.Append("CYL=@CYL,");
                strSql.Append("X_ADD=@X_ADD,");
                strSql.Append("Qty=@Qty,");
                strSql.Append("Price=@Price,");
                strSql.Append("ProCost=@ProCost");
                strSql.Append(" where ID=@ID and F_LR=@F_LR ");
                parameters = new SqlParameter[]  {
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),  
                    new SqlParameter("@ProCost", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1)};
                parameters[0].Value = modelSD.LensCode;
                parameters[1].Value = modelSD.SPH;
                parameters[2].Value = modelSD.CYL;
                parameters[3].Value = modelSD.X_ADD;
                parameters[4].Value = modelSD.Qty;
                parameters[5].Value = modelSD.Price;
                parameters[6].Value = modelSD.ProCost;
                parameters[7].Value = modelSD.ID;
                parameters[8].Value = modelSD.F_LR;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void UpdateWare_Bill_PD(int lgIndex, SqlCommand cmd, MWare_Bill_PD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill_PD set ");
            strSql.Append("LensCode=@LensCode,");
            strSql.Append("F_LR=@F_LR");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.LensCode;
            parameters[1].Value = model.F_LR;
            parameters[2].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateWare_Bill_PD_Detail(int lgIndex, SqlCommand cmd, List<MWare_Bill_PD_Detail> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append("delete Ware_Bill_PD_Detail");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = modelList.FirstOrDefault().ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var modelPD_Detail in modelList)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Bill_PD_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@Price)");
                parameters = new SqlParameter[]{
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = modelPD_Detail.ID;
                parameters[1].Value = modelPD_Detail.SubID;
                parameters[2].Value = modelPD_Detail.SPH;
                parameters[3].Value = modelPD_Detail.CYL;
                parameters[4].Value = modelPD_Detail.X_ADD;
                parameters[5].Value = modelPD_Detail.Qty;
                parameters[6].Value = modelPD_Detail.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void UpdateWare_Bill_Count_PD_Detail2(int lgIndex, SqlCommand cmd, List<MWare_Bill_Count_PD_Detail2> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append("delete Ware_Bill_Count_PD_Detail2");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = modelList.FirstOrDefault().ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var model in modelList)
            {
                strSql.Clear();
                strSql.Append("insert into Ware_Bill_Count_PD_Detail2(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@Price)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.SubID;
                parameters[2].Value = model.SPH;
                parameters[3].Value = model.CYL;
                parameters[4].Value = model.X_ADD;
                parameters[5].Value = model.Qty;
                parameters[6].Value = model.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void UpdateWare_Bill_Extend(int lgIndex, SqlCommand cmd, MWare_Bill_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill_Extend set ");
            strSql.Append("SCode=@SCode,");
            strSql.Append("SumQty=@SumQty,");
            strSql.Append("SumMoney=@SumMoney,");
            strSql.Append("LensCodeR=@LensCodeR,");
            strSql.Append("LensCodeL=@LensCodeL,");
            strSql.Append("SPHR=@SPHR,");
            strSql.Append("SPHL=@SPHL,");
            strSql.Append("CYLR=@CYLR,");
            strSql.Append("CYLL=@CYLL,");
            strSql.Append("X_ADDR=@X_ADDR,");
            strSql.Append("X_ADDL=@X_ADDL,");
            strSql.Append("QtyR=@QtyR,");
            strSql.Append("QtyL=@QtyL,");
            strSql.Append("PriceR=@PriceR,");
            strSql.Append("PriceL=@PriceL,");
            strSql.Append("ProCostR=@ProCostR,");
            strSql.Append("ProCostL=@ProCostL");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SCode", SqlDbType.VarChar,200),
					new SqlParameter("@SumQty", SqlDbType.Int,4),
                    new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeL", SqlDbType.VarChar,50),
					new SqlParameter("@SPHR", SqlDbType.Int,4),
					new SqlParameter("@SPHL", SqlDbType.Int,4),
					new SqlParameter("@CYLR", SqlDbType.Int,4),
					new SqlParameter("@CYLL", SqlDbType.Int,4),
					new SqlParameter("@X_ADDR", SqlDbType.Int,4),
					new SqlParameter("@X_ADDL", SqlDbType.Int,4),
                    new SqlParameter("@QtyR", SqlDbType.Int,4),
					new SqlParameter("@QtyL", SqlDbType.Int,4),
                    new SqlParameter("@PriceR", SqlDbType.Decimal,9),
					new SqlParameter("@PriceL", SqlDbType.Decimal,9),
					new SqlParameter("@ProCostR", SqlDbType.Decimal,9),
					new SqlParameter("@ProCostL", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.SCode;
            parameters[1].Value = model.SumQty;
            parameters[2].Value = model.SumMoney;
            parameters[3].Value = model.LensCodeR;
            parameters[4].Value = model.LensCodeL;
            parameters[5].Value = model.SPHR;
            parameters[6].Value = model.SPHL;
            parameters[7].Value = model.CYLR;
            parameters[8].Value = model.CYLL;
            parameters[9].Value = model.X_ADDR;
            parameters[10].Value = model.X_ADDL;
            parameters[11].Value = model.QtyR;
            parameters[12].Value = model.QtyL;
            parameters[13].Value = model.PriceR;
            parameters[14].Value = model.PriceL;
            parameters[15].Value = model.ProCostR;
            parameters[16].Value = model.ProCostL;
            parameters[17].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateWare_Bill_Count_Extend(int lgIndex, SqlCommand cmd, MWare_Bill_Count_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ware_Bill_Count_Extend set ");
            strSql.Append("SumQty1=@SumQty1,");
            strSql.Append("SumQty2=@SumQty2,");
            strSql.Append("SumQty=@SumQty");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SumQty1", SqlDbType.Int,4),
					new SqlParameter("@SumQty2", SqlDbType.Int,4),
					new SqlParameter("@SumQty", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.SumQty1;
            parameters[1].Value = model.SumQty2;
            parameters[2].Value = model.SumQty;
            parameters[3].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        #endregion
    }
}
