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
    public partial class DWare_Bill_Count : DALBase
    {
        DWare _DW = new DWare();

        public DWare_Bill_Count()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return _DW.Exists(dbCode, lgIndex, "Ware_Bill_Count", vCode);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill_Count model = t as MWare_Bill_Count;
            _DW.AddWare_Bill_Count(lgIndex, cmd, model);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MWare_Bill_Count model = t as MWare_Bill_Count;
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

        private void PrepareExtend(MWare_Bill_Count model)
        {
            model.Sub_Extend = new MWare_Bill_Count_Extend()
            {
                ID = model.ID,
                SumQty1 = 0,
                SumQty2 = 0,
                SumQty = 0,
            };

            switch (model.MType)
            {
                case "L":


                    break;

                default:

                    break;
            }
        }

        private void PrepareAddExtend(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            this.PrepareExtend(model);
            _DW.AddWare_Bill_Count_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void PreparePD(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            model.Sub_PD.ID = model.ID;
            _DW.AddWare_Bill_PD(lgIndex, cmd, model.Sub_PD);

            model.Sub_PD_Detail2.ForEach(it => it.ID = model.ID);
            _DW.AddWare_Bill_Count_PD_Detail2(lgIndex, cmd, model.Sub_PD_Detail2);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Count;
            _DW.UpdateWare_Bill_Count(lgIndex, cmd, model);
        }

        protected override void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Count;
            switch (model.MType)
            {
                case "L":
                    this.UpdatePD(lgIndex, cmd, model);
                    break;

                default: break;
            }
            this.UpdateExtend(lgIndex, cmd, model);
        }

        private void UpdateExtend(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            this.PrepareExtend(model);
            _DW.UpdateWare_Bill_Count_Extend(lgIndex, cmd, model.Sub_Extend);
        }

        private void UpdatePD(int lgIndex, SqlCommand cmd, MWare_Bill_Count model)
        {
            _DW.UpdateWare_Bill_PD(lgIndex, cmd, model.Sub_PD);
            _DW.UpdateWare_Bill_Count_PD_Detail2(lgIndex, cmd, model.Sub_PD_Detail2);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MWare_Bill_Count;
            _DW.UpdateEditWare_Bill_Count(lgIndex, cmd, model);
        }
    }
}
