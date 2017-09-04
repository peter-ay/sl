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
    public partial class DWare_Bill_Transfer : DALBase
    {
        DWare _DW = new DWare();

        public DWare_Bill_Transfer()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return _DW.Exists(dbCode, lgIndex, "Ware_Bill_Transfer", vCode);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill_Transfer model = t as MWare_Bill_Transfer;
            _DW.AddWare_Bill_Transfer(lgIndex, cmd, model);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill_Transfer model = t as MWare_Bill_Transfer;
            switch (model.MType)
            {
                case "L":
                    this.PreparePD(lgIndex, cmd, model);
                    break;

                default:
                    break;
            }
            this.PrepareAddExtend(lgIndex, cmd, model);
        }

        private void PrepareExtend(MWare_Bill_Transfer model)
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
                SumQty = 0,
            };

            switch (model.MType)
            {
                case "L":

                    model.Sub_Extend.LensCodeR = model.Sub_PD.LensCode;
                    model.Sub_Extend.LensCodeL = model.Sub_PD.LensCode;
                    model.Sub_Extend.SumQty = model.Sub_PD_Detail.Sum(it => it.Qty);
                    break;

                default:

                    break;
            }
        }

        private void PrepareAddExtend(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            this.PrepareExtend(model);
            _DW.AddWare_Bill_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void PreparePD(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            model.Sub_PD.ID = model.ID;
            _DW.AddWare_Bill_PD(lgIndex, cmd, model.Sub_PD);

            model.Sub_PD_Detail.ForEach(it => it.ID = model.ID);
            _DW.AddWare_Bill_PD_Detail(lgIndex, cmd, model.Sub_PD_Detail);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Transfer;
            _DW.UpdateWare_Bill_Transfer(lgIndex, cmd, model);
        }

        protected override void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Transfer;
            switch (model.MType)
            {
                case "L":
                    this.UpdatePD(lgIndex, cmd, model);
                    break;

                default: break;
            }
            this.UpdateExtend(lgIndex, cmd, model);
        }

        private void UpdateExtend(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            this.PrepareExtend(model);
            _DW.UpdateWare_Bill_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void UpdatePD(int lgIndex, SqlCommand cmd, MWare_Bill_Transfer model)
        {
            _DW.UpdateWare_Bill_PD(lgIndex, cmd, model.Sub_PD);
            _DW.UpdateWare_Bill_PD_Detail(lgIndex, cmd, model.Sub_PD_Detail);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Transfer;
            _DW.UpdateEditWare_Bill_Transfer(lgIndex, cmd, model);
        }
    }
}
