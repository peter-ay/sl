
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
using ERP.Web.DomainService.Erp;
namespace ERP.ViewModel
{
    public class VMWare_Stocks_Base_Lens : VMBillPD
    {
        #region property

        private V_Ware_Stocks_Base_Lens _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Stocks_Base_Lens;
            }
        }

        private System.Windows.Visibility _IsShowCopy = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsShowCopy
        {
            get { return _IsShowCopy; }
            set { _IsShowCopy = value; RaisePropertyChanged("IsShowCopy"); }
        }

        private string _WhCodeCopy = "";
        public string WhCodeCopy
        {
            get { return _WhCodeCopy; }
            set { _WhCodeCopy = value; RaisePropertyChanged("WhCodeCopy"); }
        }

        private string _LensCodeCopy = "";
        public string LensCodeCopy
        {
            get { return _LensCodeCopy; }
            set { _LensCodeCopy = value; RaisePropertyChanged("LensCodeCopy"); }
        }

        private string _F_LRCopy = "";
        public string F_LRCopy
        {
            get { return _F_LRCopy; }
            set { _F_LRCopy = value; RaisePropertyChanged("F_LRCopy"); }
        }

        #endregion

        public VMWare_Stocks_Base_Lens()
            : base("ID", "Ware_Stocks_Base_Lens", true)
        {

        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Stocks_Base_Lens();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Stocks_Base_Lens;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            ////
            MWare_Stocks_Base_Lens_Detail _Item = null;
            int _SumQty = 0;
            _CM.Sub_Detail = new List<MWare_Stocks_Base_Lens_Detail>();
            foreach (V_Ware_Stocks_Base_Lens_Detail item in this.DContextSub)
            {
                _Item = new MWare_Stocks_Base_Lens_Detail()
                {
                    ID = _DC.ID,
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value,
                };
                _CM.Sub_Detail.Add(_Item);
                _SumQty += item.Qty.Value;
            }
            ////
            _CM.SumQty = _SumQty;
        }

        protected override bool VerifySave()
        {

            if (string.IsNullOrEmpty(_DC.WhCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_WhCodeNull"));
                return false;
            }

            if (string.IsNullOrEmpty(_DC.LensCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_LensCodeNull"));
                return false;
            }

            if ((this.DContextSub.Count) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_SumQtyLess0"));
                return false;
            }

            return true;
        }

        protected override void FillXYInputResultDataList(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> observableCollection)
        {
            ComXYInputListFormat _item = null;
            foreach (V_Ware_Stocks_Base_Lens_Detail item in this.DContextSub)
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
            V_Ware_Stocks_Base_Lens_Detail _item = null;
            foreach (ComXYInputListFormat item in comXYInputListFormat)
            {
                _item = new V_Ware_Stocks_Base_Lens_Detail()
                {
                    ID = "",
                    SubID = item.SubID,
                    SPH = item.SPH,
                    CYL = item.CYL,
                    X_ADD = item.X_ADD,
                    Qty = item.Qty,
                };
                this.DContextSub.Add(_item);
            }
            ComSubGridColumnUpdate _Rt = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };
            return _Rt;
        }

        protected override ComSubGridColumnUpdate GetDContextSubToUpdateSubGrid(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Ware_Stocks_Base_Lens_Detail _item = null;

            foreach (V_Ware_Stocks_Base_Lens_Detail item in items)
            {
                _item = new V_Ware_Stocks_Base_Lens_Detail()
                {
                    ID = item.ID,
                    SubID = item.SubID,
                    SPH = item.SPH,
                    CYL = item.CYL,
                    X_ADD = item.X_ADD,
                    Qty = item.Qty,
                };
                this.DContextSub.Add(_item);
            }
            ComSubGridColumnUpdate _Rt = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };

            return _Rt;
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsShowCopy = System.Windows.Visibility.Collapsed;
            this.IsEnableExport = false;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableExport = true;

                    break;
                case UBillState.New:
                    this.IsShowCopy = System.Windows.Visibility.Visible;

                    break;
                case UBillState.Edit:


                    break;
                case UBillState.Drop:

                    break;
                default: break;
            }
        }

        #region Copy

        private RelayCommand _CmdCopy;

        /// <summary>
        /// Gets the CmdCopy.
        /// </summary>
        public RelayCommand CmdCopy
        {
            get
            {
                return _CmdCopy
                    ?? (_CmdCopy = new RelayCommand(ExecuteCmdCopy));
            }
        }

        private void ExecuteCmdCopy()
        {
            var _ID = this.WhCodeCopy + this.LensCodeCopy + this.F_LRCopy;
            DSErp _DS = new DSErp();
            var p = _DS.GetV_Ware_Stocks_Base_LensDetailForCopyListQuery(USysInfo.DBCode, _ID);
            this.IsBusy = true;
            _DS.Load(p, geted =>
                {
                    this.IsBusy = false;
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }

                    if (geted.AllEntities.Count() == 0)
                    {
                        MessageErp.InfoMessage(ErpUIText.Get("Err_RecordNone"));
                        return;
                    }

                    var _Items = geted.AllEntities;
                    this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
                    V_Ware_Stocks_Base_Lens_Detail _item = null;
                    foreach (V_Ware_Stocks_Base_Lens_Detail item in _Items)
                    {
                        _item = new V_Ware_Stocks_Base_Lens_Detail()
                        {
                            ID = "",
                            SubID = item.SubID,
                            SPH = item.SPH,
                            CYL = item.CYL,
                            X_ADD = item.X_ADD,
                            Qty = item.Qty,
                        };
                        this.DContextSub.Add(_item);
                    }
                    ComSubGridColumnUpdate _Rt = new ComSubGridColumnUpdate()
                    {
                        GridName = this.VMNameAuthority,
                        Source = DContextSub
                    };

                    Messenger.Default.Send<ComSubGridColumnUpdate>(_Rt, USysMessages.RefreshSubGrid);
                    this.IsFocusMain = true;

                }, null);
        }

        #endregion

        protected override void Export()
        {
            List<string> _ExportItems = new List<string>();
            _ExportItems.Add(this.CurrentIDCode);
            DSErp _DS = new DSErp();
            this.IsBusy = true;
            var _ID = UReportID.ExcelFileName;
            var p = _DS.GetV_Ware_Stocks_Base_LensForExportQuery(USysInfo.DBCode, USysInfo.LgIndex, _ID, _ExportItems);
            _DS.Load(p, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                ComOpenURL.Open(_ID);
            }, null);
        }
    }
}
