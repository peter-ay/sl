using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public class DSale
    {
        #region exists

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

        #region ADD

        public void AddSale_Order(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sale_Order(");
            strSql.Append("ID,BCode,BDate,OBCode,FBCode,UD,CsDate,BType,MType,F_SD,F_FS,CusCode,OGType,WhCode,SpCode,DpCodeWG,Notes,Remark,Freight,Maker,MName,BarCodePre)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BCode,@BDate,@OBCode,@FBCode,@UD,@CsDate,@BType,@MType,@F_SD,@F_FS,@CusCode,@OGType,@WhCode,@SpCode,@DpCodeWG,@Notes,@Remark,@Freight,@Maker,@MName,@BarCodePre)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BCode", SqlDbType.VarChar,25),
					new SqlParameter("@BDate", SqlDbType.Date,3),
					new SqlParameter("@OBCode", SqlDbType.NVarChar,50),
					new SqlParameter("@FBCode", SqlDbType.VarChar,50),
					new SqlParameter("@UD", SqlDbType.TinyInt,1),
					new SqlParameter("@CsDate", SqlDbType.Date,3),
					new SqlParameter("@BType", SqlDbType.VarChar,6),
					new SqlParameter("@MType", SqlDbType.VarChar,10),
					new SqlParameter("@F_SD", SqlDbType.Bit,1),
					new SqlParameter("@F_FS", SqlDbType.Bit,1),
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
					new SqlParameter("@OGType", SqlDbType.TinyInt,1),
					new SqlParameter("@WhCode", SqlDbType.VarChar,10),
					new SqlParameter("@SpCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCodeWG", SqlDbType.VarChar,10),
					new SqlParameter("@Notes", SqlDbType.NVarChar,200),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.NVarChar,30),
					new SqlParameter("@BarCodePre", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BCode;
            parameters[2].Value = model.BDate;
            parameters[3].Value = model.OBCode;
            parameters[4].Value = model.FBCode;
            parameters[5].Value = model.UD;
            parameters[6].Value = model.CsDate;
            parameters[7].Value = model.BType;
            parameters[8].Value = model.MType;
            parameters[9].Value = model.F_SD;
            parameters[10].Value = model.F_FS;
            parameters[11].Value = model.CusCode;
            parameters[12].Value = model.OGType;
            parameters[13].Value = model.WhCode;
            parameters[14].Value = model.SpCode;
            parameters[15].Value = model.DpCodeWG;
            parameters[16].Value = model.Notes;
            parameters[17].Value = model.Remark;
            parameters[18].Value = model.Freight;
            parameters[19].Value = model.Maker;
            parameters[20].Value = model.MName;
            parameters[21].Value = model.BarCodePre ?? "";
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);

            //Addtional 
            strSql.Clear();
            strSql.Append("insert into Sale_Order_ADD(");
            strSql.Append("ID,StCode,BCodeKFSO,BCodeCGDD,BCodePC,MDate,Checker,ChName,ChDate,Deler,DelName,DelDate,Closer,ClName,ClDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@StCode,@BCodeKFSO,@BCodeCGDD,@BCodePC,@MDate,@Checker,@ChName,@ChDate,@Deler,@DelName,@DelDate,@Closer,@ClName,@ClDate)");
            parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
                    new SqlParameter("@StCode", SqlDbType.VarChar,6),
					new SqlParameter("@BCodeKFSO", SqlDbType.VarChar,25),
					new SqlParameter("@BCodeCGDD", SqlDbType.VarChar,25),
					new SqlParameter("@BCodePC", SqlDbType.VarChar,25),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@Checker", SqlDbType.VarChar,10),
					new SqlParameter("@ChName", SqlDbType.NVarChar,30),
					new SqlParameter("@ChDate", SqlDbType.DateTime),
					new SqlParameter("@Deler", SqlDbType.VarChar,10),
					new SqlParameter("@DelName", SqlDbType.NVarChar,30),
					new SqlParameter("@DelDate", SqlDbType.DateTime),
					new SqlParameter("@Closer", SqlDbType.VarChar,10),
					new SqlParameter("@ClName", SqlDbType.NVarChar,30),
					new SqlParameter("@ClDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = "DSH";
            parameters[2].Value = "";// model.BCodeKFSO;
            parameters[3].Value = "";//model.BCodeCGDD;
            parameters[4].Value = "";//model.BCodePC;
            parameters[5].Value = System.DateTime.Now;//model.MDate;
            parameters[6].Value = "";// model.Checker;
            parameters[7].Value = "";//model.ChName;
            parameters[8].Value = System.DBNull.Value;// model.ChDate;
            parameters[9].Value = "";// model.Deler;
            parameters[10].Value = "";//model.DelName;
            parameters[11].Value = System.DBNull.Value;// model.DelDate;
            parameters[12].Value = "";// model.Closer;
            parameters[13].Value = "";// model.ClName;
            parameters[14].Value = System.DBNull.Value;//model.ClDate;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddSale_Order_SD(int lgIndex, SqlCommand cmd, List<MSale_Order_SD> model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelSD in model)
            {
                strSql.Clear();
                strSql.Append("insert into Sale_Order_SD(");
                strSql.Append("ID,F_LR,Dia,LensCode,LensCodeR,SPH,CYL,Axis,X_ADD,Qty,BASE,CT,DB,D1,D2,D3,D4,P1,P2,P3,P4,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price,ProCost,InvTitle,ProReport,ProCostReport)");
                strSql.Append(" values (");
                strSql.Append("@ID,@F_LR,@Dia,@LensCode,@LensCodeR,@SPH,@CYL,@Axis,@X_ADD,@Qty,@BASE,@CT,@DB,@D1,@D2,@D3,@D4,@P1,@P2,@P3,@P4,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price,@ProCost,@InvTitle,@ProReport,@ProCostReport)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@Dia", SqlDbType.Int,4),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@Axis", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@BASE", SqlDbType.VarChar,10),
					new SqlParameter("@CT", SqlDbType.VarChar,10),
					new SqlParameter("@DB", SqlDbType.Bit,1),
					new SqlParameter("@D1", SqlDbType.VarChar,10),
					new SqlParameter("@D2", SqlDbType.VarChar,10),
					new SqlParameter("@D3", SqlDbType.VarChar,10),
					new SqlParameter("@D4", SqlDbType.VarChar,10),
					new SqlParameter("@P1", SqlDbType.VarChar,10),
					new SqlParameter("@P2", SqlDbType.VarChar,10),
					new SqlParameter("@P3", SqlDbType.VarChar,10),
					new SqlParameter("@P4", SqlDbType.VarChar,10),
					new SqlParameter("@QtyPur", SqlDbType.Int,4),
					new SqlParameter("@QtyRec", SqlDbType.Int,4),
					new SqlParameter("@QtySO", SqlDbType.Int,4),
					new SqlParameter("@QtyCs", SqlDbType.Int,4),
					new SqlParameter("@QtyRt", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@ProCost", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@ProReport", SqlDbType.NVarChar,200),
					new SqlParameter("@ProCostReport", SqlDbType.NVarChar,200)};
                parameters[0].Value = modelSD.ID;
                parameters[1].Value = modelSD.F_LR;
                parameters[2].Value = modelSD.Dia;
                parameters[3].Value = modelSD.LensCode;
                parameters[4].Value = modelSD.LensCodeR;
                parameters[5].Value = modelSD.SPH;
                parameters[6].Value = modelSD.CYL;
                parameters[7].Value = modelSD.Axis;
                parameters[8].Value = modelSD.X_ADD;
                parameters[9].Value = modelSD.Qty;
                parameters[10].Value = modelSD.BASE;
                parameters[11].Value = modelSD.CT;
                parameters[12].Value = modelSD.DB;
                parameters[13].Value = modelSD.D1;
                parameters[14].Value = modelSD.D2;
                parameters[15].Value = modelSD.D3;
                parameters[16].Value = modelSD.D4;
                parameters[17].Value = modelSD.P1;
                parameters[18].Value = modelSD.P2;
                parameters[19].Value = modelSD.P3;
                parameters[20].Value = modelSD.P4;
                parameters[21].Value = modelSD.QtyPur;
                parameters[22].Value = modelSD.QtyRec;
                parameters[23].Value = modelSD.QtySO;
                parameters[24].Value = modelSD.QtyCs;
                parameters[25].Value = modelSD.QtyRt;
                parameters[26].Value = modelSD.Price;
                parameters[27].Value = modelSD.ProCost;
                parameters[28].Value = modelSD.InvTitle;
                parameters[29].Value = modelSD.ProReport;
                parameters[30].Value = modelSD.ProCostReport;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void AddSale_Order_SD_Process(int lgIndex, SqlCommand cmd, MSale_Order_SD_Process model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Clear();
            strSql.Append("insert into Sale_Order_SD_Process(");
            strSql.Append("ID,F_CusLens,CXType,PD,PH,JY,UV,JS,RS,RSName,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP,DpCodeJG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@F_CusLens,@CXType,@PD,@PH,@JY,@UV,@JS,@RS,@RSName,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP,@DpCodeJG)");
            parameters = new SqlParameter[]{
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_CusLens", SqlDbType.Bit,1),
					new SqlParameter("@CXType", SqlDbType.TinyInt,1),
					new SqlParameter("@PD", SqlDbType.VarChar,30),
					new SqlParameter("@PH", SqlDbType.VarChar,30),
					new SqlParameter("@JY", SqlDbType.Bit,1),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JS", SqlDbType.VarChar,15),
					new SqlParameter("@RS", SqlDbType.VarChar,15),
					new SqlParameter("@RSName", SqlDbType.NVarChar,20),
					new SqlParameter("@CS", SqlDbType.VarChar,15),
					new SqlParameter("@SY", SqlDbType.VarChar,15),
					new SqlParameter("@CB", SqlDbType.VarChar,15),
					new SqlParameter("@ChB", SqlDbType.VarChar,15),
					new SqlParameter("@KK", SqlDbType.VarChar,15),
					new SqlParameter("@ZK", SqlDbType.VarChar,15),
					new SqlParameter("@PiH", SqlDbType.VarChar,15),
					new SqlParameter("@PG", SqlDbType.VarChar,15),
					new SqlParameter("@JJ", SqlDbType.VarChar,15),
					new SqlParameter("@OP", SqlDbType.VarChar,15),
					new SqlParameter("@DpCodeJG", SqlDbType.VarChar,10)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.F_CusLens;
            parameters[2].Value = model.CXType;
            parameters[3].Value = model.PD;
            parameters[4].Value = model.PH;
            parameters[5].Value = model.JY;
            parameters[6].Value = model.UV;
            parameters[7].Value = model.JS;
            parameters[8].Value = model.RS;
            parameters[9].Value = model.RSName;
            parameters[10].Value = model.CS;
            parameters[11].Value = model.SY;
            parameters[12].Value = model.CB;
            parameters[13].Value = model.ChB;
            parameters[14].Value = model.KK;
            parameters[15].Value = model.ZK;
            parameters[16].Value = model.PiH;
            parameters[17].Value = model.PG;
            parameters[18].Value = model.JJ;
            parameters[19].Value = model.OP;
            parameters[20].Value = model.DpCodeJG;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddSale_Order_PD(int lgIndex, SqlCommand cmd, MSale_Order_PD model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append("insert into Sale_Order_PD(");
            strSql.Append("ID,F_LR,LensCode,LensCodeR,InvTitle)");
            strSql.Append(" values (");
            strSql.Append("@ID,@F_LR,@LensCode,@LensCodeR,@InvTitle)");
            parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@LensCode", SqlDbType.NVarChar,50),
					new SqlParameter("@LensCodeR", SqlDbType.NVarChar,50),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.F_LR;
            parameters[2].Value = model.LensCode;
            parameters[3].Value = model.LensCodeR;
            parameters[4].Value = model.InvTitle;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void AddSale_Order_PD_Detail(int lgIndex, SqlCommand cmd, List<MSale_Order_PD_Detail> model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelPD_Detail in model)
            {
                strSql.Clear();
                strSql.Append("insert into Sale_Order_PD_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@QtyPur", SqlDbType.Int,4),
					new SqlParameter("@QtyRec", SqlDbType.Int,4),
					new SqlParameter("@QtySO", SqlDbType.Int,4),
					new SqlParameter("@QtyCs", SqlDbType.Int,4),
					new SqlParameter("@QtyRt", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = modelPD_Detail.ID;
                parameters[1].Value = modelPD_Detail.SubID;
                parameters[2].Value = modelPD_Detail.SPH;
                parameters[3].Value = modelPD_Detail.CYL;
                parameters[4].Value = modelPD_Detail.X_ADD;
                parameters[5].Value = modelPD_Detail.Qty;
                parameters[6].Value = modelPD_Detail.QtyPur;
                parameters[7].Value = modelPD_Detail.QtyRec;
                parameters[8].Value = modelPD_Detail.QtySO;
                parameters[9].Value = modelPD_Detail.QtyCs;
                parameters[10].Value = modelPD_Detail.QtyRt;
                parameters[11].Value = modelPD_Detail.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void AddSale_Order_Extend(int lgIndex, SqlCommand cmd, MSale_Order_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sale_Order_Extend(");
            strSql.Append("ID,SumQty,SumMoney,SumQtyPur,SumQtyRec,SumQtySO,SumQtyCs,SumQtyRt,DN,DDate,Rt1,Rt2,Rt3,Rt4,Rt5,RtQR1,RtQR2,PdCode,PdName,LensCodeR,LensCodeRR,LensCodeL,LensCodeRL,SPHR,SPHL,CYLR,CYLL,X_ADDR,X_ADDL,QtyR,QtyL,PriceR,PriceL,ProCostR,ProCostL,SN)");
            strSql.Append(" values (");
            strSql.Append("@ID,@SumQty,@SumMoney,@SumQtyPur,@SumQtyRec,@SumQtySO,@SumQtyCs,@SumQtyRt,@DN,@DDate,@Rt1,@Rt2,@Rt3,@Rt4,@Rt5,@RtQR1,@RtQR2,@PdCode,@PdName,@LensCodeR,@LensCodeRR,@LensCodeL,@LensCodeRL,@SPHR,@SPHL,@CYLR,@CYLL,@X_ADDR,@X_ADDL,@QtyR,@QtyL,@PriceR,@PriceL,@ProCostR,@ProCostL,@SN)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SumQty", SqlDbType.Int,4),
					new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SumQtyPur", SqlDbType.Int,4),
					new SqlParameter("@SumQtyRec", SqlDbType.Int,4),
					new SqlParameter("@SumQtySO", SqlDbType.Int,4),
					new SqlParameter("@SumQtyCs", SqlDbType.Int,4),
					new SqlParameter("@SumQtyRt", SqlDbType.Int,4),
					new SqlParameter("@DN", SqlDbType.VarChar,100),
					new SqlParameter("@DDate", SqlDbType.DateTime),
					new SqlParameter("@Rt1", SqlDbType.VarChar,200),
					new SqlParameter("@Rt2", SqlDbType.VarChar,200),
					new SqlParameter("@Rt3", SqlDbType.VarChar,200),
					new SqlParameter("@Rt4", SqlDbType.VarChar,200),
					new SqlParameter("@Rt5", SqlDbType.VarChar,200),
					new SqlParameter("@RtQR1", SqlDbType.VarChar,2000),
					new SqlParameter("@RtQR2", SqlDbType.VarChar,2000),
					new SqlParameter("@PdCode", SqlDbType.VarChar,500),
					new SqlParameter("@PdName", SqlDbType.VarChar,500),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeRR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeL", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeRL", SqlDbType.VarChar,50),
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
					new SqlParameter("@SN", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SumQty;
            parameters[2].Value = model.SumMoney;
            parameters[3].Value = model.SumQtyPur;
            parameters[4].Value = model.SumQtyRec;
            parameters[5].Value = model.SumQtySO;
            parameters[6].Value = model.SumQtyCs;
            parameters[7].Value = model.SumQtyRt;
            parameters[8].Value = model.DN;
            parameters[9].Value = System.DBNull.Value;//model.DDate;
            parameters[10].Value = model.Rt1;
            parameters[11].Value = model.Rt2;
            parameters[12].Value = model.Rt3;
            parameters[13].Value = model.Rt4;
            parameters[14].Value = model.Rt5;
            parameters[15].Value = model.RtQR1;
            parameters[16].Value = model.RtQR2;
            parameters[17].Value = model.PdCode;
            parameters[18].Value = model.PdName;
            parameters[19].Value = model.LensCodeR;
            parameters[20].Value = model.LensCodeRR;
            parameters[21].Value = model.LensCodeL;
            parameters[22].Value = model.LensCodeRL;
            parameters[23].Value = model.SPHR;
            parameters[24].Value = model.SPHL;
            parameters[25].Value = model.CYLR;
            parameters[26].Value = model.CYLL;
            parameters[27].Value = model.X_ADDR;
            parameters[28].Value = model.X_ADDL;
            parameters[29].Value = model.QtyR;
            parameters[30].Value = model.QtyL;
            parameters[31].Value = model.PriceR;
            parameters[32].Value = model.PriceL;
            parameters[33].Value = model.ProCostR;
            parameters[34].Value = model.ProCostL;
            parameters[35].Value = model.SN;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        #endregion

        #region Update

        public void UpdateSale_Order(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Order set ");
            strSql.Append("OBCode=@OBCode,");
            strSql.Append("UD=@UD,");
            strSql.Append("CsDate=@CsDate,");
            strSql.Append("CusCode=@CusCode,");
            strSql.Append("SpCode=@SpCode,");
            strSql.Append("DpCodeWG=@DpCodeWG,");
            strSql.Append("WhCode=@WhCode,");
            strSql.Append("OGType=@OGType,");
            strSql.Append("Notes=@Notes,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Freight=@Freight,");
            strSql.Append("BarCodePre=@BarCodePre");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                        new SqlParameter("@OBCode", SqlDbType.NVarChar,50),
                        new SqlParameter("@UD", SqlDbType.TinyInt,1), 
                        new SqlParameter("@CsDate", SqlDbType.Date,3),  
                        new SqlParameter("@CusCode", SqlDbType.VarChar,10),
                        new SqlParameter("@SpCode", SqlDbType.VarChar,10),
                        new SqlParameter("@DpCodeWG", SqlDbType.VarChar,10),
                        new SqlParameter("@WhCode", SqlDbType.VarChar,10),
                        new SqlParameter("@OGType", SqlDbType.TinyInt,1),
                        new SqlParameter("@Notes", SqlDbType.NVarChar,200),
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@Freight", SqlDbType.Decimal,9),
                        new SqlParameter("@BarCodePre", SqlDbType.VarChar,50),
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.OBCode;
            parameters[1].Value = model.UD;
            parameters[2].Value = model.CsDate;
            parameters[3].Value = model.CusCode;
            parameters[4].Value = model.SpCode;
            parameters[5].Value = model.DpCodeWG;
            parameters[6].Value = model.WhCode;
            parameters[7].Value = model.OGType;
            parameters[8].Value = model.Notes;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.Freight;
            parameters[11].Value = model.BarCodePre ?? "";
            parameters[12].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateEditSale_Order(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Order set ");
            strSql.Append("OBCode=@OBCode,");
            strSql.Append("Notes=@Notes,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                        new SqlParameter("@OBCode", SqlDbType.NVarChar,50), 
                        new SqlParameter("@Notes", SqlDbType.NVarChar,200),
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
                        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.OBCode;
            parameters[1].Value = model.Notes;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateSale_Order_SD(int lgIndex, SqlCommand cmd, List<MSale_Order_SD> model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelSD in model)
            {
                strSql.Clear();
                strSql.Append("update Sale_Order_SD set ");
                strSql.Append("Dia=@Dia,");
                strSql.Append("LensCode=@LensCode,");
                strSql.Append("LensCodeR=@LensCodeR,");
                strSql.Append("SPH=@SPH,");
                strSql.Append("CYL=@CYL,");
                strSql.Append("Axis=@Axis,");
                strSql.Append("X_ADD=@X_ADD,");
                strSql.Append("Qty=@Qty,");
                strSql.Append("BASE=@BASE,");
                strSql.Append("CT=@CT,");
                strSql.Append("DB=@DB,");
                strSql.Append("D1=@D1,");
                strSql.Append("D2=@D2,");
                strSql.Append("D3=@D3,");
                strSql.Append("D4=@D4,");
                strSql.Append("P1=@P1,");
                strSql.Append("P2=@P2,");
                strSql.Append("P3=@P3,");
                strSql.Append("P4=@P4");
                strSql.Append(" where ID=@ID and F_LR=@F_LR ");
                parameters = new SqlParameter[]  {
					new SqlParameter("@Dia", SqlDbType.Int,4),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@Axis", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@BASE", SqlDbType.VarChar,10),
					new SqlParameter("@CT", SqlDbType.VarChar,10),
					new SqlParameter("@DB", SqlDbType.Bit,1),
					new SqlParameter("@D1", SqlDbType.VarChar,10),
					new SqlParameter("@D2", SqlDbType.VarChar,10),
					new SqlParameter("@D3", SqlDbType.VarChar,10),
					new SqlParameter("@D4", SqlDbType.VarChar,10),
					new SqlParameter("@P1", SqlDbType.VarChar,10),
					new SqlParameter("@P2", SqlDbType.VarChar,10),
					new SqlParameter("@P3", SqlDbType.VarChar,10),
					new SqlParameter("@P4", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@F_LR", SqlDbType.VarChar,1)};
                parameters[0].Value = modelSD.Dia;
                parameters[1].Value = modelSD.LensCode;
                parameters[2].Value = modelSD.LensCodeR;
                parameters[3].Value = modelSD.SPH;
                parameters[4].Value = modelSD.CYL;
                parameters[5].Value = modelSD.Axis;
                parameters[6].Value = modelSD.X_ADD;
                parameters[7].Value = modelSD.Qty;
                parameters[8].Value = modelSD.BASE;
                parameters[9].Value = modelSD.CT;
                parameters[10].Value = modelSD.DB;
                parameters[11].Value = modelSD.D1;
                parameters[12].Value = modelSD.D2;
                parameters[13].Value = modelSD.D3;
                parameters[14].Value = modelSD.D4;
                parameters[15].Value = modelSD.P1;
                parameters[16].Value = modelSD.P2;
                parameters[17].Value = modelSD.P3;
                parameters[18].Value = modelSD.P4;
                parameters[19].Value = modelSD.ID;
                parameters[20].Value = modelSD.F_LR;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void UpdateSale_Order_SD_Process(int lgIndex, SqlCommand cmd, MSale_Order_SD_Process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Order_SD_Process set ");
            strSql.Append("F_CusLens=@F_CusLens,");
            strSql.Append("CXType=@CXType,");
            strSql.Append("PD=@PD,");
            strSql.Append("PH=@PH,");
            strSql.Append("JY=@JY,");
            strSql.Append("UV=@UV,");
            strSql.Append("JS=@JS,");
            strSql.Append("RS=@RS,");
            strSql.Append("RSName=@RSName,");
            strSql.Append("CS=@CS,");
            strSql.Append("SY=@SY,");
            strSql.Append("CB=@CB,");
            strSql.Append("ChB=@ChB,");
            strSql.Append("KK=@KK,");
            strSql.Append("ZK=@ZK,");
            strSql.Append("PiH=@PiH,");
            strSql.Append("PG=@PG,");
            strSql.Append("JJ=@JJ,");
            strSql.Append("OP=@OP,");
            strSql.Append("DpCodeJG=@DpCodeJG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@F_CusLens", SqlDbType.Bit,1),
					new SqlParameter("@CXType", SqlDbType.TinyInt,1),
					new SqlParameter("@PD", SqlDbType.VarChar,30),
					new SqlParameter("@PH", SqlDbType.VarChar,30),
					new SqlParameter("@JY", SqlDbType.Bit,1),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JS", SqlDbType.VarChar,15),
					new SqlParameter("@RS", SqlDbType.VarChar,15),
					new SqlParameter("@RSName", SqlDbType.NVarChar,20),
					new SqlParameter("@CS", SqlDbType.VarChar,15),
					new SqlParameter("@SY", SqlDbType.VarChar,15),
					new SqlParameter("@CB", SqlDbType.VarChar,15),
					new SqlParameter("@ChB", SqlDbType.VarChar,15),
					new SqlParameter("@KK", SqlDbType.VarChar,15),
					new SqlParameter("@ZK", SqlDbType.VarChar,15),
					new SqlParameter("@PiH", SqlDbType.VarChar,15),
					new SqlParameter("@PG", SqlDbType.VarChar,15),
					new SqlParameter("@JJ", SqlDbType.VarChar,15),
					new SqlParameter("@OP", SqlDbType.VarChar,15),
					new SqlParameter("@DpCodeJG", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.F_CusLens;
            parameters[1].Value = model.CXType;
            parameters[2].Value = model.PD;
            parameters[3].Value = model.PH;
            parameters[4].Value = model.JY;
            parameters[5].Value = model.UV;
            parameters[6].Value = model.JS;
            parameters[7].Value = model.RS;
            parameters[8].Value = model.RSName;
            parameters[9].Value = model.CS;
            parameters[10].Value = model.SY;
            parameters[11].Value = model.CB;
            parameters[12].Value = model.ChB;
            parameters[13].Value = model.KK;
            parameters[14].Value = model.ZK;
            parameters[15].Value = model.PiH;
            parameters[16].Value = model.PG;
            parameters[17].Value = model.JJ;
            parameters[18].Value = model.OP;
            parameters[19].Value = model.DpCodeJG;
            parameters[20].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateSale_Order_PD(int lgIndex, SqlCommand cmd, MSale_Order_PD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Order_PD set ");
            strSql.Append("F_LR=@F_LR,");
            strSql.Append("LensCode=@LensCode,");
            strSql.Append("LensCodeR=@LensCodeR");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[]  {
					new SqlParameter("@F_LR", SqlDbType.VarChar,1),
					new SqlParameter("@LensCode", SqlDbType.NVarChar,50),
					new SqlParameter("@LensCodeR", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.F_LR;
            parameters[1].Value = model.LensCode;
            parameters[2].Value = model.LensCodeR;
            parameters[3].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        public void UpdateSale_Order_PD_Detail(int lgIndex, SqlCommand cmd, List<MSale_Order_PD_Detail> model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append("delete Sale_Order_PD_Detail");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.FirstOrDefault().ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var modelPD_Detail in model)
            {
                strSql.Clear();
                strSql.Append("insert into Sale_Order_PD_Detail(");
                strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@QtyPur", SqlDbType.Int,4),
					new SqlParameter("@QtyRec", SqlDbType.Int,4),
					new SqlParameter("@QtySO", SqlDbType.Int,4),
					new SqlParameter("@QtyCs", SqlDbType.Int,4),
					new SqlParameter("@QtyRt", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9)};
                parameters[0].Value = modelPD_Detail.ID;
                parameters[1].Value = modelPD_Detail.SubID;
                parameters[2].Value = modelPD_Detail.SPH;
                parameters[3].Value = modelPD_Detail.CYL;
                parameters[4].Value = modelPD_Detail.X_ADD;
                parameters[5].Value = modelPD_Detail.Qty;
                parameters[6].Value = modelPD_Detail.QtyPur;
                parameters[7].Value = modelPD_Detail.QtyRec;
                parameters[8].Value = modelPD_Detail.QtySO;
                parameters[9].Value = modelPD_Detail.QtyCs;
                parameters[10].Value = modelPD_Detail.QtyRt;
                parameters[11].Value = modelPD_Detail.Price;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        public void UpdateSale_Order_Extend(int lgIndex, SqlCommand cmd, MSale_Order_Extend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Order_Extend set ");
            strSql.Append("SumQty=@SumQty,");
            strSql.Append("SumMoney=@SumMoney,");
            strSql.Append("SumQtyPur=@SumQtyPur,");
            strSql.Append("SumQtyRec=@SumQtyRec,");
            strSql.Append("SumQtySO=@SumQtySO,");
            strSql.Append("SumQtyCs=@SumQtyCs,");
            strSql.Append("SumQtyRt=@SumQtyRt,");
            strSql.Append("DN=@DN,");
            strSql.Append("DDate=@DDate,");
            strSql.Append("Rt1=@Rt1,");
            strSql.Append("Rt2=@Rt2,");
            strSql.Append("Rt3=@Rt3,");
            strSql.Append("Rt4=@Rt4,");
            strSql.Append("Rt5=@Rt5,");
            strSql.Append("RtQR1=@RtQR1,");
            strSql.Append("RtQR2=@RtQR2,");
            strSql.Append("PdCode=@PdCode,");
            strSql.Append("PdName=@PdName,");
            strSql.Append("LensCodeR=@LensCodeR,");
            strSql.Append("LensCodeRR=@LensCodeRR,");
            strSql.Append("LensCodeL=@LensCodeL,");
            strSql.Append("LensCodeRL=@LensCodeRL,");
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
            strSql.Append("ProCostL=@ProCostL,");
            strSql.Append("SN=@SN");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SumQty", SqlDbType.Int,4),
					new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SumQtyPur", SqlDbType.Int,4),
					new SqlParameter("@SumQtyRec", SqlDbType.Int,4),
					new SqlParameter("@SumQtySO", SqlDbType.Int,4),
					new SqlParameter("@SumQtyCs", SqlDbType.Int,4),
					new SqlParameter("@SumQtyRt", SqlDbType.Int,4),
					new SqlParameter("@DN", SqlDbType.VarChar,100),
					new SqlParameter("@DDate", SqlDbType.DateTime),
					new SqlParameter("@Rt1", SqlDbType.VarChar,200),
					new SqlParameter("@Rt2", SqlDbType.VarChar,200),
					new SqlParameter("@Rt3", SqlDbType.VarChar,200),
					new SqlParameter("@Rt4", SqlDbType.VarChar,200),
					new SqlParameter("@Rt5", SqlDbType.VarChar,200),
					new SqlParameter("@RtQR1", SqlDbType.VarChar,2000),
					new SqlParameter("@RtQR2", SqlDbType.VarChar,2000),
					new SqlParameter("@PdCode", SqlDbType.VarChar,500),
					new SqlParameter("@PdName", SqlDbType.VarChar,500),
					new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeRR", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeL", SqlDbType.VarChar,50),
					new SqlParameter("@LensCodeRL", SqlDbType.VarChar,50),
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
					new SqlParameter("@SN", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.SumQty;
            parameters[1].Value = model.SumMoney;
            parameters[2].Value = model.SumQtyPur;
            parameters[3].Value = model.SumQtyRec;
            parameters[4].Value = model.SumQtySO;
            parameters[5].Value = model.SumQtyCs;
            parameters[6].Value = model.SumQtyRt;
            parameters[7].Value = model.DN;
            parameters[8].Value = System.DBNull.Value;//model.DDate;
            parameters[9].Value = model.Rt1;
            parameters[10].Value = model.Rt2;
            parameters[11].Value = model.Rt3;
            parameters[12].Value = model.Rt4;
            parameters[13].Value = model.Rt5;
            parameters[14].Value = model.RtQR1;
            parameters[15].Value = model.RtQR2;
            parameters[16].Value = model.PdCode;
            parameters[17].Value = model.PdName;
            parameters[18].Value = model.LensCodeR;
            parameters[19].Value = model.LensCodeRR;
            parameters[20].Value = model.LensCodeL;
            parameters[21].Value = model.LensCodeRL;
            parameters[22].Value = model.SPHR;
            parameters[23].Value = model.SPHL;
            parameters[24].Value = model.CYLR;
            parameters[25].Value = model.CYLL;
            parameters[26].Value = model.X_ADDR;
            parameters[27].Value = model.X_ADDL;
            parameters[28].Value = model.QtyR;
            parameters[29].Value = model.QtyL;
            parameters[30].Value = model.PriceR;
            parameters[31].Value = model.PriceL;
            parameters[32].Value = model.ProCostR;
            parameters[33].Value = model.ProCostL;
            parameters[34].Value = model.SN;
            parameters[35].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        #endregion


    }
}
