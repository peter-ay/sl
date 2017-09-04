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
    public partial class DWare_Bill : DALBase
    {
        DWare _DW = new DWare();

        public DWare_Bill()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return _DW.Exists(dbCode, lgIndex, "Ware_Bill", vCode);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill _model = t as MWare_Bill;
            _DW.AddWare_Bill(lgIndex, cmd, _model);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill _model = t as MWare_Bill;
            switch (_model.MType)
            {
                case "L":
                    if (_model.F_SD)
                    {
                        this.PrepareAddSD(lgIndex, cmd, _model);
                    }
                    else
                    {
                        this.PrepareAddPD(lgIndex, cmd, _model);
                    }
                    break;

                default:
                    break;
            }
            this.PrepareAddExtend(lgIndex, cmd, _model);
        }

        private void PrepareAddSD(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            model.Sub_SD.ForEach(it => it.ID = model.ID);
            _DW.AddWare_Bill_SD(lgIndex, cmd, model.Sub_SD);
        }

        private void PrepareExtend(MWare_Bill model)
        {
            model.Sub_Extend = new MWare_Bill_Extend()
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
                SCode = "",
                QtyR = 0,
                QtyL = 0,
                SumQty = 0,
                SumMoney = 0,
                PriceL = 0,
                PriceR = 0,
                ProCostL = 0,
                ProCostR = 0
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
                        model.Sub_Extend.QtyR = model.Sub_SD[0].Qty;
                        model.Sub_Extend.QtyL = model.Sub_SD[1].Qty;
                        model.Sub_Extend.SumQty = model.Sub_SD[0].Qty + model.Sub_SD[1].Qty;
                        model.Sub_Extend.SumMoney = model.Sub_SD[0].Qty * model.Sub_SD[0].Price + model.Sub_SD[1].Qty * model.Sub_SD[1].Price;
                        model.Sub_Extend.PriceR = model.Sub_SD[0].Price;
                        model.Sub_Extend.PriceL = model.Sub_SD[1].Price;
                        model.Sub_Extend.ProCostR = model.Sub_SD[0].ProCost;
                        model.Sub_Extend.ProCostL = model.Sub_SD[1].ProCost;
                    }
                    else
                    {
                        model.Sub_Extend.LensCodeR = model.Sub_PD.LensCode;
                        model.Sub_Extend.LensCodeL = model.Sub_PD.LensCode;
                        model.Sub_Extend.SumQty = model.Sub_PD_Detail.Sum(it => it.Qty);
                        model.Sub_Extend.SumMoney = model.Sub_PD_Detail.Sum(it => it.Qty * it.Price);
                    }
                    break;

                default:

                    break;
            }
        }

        private void PrepareAddExtend(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            this.PrepareExtend(model);
            _DW.AddWare_Bill_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void PrepareAddPD(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            model.Sub_PD.ID = model.ID;
            _DW.AddWare_Bill_PD(lgIndex, cmd, model.Sub_PD);

            model.Sub_PD_Detail.ForEach(it => it.ID = model.ID);
            _DW.AddWare_Bill_PD_Detail(lgIndex, cmd, model.Sub_PD_Detail);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var _model = t as MWare_Bill;
            _DW.UpdateWare_Bill(lgIndex, cmd, _model);
        }

        protected override void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill;
            switch (model.MType)
            {
                case "L":
                    if (model.F_SD)
                    {
                        this.UpdateSD(lgIndex, cmd, model);
                    }
                    else
                    {
                        this.UpdatePD(lgIndex, cmd, model);
                    }
                    break;

                default: break;
            }
            this.UpdateExtend(lgIndex, cmd, model);
        }

        private void UpdateExtend(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            this.PrepareExtend(model);
            _DW.UpdateWare_Bill_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void UpdatePD(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            var _modelPD = model.Sub_PD;
            _DW.UpdateWare_Bill_PD(lgIndex, cmd, _modelPD);

            var _modelPD_Detail = model.Sub_PD_Detail;
            _DW.UpdateWare_Bill_PD_Detail(lgIndex, cmd, _modelPD_Detail);
        }

        private void UpdateSD(int lgIndex, SqlCommand cmd, MWare_Bill model)
        {
            _DW.UpdateWare_Bill_SD(lgIndex, cmd, model.Sub_SD);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill;
            _DW.UpdateEditWare_Bill(lgIndex, cmd, model);
        }
    }
}
