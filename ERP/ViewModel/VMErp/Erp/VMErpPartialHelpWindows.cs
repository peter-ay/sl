using System;
using ERP.Common;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private string HCWKeyCode = "";
        private string HKeyCode = "";
        private bool HF_InList = false;

        private void CallHelpWindow()
        {
            ComOpenWins.Open("", this.HCWKeyCode);
            Messenger.Default.Register<string>(this, this.HCWKeyCode + "_Return", new Action<string>(ReturnMsg));
            Messenger.Default.Register<string>(this, this.HCWKeyCode + "_ReturnNoMsg", new Action<string>(ReturnNoMsg));
        }

        private void ReturnMsg(string msg)
        {
            try
            {
                Messenger.Default.Unregister<string>(this, ReturnMsg);
                this.HandleReturnMsg(msg);
            }
            catch { }
        }

        protected virtual void HandleReturnMsg(string msg)
        {
            if (!this.HF_InList)
            {
                this.DContextMain.GetType().GetProperty(GetUpdateReturnCode(this.HKeyCode)).SetValue(this.DContextMain, msg, null);
            }
            else
            {
                this.GetType().GetProperty(GetUpdateReturnCode(this.HKeyCode)).SetValue(this, msg, null);
            }

            this.GetType().GetProperty("IsFocus" + this.HKeyCode).SetValue(this, true, null);
            this.OnReturnMsgEnd(this.HKeyCode);
        }

        protected virtual void OnReturnMsgEnd(string hKeyCode)
        {

        }

        private void ReturnNoMsg(string msg)
        {
            try
            {
                Messenger.Default.Unregister<string>(this, ReturnNoMsg);
                this.GetType().GetProperty("IsFocus" + this.HKeyCode).SetValue(this, true, null);
                this.OnReturnNoMsgEnd(this.HKeyCode);
            }
            catch { }
        }

        protected virtual void OnReturnNoMsgEnd(string hKeyCode)
        {

        }

        protected virtual string GetUpdateReturnCode(string keyCode)
        {
            return keyCode;
        }

        private bool isFocusDB = false;
        public bool IsFocusDataBaseCode
        {
            get { return isFocusDB; }
            set
            {
                isFocusDB = false;
                RaisePropertyChanged("IsFocusDataBaseCode");
                isFocusDB = true;
                RaisePropertyChanged("IsFocusDataBaseCode");
            }
        }

        private RelayCommand _CmdDataBaseCode;

        /// <summary>
        /// Gets the CmdDataBaseCode.
        /// </summary>
        public RelayCommand CmdDataBaseCode
        {
            get
            {
                return _CmdDataBaseCode
                    ?? (_CmdDataBaseCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_DataBase";
                        this.HKeyCode = "DataBaseCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////
        /// </summary>
        private bool isFocusDpCode = false;
        public bool IsFocusDpCode
        {
            get { return isFocusDpCode; }
            set
            {
                isFocusDpCode = false;
                RaisePropertyChanged("IsFocusDpCode");
                isFocusDpCode = true;
                RaisePropertyChanged("IsFocusDpCode");
            }
        }

        private RelayCommand _CmdDpCode;

        /// <summary>
        /// Gets the DpCode.
        /// </summary>
        public RelayCommand CmdDpCode
        {
            get
            {
                return _CmdDpCode
                    ?? (_CmdDpCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowDpCode();
                    }));
            }
        }

        protected void CallHelpWinDowDpCode()
        {
            this.HCWKeyCode = "CH_DeptCode";
            this.HKeyCode = "DpCode";
            this.CallHelpWindow();
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        private bool isFocusTempDpCode = false;
        public bool IsFocusTempDpCode
        {
            get { return isFocusTempDpCode; }
            set
            {
                isFocusTempDpCode = false;
                RaisePropertyChanged("IsFocusTempDpCode");
                isFocusTempDpCode = true;
                RaisePropertyChanged("IsFocusTempDpCode");
            }
        }

        private RelayCommand _CmdTempDpCode;

        /// <summary>
        /// Gets the CmdTempDpCode.
        /// </summary>
        public RelayCommand CmdTempDpCode
        {
            get
            {
                return _CmdTempDpCode
                    ?? (_CmdTempDpCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowTempDpCode();
                    }));
            }
        }

        protected void CallHelpWinDowTempDpCode()
        {
            this.HCWKeyCode = "CH_DpCode";
            this.HKeyCode = "TempDpCode";
            this.CallHelpWindow();
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private bool isFocusAreaCode = false;
        public bool IsFocusAreaCode
        {
            get { return isFocusAreaCode; }
            set
            {
                isFocusAreaCode = false;
                RaisePropertyChanged("IsFocusAreaCode");
                isFocusAreaCode = true;
                RaisePropertyChanged("IsFocusAreaCode");
            }
        }

        private RelayCommand _CmdAreaCode;

        /// <summary>
        /// Gets the CmdAreaCode.
        /// </summary>
        public RelayCommand CmdAreaCode
        {
            get
            {
                return _CmdAreaCode
                    ?? (_CmdAreaCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_AreaCode";
                        this.HKeyCode = "AreaCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusPayWayCode = false;
        public bool IsFocusPayWayCode
        {
            get { return isFocusPayWayCode; }
            set
            {
                isFocusPayWayCode = false;
                RaisePropertyChanged("IsFocusPayWayCode");
                isFocusPayWayCode = true;
                RaisePropertyChanged("IsFocusPayWayCode");
            }
        }

        private RelayCommand _CmdPayWayCode;

        /// <summary>
        /// Gets the CmdPayWayCode.
        /// </summary>
        public RelayCommand CmdPayWayCode
        {
            get
            {
                return _CmdPayWayCode
                    ?? (_CmdPayWayCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_PayWay";
                        this.HKeyCode = "PayWayCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusTradeWayCode = false;
        public bool IsFocusTradeWayCode
        {
            get { return isFocusTradeWayCode; }
            set
            {
                isFocusTradeWayCode = false;
                RaisePropertyChanged("IsFocusTradeWayCode");
                isFocusTradeWayCode = true;
                RaisePropertyChanged("IsFocusTradeWayCode");
            }
        }

        private RelayCommand _CmdTradeWayCode;

        /// <summary>
        /// Gets the CmdTradeWayCode.
        /// </summary>
        public RelayCommand CmdTradeWayCode
        {
            get
            {
                return _CmdTradeWayCode
                    ?? (_CmdTradeWayCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_TradeWay";
                        this.HKeyCode = "TradeWayCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusTransferWayCode = false;
        public bool IsFocusTransferWayCode
        {
            get { return isFocusTransferWayCode; }
            set
            {
                isFocusTransferWayCode = false;
                RaisePropertyChanged("IsFocusTransferWayCode");
                isFocusTransferWayCode = true;
                RaisePropertyChanged("IsFocusTransferWayCode");
            }
        }

        private RelayCommand _CmdTransferWayCode;

        /// <summary>
        /// Gets the CmdTransferWayCode.
        /// </summary>
        public RelayCommand CmdTransferWayCode
        {
            get
            {
                return _CmdTransferWayCode
                    ?? (_CmdTransferWayCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_TransferWay";
                        this.HKeyCode = "TransferWayCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusForeignCurrCode = false;
        public bool IsFocusForeignCurrCode
        {
            get { return isFocusForeignCurrCode; }
            set
            {
                isFocusForeignCurrCode = false;
                RaisePropertyChanged("IsFocusForeignCurrCode");
                isFocusForeignCurrCode = true;
                RaisePropertyChanged("IsFocusForeignCurrCode");
            }
        }

        private RelayCommand _CmdForeignCurrCode;

        /// <summary>
        /// Gets the CmdForeignCurrCode.
        /// </summary>
        public RelayCommand CmdForeignCurrCode
        {
            get
            {
                return _CmdForeignCurrCode
                    ?? (_CmdForeignCurrCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_ForeignCurrency";
                        this.HKeyCode = "ForeignCurrCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusPersonCode = false;
        public bool IsFocusPersonCode
        {
            get { return isFocusPersonCode; }
            set
            {
                isFocusPersonCode = false;
                RaisePropertyChanged("IsFocusPersonCode");
                isFocusPersonCode = true;
                RaisePropertyChanged("IsFocusPersonCode");
            }
        }

        private RelayCommand _CmdPersonCode;

        /// <summary>
        /// Gets the CmdPersonCode.
        /// </summary>
        public RelayCommand CmdPersonCode
        {
            get
            {
                return _CmdPersonCode
                    ?? (_CmdPersonCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_Person";
                        this.HKeyCode = "PersonCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusBrandCode = false;
        public bool IsFocusBrandCode
        {
            get { return isFocusBrandCode; }
            set
            {
                isFocusBrandCode = false;
                RaisePropertyChanged("IsFocusBrandCode");
                isFocusBrandCode = true;
                RaisePropertyChanged("IsFocusBrandCode");
            }
        }

        private RelayCommand _CmdBrandCode;

        /// <summary>
        /// Gets the CmdBrandCode.
        /// </summary>
        public RelayCommand CmdBrandCode
        {
            get
            {
                return _CmdBrandCode
                    ?? (_CmdBrandCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_BrandCode";
                        this.HKeyCode = "BrandCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusApplyCode = false;
        public bool IsFocusApplyCode
        {
            get { return isFocusApplyCode; }
            set
            {
                isFocusApplyCode = false;
                RaisePropertyChanged("IsFocusApplyCode");
                isFocusApplyCode = true;
                RaisePropertyChanged("IsFocusApplyCode");
            }
        }

        private RelayCommand _CmdApplyCode;

        /// <summary>
        /// Gets the CmdApplyCode.
        /// </summary>
        public RelayCommand CmdApplyCode
        {
            get
            {
                return _CmdApplyCode
                    ?? (_CmdApplyCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_ApplyCode";
                        this.HKeyCode = "ApplyCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusFocusCode = false;
        public bool IsFocusFocusCode
        {
            get { return isFocusFocusCode; }
            set
            {
                isFocusFocusCode = false;
                RaisePropertyChanged("IsFocusFocusCode");
                isFocusFocusCode = true;
                RaisePropertyChanged("IsFocusFocusCode");
            }
        }

        private RelayCommand _CmdFocusCode;

        /// <summary>
        /// Gets the CmdFocusCode.
        /// </summary>
        public RelayCommand CmdFocusCode
        {
            get
            {
                return _CmdFocusCode
                    ?? (_CmdFocusCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_FocusCode";
                        this.HKeyCode = "FocusCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusRefractionCode = false;
        public bool IsFocusRefractionCode
        {
            get { return isFocusRefractionCode; }
            set
            {
                isFocusRefractionCode = false;
                RaisePropertyChanged("IsFocusRefCode");
                isFocusRefractionCode = true;
                RaisePropertyChanged("IsFocusRefCode");
            }
        }

        private RelayCommand _CmdRefractionCode;

        /// <summary>
        /// Gets the CmdRefractionCode.
        /// </summary>
        public RelayCommand CmdRefractionCode
        {
            get
            {
                return _CmdRefractionCode
                    ?? (_CmdRefractionCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_RefractionCode";
                        this.HKeyCode = "RefCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusTechnologyCode = false;
        public bool IsFocusTechnologyCode
        {
            get { return isFocusTechnologyCode; }
            set
            {
                isFocusTechnologyCode = false;
                RaisePropertyChanged("IsFocusTechCode");
                isFocusTechnologyCode = true;
                RaisePropertyChanged("IsFocusTechCode");
            }
        }

        private RelayCommand _CmdTechnologyCode;

        /// <summary>
        /// Gets the CmdTechnologyCode.
        /// </summary>
        public RelayCommand CmdTechnologyCode
        {
            get
            {
                return _CmdTechnologyCode
                    ?? (_CmdTechnologyCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_TechnologyCode";
                        this.HKeyCode = "TechCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusTextureCode = false;
        public bool IsFocusTextureCode
        {
            get { return isFocusTextureCode; }
            set
            {
                isFocusTextureCode = false;
                RaisePropertyChanged("IsFocusTextureCode");
                isFocusTextureCode = true;
                RaisePropertyChanged("IsFocusTextureCode");
            }
        }

        private RelayCommand _CmdTextureCode;

        /// <summary>
        /// Gets the CmdTextureCode.
        /// </summary>
        public RelayCommand CmdTextureCode
        {
            get
            {
                return _CmdTextureCode
                    ?? (_CmdTextureCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_TextureCode";
                        this.HKeyCode = "TextureCode";
                        this.CallHelpWindow();
                    }));
            }
        }

        private bool isFocusSupplierCode = false;
        public bool IsFocusSupplierCode
        {
            get { return isFocusSupplierCode; }
            set
            {
                isFocusSupplierCode = false;
                RaisePropertyChanged("IsFocusSpCode");
                isFocusSupplierCode = true;
                RaisePropertyChanged("IsFocusSpCode");
            }
        }

        private RelayCommand _CmdSupplierCode;

        /// <summary>
        /// Gets the CmdSupplierCode.
        /// </summary>
        public RelayCommand CmdSupplierCode
        {
            get
            {
                return _CmdSupplierCode
                    ?? (_CmdSupplierCode = new RelayCommand(
                    () =>
                    {
                        this.HCWKeyCode = "CH_SupplierCode";
                        this.HKeyCode = "SpCode";
                        this.CallHelpWindow();
                    }));
            }
        }



        private RelayCommand _CmdLensCodeR;

        /// <summary>
        /// Gets the CmdLensCodeR.
        /// </summary>
        public RelayCommand CmdLensCodeR
        {
            get
            {
                return _CmdLensCodeR
                    ?? (_CmdLensCodeR = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodeR();
                    }));
            }
        }

        protected void CallHelpWinDowLensCodeR()
        {
            try
            {
                var _CusCode = this.DContextMain.GetType().GetProperty("CusCode").GetValue(this.DContextMain, null).ToString();
                if (string.IsNullOrEmpty(_CusCode))
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                    return;
                }
                this.HCWKeyCode = "CH_CusLensCode";
                this.HKeyCode = "LensCodeR";
                this.CallHelpWindow();
                Messenger.Default.Send<string>(_CusCode, this.HCWKeyCode + "_MsgCusCode");
            }
            catch
            {
                MessageErp.InfoMessage(ErpUIText.Get("Err_GetCusCodeErr"));
            }
        }

        private RelayCommand _CmdLensCodeL;

        /// <summary>
        /// Gets the CmdLensCodeL.
        /// </summary>
        public RelayCommand CmdLensCodeL
        {
            get
            {
                return _CmdLensCodeL
                    ?? (_CmdLensCodeL = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodeL();
                    }));
            }
        }

        protected void CallHelpWinDowLensCodeL()
        {
            try
            {
                var _CusCode = this.DContextMain.GetType().GetProperty("CusCode").GetValue(this.DContextMain, null).ToString();
                if (string.IsNullOrEmpty(_CusCode))
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                    return;
                }
                this.HCWKeyCode = "CH_CusLensCode";
                this.HKeyCode = "LensCodeL";
                this.CallHelpWindow();
                Messenger.Default.Send<string>(_CusCode, this.HCWKeyCode + "_MsgCusCode");
            }
            catch
            {
                MessageErp.InfoMessage(ErpUIText.Get("Err_GetCusCodeErr"));
            }
        }

        private bool _IsFocusCusLensCode = false;
        public bool IsFocusCusLensCode
        {
            get { return _IsFocusCusLensCode; }
            set
            {
                _IsFocusCusLensCode = false;
                RaisePropertyChanged("IsFocusCusLensCode");
                _IsFocusCusLensCode = true;
                RaisePropertyChanged("IsFocusCusLensCode");
            }
        }
        ////////////////////////////////////////////////////
        //private bool _IsFocusCusLensCode = false;
        //public bool IsFocusCusLensCode
        //{
        //    get { return IsFocusCusLensCode; }
        //    set
        //    {
        //        _IsFocusCusLensCode = false;
        //        RaisePropertyChanged("IsFocusCusLensCode");
        //        _IsFocusCusLensCode = true;
        //        RaisePropertyChanged("IsFocusCusLensCode");
        //    }
        //}
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private bool isFocusLensCodeReplace = false;
        public bool IsFocusLensCodeReplace
        {
            get { return isFocusLensCodeReplace; }
            set
            {
                isFocusLensCodeReplace = false;
                RaisePropertyChanged("IsFocusLensCodeReplace");
                isFocusLensCodeReplace = true;
                RaisePropertyChanged("IsFocusLensCodeReplace");
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////
        /// </summary>
        private RelayCommand _CmdCusLensCode;

        public RelayCommand CmdCusLensCode
        {
            get
            {
                return _CmdCusLensCode
                    ?? (_CmdCusLensCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowCusLensCode();
                    }));
            }
        }

        protected void CallHelpWinDowCusLensCode()
        {
            var _CusCode = this.GetDContextMainCusCode();
            if (string.IsNullOrEmpty(_CusCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return;
            }
            this.HCWKeyCode = "CH_CusLensCode";
            this.HKeyCode = "LensCode";
            this.CallHelpWindow();
            Messenger.Default.Send<string>(_CusCode, this.HCWKeyCode + "_MsgCusCode");
        }

        protected virtual string GetDContextMainCusCode()
        {
            return this.DContextMain.GetType().GetProperty("CusCode").GetValue(this.DContextMain, null).ToString();
        }

        ///////////////////////////////////////////////

        /// <summary>
        /// ///////////////////////////////////////////////////////
        /// </summary>
        private RelayCommand _CmdLensCodeReplace;

        /// <summary>
        /// Gets the CmdLensCodeReplace.
        /// </summary>
        public RelayCommand CmdLensCodeReplace
        {
            get
            {
                return _CmdLensCodeReplace
                    ?? (_CmdLensCodeReplace = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodeReplace();
                    }));
            }
        }

        protected void CallHelpWinDowLensCodeReplace()
        {
            this.HCWKeyCode = "CH_LensCode";
            this.HKeyCode = "LensCodeReplace";
            this.CallHelpWindow();
        }

        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        private RelayCommand _CmdLensCode_ReplaceR;

        /// <summary>
        /// Gets the CmdLensCode_ReplaceR.
        /// </summary>
        public RelayCommand CmdLensCode_ReplaceR
        {
            get
            {
                return _CmdLensCode_ReplaceR
                    ?? (_CmdLensCode_ReplaceR = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCode_ReplaceR();
                    }));
            }
        }

        protected void CallHelpWinDowLensCode_ReplaceR()
        {
            this.HCWKeyCode = "CH_LensCode";
            this.HKeyCode = "LensCodeRR";
            this.CallHelpWindow();
        }

        private RelayCommand _CmdLensCode_ReplaceL;

        /// <summary>
        /// Gets the CmdLensCode_ReplaceL.
        /// </summary>
        public RelayCommand CmdLensCode_ReplaceL
        {
            get
            {
                return _CmdLensCode_ReplaceL
                    ?? (_CmdLensCode_ReplaceL = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCode_ReplaceL();
                    }));
            }
        }

        protected void CallHelpWinDowLensCode_ReplaceL()
        {
            this.HCWKeyCode = "CH_LensCode";
            this.HKeyCode = "LensCodeRL";
            this.CallHelpWindow();
        }
         
        private RelayCommand _CmdWhCodeBrowseSD;

        /// <summary>
        /// Gets the CmdWhCodeBrowseR.
        /// </summary>
        public RelayCommand CmdWhCodeBrowseSD
        {
            get
            {
                return _CmdWhCodeBrowseSD
                    ?? (_CmdWhCodeBrowseSD = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowWhCodeBrowseSD();
                    }));
            }
        }

        protected void CallHelpWinDowWhCodeBrowseSD()
        {
            this.HCWKeyCode = "CH_WhCodeBrowse";
            this.HKeyCode = "WhCode";
            this.CallHelpWindow();
        }


        #region LensCode




        #endregion

        ////////////////////////////////////////////////////////////////////////
    }
}
