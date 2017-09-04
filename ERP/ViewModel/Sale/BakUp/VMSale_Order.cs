
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

namespace ERP.ViewModel
{
    public class VMSale_Order : VMBill
    {
        #region 独有属性

        #region BillType类型

        private bool _IsEnableBillType = false;
        public bool IsEnableBillType
        {
            get { return _IsEnableBillType; }
            set { _IsEnableBillType = value; RaisePropertyChanged("IsEnableBillType"); }
        }

        private bool _IsCheckBillTypeXSSD = true;
        public bool IsCheckBillTypeXSSD
        {
            get { return _IsCheckBillTypeXSSD; }
            set { _IsCheckBillTypeXSSD = value; RaisePropertyChanged("IsCheckBillTypeXSSD"); }
        }

        private bool _IsCheckBillTypeXSPD = false;
        public bool IsCheckBillTypeXSPD
        {
            get { return _IsCheckBillTypeXSPD; }
            set { _IsCheckBillTypeXSPD = value; RaisePropertyChanged("IsCheckBillTypeXSPD"); }
        }

        private bool _IsCheckBillTypeXSFD = false;
        public bool IsCheckBillTypeXSFD
        {
            get { return _IsCheckBillTypeXSFD; }
            set { _IsCheckBillTypeXSFD = value; RaisePropertyChanged("IsCheckBillTypeXSFD"); }
        }

        private bool _IsCheckBillTypeXSFS = false;
        public bool IsCheckBillTypeXSFS
        {
            get { return _IsCheckBillTypeXSFS; }
            set { _IsCheckBillTypeXSFS = value; RaisePropertyChanged("IsCheckBillTypeXSFS"); }
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

        private bool isFocusLensCodeR = false;
        public bool IsFocusLensCodeR
        {
            get { return isFocusLensCodeR; }
            set
            {
                isFocusLensCodeR = false;
                RaisePropertyChanged("IsFocusLensCodeR");
                isFocusLensCodeR = true;
                RaisePropertyChanged("IsFocusLensCodeR");
            }
        }

        private bool isFocusLensCodeL = false;
        public bool IsFocusLensCodeL
        {
            get { return isFocusLensCodeL; }
            set
            {
                isFocusLensCodeL = false;
                RaisePropertyChanged("IsFocusLensCodeL");
                isFocusLensCodeL = true;
                RaisePropertyChanged("IsFocusLensCodeL");
            }
        }
        //
        private bool isFocusLensCodeRR = false;
        public bool IsFocusLensCodeRR
        {
            get { return isFocusLensCodeRR; }
            set
            {
                isFocusLensCodeRR = false;
                RaisePropertyChanged("IsFocusLensCodeRR");
                isFocusLensCodeRR = true;
                RaisePropertyChanged("IsFocusLensCodeRR");
            }
        }

        private bool isFocusLensCodeRL = false;
        public bool IsFocusLensCodeRL
        {
            get { return isFocusLensCodeRL; }
            set
            {
                isFocusLensCodeRL = false;
                RaisePropertyChanged("IsFocusLensCodeRL");
                isFocusLensCodeRL = true;
                RaisePropertyChanged("IsFocusLensCodeRL");
            }
        }

        #endregion

        public VMSale_Order()
            : base("ID", "Sale_Order")
        {
            this.InitMessage();
        }

        private void InitMessage()
        {
            //Messenger.Default.Register<string>(this, "Sale_Order_LensCode_SDPrintPreView" + "_ReturnNoMsg", (msg) =>
            //{
            //    var dc = this.DContextMain as V_Sale_Order_SD;
            //if (string.IsNullOrEmpty(dc.DeliveryNum))
            //    this.Search();
            //});
        }

        #region methods

        protected override string PrepareDDsInfoMainQueryName()
        {
            return "GetV_Sale_Order_SDBill";
        }

        protected override void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        {
            base.PrepareDDsInfoMainParameters(ispnIndex);
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
        }

        protected override void PrepareDContextMain()
        {
            this.DContextMain = new V_Sale_Order_SD();
        }

        protected override void PrepareModelToSave()
        {
            var _DC = this.DContextMain as V_Sale_Order_SD;
            var _CM = this.CurrentModel as MSale_Order;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.Ex_SD = new List<MSale_Order_SD>();
            MSale_Order_SD ex_sd = null;
            for (int i = 0; i <= 1; i++)
            {
                ex_sd = new MSale_Order_SD()
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
                    F_LR = i == 0 ? false : true,
                    IvoLensName = "",
                    QtyCs = 0,
                    QtyRt = 0
                };
                _CM.Ex_SD.Add(ex_sd);
            }

            _CM.Ex_SD_Sub = new MSale_Order_SD_Sub();
            ComCopyProperties.Copy(_CM.Ex_SD_Sub, this.DContextMain);


        }

        protected override string PrepareDSBill()
        {
            return "Sale_Order";
        }

