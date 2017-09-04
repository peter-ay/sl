
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
using System.Linq;
using ERP.Web.Model;
namespace ERP.ViewModel
{
    public class VMWare_Bill_OI_Lens : VMBillPD
    {
        #region property

        private V_Ware_Bill_PD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_PD;
            }
        }

        #endregion

        public VMWare_Bill_OI_Lens()
            : base("ID", "Ware_Bill_PD")
        {
            this.InitMessages();
        }

        private void InitMessages()
        {
            //Messenger.Default.Register<string>(this, this.VMName + "_NewSOFromList", (msg) =>
            //{
            //    this._IDSale = msg;
            //    this.NewSO();
            //});
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.BType = "KFOIPD";
            _CM.F_IO = true;
            _CM.F_SD = false;
            _CM.MType = "L";
            //
            _CM.Sub_PD = new MWare_Bill_PD()
            {
                ID = _DC.ID,
                F_LR = _DC.F_LR,
                LensCode = _DC.LensCode
            };
            //
            MWare_Bill_PD_Detail _Item = null;
            int _SumQty = 0;
            _CM.Sub_PD_Detail = new List<MWare_Bill_PD_Detail>();
            foreach (V_Ware_Bill_PD_Detail item in this.DContextSub)
            {
                _Item = new MWare_Bill_PD_Detail()
                {
                    ID = _DC.ID,
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value,
                    Price = 0
                };
                _CM.Sub_PD_Detail.Add(_Item);
                _SumQty += item.Qty.Value;
            }
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill";
        }

        protected override string PrepareDDsInfoMainQueryName()
        { 
            return "GetV_Ware_Bill_OI_PDBillQuery";
        }

        protected override void FillXYInputResultDataList(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> observableCollection)
        {
            ComXYInputListFormat _item = null;
            foreach (V_Ware_Bill_PD_Detail item in this.DContextSub)
            {
                _item = new ComXYInputListFormat()
                {
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value,
                };
                observableCollection.Add(_item);
            }
        }

        protected override ComSubGridColumnUpdate GetReturnXYData(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> comXYInputListFormat)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Ware_Bill_PD_Detail _item = null;

            foreach (ComXYInputListFormat item in comXYInputListFormat)
            {
                _item = new V_Ware_Bill_PD_Detail()
                {
                    ID = "",
                    SubID = item.SubID,
                    SPH = item.SPH,
                    CYL = item.CYL,
                    X_ADD = item.X_ADD,
                    Qty = item.Qty,
                    Price = 0
                };
                this.DContextSub.Add(_item);
            }

            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };
            return t;
        }

        protected override ComSubGridColumnUpdate GetDContextSubToUpdateSubGrid(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Ware_Bill_PD_Detail _item = null;

            foreach (V_Ware_Bill_PD_Detail item in items)
            {
                _item = new V_Ware_Bill_PD_Detail()
                {
                    CYL = item.CYL,
                    ID = item.ID,
                    Price = item.Price,
                    Qty = item.Qty,
                    X_ADD = item.X_ADD,
                    SPH = item.SPH,
                    SubID = item.SubID
                };
                this.DContextSub.Add(_item);
            }
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };

            return t;
        }
    }
}
