
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
    public class VMWare_Bill_Count_Lens : VMBillPD
    {
        #region property

        CH_PDChoose _CP = null;

        private V_Ware_Bill_Count_PD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_Count_PD;
            }
        }

        private bool _IsEnablePDChoose = false;
        public bool IsEnablePDChoose
        {
            get { return _IsEnablePDChoose; }
            set { _IsEnablePDChoose = value; RaisePropertyChanged("IsEnablePDChoose"); }
        }

        private bool _IsEnablePDStart = false;
        public bool IsEnablePDStart
        {
            get { return _IsEnablePDStart; }
            set { _IsEnablePDStart = value; RaisePropertyChanged("IsEnablePDStart"); }
        }

        private bool _IsEnablePDEnd = false;
        public bool IsEnablePDEnd
        {
            get { return _IsEnablePDEnd; }
            set { _IsEnablePDEnd = value; RaisePropertyChanged("IsEnablePDEnd"); }
        }

        #endregion

        public VMWare_Bill_Count_Lens()
            : base("ID", "Ware_Bill_Count_PD", true)
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

            this.IsEnablePDChoose = false;
            this.IsEnablePDStart = false;
            this.IsEnablePDEnd = false;

            switch (uBillState)
            {
                case UBillState.View:
                    if (string.IsNullOrEmpty(this._DC.Starter))
                    {
                        this.IsEnablePDStart = true;
                        this.IsEnableDelete = true;
                    }
                    if (!string.IsNullOrEmpty(this._DC.Starter) && string.IsNullOrEmpty(this._DC.Ender))
                    {
                        this.IsEnablePDEnd = true;
                    }
                    break;
                case UBillState.New:
                    this.IsEnablePDChoose = true;

                    break;
                case UBillState.Edit:
                    this.IsEnablePDChoose = true;
                    break;
                case UBillState.Drop:

                    break;
                default: break;
            }
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill_Count();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill_Count;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.BType = "KFPDPD";
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

            //_CM.Sub_PD_Detail2 = new List<MWare_Bill_Count_PD_Detail2>();
            //foreach (V_Ware_Bill_Count_PD_Detail item in this.DContextSub)
            //{
            //    _Item = new MWare_Bill_Count_PD_Detail2()
            //    {
            //        ID = _DC.ID,
            //        SubID = item.SubID.Value,
            //        SPH = item.SPH.Value,
            //        CYL = item.CYL.Value,
            //        X_ADD = item.X_ADD.Value,
            //        Qty = item.Qty.Value,
            //        Price = 0
            //    };
            //    _CM.Sub_PD_Detail2.Add(_Item);
            //}
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill_Count";
        }

        protected override string PrepareDDsInfoMainQueryName()
        {
            return "GetV_Ware_Bill_Count_PDBillQuery";
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

        #region Method

        private RelayCommand _CmdPDChoose;

        /// <summary>
        /// Gets the CmdPDChoose.
        /// </summary>
        public RelayCommand CmdPDChoose
        {
            get
            {
                return _CmdPDChoose
                    ?? (_CmdPDChoose = new RelayCommand(ExecuteCmdPDChoose));
            }
        }

        private void ExecuteCmdPDChoose()
        {
            var _CH_PDChoose = _CP ?? new CH_PDChoose();
            _CH_PDChoose.Closed += (e, s) =>
                {
                    if (_CH_PDChoose.DialogResult != true)
                        return;
                    var _VMPDChoose = _CH_PDChoose.DataContext as VMCH_PDChoose;
                    this._DC.LensCode = _VMPDChoose.LensCodeSelected;
                    this._DC.F_LR = _VMPDChoose.F_LR;
                    this._DC.WhCode = _VMPDChoose.WhCodeSelected;
                    this.IsFocusMain = true;
                };
            _CH_PDChoose.Show();
        }

        #endregion


    }
}
