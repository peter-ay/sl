
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using ERP.Web.DomainService.Erp;

namespace ERP.ViewModel
{
    public class VMSale_Order_SD : VMBill
    {
        #region 独有属性

        private V_Sale_Order_SD _DC
        {
            get
            {
                return this.DContextMain as V_Sale_Order_SD;
            }
        }

        #region IsShowProcess
        private Visibility _IsShowACProcessCF = Visibility.Visible;
        public Visibility IsShowACProcessCF
        {
            get { return _IsShowACProcessCF; }
            set
            {
                _IsShowACProcessCF = value;
                RaisePropertyChanged("IsShowACProcessCF");
            }
        }

        private Visibility _IsShowACProcessKF = Visibility.Collapsed;
        public Visibility IsShowACProcessKF
        {
            get { return _IsShowACProcessKF; }
            set
            {
                _IsShowACProcessKF = value;
                RaisePropertyChanged("IsShowACProcessKF");
            }
        }
        #endregion

        #region CX 类型

        private bool _IsEnableCX = false;
        public bool IsEnableCX
        {
            get { return _IsEnableCX; }
            set { _IsEnableCX = value; RaisePropertyChanged("IsEnableCX"); }
        }

        private bool _IsCheckCXNone = true;
        public bool IsCheckCXNone
        {
            get { return _IsCheckCXNone; }
            set { _IsCheckCXNone = value; RaisePropertyChanged("IsCheckCXNone"); }
        }

        private bool _IsCheckCXLJ = false;
        public bool IsCheckCXLJ
        {
            get { return _IsCheckCXLJ; }
            set { _IsCheckCXLJ = value; RaisePropertyChanged("IsCheckCXLJ"); }
        }

        private bool _IsCheckCXFLJ = false;
        public bool IsCheckCXFLJ
        {
            get { return _IsCheckCXFLJ; }
            set { _IsCheckCXFLJ = value; RaisePropertyChanged("IsCheckCXFLJ"); }
        }

        #endregion

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

        //private bool isFocusLensCodeR = false;
        //public bool IsFocusLensCodeR
        //{
        //    get { return isFocusLensCodeR; }
        //    set
        //    {
        //        isFocusLensCodeR = false;
        //        RaisePropertyChanged("IsFocusLensCodeR");
        //        isFocusLensCodeR = true;
        //        RaisePropertyChanged("IsFocusLensCodeR");
        //    }
        //}

        //private bool isFocusLensCodeL = false;
        //public bool IsFocusLensCodeL
        //{
        //    get { return isFocusLensCodeL; }
        //    set
        //    {
        //        isFocusLensCodeL = false;
        //        RaisePropertyChanged("IsFocusLensCodeL");
        //        isFocusLensCodeL = true;
        //        RaisePropertyChanged("IsFocusLensCodeL");
        //    }
        //}
        ////
        //private bool isFocusLensCodeRR = false;
        //public bool IsFocusLensCodeRR
        //{
        //    get { return isFocusLensCodeRR; }
        //    set
        //    {
        //        isFocusLensCodeRR = false;
        //        RaisePropertyChanged("IsFocusLensCodeRR");
        //        isFocusLensCodeRR = true;
        //        RaisePropertyChanged("IsFocusLensCodeRR");
        //    }
        //}

        //private bool isFocusLensCodeRL = false;
        //public bool IsFocusLensCodeRL
        //{
        //    get { return isFocusLensCodeRL; }
        //    set
        //    {
        //        isFocusLensCodeRL = false;
        //        RaisePropertyChanged("IsFocusLensCodeRL");
        //        isFocusLensCodeRL = true;
        //        RaisePropertyChanged("IsFocusLensCodeRL");
        //    }
        //}

        #endregion

        public VMSale_Order_SD()
            : base("ID", "Sale_Order_SD", true)
        {
            this.InitMessages();
        }

