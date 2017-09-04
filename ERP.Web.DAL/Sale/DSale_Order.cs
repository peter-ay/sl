using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;
using System.Collections;
using ERP.Web.Common;
using ERP.Web.DBUtility;
using System.Linq;

namespace ERP.Web.DAL
{
    public partial class DSale_Order : DALBase
    {
        DSale _DS = new DSale();

        public DSale_Order()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return _DS.Exists(dbCode, lgIndex, "Sale_Order", vCode);
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select count(1) from Sale_Order with (nolock)");
            //strSql.Append(" where ID=@ID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            //parameters[0].Value = vCode;
            //DALUtility du = new DALUtility();
            //return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MSale_Order model = t as MSale_Order;
            _DS.AddSale_Order(lgIndex, cmd, model);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MSale_Order model = t as MSale_Order;
            switch (model.MType)
            {
                case "L":
                    if (model.F_SD)
                    {
                        this.PrepareSD(lgIndex, cmd, model);
                    }
                    else
                    {
                        this.PreparePD(lgIndex, cmd, model);
                    }
                    break;

                case "F":
                    this.PrepareFD(lgIndex, cmd, model);
                    break;

                default: break;
            }
            this.PrepareAddExtend(lgIndex, cmd, model);
        }

        private void PrepareAddExtend(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            this.PrepareExtend(model);
            _DS.AddSale_Order_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void PrepareExtend(MSale_Order model)
        {
            model.Sub_Extend = new MSale_Order_Extend()
            {
                ID = model.ID,
                SPHL = 0,
                SPHR = 0,
                CYLL = 0,
                CYLR = 0,
                X_ADDL = 0,
                X_ADDR = 0,
                LensCodeL = "",
                LensCodeR = "",
                SumQty = 0,
                DN = "",
                LensCodeRL = "",
                LensCodeRR = "",
                PdCode = "",
                PdName = "",
                Rt1 = "",
                Rt2 = "",
                Rt3 = "",
                Rt4 = "",
                Rt5 = "",
                SumMoney = 0,
                SumQtyCs = 0,
                SumQtyPur = 0,
                SumQtyRec = 0,
                SumQtyRt = 0,
                SumQtySO = 0,
                QtyR = 0,
                QtyL = 0,
                RtQR1 = "",
                RtQR2 = "",
                PriceL = 0,
                PriceR = 0,
                ProCostL = 0,
                ProCostR = 0,
                SN = "",
            };

            switch (model.MType)
            {
                case "L":
                    if (model.F_SD)
                    {
                        model.Sub_Extend.SPHR = model.Sub_SD[0].SPH;
                        model.Sub_Extend.SPHL = model.Sub_SD[1].SPH;
                        model.Sub_Extend.CYLR = model.Sub_SD[0].CYL;
                        model.Sub_Extend.CYLL = model.Sub_SD[1].CYL;
                        model.Sub_Extend.X_ADDR = model.Sub_SD[0].X_ADD;
                        model.Sub_Extend.X_ADDL = model.Sub_SD[1].X_ADD;
                        model.Sub_Extend.LensCodeR = model.Sub_SD[0].LensCode;
                        model.Sub_Extend.LensCodeL = model.Sub_SD[1].LensCode;
                        model.Sub_Extend.LensCodeRR = model.Sub_SD[0].LensCodeR;
                        model.Sub_Extend.LensCodeRL = model.Sub_SD[1].LensCodeR;
                        model.Sub_Extend.QtyR = model.Sub_SD[0].Qty;
                        model.Sub_Extend.QtyL = model.Sub_SD[1].Qty;
                        model.Sub_Extend.PriceR = model.Sub_SD[0].Price;
                        model.Sub_Extend.PriceL = model.Sub_SD[1].Price;
                        model.Sub_Extend.ProCostR = model.Sub_SD[0].ProCost;
                        model.Sub_Extend.ProCostL = model.Sub_SD[1].ProCost;
                        model.Sub_Extend.SumQty = model.Sub_SD[0].Qty + model.Sub_SD[1].Qty;
                    }
                    else
                    {
                        model.Sub_Extend.LensCodeR = model.Sub_PD.LensCode;
                        model.Sub_Extend.LensCodeL = model.Sub_PD.LensCode;
                        model.Sub_Extend.SumQty = model.Sub_PD_Detail.Sum(it => it.Qty);
                    }
                    break;

                default:

                    break;
            }
        }

        private void PrepareFD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            foreach (var modelFD_Detail in model.Sub_FD_Detail)
            {
                strSql.Clear();
                strSql.Append("insert into Sale_Order_FD_Detail(");
                strSql.Append("ID,SubID,FrameCode,Qty,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price,DeliveryName)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@FrameCode,@Qty,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price,@DeliveryName)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@QtyPur", SqlDbType.Int,4),
					new SqlParameter("@QtyRec", SqlDbType.Int,4),
					new SqlParameter("@QtySO", SqlDbType.Int,4),
					new SqlParameter("@QtyCs", SqlDbType.Int,4),
					new SqlParameter("@QtyRt", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@DeliveryName", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.ID;
                parameters[1].Value = modelFD_Detail.SubID;
                parameters[2].Value = modelFD_Detail.FrameCode;
                parameters[3].Value = modelFD_Detail.Qty;
                parameters[4].Value = modelFD_Detail.QtyPur;
                parameters[5].Value = modelFD_Detail.QtyRec;
                parameters[6].Value = modelFD_Detail.QtySO;
                parameters[7].Value = modelFD_Detail.QtyCs;
                parameters[8].Value = modelFD_Detail.QtyRt;
                parameters[9].Value = modelFD_Detail.Price;
                parameters[10].Value = modelFD_Detail.DeliveryName;
            }
        }

        private void PreparePD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            model.Sub_PD.ID = model.ID;
            _DS.AddSale_Order_PD(lgIndex, cmd, model.Sub_PD);

            model.Sub_PD_Detail.ForEach(it => it.ID = model.ID);
            _DS.AddSale_Order_PD_Detail(lgIndex, cmd, model.Sub_PD_Detail);
        }