        protected override void OnLoadMainBegin()
        {
            Messenger.Default.Send<int>((-1), USysMessages.ACBoxMinPrefixLengthChange);
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            var cDC = this.DContextMain as V_Sale_Order_SD;

            Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_CF_IsShow);
            Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_KF_IsShow);

            this.IsEnableBillType = false;
            this.IsEnableCX = false;
            this.IsEnableUD = false;
            //this.SetBillTypeIsCheckAll(false);

            switch (uBillState)
            {
                case UBillState.View:

                    if (string.IsNullOrEmpty(cDC.SpCode))
                        this.IsEnableExport = false;


                    break;
                case UBillState.Drop:
                    break;

                case UBillState.New:

                    if (this.IsCheckBillTypeXSSD == false && this.IsCheckBillTypeXSPD == false && this.IsCheckBillTypeXSFD == false && this.IsCheckBillTypeXSFS == false)
                        this.IsCheckBillTypeXSSD = true;

                    this.ResetProcessCodes();
                    this.IsEnableBillType = true;
                    this.IsEnableCX = true;
                    this.IsEnableUD = true;

                    this.IsCheckCXNone = true;
                    this.IsCheckUD1 = true;
                    break;

                case UBillState.Edit:

                    if (!string.IsNullOrEmpty(cDC.CusCode))
                    {
                        //ComHelpV_Base_LensCode.LoadCusLensCodeSmart(cDC.CusCode);
                    }

                    this.ResetProcessCodes();
                    this.IsEnableCX = true;
                    this.IsEnableUD = true;
                    break;
            }
        }

        //private void SetBillTypeIsCheckAll(bool p)
        //{
        //    this.IsCheckBillTypeXSSD = false;
        //    this.IsCheckBillTypeXSPD = false;
        //    this.IsCheckBillTypeXSFD = false;
        //    this.IsCheckBillTypeXSFS = false;
        //}

        private void ResetProcessCodes()
        {
            try
            {
                UResetProcess.Set(true);
                var cDC = this.DContextMain as V_Sale_Order_SD;
                //
                string mnumber = cDC.LensCodeR;
                if (string.IsNullOrEmpty(mnumber))
                    mnumber = cDC.LensCodeL;
                //
                if (string.IsNullOrEmpty(mnumber)) return;
                //
                //var item2 = ComHelpV_Base_LensCode.UHV_Base_LensCodeSmart.Where
                //    (
                //        it => it.LensCode == mnumber && !it.IsCheFang
                //    ).FirstOrDefault();
                //
                //if (null != item2)
                //{
                //    UResetProcess.Set(false);
                //}
                //
            }
            catch { }
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
            var cDC = this.DContextMain as V_Sale_Order_SD;

            if (cDC.EditState != 1) return;

            if (cDC.LensCodeL == cDC.LensCodeR || cDC.LensCodeL.Trim() != "")
                return;

            cDC.LensCodeL = cDC.LensCodeR;
            cDC.LensCodeRR = cDC.LensCodeR;
            cDC.LensCodeRL = cDC.LensCodeR;
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

        private Lazy<DSGetDefaultSupplierCode> dsgetdefaultsuppliercode = new Lazy<DSGetDefaultSupplierCode>();
        private void GetDefaultSpCode()
        {
            var cDC = this.DContextMain as V_Sale_Order_SD;
            var cuscode = cDC.CusCode.Trim();
            var mnumber = cDC.LensCodeRR.Trim() == "" ? cDC.LensCodeRL.Trim() : cDC.LensCodeRR.Trim();

            string processCodes = "";

            if (!string.IsNullOrEmpty(cDC.CB.Trim()))
            {
                processCodes += cDC.CB.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.CS.Trim()))
            {
                processCodes += cDC.CS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.CB.Trim()))
            {
                processCodes += cDC.CB.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.JJ.Trim()))
            {
                processCodes += cDC.JJ.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.JS.Trim()))
            {
                processCodes += cDC.JS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.KK.Trim()))
            {
                processCodes += cDC.KK.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.OP.Trim()))
            {
                processCodes += cDC.OP.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.PG.Trim()))
            {
                processCodes += cDC.PG.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.PiH.Trim()))
            {
                processCodes += cDC.PiH.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.RS.Trim()))
            {
                processCodes += cDC.RS.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.SY.Trim()))
            {
                processCodes += cDC.SY.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.ZK.Trim()))
            {
                processCodes += cDC.ZK.Trim() + ";";
            }

            if (processCodes.Length > 1)
            {
                processCodes = processCodes.Substring(0, processCodes.Length - 1);
            }

            cDC.SpName = ErpUIText.Get("ERP_Getting");
            dsgetdefaultsuppliercode.Value.Get(cuscode, mnumber, processCodes, geted =>
            {
                cDC.SpCode = "";
                cDC.SpName = "";
                if (geted.HasError)
                {
                    //USysInfo.ErrMsg = geted.Error.Message;
                    //USysInfo.ErrMsg = ErpUIText.ErrMsg + USysInfo.ErrMsg.Substring(USysInfo.ErrMsg.IndexOf('.') + 1);
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                cDC.SpCode = geted.Value;
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
            if (parameter.Key != Key.Enter)
                return;

            var cDX = this.DContextMain as V_Sale_Order_SD;
            if (cDX == null || cDX.EditState != 1)
                return;

            this.CallHelpWinDowWhCodeBrowse();
        }

        //////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////

        protected override bool VerifySave()
        {
            return true;
            var cDC = this.DContextMain as V_Sale_Order_SD;

            if (this.ViewErrList != null && this.ViewErrList.Value.Count > 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_ViewErrList"));
                return false;
            }

            //////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.CusCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }
            /////////////////////////////////////////////////////////
            if (cDC.QtyR < 0 || cDC.QtyL < 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_QtyLess"));
                return false;
            }

            if ((cDC.QtyR + cDC.QtyL) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_SumQtyLess"));
                return false;
            }
            //////////////////////////////////////////////////////
            if (cDC.SPHR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_SPHR25"));
                return false;
            }
            if (cDC.SPHL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_SPHL25"));
                return false;
            }
            if (cDC.CYLR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_CYLR25"));
                return false;
            }
            if (cDC.CYLL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_CYLL25"));
                return false;
            }
            if (cDC.X_ADDR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_ADDR25"));
                return false;
            }
            if (cDC.X_ADDL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_ADDL25"));
                return false;
            }
            ////////////////////////////////////////
            if (cDC.QtyR > 0 && string.IsNullOrEmpty(cDC.LensCodeR))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_LensCodeRNull"));
                return false;
            }
            if (cDC.QtyL > 0 && string.IsNullOrEmpty(cDC.LensCodeL))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_LensCodeLNull"));
                return false;
            }
            //////////////////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(cDC.RS.Trim()) && string.IsNullOrEmpty(cDC.RSName.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_RanseNameNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.WhCode.Trim()) && string.IsNullOrEmpty(cDC.SpCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_WGorWhCode"));
                return false;
            }

            if (!string.IsNullOrEmpty(cDC.WhCode.Trim()) && !string.IsNullOrEmpty(cDC.SpCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_WGandWhCode"));
                return false;
            }
            ///////////////////////////////////////////////////////////////////

            //if (cDC.UpdateMoney != 0 && string.IsNullOrEmpty(cDC.UpdateMoneyReason.Trim()))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_UpdateMoneyReasonNull"));
            //    return false;
            //}

            //if (cDC.Flag_CX && string.IsNullOrEmpty(cDC.PD.Trim()))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_Order_LensCode_SD_Err_PDNotNull"));
            //    return false;
            //}

            ///////////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.LensCodeR.Trim()))
            {
                cDC.LensCodeR = cDC.LensCodeL;
            }
            if (string.IsNullOrEmpty(cDC.LensCodeL.Trim()))
            {
                cDC.LensCodeL = cDC.LensCodeR;
            }
            if (string.IsNullOrEmpty(cDC.LensCodeRR.Trim()))
            {
                cDC.LensCodeRR = cDC.LensCodeR;
            }
            if (string.IsNullOrEmpty(cDC.LensCodeRL.Trim()))
            {
                cDC.LensCodeRL = cDC.LensCodeL;
            }
            //if (string.IsNullOrEmpty(cDC.Out_Good.Trim()))
            //    cDC.Out_Good = DateTime.Now.AddDays(2).Day.ToString();
            ///////////////////////////////////////////////////////////////////

            //////////////////////////////////
            this.AsynchronizeVerifySave();
            return false;
        }

        private void AsynchronizeVerifySave()
        {
            var cDC = this.DContextMain as V_Sale_Order_SD;

            if (cDC.QtyR == 0 || cDC.QtyL == 0)
            {
                var lr = cDC.QtyR == 0 ? ErpUIText.Get("Sale_Order_LensCode_SD_Err_R") : ErpUIText.Get("Sale_Order_LensCode_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Order_LensCode_SD_Err_Qty0"), MessageWindowErp.MessageType.Confirm);
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
            var cDC = this.DContextMain as V_Sale_Order_SD;

            if (cDC.QtyR >= 2 || cDC.QtyL >= 2)
            {
                var lr = cDC.QtyR >= 2 ? ErpUIText.Get("Sale_Order_LensCode_SD_Err_R") : ErpUIText.Get("Sale_Order_LensCode_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Order_LensCode_SD_Err_Qty1"), MessageWindowErp.MessageType.Confirm);
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
            base.Save();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            var dc = this.DContextMain as V_Sale_Order_SD;
            List<string> billcodes = new List<string>();
            billcodes.Add(this.CurrentIDCode);
            //ComExportToFactory.Export(billcodes, dc.Flag_CX == true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Print()
        {
            ComOpenWins.Open("", "Sale_Order_LensCode_SDPrintPreView");
            Messenger.Default.Send<string>(this.CurrentIDCode, USysMessages.RefreshPreViewSDBillCode);
            //Sale_Order_LensCode_SDPrintPreView
        }
        #endregion

    }
}