        private void InitMessages()
        {
            //Messenger.Default.Register<string>(this, "Sale_Order_SDPrintPreView" + "_ReturnNoMsg", (msg) =>
            //{
            //    var dc = this.DContextMain as V_Sale_Order_SD;
            //if (string.IsNullOrEmpty(dc.DeliveryNum))
            //    this.Search();
            //});

            Messenger.Default.Register<bool>(this, USysMessages.SDProcessUpdate, (msg) =>
            {
                if (msg)
                {
                    this.IsShowACProcessCF = Visibility.Visible;
                    this.IsShowACProcessKF = Visibility.Collapsed;
                }
                else
                {
                    this.IsShowACProcessCF = Visibility.Collapsed;
                    this.IsShowACProcessKF = Visibility.Visible;
                }
            });
        }

        #region methods

        protected override void PrepareModel()
        {
            this.CurrentModel = new MSale_Order();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MSale_Order;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            // 
            _CM.MType = "L";
            _CM.F_FS = false;
            _CM.F_SD = true;
            //
            _CM.Sub_SD = new List<MSale_Order_SD>();
            MSale_Order_SD sub_SD = null;
            for (int i = 0; i <= 1; i++)
            {
                sub_SD = new MSale_Order_SD()
                {
                    ID = _CM.ID,
                    Axis = i == 0 ? _DC.AxisR.Value : _DC.AxisL.Value,
                    CT = i == 0 ? _DC.CTR.Trim() : _DC.CTL.Trim(),
                    CYL = i == 0 ? _DC.CYLR.Value : _DC.CYLL.Value,
                    Qty = i == 0 ? _DC.QtyR.Value : _DC.QtyL.Value,
                    SPH = i == 0 ? _DC.SPHR.Value : _DC.SPHL.Value,
                    DB = i == 0 ? _DC.DBR : _DC.DBL,
                    D1 = i == 0 ? _DC.D1R.Trim() : _DC.D1L.Trim(),
                    D2 = i == 0 ? _DC.D2R.Trim() : _DC.D2L.Trim(),
                    D3 = i == 0 ? _DC.D3R.Trim() : _DC.D3L.Trim(),
                    D4 = i == 0 ? _DC.D4R.Trim() : _DC.D4L.Trim(),
                    Dia = i == 0 ? _DC.DiaR.Value : _DC.DiaL.Value,
                    BASE = i == 0 ? _DC.BASER.Trim() : _DC.BASEL.Trim(),
                    LensCode = i == 0 ? _DC.LensCodeR.Trim() : _DC.LensCodeL.Trim(),
                    LensCodeR = i == 0 ? _DC.LensCodeRR.Trim() : _DC.LensCodeRL.Trim(),
                    P1 = i == 0 ? _DC.P1R.Trim() : _DC.P1L.Trim(),
                    P2 = i == 0 ? _DC.P2R.Trim() : _DC.P2L.Trim(),
                    P3 = i == 0 ? _DC.P3R.Trim() : _DC.P3L.Trim(),
                    P4 = i == 0 ? _DC.P4R.Trim() : _DC.P4L.Trim(),
                    X_ADD = i == 0 ? _DC.X_ADDR.Value : _DC.X_ADDL.Value,
                    Price = 0,
                    ProCost = 0,
                    ProCostReport = "",
                    ProReport = "",
                    F_LR = i == 0 ? "R" : "L",
                    InvTitle = "",
                    QtySO = 0,
                    QtyCs = 0,
                    QtyRt = 0,
                    QtyPur = 0,
                    QtyRec = 0
                };
                _CM.Sub_SD.Add(sub_SD);
            }

            _CM.Sub_SD_Process = new MSale_Order_SD_Process();
            ComCopyProperties.Copy(_CM.Sub_SD_Process, this.DContextMain);

            _CM.Sub_Extend = new MSale_Order_Extend()
            {
                ID = _CM.ID,
                LensCodeR = _DC.LensCodeR,
                LensCodeRR = _DC.LensCodeRR,
                LensCodeRL = _DC.LensCodeRL,
                LensCodeL = _DC.LensCodeL,
                SPHR = _DC.SPHR.Value,
                SPHL = _DC.SPHL.Value,
                CYLR = _DC.CYLR.Value,
                CYLL = _DC.CYLL.Value,
                X_ADDR = _DC.X_ADDR.Value,
                X_ADDL = _DC.X_ADDL.Value,
                DN = "",
                SumQty = _DC.QtyR.Value + _DC.QtyL.Value,
                SumQtySO = 0,
                SumQtyCs = 0,
                SumQtyRt = 0,
                SumQtyPur = 0,
                SumQtyRec = 0,
                Rt1 = "",
                Rt2 = "",
                Rt3 = "",
                Rt4 = "",
                Rt5 = "",
                PdCode = "",
                PdName = "",
                SumMoney = 0
            };
        }

