
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
    public class VMWare_Bill_Transfer_Lens : VMBillPD
    {
        #region property

        private V_Ware_Bill_Transfer_PD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_Transfer_PD;
            }
        }

        private bool isEnableCheckIn = false;
        public bool IsEnableCheckIn
        {
            get { return isEnableCheckIn; }
            set { isEnableCheckIn = value; RaisePropertyChanged("IsEnableCheckIn"); }
        }

        private bool isEnableCheckOut = false;
        public bool IsEnableCheckOut
        {
            get { return isEnableCheckOut; }
            set { isEnableCheckOut = value; RaisePropertyChanged("IsEnableCheckOut"); }
        }

        private bool isEnableUnCheckIn = false;
        public bool IsEnableUnCheckIn
        {
            get { return isEnableUnCheckIn; }
            set { isEnableUnCheckIn = value; RaisePropertyChanged("IsEnableUnCheckIn"); }
        }

        private bool isEnableUnCheckOut = false;
        public bool IsEnableUnCheckOut
        {
            get { return isEnableUnCheckOut; }
            set { isEnableUnCheckOut = value; RaisePropertyChanged("IsEnableUnCheckOut"); }
        }

        #endregion

        public VMWare_Bill_Transfer_Lens()
            : base("ID", "Ware_Bill_Transfer_PD", true)
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

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            IsEnableCheckIn = false;
            IsEnableCheckOut = false;
            IsEnableUnCheckIn = false;
            IsEnableUnCheckOut = false;
            switch (uBillState)
            {
                case UBillState.View:
                    if (string.IsNullOrEmpty(_DC.CheckerIn) && string.IsNullOrEmpty(_DC.CheckerOut))
                    {
                        this.IsEnableCheckOut = true;
                    }
                    if (string.IsNullOrEmpty(_DC.CheckerIn) && !string.IsNullOrEmpty(_DC.CheckerOut))
                    {
                        this.IsEnableUnCheckOut = true;
                    }
                    if (string.IsNullOrEmpty(_DC.CheckerIn) && !string.IsNullOrEmpty(_DC.CheckerOut))
                    {
                        this.IsEnableCheckIn = true;
                    }
                    if (!string.IsNullOrEmpty(_DC.CheckerIn))
                    {
                        this.IsEnableUnCheckIn = true;
                    }

                    break;
                case UBillState.New:

                    break;
                case UBillState.Edit:

                    break;
                case UBillState.Drop:

                    break;
                default: break;
            }
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill_Transfer();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill_Transfer;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.BType = "KFDBPD";
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
            }
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill_Transfer";
        }

        protected override string PrepareDDsInfoMainQueryName()
        {
            return "GetV_Ware_Bill_Transfer_PDBillQuery";
        }

        protected override string PrepareDDsInfoSubQueryName()
        {
            return UDSMethods.V_Ware_Bill_PDDetailList;
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
