
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using ERP.Web.DomainService.Erp;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMSale_Order_JM : VMBillPD
    {
        #region property

        private V_Sale_Order_PD _DC
        {
            get
            {
                return this.DContextMain as V_Sale_Order_PD;
            }
        }

        #region UD类型

        private bool _IsEnableUD = false;
        public bool IsEnableUD
        {
            get { return _IsEnableUD; }
            set { _IsEnableUD = value; RaisePropertyChanged("IsEnableUD"); }
        }

        //
        private bool _IsCheckUD0 = true;
        public bool IsCheckUD0
        {
            get { return _IsCheckUD0; }
            set { _IsCheckUD0 = value; RaisePropertyChanged("IsCheckUD0"); }

        }
        private bool _IsCheckUD1 = true;
        public bool IsCheckUD1
        {
            get { return _IsCheckUD1; }
            set { _IsCheckUD1 = value; RaisePropertyChanged("IsCheckUD1"); }
        }

        private bool _IsCheckUD2 = false;
        public bool IsCheckUD2
        {
            get { return _IsCheckUD2; }
            set { _IsCheckUD2 = value; RaisePropertyChanged("IsCheckUD2"); }
        }

        private bool _IsCheckUD3 = false;
        public bool IsCheckUD3
        {
            get { return _IsCheckUD3; }
            set { _IsCheckUD3 = value; RaisePropertyChanged("IsCheckUD3"); }
        }

        #endregion

        #region OG 类型

        private bool _IsEnableOG = true;
        public bool IsEnableOG
        {
            get { return _IsEnableOG; }
            set { _IsEnableOG = value; RaisePropertyChanged("IsEnableOG"); }
        }

        private bool _IsCheckOG1 = true;
        public bool IsCheckOG1
        {
            get { return _IsCheckOG1; }
            set { _IsCheckOG1 = value; RaisePropertyChanged("IsCheckOG1"); }
        }

        private bool _IsCheckOG2 = false;
        public bool IsCheckOG2
        {
            get { return _IsCheckOG2; }
            set { _IsCheckOG2 = value; RaisePropertyChanged("IsCheckOG2"); }
        }

        #endregion

        #region WGRC

        private bool _IsEnableRCNew = false;
        public bool IsEnableRCNew
        {
            get { return _IsEnableRCNew; }
            set { _IsEnableRCNew = value; RaisePropertyChanged("IsEnableRCNew"); }
        }

        private bool _IsEnableRCList = false;
        public bool IsEnableRCList
        {
            get { return _IsEnableRCList; }
            set { _IsEnableRCList = value; RaisePropertyChanged("IsEnableRCList"); }
        }

        #endregion

        #endregion

        public VMSale_Order_JM()
            : base("ID", "Sale_Order_PD", true)
        {
        }

        //protected override string PrepareDDsInfoMainQueryName()
        //{
        //    return "GetV_Sale_Order_JMBill";
        //}

        //protected override string PrepareDDsInfoSubQueryName()
        //{
        //    return "GetV_Sale_Order_JMDetailList";
        //}

        //protected override void PrepareDContextMain()
        //{
        //    this.DContextMain = new V_Sale_Order_JM();
        //}

        //protected override void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        //{
        //    base.PrepareDDsInfoMainParameters(ispnIndex);
        //    this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
        //}
        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            this.ReSetUD();
            this.ReSetOG();
        }

        private void ReSetUD()
        {
            try
            {
                switch (_DC.UD)
                {
                    case 1:
                        this.IsCheckUD1 = true;
                        break;
                    case 2:
                        this.IsCheckUD2 = true;
                        break;
                    case 3:
                        this.IsCheckUD3 = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void ReSetOG()
        {
            try
            {
                switch (_DC.OGType)
                {
                    case 1:
                        this.IsCheckOG1 = true;
                        break;
                    case 2:
                        this.IsCheckOG2 = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MSale_Order();
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnableUD = false;
            this.IsEnableOG = false;
            this.IsEnableRCNew = false;
            this.IsEnableRCList = false;
            //var cDC = this.DContextMain as V_Sale_Order_JM;
            //this.IsEnableXYInPut = false;

            switch (uBillState)
            {
                case UBillState.View:
                    if (_DC.OGType == 2)
                    {
                        this.IsEnableRCNew = true;
                        this.IsEnableRCList = true;
                    }
                    break;
                case UBillState.Drop:

                    break;

                case UBillState.New:
                    this.IsEnableUD = true;
                    this.IsEnableOG = true;

                    this.IsCheckUD1 = true;
                    this.IsCheckOG1 = true;
                    break;
                case UBillState.Edit:

                    if (string.IsNullOrEmpty(_DC.Checker))
                    {
                        if (!string.IsNullOrEmpty(_DC.CusCode))
                        {
                            ComHelpLensCode.LoadCusLensCodeSmartPD(_DC.CusCode);
                        }
                        this.IsEnableUD = true;
                        this.IsEnableOG = true;

                    }

                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.CusCode = " " + this._DC.CusCode;
            this._DC.CusCode = this._DC.CusCode.Trim();
            ///////////////////////////////////////////
            this._DC.LensCode = " " + this._DC.LensCode;
            this._DC.LensCode = this._DC.LensCode.Trim();
            ////////////////////////////////////////////////////////////////
            this._DC.LensCodeR = " " + this._DC.LensCodeR;
            this._DC.LensCodeR = this._DC.LensCodeR.Trim();
            ///////////////////////////////////////////////
            this._DC.WhCode = " " + this._DC.WhCode;
            this._DC.WhCode = this._DC.WhCode.Trim();
            ///////////////////////////////////////////////
            this._DC.SpCode = " " + this._DC.SpCode;
            this._DC.SpCode = this._DC.SpCode.Trim();
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //private RelayCommand<KeyEventArgs> _CmdKeyDownSupplierCode;

        ///// <summary>
        ///// Gets the CmdKeyDownSupplierCode.
        ///// </summary>
        //public RelayCommand<KeyEventArgs> CmdKeyDownSupplierCode
        //{
        //    get
        //    {
        //        return _CmdKeyDownSupplierCode
        //            ?? (_CmdKeyDownSupplierCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownSupplierCode));
        //    }
        //}

        //private void ExecuteCmdKeyDownSupplierCode(KeyEventArgs parameter)
        //{
        //    if (parameter.Key != Key.Enter)
        //        return;

        //    var cDX = this.DContextMain as V_Sale_Order_JM;
        //    if (cDX == null || cDX.EditState != 1)
        //        return;

        //    this.GetDefaultSupplierCode();
        //}

        //private Lazy<DSGetDefaultSupplierCode> dsgetdefaultsuppliercode = new Lazy<DSGetDefaultSupplierCode>();
        //private void GetDefaultSupplierCode()
        //{
        //    var cDC = this.DContextMain as V_Sale_Order_JM;
        //    var cuscode = cDC.CusCode.Trim();
        //    var mnumber = cDC.Mnumber.Trim();

        //    string processCodes = "";

        //    cDC.SupplierName = ErpUIText.Get("ERP_Getting");
        //    dsgetdefaultsuppliercode.Value.Get(cuscode, mnumber, processCodes, geted =>
        //    {
        //        cDC.SupplierCode = "";
        //        cDC.SupplierName = "";
        //        if (geted.HasError)
        //        {
        //            //USysInfo.ErrMsg = geted.Error.Message;
        //            //USysInfo.ErrMsg = ErpUIText.ErrMsg + USysInfo.ErrMsg.Substring(USysInfo.ErrMsg.IndexOf('.') + 1);
        //            MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
        //            geted.MarkErrorAsHandled();
        //            return;
        //        }
        //        cDC.SupplierCode = geted.Value;
        //        this.IsFocusSupplierCode = true;
        //    }, null);
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override string PrepareDSBill()
        {
            return "Sale_Order";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MSale_Order;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();

            _CM.BType = "XSJM";
            _CM.MType = "L";
            _CM.F_FS = false;
            _CM.F_SD = false;

            if (string.IsNullOrEmpty(_DC.LensCodeR))
            {
                _DC.LensCodeR = _DC.LensCode;
            }

            _CM.Sub_PD = new MSale_Order_PD()
                {
                    ID = _DC.ID.Trim(),
                    InvTitle = "",
                    F_LR = _DC.F_LR.Trim(),
                    LensCode = _DC.LensCode.Trim(),
                    LensCodeR = _DC.LensCodeR.Trim()
                };

            _CM.Sub_PD_Detail = new List<MSale_Order_PD_Detail>();
            MSale_Order_PD_Detail _item = null;
            var _SumQty = 0;
            foreach (V_Sale_Order_PD_Detail item in this.DContextSub)
            {
                _item = new MSale_Order_PD_Detail()
                {
                    ID = _DC.ID.Trim(),
                    CYL = item.CYL.Value,
                    Price = 0,
                    Qty = item.Qty.Value,
                    QtyPur = 0,
                    QtyRec = 0,
                    QtySO = 0,
                    QtyCs = 0,
                    QtyRt = 0,
                    SPH = item.SPH.Value,
                    SubID = item.SubID,
                    X_ADD = item.X_ADD.Value,

                };
                _CM.Sub_PD_Detail.Add(_item);
                _SumQty += _item.Qty;
            }

            _CM.Sub_Extend = new MSale_Order_Extend()
            {
                ID = _CM.ID,
                LensCodeR = _DC.LensCode,
                LensCodeL = _DC.LensCode,
                SPHR = 0,
                SPHL = 0,
                CYLR = 0,
                CYLL = 0,
                X_ADDR = 0,
                X_ADDL = 0,
                DN = "",
                SumQty = _SumQty,
                SumQtySO = 0,
                SumQtyCs = 0,
                SumQtyRt = 0,
                SumQtyPur = 0,
                SumQtyRec = 0,
                PdCode = "",
                PdName = "",
                Rt1 = "",
                Rt2 = "",
                Rt3 = "",
                Rt4 = "",
                Rt5 = "",
                SumMoney = 0
            };
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override bool VerifySave()
        {
            //////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(_DC.CusCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////////
            if ((this.DContextSub.Count) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_SumQtyLess"));
                return false;
            }

            ///////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(_DC.WhCode) && string.IsNullOrEmpty(_DC.SpCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_WGorWhCode"));
                return false;
            }

            if (!string.IsNullOrEmpty(_DC.WhCode) && !string.IsNullOrEmpty(_DC.SpCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_WGandWhCode"));
                return false;
            }

            return true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void FillXYInputResultDataList(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> observableCollection)
        {
            ComXYInputListFormat _item = null;
            foreach (V_Sale_Order_PD_Detail item in this.DContextSub)
            {
                _item = new ComXYInputListFormat()
                {
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value
                };
                observableCollection.Add(_item);
            }
        }

        protected override ComSubGridColumnUpdate GetReturnXYData(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> comXYInputListFormat)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Sale_Order_PD_Detail _item = null;
            foreach (ComXYInputListFormat item in comXYInputListFormat)
            {
                _item = new V_Sale_Order_PD_Detail()
                {
                    ID = "",
                    SubID = item.SubID,
                    SPH = item.SPH,
                    CYL = item.CYL,
                    X_ADD = item.X_ADD,
                    Qty = item.Qty,
                    QtyCs = 0,
                    QtyRt = 0,
                    QtyUnCs = item.Qty,
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
            V_Sale_Order_PD_Detail _item = null;

            foreach (V_Sale_Order_PD_Detail item in items)
            {
                _item = new V_Sale_Order_PD_Detail()
                {
                    CYL = item.CYL,
                    ID = item.ID,
                    Price = item.Price,
                    Qty = item.Qty,
                    QtyCs = item.QtyCs,
                    QtyUnCs = item.QtyUnCs,
                    QtyRt = item.QtyRt,
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

        protected override void Export()
        {
            DSErp _DS = new DSErp();
            this.IsBusy = true;
            //var _ID = UReportID.ExcelFileName;
            var _ID = this._DC.BCode + ".xls";
            var p = _DS.GetV_Sale_Order_PDBillForExportQuery(USysInfo.DBCode, USysInfo.LgIndex, _ID, this.CurrentIDCode);
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

        protected override void Print()
        {
            //base.Print();
            var _FunCode = "Sale_Delivery_Lens_List";
            ComOpenWins.Open("", _FunCode);
            Messenger.Default.Send<string>(this._DC.BCode, _FunCode + "_MsgIDChange");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region RBUDCheck

        private RelayCommand<string> _CmdRBUDCheck;
        /// <summary>
        /// Gets the CmdRBUDCheck.
        /// </summary>
        public RelayCommand<string> CmdRBUDCheck
        {
            get
            {
                return _CmdRBUDCheck
                    ?? (_CmdRBUDCheck = new RelayCommand<string>(ExecuteCmdRBUDCheck));
            }
        }

        private void ExecuteCmdRBUDCheck(string parameter)
        {
            try
            {
                _DC.UD = Convert.ToByte(parameter);
            }
            catch
            {
                if (_DC != null)
                {
                    _DC.UD = 1;
                }
            }
        }

        #endregion

        #region CmdRBCdiOG

        private RelayCommand<string> _CmdRBCdiOG;
        /// <summary>
        /// Gets the CmdRBCdiOG.
        /// </summary>
        public RelayCommand<string> CmdRBCdiOG
        {
            get
            {
                return _CmdRBCdiOG
                    ?? (_CmdRBCdiOG = new RelayCommand<string>(ExecuteCmdRBCdiOG));
            }
        }

        private void ExecuteCmdRBCdiOG(string parameter)
        {
            try
            {
                _DC.OGType = Convert.ToByte(parameter);
            }
            catch
            {
                if (_DC != null)
                {
                    _DC.OGType = 1;
                }
            }
            switch (_DC.OGType)
            {
                case 1:
                    if (this._DC.WhCode == "")
                    {
                        this._DC.WhCode = ComHelpWhCode.UHV_B_Warehouse_Browse.OrderBy(item => item.Priority).FirstOrDefault().WhCode;
                        this._DC.SpCode = "";
                        this._DC.DpCodeWG = "";
                    }
                    break;

                case 2:
                    if (this._DC.SpCode == "")
                    {
                        this._DC.WhCode = "";
                        this._DC.SpCode = "T1";
                    }
                    break;

                default: break;
            }
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////

        #region RCNew

        private RelayCommand _CmdRCNew;

        /// <summary>
        /// Gets the CmdRCNew.
        /// </summary>
        public RelayCommand CmdRCNew
        {
            get
            {
                return _CmdRCNew
                    ?? (_CmdRCNew = new RelayCommand(ExecuteCmdRCNew));
            }
        }

        private void ExecuteCmdRCNew()
        {
            var _ID = _DC.ID;
            var _VMCode = "VMSale_Rec_PD";
            var _FunCode = "Sale_Rec_PD";
            var _VName = ErpUIText.Get(_FunCode);
            ComOpenWins.Open("", _FunCode, _VName);
            Messenger.Default.Send<string>((_ID), _VMCode + "_NewWGSOFromList");
        }


        #endregion

        #region RCList

        private RelayCommand _CmdRCList;

        /// <summary>
        /// Gets the CmdRCList.
        /// </summary>
        public RelayCommand CmdRCList
        {
            get
            {
                return _CmdRCList
                    ?? (_CmdRCList = new RelayCommand(ExecuteCmdRCList));
            }
        }

        private void ExecuteCmdRCList()
        {
            var _FunCode = "Sale_Rec_Lens_List";
            ComOpenWins.Open("", _FunCode);
            Messenger.Default.Send<string>(this._DC.BCode, _FunCode + "_MsgIDChange");
        }


        #endregion

    }
}
