
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
    public class VMSale_Bill_Mnumber_SD : VMBill
    {
        #region 独有属性

        private bool isFocusMnumberR = false;
        public bool IsFocusMnumberR
        {
            get { return isFocusMnumberR; }
            set
            {
                isFocusMnumberR = false;
                RaisePropertyChanged("IsFocusMnumberR");
                isFocusMnumberR = true;
                RaisePropertyChanged("IsFocusMnumberR");
            }
        }

        private bool isFocusMnumberL = false;
        public bool IsFocusMnumberL
        {
            get { return isFocusMnumberL; }
            set
            {
                isFocusMnumberL = false;
                RaisePropertyChanged("IsFocusMnumberL");
                isFocusMnumberL = true;
                RaisePropertyChanged("IsFocusMnumberL");
            }
        }
        //
        private bool isFocusMnumber_ReplaceR = false;
        public bool IsFocusMnumber_ReplaceR
        {
            get { return isFocusMnumber_ReplaceR; }
            set
            {
                isFocusMnumber_ReplaceR = false;
                RaisePropertyChanged("IsFocusMnumber_ReplaceR");
                isFocusMnumber_ReplaceR = true;
                RaisePropertyChanged("IsFocusMnumber_ReplaceR");
            }
        }

        private bool isFocusMnumber_ReplaceL = false;
        public bool IsFocusMnumber_ReplaceL
        {
            get { return isFocusMnumber_ReplaceL; }
            set
            {
                isFocusMnumber_ReplaceL = false;
                RaisePropertyChanged("IsFocusMnumber_ReplaceL");
                isFocusMnumber_ReplaceL = true;
                RaisePropertyChanged("IsFocusMnumber_ReplaceL");
            }
        }

        #endregion

        public VMSale_Bill_Mnumber_SD()
            : base("BillCode", "Sale_Bill")
        {
            this.InitMessage();
        }

        private void InitMessage()
        {
            Messenger.Default.Register<string>(this, "Sale_Bill_Mnumber_SDPrintPreView" + "_ReturnNoMsg", (msg) =>
            {
                var dc = this.DContextMain as V_Sale_Bill_Mnumber_SD;
                if (string.IsNullOrEmpty(dc.DeliveryNum))
                    this.Search();
            });
        }

        #region methods

        protected override string PrepareDDsInfoMainQueryName()
        {
            return "GetV_Sale_Bill_Mnumber_SDBill";
        }

        protected override void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        {
            base.PrepareDDsInfoMainParameters(ispnIndex);
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
        }

        protected override void PrepareDContextMain()
        {
            this.DContextMain = new V_Sale_Bill_Mnumber_SD();
        }

        protected override void PrepareModelToSave()
        {
            var _DC = this.DContextMain as V_Sale_Bill_Mnumber_SD;
            var _CM = this.CurrentModel as MSale_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.SubMnumber_SD = new List<MSale_Bill_Mnumber_SD>();

            MSale_Bill_Mnumber_SD msd = new MSale_Bill_Mnumber_SD()
            {
                BillCode = _CM.BillCode,
                Axis = _DC.AxisR.Trim(),
                Center_Thickness = _DC.Center_ThicknessR.Trim(),
                CYL = _DC.CYLR.Value,
                Quantity = _DC.QuantityR.Value,
                SPH = _DC.SPHR.Value,
                DaoBian = _DC.DaoBianR.Value,
                Decenter1 = _DC.Decenter1R.Trim(),
                Decenter2 = _DC.Decenter2R.Trim(),
                Decenter3 = _DC.Decenter3R.Trim(),
                Decenter4 = _DC.Decenter4R.Trim(),
                Diameter = _DC.DiameterR.Value,
                LR_Flag = "R",
                MianWan = _DC.MianWanR.Trim(),
                Mnumber = _DC.MnumberR.Trim(),
                Mnumber_Replace = _DC.Mnumber_ReplaceR.Trim(),
                Prism1 = _DC.Prism1R.Trim(),
                Prism2 = _DC.Prism2R.Trim(),
                Prism3 = _DC.Prism3R.Trim(),
                Prism4 = _DC.Prism4R.Trim(),
                X_ADD = _DC.X_ADDR.Value,
                ContractType = "",
                ContractType_Process = "",
                Price = 0,
                ProCost = 0,
                ProCostReport = "",
                ProReport = "",
                Quantity_Consign = 0,
                Quantity_Return = 0
            };

            _CM.SubMnumber_SD.Add(msd);

            msd = new MSale_Bill_Mnumber_SD()
            {
                BillCode = _CM.BillCode,
                Axis = _DC.AxisL.Trim(),
                Center_Thickness = _DC.Center_ThicknessL.Trim(),
                CYL = _DC.CYLL.Value,
                Quantity = _DC.QuantityL.Value,
                SPH = _DC.SPHL.Value,
                DaoBian = _DC.DaoBianL.Value,
                Decenter1 = _DC.Decenter1L.Trim(),
                Decenter2 = _DC.Decenter2L.Trim(),
                Decenter3 = _DC.Decenter3L.Trim(),
                Decenter4 = _DC.Decenter4L.Trim(),
                Diameter = _DC.DiameterL.Value,
                LR_Flag = "L",
                MianWan = _DC.MianWanL.Trim(),
                Mnumber = _DC.MnumberL.Trim(),
                Mnumber_Replace = _DC.Mnumber_ReplaceL.Trim(),
                Prism1 = _DC.Prism1L.Trim(),
                Prism2 = _DC.Prism2L.Trim(),
                Prism3 = _DC.Prism3L.Trim(),
                Prism4 = _DC.Prism4L.Trim(),
                X_ADD = _DC.X_ADDL.Value,
                ContractType = "",
                ContractType_Process = "",
                Price = 0,
                ProCost = 0,
                ProCostReport = "",
                ProReport = "",
                Quantity_Consign = 0,
                Quantity_Return = 0
            };

            _CM.SubMnumber_SD.Add(msd);

            _CM.SubMnumber_SD_Process = new MSale_Bill_Mnumber_SD_Process();
            ComCopyProperties.Copy(_CM.SubMnumber_SD_Process, this.DContextMain);

            _CM.SubFlag = new MSale_Bill_Flag();
            ComCopyProperties.Copy(_CM.SubFlag, this.DContextMain);
        }

        protected override string PrepareDSBill()
        {
            return "Sale_Bill";
        }

        protected override void OnLoadMainBegin()
        {
            Messenger.Default.Send<int>((-1), USysMessages.ACBoxMinPrefixLengthChange);
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;

            Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_CF_IsShow);
            Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_KF_IsShow);

            switch (uBillState)
            {
                case UBillState.View:

                    if (string.IsNullOrEmpty(cDC.SupplierCode))
                        this.IsEnableExport = false;

                    break;
                case UBillState.Drop:
                    break;

                case UBillState.New:
                case UBillState.Edit:

                    if (!string.IsNullOrEmpty(cDC.CusCode))
                    {
                        ComHelpV_Base_Mnumber.LoadCusMnumberSmart(cDC.CusCode);
                    }

                    this.ResetProcessCodes();
                    break;
            }
        }

        private void ResetProcessCodes()
        {
            try
            {
                UResetProcess.Set(true);
                var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;
                //
                string mnumber = cDC.MnumberR;
                if (string.IsNullOrEmpty(mnumber))
                    mnumber = cDC.MnumberL;
                //
                if (string.IsNullOrEmpty(mnumber)) return;
                //
                var item2 = ComHelpV_Base_Mnumber.UHV_Base_MnumberSmart.Where
                    (
                        it => it.Mnumber == mnumber && !it.IsCheFang
                    ).FirstOrDefault();
                //
                if (null != item2)
                {
                    UResetProcess.Set(false);
                }
                //
            }
            catch { }
        }

        private RelayCommand _CmdGotFocusMnumberL;

        /// <summary>
        /// Gets the CmdGotFocusMnumberL.
        /// </summary>
        public RelayCommand CmdGotFocusMnumberL
        {
            get
            {
                return _CmdGotFocusMnumberL
                    ?? (_CmdGotFocusMnumberL = new RelayCommand(ExecuteCmdGotFocusMnumberL));
            }
        }

        private void ExecuteCmdGotFocusMnumberL()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;

            if (cDC.EditState != 1) return;

            if (cDC.MnumberL == cDC.MnumberR || cDC.MnumberL.Trim() != "")
                return;

            cDC.MnumberL = cDC.MnumberR;
            cDC.Mnumber_ReplaceR = cDC.MnumberR;
            cDC.Mnumber_ReplaceL = cDC.MnumberR;
        }

        /////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        private RelayCommand<KeyEventArgs> _CmdKeyDownSupplierCode;

        /// <summary>
        /// Gets the CmdKeyDownSupplierCode.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdKeyDownSupplierCode
        {
            get
            {
                return _CmdKeyDownSupplierCode
                    ?? (_CmdKeyDownSupplierCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownSupplierCode));
            }
        }

        private void ExecuteCmdKeyDownSupplierCode(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            var cDX = this.DContextMain as V_Sale_Bill_Mnumber_SD;
            if (cDX == null || cDX.EditState != 1)
                return;

            this.GetDefaultSupplierCode();
        }

        private Lazy<DSGetDefaultSupplierCode> dsgetdefaultsuppliercode = new Lazy<DSGetDefaultSupplierCode>();
        private void GetDefaultSupplierCode()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;
            var cuscode = cDC.CusCode.Trim();
            var mnumber = cDC.Mnumber_ReplaceR.Trim() == "" ? cDC.Mnumber_ReplaceL.Trim() : cDC.Mnumber_ReplaceR.Trim();

            string processCodes = "";

            if (!string.IsNullOrEmpty(cDC.CaiBian.Trim()))
            {
                processCodes += cDC.CaiBian.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.ChaSe.Trim()))
            {
                processCodes += cDC.ChaSe.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.CheBian.Trim()))
            {
                processCodes += cDC.CheBian.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.ExtraProcess.Trim()))
            {
                processCodes += cDC.ExtraProcess.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.JingJia.Trim()))
            {
                processCodes += cDC.JingJia.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.JuSe.Trim()))
            {
                processCodes += cDC.JuSe.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.KaiKeng.Trim()))
            {
                processCodes += cDC.KaiKeng.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.OtherProcess.Trim()))
            {
                processCodes += cDC.OtherProcess.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.PaoGuang.Trim()))
            {
                processCodes += cDC.PaoGuang.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.PiHua.Trim()))
            {
                processCodes += cDC.PiHua.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.RanSe.Trim()))
            {
                processCodes += cDC.RanSe.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.ShuiYin.Trim()))
            {
                processCodes += cDC.ShuiYin.Trim() + ";";
            }

            if (!string.IsNullOrEmpty(cDC.ZuanKong.Trim()))
            {
                processCodes += cDC.ZuanKong.Trim() + ";";
            }

            if (processCodes.Length > 1)
            {
                processCodes = processCodes.Substring(0, processCodes.Length - 1);
            }

            cDC.SupplierName = ErpUIText.Get("ERP_Getting");
            dsgetdefaultsuppliercode.Value.Get(cuscode, mnumber, processCodes, geted =>
            {
                cDC.SupplierCode = "";
                cDC.SupplierName = "";
                if (geted.HasError)
                {
                    //USysInfo.ErrMsg = geted.Error.Message;
                    //USysInfo.ErrMsg = ErpUIText.ErrMsg + USysInfo.ErrMsg.Substring(USysInfo.ErrMsg.IndexOf('.') + 1);
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                cDC.SupplierCode = geted.Value;
                this.IsFocusSupplierCode = true;
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

            var cDX = this.DContextMain as V_Sale_Bill_Mnumber_SD;
            if (cDX == null || cDX.EditState != 1)
                return;

            this.CallHelpWinDowWhCodeBrowse();
        }

        //////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////

        protected override bool VerifySave()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;

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
            if (cDC.QuantityR < 0 || cDC.QuantityL < 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_QtyLess"));
                return false;
            }

            if ((cDC.QuantityR + cDC.QuantityL) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_SumQtyLess"));
                return false;
            }
            //////////////////////////////////////////////////////
            if (cDC.SPHR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_SPHR25"));
                return false;
            }
            if (cDC.SPHL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_SPHL25"));
                return false;
            }
            if (cDC.CYLR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_CYLR25"));
                return false;
            }
            if (cDC.CYLL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_CYLL25"));
                return false;
            }
            if (cDC.X_ADDR % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_ADDR25"));
                return false;
            }
            if (cDC.X_ADDL % 25 != 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_ADDL25"));
                return false;
            }
            ////////////////////////////////////////
            if (cDC.QuantityR > 0 && string.IsNullOrEmpty(cDC.MnumberR))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_MnumberRNull"));
                return false;
            }
            if (cDC.QuantityL > 0 && string.IsNullOrEmpty(cDC.MnumberL))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_MnumberLNull"));
                return false;
            }
            //////////////////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(cDC.RanSe.Trim()) && string.IsNullOrEmpty(cDC.RanSeName.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_RanseNameNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.WhCode.Trim()) && string.IsNullOrEmpty(cDC.SupplierCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_WGorWhCode"));
                return false;
            }

            if (!string.IsNullOrEmpty(cDC.WhCode.Trim()) && !string.IsNullOrEmpty(cDC.SupplierCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_WGandWhCode"));
                return false;
            }
            ///////////////////////////////////////////////////////////////////

            if (cDC.UpdateMoney != 0 && string.IsNullOrEmpty(cDC.UpdateMoneyReason.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_UpdateMoneyReasonNull"));
                return false;
            }

            if (cDC.Flag_CX && string.IsNullOrEmpty(cDC.PD.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_PDNotNull"));
                return false;
            }

            ///////////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.MnumberR.Trim()))
            {
                cDC.MnumberR = cDC.MnumberL;
            }
            if (string.IsNullOrEmpty(cDC.MnumberL.Trim()))
            {
                cDC.MnumberL = cDC.MnumberR;
            }
            if (string.IsNullOrEmpty(cDC.Mnumber_ReplaceR.Trim()))
            {
                cDC.Mnumber_ReplaceR = cDC.MnumberR;
            }
            if (string.IsNullOrEmpty(cDC.Mnumber_ReplaceL.Trim()))
            {
                cDC.Mnumber_ReplaceL = cDC.MnumberL;
            }
            if (string.IsNullOrEmpty(cDC.Out_Good.Trim()))
                cDC.Out_Good = DateTime.Now.AddDays(2).Day.ToString();
            ///////////////////////////////////////////////////////////////////

            //////////////////////////////////
            this.AsynchronizeVerifySave();
            return false;
        }

        private void AsynchronizeVerifySave()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;

            if (cDC.QuantityR == 0 || cDC.QuantityL == 0)
            {
                var lr = cDC.QuantityR == 0 ? ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_R") : ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_Qty0"), MessageWindowErp.MessageType.Confirm);
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
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_SD;

            if (cDC.QuantityR >= 2 || cDC.QuantityL >= 2)
            {
                var lr = cDC.QuantityR >= 2 ? ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_R") : ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_L");
                MessageWindowErp u = new MessageWindowErp(lr + ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_Qty1"), MessageWindowErp.MessageType.Confirm);
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
            var dc = this.DContextMain as V_Sale_Bill_Mnumber_SD;
            List<string> billcodes = new List<string>();
            billcodes.Add(this.CurrentIDCode);
            ComExportToFactory.Export(billcodes, dc.Flag_CX == true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Print()
        {
            ComOpenWins.Open("", "Sale_Bill_Mnumber_SDPrintPreView");
            Messenger.Default.Send<string>(this.CurrentIDCode, USysMessages.RefreshPreViewSDBillCode);
            //Sale_Bill_Mnumber_SDPrintPreView
        }
        #endregion

    }
}