        private void PrepareSD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            model.Sub_SD.ForEach(it => it.ID = model.ID);
            _DS.AddSale_Order_SD(lgIndex, cmd, model.Sub_SD);

            model.Sub_SD_Process.ID = model.ID;
            _DS.AddSale_Order_SD_Process(lgIndex, cmd, model.Sub_SD_Process);
            //StringBuilder strSql = new StringBuilder();
            //SqlParameter[] parameters = null;
            //foreach (var modelSD in model.Sub_SD)
            //{
            //    strSql.Clear();
            //    strSql.Append("insert into Sale_Order_SD(");
            //    strSql.Append("ID,F_LR,Dia,LensCode,LensCodeR,SPH,CYL,Axis,X_ADD,Qty,BASE,CT,DB,D1,D2,D3,D4,P1,P2,P3,P4,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price,ProCost,InvTitle,ProReport,ProCostReport)");
            //    strSql.Append(" values (");
            //    strSql.Append("@ID,@F_LR,@Dia,@LensCode,@LensCodeR,@SPH,@CYL,@Axis,@X_ADD,@Qty,@BASE,@CT,@DB,@D1,@D2,@D3,@D4,@P1,@P2,@P3,@P4,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price,@ProCost,@InvTitle,@ProReport,@ProCostReport)");
            //    parameters = new SqlParameter[]  {
            //        new SqlParameter("@ID", SqlDbType.VarChar,25),
            //        new SqlParameter("@F_LR", SqlDbType.VarChar,1),
            //        new SqlParameter("@Dia", SqlDbType.Int,4),
            //        new SqlParameter("@LensCode", SqlDbType.VarChar,50),
            //        new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
            //        new SqlParameter("@SPH", SqlDbType.Int,4),
            //        new SqlParameter("@CYL", SqlDbType.Int,4),
            //        new SqlParameter("@Axis", SqlDbType.Int,4),
            //        new SqlParameter("@X_ADD", SqlDbType.Int,4),
            //        new SqlParameter("@Qty", SqlDbType.Int,4),
            //        new SqlParameter("@BASE", SqlDbType.VarChar,10),
            //        new SqlParameter("@CT", SqlDbType.VarChar,10),
            //        new SqlParameter("@DB", SqlDbType.Bit,1),
            //        new SqlParameter("@D1", SqlDbType.VarChar,10),
            //        new SqlParameter("@D2", SqlDbType.VarChar,10),
            //        new SqlParameter("@D3", SqlDbType.VarChar,10),
            //        new SqlParameter("@D4", SqlDbType.VarChar,10),
            //        new SqlParameter("@P1", SqlDbType.VarChar,10),
            //        new SqlParameter("@P2", SqlDbType.VarChar,10),
            //        new SqlParameter("@P3", SqlDbType.VarChar,10),
            //        new SqlParameter("@P4", SqlDbType.VarChar,10),
            //        new SqlParameter("@QtyPur", SqlDbType.Int,4),
            //        new SqlParameter("@QtyRec", SqlDbType.Int,4),
            //        new SqlParameter("@QtySO", SqlDbType.Int,4),
            //        new SqlParameter("@QtyCs", SqlDbType.Int,4),
            //        new SqlParameter("@QtyRt", SqlDbType.Int,4),
            //        new SqlParameter("@Price", SqlDbType.Decimal,9),
            //        new SqlParameter("@ProCost", SqlDbType.Decimal,9),
            //        new SqlParameter("@InvTitle", SqlDbType.NVarChar,100),
            //        new SqlParameter("@ProReport", SqlDbType.NVarChar,200),
            //        new SqlParameter("@ProCostReport", SqlDbType.NVarChar,200)};
            //    parameters[0].Value = model.ID;
            //    parameters[1].Value = modelSD.F_LR;
            //    parameters[2].Value = modelSD.Dia;
            //    parameters[3].Value = modelSD.LensCode;
            //    parameters[4].Value = modelSD.LensCodeR;
            //    parameters[5].Value = modelSD.SPH;
            //    parameters[6].Value = modelSD.CYL;
            //    parameters[7].Value = modelSD.Axis;
            //    parameters[8].Value = modelSD.X_ADD;
            //    parameters[9].Value = modelSD.Qty;
            //    parameters[10].Value = modelSD.BASE;
            //    parameters[11].Value = modelSD.CT;
            //    parameters[12].Value = modelSD.DB;
            //    parameters[13].Value = modelSD.D1;
            //    parameters[14].Value = modelSD.D2;
            //    parameters[15].Value = modelSD.D3;
            //    parameters[16].Value = modelSD.D4;
            //    parameters[17].Value = modelSD.P1;
            //    parameters[18].Value = modelSD.P2;
            //    parameters[19].Value = modelSD.P3;
            //    parameters[20].Value = modelSD.P4;
            //    parameters[21].Value = modelSD.QtyPur;
            //    parameters[22].Value = modelSD.QtyRec;
            //    parameters[23].Value = modelSD.QtySO;
            //    parameters[24].Value = modelSD.QtyCs;
            //    parameters[25].Value = modelSD.QtyRt;
            //    parameters[26].Value = modelSD.Price;
            //    parameters[27].Value = modelSD.ProCost;
            //    parameters[28].Value = modelSD.InvTitle;
            //    parameters[29].Value = modelSD.ProReport;
            //    parameters[30].Value = modelSD.ProCostReport;
            //    cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //}
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var modelSDProcess = model.Sub_SD_Process;
            //strSql.Clear();
            //strSql.Append("insert into Sale_Order_SD_Process(");
            //strSql.Append("ID,F_CusLens,CXType,PD,PH,JY,UV,JS,RS,RSName,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP,DpCodeJG)");
            //strSql.Append(" values (");
            //strSql.Append("@ID,@F_CusLens,@CXType,@PD,@PH,@JY,@UV,@JS,@RS,@RSName,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP,@DpCodeJG)");
            //parameters = new SqlParameter[]{
            //        new SqlParameter("@ID", SqlDbType.VarChar,25),
            //        new SqlParameter("@F_CusLens", SqlDbType.Bit,1),
            //        new SqlParameter("@CXType", SqlDbType.TinyInt,1),
            //        new SqlParameter("@PD", SqlDbType.VarChar,30),
            //        new SqlParameter("@PH", SqlDbType.VarChar,30),
            //        new SqlParameter("@JY", SqlDbType.Bit,1),
            //        new SqlParameter("@UV", SqlDbType.Bit,1),
            //        new SqlParameter("@JS", SqlDbType.VarChar,15),
            //        new SqlParameter("@RS", SqlDbType.VarChar,15),
            //        new SqlParameter("@RSName", SqlDbType.NVarChar,20),
            //        new SqlParameter("@CS", SqlDbType.VarChar,15),
            //        new SqlParameter("@SY", SqlDbType.VarChar,15),
            //        new SqlParameter("@CB", SqlDbType.VarChar,15),
            //        new SqlParameter("@ChB", SqlDbType.VarChar,15),
            //        new SqlParameter("@KK", SqlDbType.VarChar,15),
            //        new SqlParameter("@ZK", SqlDbType.VarChar,15),
            //        new SqlParameter("@PiH", SqlDbType.VarChar,15),
            //        new SqlParameter("@PG", SqlDbType.VarChar,15),
            //        new SqlParameter("@JJ", SqlDbType.VarChar,15),
            //        new SqlParameter("@OP", SqlDbType.VarChar,15),
            //        new SqlParameter("@DpCodeJG", SqlDbType.VarChar,10)};
            //parameters[0].Value = model.ID;
            //parameters[1].Value = modelSDProcess.F_CusLens;
            //parameters[2].Value = modelSDProcess.CXType;
            //parameters[3].Value = modelSDProcess.PD;
            //parameters[4].Value = modelSDProcess.PH;
            //parameters[5].Value = modelSDProcess.JY;
            //parameters[6].Value = modelSDProcess.UV;
            //parameters[7].Value = modelSDProcess.JS;
            //parameters[8].Value = modelSDProcess.RS;
            //parameters[9].Value = modelSDProcess.RSName;
            //parameters[10].Value = modelSDProcess.CS;
            //parameters[11].Value = modelSDProcess.SY;
            //parameters[12].Value = modelSDProcess.CB;
            //parameters[13].Value = modelSDProcess.ChB;
            //parameters[14].Value = modelSDProcess.KK;
            //parameters[15].Value = modelSDProcess.ZK;
            //parameters[16].Value = modelSDProcess.PiH;
            //parameters[17].Value = modelSDProcess.PG;
            //parameters[18].Value = modelSDProcess.JJ;
            //parameters[19].Value = modelSDProcess.OP;
            //parameters[20].Value = modelSDProcess.DpCodeJG;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_Order;
            _DS.UpdateSale_Order(lgIndex, cmd, model);
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Sale_Order set ");
            //strSql.Append("OBCode=@OBCode,");
            //strSql.Append("UD=@UD,");
            //strSql.Append("CsDate=@CsDate,");
            //strSql.Append("CusCode=@CusCode,");
            //strSql.Append("SpCode=@SpCode,");
            //strSql.Append("DpCodeWG=@DpCodeWG,");
            //strSql.Append("WhCode=@WhCode,");
            //strSql.Append("OGType=@OGType,");
            //strSql.Append("Notes=@Notes,");
            //strSql.Append("Remark=@Remark,");
            //strSql.Append("Freight=@Freight");
            //strSql.Append(" where ID=@ID ");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@OBCode", SqlDbType.NVarChar,50),
            //            new SqlParameter("@UD", SqlDbType.TinyInt,1), 
            //            new SqlParameter("@CsDate", SqlDbType.Date,3),  
            //            new SqlParameter("@CusCode", SqlDbType.VarChar,10),
            //            new SqlParameter("@SpCode", SqlDbType.VarChar,10),
            //            new SqlParameter("@DpCodeWG", SqlDbType.VarChar,10),
            //            new SqlParameter("@WhCode", SqlDbType.VarChar,10),
            //            new SqlParameter("@OGType", SqlDbType.TinyInt,1),
            //            new SqlParameter("@Notes", SqlDbType.NVarChar,200),
            //            new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
            //            new SqlParameter("@Freight", SqlDbType.Decimal,9),
            //            new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = model.OBCode;
            //parameters[1].Value = model.UD;
            //parameters[2].Value = model.CsDate;
            //parameters[3].Value = model.CusCode;
            //parameters[4].Value = model.SpCode;
            //parameters[5].Value = model.DpCodeWG;
            //parameters[6].Value = model.WhCode;
            //parameters[7].Value = model.OGType;
            //parameters[8].Value = model.Notes;
            //parameters[9].Value = model.Remark;
            //parameters[10].Value = model.Freight;
            //parameters[11].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_Order;
            StringBuilder strSql = new StringBuilder();
            switch (model.MType)
            {
                case "L":
                    if (model.F_SD)
                        this.UpdateSD(lgIndex, cmd, model);
                    else
                        this.UpdatePD(lgIndex, cmd, model);
                    break;

                case "F":
                    this.UpdateFD(lgIndex, cmd, model);
                    break;
                default: break;
            }
            this.UpdateExtend(lgIndex, cmd, model);
        }

        private void UpdateExtend(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            this.PrepareExtend(model);
            _DS.UpdateSale_Order_Extend(lgIndex, cmd, model.Sub_Extend);
            //MSale_Order_Extend model_Extend = model.Sub_Extend;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Sale_Order_Extend set ");
            //strSql.Append("SumQty=@SumQty,");
            //strSql.Append("SumMoney=@SumMoney,");
            //strSql.Append("SumQtyPur=@SumQtyPur,");
            //strSql.Append("SumQtyRec=@SumQtyRec,");
            //strSql.Append("SumQtySO=@SumQtySO,");
            //strSql.Append("SumQtyCs=@SumQtyCs,");
            //strSql.Append("SumQtyRt=@SumQtyRt,");
            //strSql.Append("DN=@DN,");
            //strSql.Append("DDate=@DDate,");
            //strSql.Append("Rt1=@Rt1,");
            //strSql.Append("Rt2=@Rt2,");
            //strSql.Append("Rt3=@Rt3,");
            //strSql.Append("Rt4=@Rt4,");
            //strSql.Append("Rt5=@Rt5,");
            //strSql.Append("PdCode=@PdCode,");
            //strSql.Append("PdName=@PdName,");
            //strSql.Append("LensCodeR=@LensCodeR,");
            //strSql.Append("LensCodeRR=@LensCodeRR,");
            //strSql.Append("LensCodeL=@LensCodeL,");
            //strSql.Append("LensCodeRL=@LensCodeRL,");
            //strSql.Append("SPHR=@SPHR,");
            //strSql.Append("SPHL=@SPHL,");
            //strSql.Append("CYLR=@CYLR,");
            //strSql.Append("CYLL=@CYLL,");
            //strSql.Append("X_ADDR=@X_ADDR,");
            //strSql.Append("X_ADDL=@X_ADDL");
            //strSql.Append(" where ID=@ID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@SumQty", SqlDbType.Int,4),
            //        new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
            //        new SqlParameter("@SumQtyPur", SqlDbType.Int,4),
            //        new SqlParameter("@SumQtyRec", SqlDbType.Int,4),
            //        new SqlParameter("@SumQtySO", SqlDbType.Int,4),
            //        new SqlParameter("@SumQtyCs", SqlDbType.Int,4),
            //        new SqlParameter("@SumQtyRt", SqlDbType.Int,4),
            //        new SqlParameter("@DN", SqlDbType.VarChar,100),
            //        new SqlParameter("@DDate", SqlDbType.DateTime),
            //        new SqlParameter("@Rt1", SqlDbType.VarChar,200),
            //        new SqlParameter("@Rt2", SqlDbType.VarChar,200),
            //        new SqlParameter("@Rt3", SqlDbType.VarChar,200),
            //        new SqlParameter("@Rt4", SqlDbType.VarChar,200),
            //        new SqlParameter("@Rt5", SqlDbType.VarChar,200),
            //        new SqlParameter("@PdCode", SqlDbType.VarChar,500),
            //        new SqlParameter("@PdName", SqlDbType.VarChar,500),
            //        new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
            //        new SqlParameter("@LensCodeRR", SqlDbType.VarChar,50),
            //        new SqlParameter("@LensCodeL", SqlDbType.VarChar,50),
            //        new SqlParameter("@LensCodeRL", SqlDbType.VarChar,50),
            //        new SqlParameter("@SPHR", SqlDbType.Int,4),
            //        new SqlParameter("@SPHL", SqlDbType.Int,4),
            //        new SqlParameter("@CYLR", SqlDbType.Int,4),
            //        new SqlParameter("@CYLL", SqlDbType.Int,4),
            //        new SqlParameter("@X_ADDR", SqlDbType.Int,4),
            //        new SqlParameter("@X_ADDL", SqlDbType.Int,4),
            //        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = model_Extend.SumQty;
            //parameters[1].Value = model_Extend.SumMoney;
            //parameters[2].Value = model_Extend.SumQtyPur;
            //parameters[3].Value = model_Extend.SumQtyRec;
            //parameters[4].Value = model_Extend.SumQtySO;
            //parameters[5].Value = model_Extend.SumQtyCs;
            //parameters[6].Value = model_Extend.SumQtyRt;
            //parameters[7].Value = model_Extend.DN;
            //parameters[8].Value = System.DBNull.Value;//model_Extend.DDate;
            //parameters[9].Value = model_Extend.Rt1;
            //parameters[10].Value = model_Extend.Rt2;
            //parameters[11].Value = model_Extend.Rt3;
            //parameters[12].Value = model_Extend.Rt4;
            //parameters[13].Value = model_Extend.Rt5;
            //parameters[14].Value = model_Extend.PdCode;
            //parameters[15].Value = model_Extend.PdName;
            //parameters[16].Value = model_Extend.LensCodeR;
            //parameters[17].Value = model_Extend.LensCodeRR;
            //parameters[18].Value = model_Extend.LensCodeL;
            //parameters[19].Value = model_Extend.LensCodeRL;
            //parameters[20].Value = model_Extend.SPHR;
            //parameters[21].Value = model_Extend.SPHL;
            //parameters[22].Value = model_Extend.CYLR;
            //parameters[23].Value = model_Extend.CYLL;
            //parameters[24].Value = model_Extend.X_ADDR;
            //parameters[25].Value = model_Extend.X_ADDL;
            //parameters[26].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        private void UpdateFD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Clear();
            strSql.Append("delete Sale_Order_FD_Detail");
            strSql.Append(" where ID=@ID ");
            parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25)};
            parameters[0].Value = model.ID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var modelFD_Detail in model.Sub_FD_Detail)
            {
                strSql.Clear();
                strSql.Append("insert into Sale_Order_FD_Detail(");
                strSql.Append("ID,SubID,FrameCode,Qty,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price,DeliveryName)");
                strSql.Append(" values (");
                strSql.Append("@ID,@SubID,@FrameCode,@Qty,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price,@DeliveryName)");
                parameters = new SqlParameter[] {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@QtyPur", SqlDbType.Int,4),
					new SqlParameter("@QtyRec", SqlDbType.Int,4),
					new SqlParameter("@QtySO", SqlDbType.Int,4),
					new SqlParameter("@QtyCs", SqlDbType.Int,4),
					new SqlParameter("@QtyRt", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@DeliveryName", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.ID;
                parameters[1].Value = modelFD_Detail.SubID;
                parameters[2].Value = modelFD_Detail.FrameCode;
                parameters[3].Value = modelFD_Detail.Qty;
                parameters[4].Value = modelFD_Detail.QtyPur;
                parameters[5].Value = modelFD_Detail.QtyRec;
                parameters[6].Value = modelFD_Detail.QtySO;
                parameters[7].Value = modelFD_Detail.QtyCs;
                parameters[8].Value = modelFD_Detail.QtyRt;
                parameters[9].Value = modelFD_Detail.Price;
                parameters[10].Value = modelFD_Detail.DeliveryName;
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
        }

        private void UpdatePD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            _DS.UpdateSale_Order_PD(lgIndex, cmd, model.Sub_PD);
            _DS.UpdateSale_Order_PD_Detail(lgIndex, cmd, model.Sub_PD_Detail);
            //StringBuilder strSql = new StringBuilder();
            //SqlParameter[] parameters = null;
            //var modelPD = model.Sub_PD;
            //strSql.Append("update Sale_Order_PD set ");
            //strSql.Append("F_LR=@F_LR,");
            //strSql.Append("LensCode=@LensCode,");
            //strSql.Append("LensCodeR=@LensCodeR");
            //strSql.Append(" where ID=@ID ");
            //parameters = new SqlParameter[]  {
            //        new SqlParameter("@F_LR", SqlDbType.VarChar,1),
            //        new SqlParameter("@LensCode", SqlDbType.NVarChar,50),
            //        new SqlParameter("@LensCodeR", SqlDbType.NVarChar,50),
            //        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = modelPD.F_LR;
            //parameters[1].Value = modelPD.LensCode;
            //parameters[2].Value = modelPD.LensCodeR;
            //parameters[3].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            /////////////////////////////////////////////////////////////////////////////////////////
            //strSql.Clear();
            //strSql.Append("delete Sale_Order_PD_Detail");
            //strSql.Append(" where ID=@ID ");
            //parameters = new SqlParameter[]  {
            //        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //////////////////////////////////////////////////////////////////////////////////////////////
            //foreach (var modelPD_Detail in model.Sub_PD_Detail)
            //{
            //    strSql.Clear();
            //    strSql.Append("insert into Sale_Order_PD_Detail(");
            //    strSql.Append("ID,SubID,SPH,CYL,X_ADD,Qty,QtyPur,QtyRec,QtySO,QtyCs,QtyRt,Price)");
            //    strSql.Append(" values (");
            //    strSql.Append("@ID,@SubID,@SPH,@CYL,@X_ADD,@Qty,@QtyPur,@QtyRec,@QtySO,@QtyCs,@QtyRt,@Price)");
            //    parameters = new SqlParameter[] {
            //        new SqlParameter("@ID", SqlDbType.VarChar,25),
            //        new SqlParameter("@SubID", SqlDbType.Int,4),
            //        new SqlParameter("@SPH", SqlDbType.Int,4),
            //        new SqlParameter("@CYL", SqlDbType.Int,4),
            //        new SqlParameter("@X_ADD", SqlDbType.Int,4),
            //        new SqlParameter("@Qty", SqlDbType.Int,4),
            //        new SqlParameter("@QtyPur", SqlDbType.Int,4),
            //        new SqlParameter("@QtyRec", SqlDbType.Int,4),
            //        new SqlParameter("@QtySO", SqlDbType.Int,4),
            //        new SqlParameter("@QtyCs", SqlDbType.Int,4),
            //        new SqlParameter("@QtyRt", SqlDbType.Int,4),
            //        new SqlParameter("@Price", SqlDbType.Decimal,9)};
            //    parameters[0].Value = model.ID;
            //    parameters[1].Value = modelPD_Detail.SubID;
            //    parameters[2].Value = modelPD_Detail.SPH;
            //    parameters[3].Value = modelPD_Detail.CYL;
            //    parameters[4].Value = modelPD_Detail.X_ADD;
            //    parameters[5].Value = modelPD_Detail.Qty;
            //    parameters[6].Value = modelPD_Detail.QtyPur;
            //    parameters[7].Value = modelPD_Detail.QtyRec;
            //    parameters[8].Value = modelPD_Detail.QtySO;
            //    parameters[9].Value = modelPD_Detail.QtyCs;
            //    parameters[10].Value = modelPD_Detail.QtyRt;
            //    parameters[11].Value = modelPD_Detail.Price;
            //    cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //}
        }

        private void UpdateSD(int lgIndex, SqlCommand cmd, MSale_Order model)
        {
            _DS.UpdateSale_Order_SD(lgIndex, cmd, model.Sub_SD);
            _DS.UpdateSale_Order_SD_Process(lgIndex, cmd, model.Sub_SD_Process);
            //StringBuilder strSql = new StringBuilder();
            //SqlParameter[] parameters = null;
            //foreach (var modelSD in model.Sub_SD)
            //{
            //    strSql.Clear();
            //    strSql.Append("update Sale_Order_SD set ");
            //    strSql.Append("Dia=@Dia,");
            //    strSql.Append("LensCode=@LensCode,");
            //    strSql.Append("LensCodeR=@LensCodeR,");
            //    strSql.Append("SPH=@SPH,");
            //    strSql.Append("CYL=@CYL,");
            //    strSql.Append("Axis=@Axis,");
            //    strSql.Append("X_ADD=@X_ADD,");
            //    strSql.Append("Qty=@Qty,");
            //    strSql.Append("BASE=@BASE,");
            //    strSql.Append("CT=@CT,");
            //    strSql.Append("DB=@DB,");
            //    strSql.Append("D1=@D1,");
            //    strSql.Append("D2=@D2,");
            //    strSql.Append("D3=@D3,");
            //    strSql.Append("D4=@D4,");
            //    strSql.Append("P1=@P1,");
            //    strSql.Append("P2=@P2,");
            //    strSql.Append("P3=@P3,");
            //    strSql.Append("P4=@P4");
            //    strSql.Append(" where ID=@ID and F_LR=@F_LR ");
            //    parameters = new SqlParameter[]  {
            //        new SqlParameter("@Dia", SqlDbType.Int,4),
            //        new SqlParameter("@LensCode", SqlDbType.VarChar,50),
            //        new SqlParameter("@LensCodeR", SqlDbType.VarChar,50),
            //        new SqlParameter("@SPH", SqlDbType.Int,4),
            //        new SqlParameter("@CYL", SqlDbType.Int,4),
            //        new SqlParameter("@Axis", SqlDbType.Int,4),
            //        new SqlParameter("@X_ADD", SqlDbType.Int,4),
            //        new SqlParameter("@Qty", SqlDbType.Int,4),
            //        new SqlParameter("@BASE", SqlDbType.VarChar,10),
            //        new SqlParameter("@CT", SqlDbType.VarChar,10),
            //        new SqlParameter("@DB", SqlDbType.Bit,1),
            //        new SqlParameter("@D1", SqlDbType.VarChar,10),
            //        new SqlParameter("@D2", SqlDbType.VarChar,10),
            //        new SqlParameter("@D3", SqlDbType.VarChar,10),
            //        new SqlParameter("@D4", SqlDbType.VarChar,10),
            //        new SqlParameter("@P1", SqlDbType.VarChar,10),
            //        new SqlParameter("@P2", SqlDbType.VarChar,10),
            //        new SqlParameter("@P3", SqlDbType.VarChar,10),
            //        new SqlParameter("@P4", SqlDbType.VarChar,10),
            //        new SqlParameter("@ID", SqlDbType.VarChar,25),
            //        new SqlParameter("@F_LR", SqlDbType.VarChar,1)};
            //    parameters[0].Value = modelSD.Dia;
            //    parameters[1].Value = modelSD.LensCode;
            //    parameters[2].Value = modelSD.LensCodeR;
            //    parameters[3].Value = modelSD.SPH;
            //    parameters[4].Value = modelSD.CYL;
            //    parameters[5].Value = modelSD.Axis;
            //    parameters[6].Value = modelSD.X_ADD;
            //    parameters[7].Value = modelSD.Qty;
            //    parameters[8].Value = modelSD.BASE;
            //    parameters[9].Value = modelSD.CT;
            //    parameters[10].Value = modelSD.DB;
            //    parameters[11].Value = modelSD.D1;
            //    parameters[12].Value = modelSD.D2;
            //    parameters[13].Value = modelSD.D3;
            //    parameters[14].Value = modelSD.D4;
            //    parameters[15].Value = modelSD.P1;
            //    parameters[16].Value = modelSD.P2;
            //    parameters[17].Value = modelSD.P3;
            //    parameters[18].Value = modelSD.P4;
            //    parameters[19].Value = model.ID;
            //    parameters[20].Value = modelSD.F_LR;
            //    cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            //}
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var modelSDProcess = model.Sub_SD_Process;
            //strSql.Clear();
            //strSql.Append("update Sale_Order_SD_Process set ");
            //strSql.Append("F_CusLens=@F_CusLens,");
            //strSql.Append("CXType=@CXType,");
            //strSql.Append("PD=@PD,");
            //strSql.Append("PH=@PH,");
            //strSql.Append("JY=@JY,");
            //strSql.Append("UV=@UV,");
            //strSql.Append("JS=@JS,");
            //strSql.Append("RS=@RS,");
            //strSql.Append("RSName=@RSName,");
            //strSql.Append("CS=@CS,");
            //strSql.Append("SY=@SY,");
            //strSql.Append("CB=@CB,");
            //strSql.Append("ChB=@ChB,");
            //strSql.Append("KK=@KK,");
            //strSql.Append("ZK=@ZK,");
            //strSql.Append("PiH=@PiH,");
            //strSql.Append("PG=@PG,");
            //strSql.Append("JJ=@JJ,");
            //strSql.Append("OP=@OP,");
            //strSql.Append("DpCodeJG=@DpCodeJG");
            //strSql.Append(" where ID=@ID ");
            //parameters = new SqlParameter[] {
            //        new SqlParameter("@F_CusLens", SqlDbType.Bit,1),
            //        new SqlParameter("@CXType", SqlDbType.TinyInt,1),
            //        new SqlParameter("@PD", SqlDbType.VarChar,30),
            //        new SqlParameter("@PH", SqlDbType.VarChar,30),
            //        new SqlParameter("@JY", SqlDbType.Bit,1),
            //        new SqlParameter("@UV", SqlDbType.Bit,1),
            //        new SqlParameter("@JS", SqlDbType.VarChar,15),
            //        new SqlParameter("@RS", SqlDbType.VarChar,15),
            //        new SqlParameter("@RSName", SqlDbType.NVarChar,20),
            //        new SqlParameter("@CS", SqlDbType.VarChar,15),
            //        new SqlParameter("@SY", SqlDbType.VarChar,15),
            //        new SqlParameter("@CB", SqlDbType.VarChar,15),
            //        new SqlParameter("@ChB", SqlDbType.VarChar,15),
            //        new SqlParameter("@KK", SqlDbType.VarChar,15),
            //        new SqlParameter("@ZK", SqlDbType.VarChar,15),
            //        new SqlParameter("@PiH", SqlDbType.VarChar,15),
            //        new SqlParameter("@PG", SqlDbType.VarChar,15),
            //        new SqlParameter("@JJ", SqlDbType.VarChar,15),
            //        new SqlParameter("@OP", SqlDbType.VarChar,15),
            //        new SqlParameter("@DpCodeJG", SqlDbType.VarChar,10),
            //        new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = modelSDProcess.F_CusLens;
            //parameters[1].Value = modelSDProcess.CXType;
            //parameters[2].Value = modelSDProcess.PD;
            //parameters[3].Value = modelSDProcess.PH;
            //parameters[4].Value = modelSDProcess.JY;
            //parameters[5].Value = modelSDProcess.UV;
            //parameters[6].Value = modelSDProcess.JS;
            //parameters[7].Value = modelSDProcess.RS;
            //parameters[8].Value = modelSDProcess.RSName;
            //parameters[9].Value = modelSDProcess.CS;
            //parameters[10].Value = modelSDProcess.SY;
            //parameters[11].Value = modelSDProcess.CB;
            //parameters[12].Value = modelSDProcess.ChB;
            //parameters[13].Value = modelSDProcess.KK;
            //parameters[14].Value = modelSDProcess.ZK;
            //parameters[15].Value = modelSDProcess.PiH;
            //parameters[16].Value = modelSDProcess.PG;
            //parameters[17].Value = modelSDProcess.JJ;
            //parameters[18].Value = modelSDProcess.OP;
            //parameters[19].Value = modelSDProcess.DpCodeJG;
            //parameters[20].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_Order;
            _DS.UpdateEditSale_Order(lgIndex, cmd, model);
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Sale_Order set ");
            //strSql.Append("OBCode=@OBCode,");
            //strSql.Append("Notes=@Notes,");
            //strSql.Append("Remark=@Remark");
            //strSql.Append(" where ID=@ID ");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@OBCode", SqlDbType.NVarChar,50), 
            //            new SqlParameter("@Notes", SqlDbType.NVarChar,200),
            //            new SqlParameter("@Remark", SqlDbType.NVarChar,200), 
            //            new SqlParameter("@ID", SqlDbType.VarChar,25)};
            //parameters[0].Value = model.OBCode;
            //parameters[1].Value = model.Notes;
            //parameters[2].Value = model.Remark;
            //parameters[3].Value = model.ID;
            //cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }
    }
}