        protected override string PrepareDSBill()
        {
            return "Sale_Order";
        }

        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            this.ReSetUD();
            this.ReSetCXType();
            this.ReSetOG();
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

        private void ReSetCXType()
        {
            try
            {
                switch (_DC.CXType)
                {
                    case 1:
                        this.IsCheckCXNone = true;
                        break;
                    case 2:
                        this.IsCheckCXLJ = true;
                        break;
                    case 3:
                        this.IsCheckCXFLJ = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
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

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.ResetProcessCodes(false);

            this.IsEnableCX = false;
            this.IsEnableUD = false;
            this.IsEnableOG = false;

            switch (uBillState)
            {
                case UBillState.View:

                    if (string.IsNullOrEmpty(_DC.SpCode))
                        this.IsEnableExport = false;

                    break;
                case UBillState.Drop:
                    break;

                case UBillState.New:

                    this.ResetProcessCodes(true);

                    this.IsEnableCX = true;
                    this.IsEnableUD = true;
                    this.IsEnableOG = true;

                    this.IsCheckCXNone = true;
                    this.IsCheckUD1 = true;
                    this.IsCheckOG1 = true;
                    break;

                case UBillState.Edit:

                    if (string.IsNullOrEmpty(_DC.Checker))
                    {
                        if (!string.IsNullOrEmpty(_DC.CusCode))
                        {
                            ComHelpLensCode.LoadCusLensCodeSmartSDR(_DC.CusCode);
                            ComHelpLensCode.LoadCusLensCodeSmartSDL(_DC.CusCode);
                        }
                        this.ResetProcessCodes(true);
                        this.IsEnableCX = true;
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
            this._DC.LensCodeR = " " + this._DC.LensCodeR;
            this._DC.LensCodeR = this._DC.LensCodeR.Trim();
            this._DC.LensCodeL = " " + this._DC.LensCodeL;
            this._DC.LensCodeL = this._DC.LensCodeL.Trim();
            ///////////////////////////////////////////
            this._DC.LensCodeRR = " " + this._DC.LensCodeRR;
            this._DC.LensCodeRR = this._DC.LensCodeRR.Trim();
            this._DC.LensCodeRL = " " + this._DC.LensCodeRL;
            this._DC.LensCodeRL = this._DC.LensCodeRL.Trim();
            ///////////////////////////////////////////////
            this._DC.WhCode = " " + this._DC.WhCode;
            this._DC.WhCode = this._DC.WhCode.Trim();
            ///////////////////////////////////////////////
            this._DC.SpCode = " " + this._DC.SpCode;
            this._DC.SpCode = this._DC.SpCode.Trim();
            ///////////////////////////////////////////////
            this._DC.DpCodeJG = " " + this._DC.DpCodeJG;
            this._DC.DpCodeJG = this._DC.DpCodeJG.Trim();
            this._DC.DpCodeWG = " " + this._DC.DpCodeWG;
            this._DC.DpCodeWG = this._DC.DpCodeWG.Trim();
            ////////////////////////////////////////////////////
            this._DC.D1R = " " + this._DC.D1R;
            this._DC.D1R = this._DC.D1R.Trim();
            this._DC.D3R = " " + this._DC.D3R;
            this._DC.D3R = this._DC.D3R.Trim();
            this._DC.D1L = " " + this._DC.D1L;
            this._DC.D1L = this._DC.D1L.Trim();
            this._DC.D3L = " " + this._DC.D3L;
            this._DC.D3L = this._DC.D3L.Trim();
            ///////////////////////////////////////////////
            this._DC.P1R = " " + this._DC.P1R;
            this._DC.P1R = this._DC.P1R.Trim();
            this._DC.P3R = " " + this._DC.P3R;
            this._DC.P3R = this._DC.P3R.Trim();
            this._DC.P1L = " " + this._DC.P1L;
            this._DC.P1L = this._DC.P1L.Trim();
            this._DC.P3L = " " + this._DC.P3L;
            this._DC.P3L = this._DC.P3L.Trim();
            //////////////////////////////////////////////////////////
            this._DC.BASER = " " + this._DC.BASER;
            this._DC.BASER = this._DC.BASER.Trim();
            this._DC.BASEL = " " + this._DC.BASEL;
            this._DC.BASEL = this._DC.BASEL.Trim();
            ////////////////////////////////////////////////////////////
            this._DC.JJ = " " + this._DC.JJ;
            this._DC.JJ = this._DC.JJ.Trim();
            this._DC.CS = " " + this._DC.CS;
            this._DC.CS = this._DC.CS.Trim();
            this._DC.RS = " " + this._DC.RS;
            this._DC.RS = this._DC.RS.Trim();
            this._DC.RSName = " " + this._DC.RSName;
            this._DC.RSName = this._DC.RSName.Trim();
            this._DC.JS = " " + this._DC.JS;
            this._DC.JS = this._DC.JS.Trim();
            this._DC.SY = " " + this._DC.SY;
            this._DC.SY = this._DC.SY.Trim();
            this._DC.ZK = " " + this._DC.ZK;
            this._DC.ZK = this._DC.ZK.Trim();
            this._DC.OP = " " + this._DC.OP;
            this._DC.OP = this._DC.OP.Trim();
            this._DC.CB = " " + this._DC.CB;
            this._DC.CB = this._DC.CB.Trim();
            this._DC.PG = " " + this._DC.PG;
            this._DC.PG = this._DC.PG.Trim();
            this._DC.KK = " " + this._DC.KK;
            this._DC.KK = this._DC.KK.Trim();
            this._DC.ChB = " " + this._DC.ChB;
            this._DC.ChB = this._DC.ChB.Trim();
            this._DC.PiH = " " + this._DC.PiH;
            this._DC.PiH = this._DC.PiH.Trim();
            //////////////////////////////////////////////////////
        }

        private void ResetProcessCodes(bool flag)
        {
            if (!flag)
            {
                this.IsShowACProcessCF = Visibility.Collapsed;
                this.IsShowACProcessKF = Visibility.Collapsed;
            }
            else
            {
                try
                {
                    this.IsShowACProcessCF = Visibility.Visible;
                    this.IsShowACProcessKF = Visibility.Collapsed;

                    string _LensCode = _DC.LensCodeR;
                    if (string.IsNullOrEmpty(_LensCode))
                        _LensCode = _DC.LensCodeL;

                    if (string.IsNullOrEmpty(_LensCode)) return;
                    var item2 = ComHelpLensCode.UHV_B_Material_LensSmart.Where
                        (it => it.LensCode == _LensCode && it.LensType == "ST").FirstOrDefault();

                    if (null != item2)
                    {
                        this.IsShowACProcessCF = Visibility.Collapsed;
                        this.IsShowACProcessKF = Visibility.Visible;
                    }

                }
                catch
                {
                    this.IsShowACProcessCF = Visibility.Visible;
                    this.IsShowACProcessKF = Visibility.Collapsed;
                }
            }
        }

        private RelayCommand _CmdGotFocusLensCodeL;

        /// <summary>
        /// Gets the CmdGotFocusLensCodeL.
        /// </summary>
        public RelayCommand CmdGotFocusLensCodeL
        {
            get
            {
                return _CmdGotFocusLensCodeL
                    ?? (_CmdGotFocusLensCodeL = new RelayCommand(ExecuteCmdGotFocusLensCodeL));
            }
        }

        private void ExecuteCmdGotFocusLensCodeL()
        {

            if (_DC.EditState != 1) return;

            if (_DC.LensCodeL == _DC.LensCodeR || _DC.LensCodeL.Trim() != "")
                return;

            this._DC.LensCodeR = " " + this._DC.LensCodeR;
            this._DC.LensCodeR = this._DC.LensCodeR.Trim();

            this._DC.LensCodeL = this._DC.LensCodeR;
            this._DC.LensCodeRR = this._DC.LensCodeR;
            this._DC.LensCodeRL = this._DC.LensCodeR;
            //
            this._DC.LensCodeL = " " + this._DC.LensCodeL;
            this._DC.LensCodeL = this._DC.LensCodeL.Trim();
            this._DC.LensCodeRR = " " + this._DC.LensCodeRR;
            this._DC.LensCodeRR = this._DC.LensCodeRR.Trim();
            this._DC.LensCodeRL = " " + this._DC.LensCodeRL;
            this._DC.LensCodeRL = this._DC.LensCodeRL.Trim();
        }

        /////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        private RelayCommand<KeyEventArgs> _CmdKeyDownSpCode;

        /// <summary>
        /// Gets the CmdKeyDownSpCode.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdKeyDownSpCode
        {
            get
            {
                return _CmdKeyDownSpCode
                    ?? (_CmdKeyDownSpCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownSpCode));
            }
        }

        private void ExecuteCmdKeyDownSpCode(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            var cDX = this.DContextMain as V_Sale_Order_SD;
            if (cDX == null || cDX.EditState != 1)
                return;

            this.GetDefaultSpCode();
        }

        private Lazy<DSGetDefaultSpCode> ds_GetDefaultSpCode = new Lazy<DSGetDefaultSpCode>();
        private void GetDefaultSpCode()
        {
            //var _DC = this.DContextMain as V_Sale_Order_SD;
            var _CusCode = _DC.CusCode.Trim();
            var _LensCode = _DC.LensCodeRR.Trim() == "" ? _DC.LensCodeRL.Trim() : _DC.LensCodeRR.Trim();

            string _ProCodes = "";

            if (!string.IsNullOrEmpty(_DC.CB.Trim()))
            {
                _ProCodes += _DC.CB.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.CS.Trim()))
            {
                _ProCodes += _DC.CS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.CB.Trim()))
            {
                _ProCodes += _DC.CB.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.JJ.Trim()))
            {
                _ProCodes += _DC.JJ.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.JS.Trim()))
            {
                _ProCodes += _DC.JS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.KK.Trim()))
            {
                _ProCodes += _DC.KK.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.OP.Trim()))
            {
                _ProCodes += _DC.OP.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.PG.Trim()))
            {
                _ProCodes += _DC.PG.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.PiH.Trim()))
            {
                _ProCodes += _DC.PiH.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.RS.Trim()))
            {
                _ProCodes += _DC.RS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.SY.Trim()))
            {
                _ProCodes += _DC.SY.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(_DC.ZK.Trim()))
            {
                _ProCodes += _DC.ZK.Trim() + ";";
            }

            if (_ProCodes.Length > 1)
            {
                _ProCodes = _ProCodes.Substring(0, _ProCodes.Length - 1);
            }

            _DC.SpName = ErpUIText.Get("ERP_Getting");
            ds_GetDefaultSpCode.Value.Get(USysInfo.DBCode, USysInfo.LgIndex, _CusCode, _LensCode, _ProCodes, geted =>
            {
                _DC.SpCode = "";
                _DC.SpName = "";
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                _DC.SpCode = geted.Value;
                //this.IsFocusSpCode = true;
            }, null);
        }

        //////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        private RelayCommand<KeyEventArgs> _CmdKeyDownWhCode;

        /// <summary>
        /// Gets the CmdKeyDownWhCode.
        /// </summary>
        public new RelayCommand<KeyEventArgs> CmdKeyDownWhCode
        {
            get
            {
                return _CmdKeyDownWhCode
                    ?? (_CmdKeyDownWhCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownWhCode));
            }
        }

        private void ExecuteCmdKeyDownWhCode(KeyEventArgs parameter)
        {
            //if (parameter.Key != Key.Enter)
            //    return;

            //var cDX = this.DContextMain as V_Sale_Order_SD;
            //if (cDX == null || cDX.EditState != 1)
            //    return;

            //this.CallHelpWinDowWhCodeBrowse();
        }

        //////////////////////////////////////////////////////////////////////////////////////

        protected override bool VerifySave()
        {
            if (this.EditMode && (!string.IsNullOrEmpty(_DC.Checker))) return true;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            if (this.ViewErrList != null && this.ViewErrList.Value.Count > 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_ViewErrList"));
                return false;
            }

            ////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(_DC.CusCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////
            if (_DC.QtyR < 0 || _DC.QtyL < 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_QtyLess"));
                return false;
            }

            if ((_DC.QtyR + _DC.QtyL) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_SumQtyLess"));
                return false;
            }
            ////////////////////////////////////////////////////////
            if (_DC.SPHR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_SPHR25"));
                return false;
            }
            if (_DC.SPHL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_SPHL25"));
                return false;
            }
            if (_DC.CYLR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_CYLR25"));
                return false;
            }
            if (_DC.CYLL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_CYLL25"));
                return false;
            }
            if (_DC.X_ADDR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_ADDR25"));
                return false;
            }
            if (_DC.X_ADDL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_ADDL25"));
                return false;
            }
            //////////////////////////////////////////
            if (_DC.QtyR > 0 && string.IsNullOrEmpty(_DC.LensCodeR))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_LensCodeRNull"));
                return false;
            }
            if (_DC.QtyL > 0 && string.IsNullOrEmpty(_DC.LensCodeL))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_LensCodeLNull"));
                return false;
            }
            ////////////////////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(_DC.RS.Trim()) && string.IsNullOrEmpty(_DC.RSName.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_RanseNameNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////

            //if (string.IsNullOrEmpty(_DC.WhCode.Trim()) && string.IsNullOrEmpty(_DC.SpCode.Trim()))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_WGorWhCode"));
            //    return false;
            //}

            //if (!string.IsNullOrEmpty(_DC.WhCode.Trim()) && !string.IsNullOrEmpty(_DC.SpCode.Trim()))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_WGandWhCode"));
            //    return false;
            //} 
            switch (this._DC.OGType)
            {
                case 1:
                    if (string.IsNullOrEmpty(_DC.WhCode.Trim()))
                    {
                        MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_WhCode"));
                        return false;
                    }
                    this._DC.SpCode = "";
                    this._DC.DpCodeWG = "";
                    break;

                case 2:
                    if (string.IsNullOrEmpty(_DC.SpCode.Trim()))
                    {
                        MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_SpCode"));
                        return false;
                    }
                    this._DC.WhCode = "";
                    break;
                default: break;
            }
            /////////////////////////////////////////////////////////////////////

            ////if (_DC.UpdateMoney != 0 && string.IsNullOrEmpty(_DC.UpdateMoneyReason.Trim()))
            ////{
            ////    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_UpdateMoneyReasonNull"));
            ////    return false;
            ////}

            ////if (_DC.Flag_CX && string.IsNullOrEmpty(_DC.PD.Trim()))
            ////{
            ////    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_SD_Err_PDNotNull"));
            ////    return false;
            ////}

            /////////////////////////////////////////////////////////////////////
            //if (string.IsNullOrEmpty(_DC.LensCodeR.Trim()))
            //{
            //    _DC.LensCodeR = _DC.LensCodeL;
            //}
            //if (string.IsNullOrEmpty(_DC.LensCodeL.Trim()))
            //{
            //    _DC.LensCodeL = _DC.LensCodeR;
            //}
            //if (string.IsNullOrEmpty(_DC.LensCodeRR.Trim()))
            //{
            //    _DC.LensCodeRR = _DC.LensCodeR;
            //}
            //if (string.IsNullOrEmpty(_DC.LensCodeRL.Trim()))
            //{
            //    _DC.LensCodeRL = _DC.LensCodeL;
            //}
            ////////////////////////////////////
            this.AsynchronizeVerifySave();
            return false;
        }

        private void AsynchronizeVerifySave()
        {
            if (_DC.QtyR == 0 || _DC.QtyL == 0)
            {
                var lr = _DC.QtyR == 0 ? ErpUIText.Get("Sale_Order_SD_Err_R") : ErpUIText.Get("Sale_Order_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Order_SD_Err_Qty0"), MessageWindowErp.MessageType.Confirm);
                u.Closed += (s1, e1) =>
                {
                    if (u.DialogResult == false)
                        return;
                    this.AsynchronizeVerifySave1();
                };
                u.Show();
            }
            else
            {
                this.AsynchronizeVerifySave1();
            }
        }

        private void AsynchronizeVerifySave1()
        {
            if (_DC.QtyR >= 2 || _DC.QtyL >= 2)
            {
                var lr = _DC.QtyR >= 2 ? ErpUIText.Get("Sale_Order_SD_Err_R") : ErpUIText.Get("Sale_Order_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Order_SD_Err_Qty1"), MessageWindowErp.MessageType.Confirm);
                u.Closed += (s1, e1) =>
                {
                    if (u.DialogResult == false)
                        return;
                    this.AsynchronizeVerifySave2();
                };
                u.Show();
            }
            else
            {
                this.AsynchronizeVerifySave2();
            }
        }

        private void AsynchronizeVerifySave2()
        {
            base.Save(false);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            ERP.Web.DomainService.Common.DSExportToFactory _DS = new ERP.Web.DomainService.Common.DSExportToFactory();
            Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            List<string> _Ls = new List<string>();
            _Ls.Add(this.CurrentIDCode);
            _DS.Export(USysInfo.DBCode, USysInfo.LgIndex, USysInfo.UserCode, _Ls, geted =>
            {
                Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                var _file = geted.Value.ToString();
                this.Load();
                ComOpenURL.Open(_file);
            }, null);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Print()
        {
            Sale_Order_SD_PrintPreView _SP = new Sale_Order_SD_PrintPreView();
            _SP.Closed += (s, e) =>
            {
                if (_SP.DialogResult == false)
                    return;

                List<string> codes = new List<string>();
                codes.Add(this.CurrentIDCode);
                var _isShowMoney = ((VMSale_Order_SD_PrintPreView)_SP.DataContext).YN == "1";
                this.PrintXSSD(codes, f_IsShowMoney: _isShowMoney);
            };
            _SP.Show();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrintToFactory()
        {
            List<string> codes = new List<string>();
            codes.Add(this.CurrentIDCode);
            this.PrintCGSD(codes);
        }

        #region CmdRBUDCheck

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

        #region CmdRBCdiCX

        private RelayCommand<string> _CmdRBCdiCX;
        /// <summary>
        /// Gets the CmdRBCdiCX.
        /// </summary>
        public RelayCommand<string> CmdRBCdiCX
        {
            get
            {
                return _CmdRBCdiCX
                    ?? (_CmdRBCdiCX = new RelayCommand<string>(ExecuteCmdRBCdiCX));
            }
        }

        private void ExecuteCmdRBCdiCX(string parameter)
        {
            try
            {
                _DC.CXType = Convert.ToByte(parameter);
            }
            catch
            {
                if (_DC != null)
                {
                    _DC.CXType = 1;
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
                        //this._DC.SpCode = "T1";
                        this.GetDefaultSpCode();
                        this._DC.DpCodeWG = this._DC.DpCodeWG;
                    }
                    break;

                default: break;
            }
        }

        #endregion

        #region CmdReOrder
        protected override void ReOrder()
        {
            USysTemp.V_Sale_Order_SD = this._DC;
            base.ReOrder();
        }

        #endregion

        #endregion

    }
}
