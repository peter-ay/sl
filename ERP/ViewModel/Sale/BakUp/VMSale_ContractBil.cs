
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMSale_ContractBill : VMBill
    {
        #region property

        #endregion

        #region enableButton

        private bool _IsEnableEditMnumberA = false;
        public bool IsEnableEditMnumberA
        {
            get { return _IsEnableEditMnumberA; }
            set
            {
                _IsEnableEditMnumberA = value;
                RaisePropertyChanged("IsEnableEditMnumberA");
            }
        }
        private bool _IsEnableEditMnumberB = false;
        public bool IsEnableEditMnumberB
        {
            get { return _IsEnableEditMnumberB; }
            set
            {
                _IsEnableEditMnumberB = value;
                RaisePropertyChanged("IsEnableEditMnumberB");
            }
        }
        private bool _IsEnableEditMnumberC = false;
        public bool IsEnableEditMnumberC
        {
            get { return _IsEnableEditMnumberC; }
            set
            {
                _IsEnableEditMnumberC = value;
                RaisePropertyChanged("IsEnableEditMnumberC");
            }
        }
        private bool _IsEnableEditMnumberD = false;
        public bool IsEnableEditMnumberD
        {
            get { return _IsEnableEditMnumberD; }
            set
            {
                _IsEnableEditMnumberD = value;
                RaisePropertyChanged("IsEnableEditMnumberD");
            }
        }
        private bool _IsEnableEditFrame = false;
        public bool IsEnableEditFrame
        {
            get { return _IsEnableEditFrame; }
            set
            {
                _IsEnableEditFrame = value;
                RaisePropertyChanged("IsEnableEditFrame");
            }
        }
        private bool _IsEnableEditFrameSet = false;
        public bool IsEnableEditFrameSet
        {
            get { return _IsEnableEditFrameSet; }
            set
            {
                _IsEnableEditFrameSet = value;
                RaisePropertyChanged("IsEnableEditFrameSet");
            }
        }

        private bool _IsEnableEditProcessA = false;
        public bool IsEnableEditProcessA
        {
            get { return _IsEnableEditProcessA; }
            set
            {
                _IsEnableEditProcessA = value;
                RaisePropertyChanged("IsEnableEditProcessA");
            }
        }
        private bool _IsEnableEditProcessB = false;
        public bool IsEnableEditProcessB
        {
            get { return _IsEnableEditProcessB; }
            set
            {
                _IsEnableEditProcessB = value;
                RaisePropertyChanged("IsEnableEditProcessB");
            }
        }
        private bool _IsEnableEditProcessD = false;
        public bool IsEnableEditProcessD
        {
            get { return _IsEnableEditProcessD; }
            set
            {
                _IsEnableEditProcessD = value;
                RaisePropertyChanged("IsEnableEditProcessD");
            }
        }


        private bool _IsEnableEditCusCodeA = false;
        public bool IsEnableEditCusCodeA
        {
            get { return _IsEnableEditCusCodeA; }
            set
            {
                _IsEnableEditCusCodeA = value;
                RaisePropertyChanged("IsEnableEditCusCodeA");
            }
        }
        private bool _IsEnableEditCusCodeB = false;
        public bool IsEnableEditCusCodeB
        {
            get { return _IsEnableEditCusCodeB; }
            set
            {
                _IsEnableEditCusCodeB = value;
                RaisePropertyChanged("IsEnableEditCusCodeB");
            }
        }
        private bool _IsEnableEditCusCodeC = false;
        public bool IsEnableEditCusCodeC
        {
            get { return _IsEnableEditCusCodeC; }
            set
            {
                _IsEnableEditCusCodeC = value;
                RaisePropertyChanged("IsEnableEditCusCodeC");
            }
        }
        private bool _IsEnableEditCusCodeD = false;
        public bool IsEnableEditCusCodeD
        {
            get { return _IsEnableEditCusCodeD; }
            set
            {
                _IsEnableEditCusCodeD = value;
                RaisePropertyChanged("IsEnableEditCusCodeD");
            }
        }
        private bool _IsEnableEditCusCodeE = false;
        public bool IsEnableEditCusCodeE
        {
            get { return _IsEnableEditCusCodeE; }
            set
            {
                _IsEnableEditCusCodeE = value;
                RaisePropertyChanged("IsEnableEditCusCodeE");
            }
        }
        private bool _IsEnableEditCusCodeF = false;
        public bool IsEnableEditCusCodeF
        {
            get { return _IsEnableEditCusCodeF; }
            set
            {
                _IsEnableEditCusCodeF = value;
                RaisePropertyChanged("IsEnableEditCusCodeF");
            }
        }

        #endregion

        public VMSale_ContractBill()
            : base("ContractCode", "Sale_ContractBill")
        {
        }

        #region methods

        protected override void ChangeBillSate(Utility.UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsEnableEditCusCodeA = false;
            this.IsEnableEditCusCodeB = false;
            this.IsEnableEditCusCodeC = false;
            this.IsEnableEditCusCodeE = false;
            this.IsEnableEditCusCodeF = false;
            this.IsEnableEditCusCodeD = false;

            this.IsEnableEditMnumberA = false;
            this.IsEnableEditMnumberB = false;
            this.IsEnableEditMnumberC = false;
            this.IsEnableEditMnumberD = false;
            this.IsEnableEditFrame = false;
            this.IsEnableEditFrameSet = false;

            this.IsEnableEditProcessA = false;
            this.IsEnableEditProcessB = false;
            this.IsEnableEditProcessD = false;

            switch (uBillState)
            {
                case UBillState.View:
                    try
                    {
                        switch (this.DContextMain.GetType().GetProperty("ContractType").GetValue(this.DContextMain, null).ToString().ToUpper())
                        {
                            case "XSCA":
                                this.IsEnableEditCusCodeA = true;
                                this.IsEnableEditMnumberA = true;
                                this.IsEnableEditProcessA = true;
                                break;
                            case "XSCB":
                                this.IsEnableEditCusCodeB = true;
                                this.IsEnableEditMnumberB = true;
                                this.IsEnableEditProcessB = true;
                                break;
                            case "XSCC":
                                this.IsEnableEditCusCodeC = true;
                                this.IsEnableEditMnumberC = true;
                                break;
                            case "XSCD":
                                this.IsEnableEditCusCodeD = true;
                                this.IsEnableEditMnumberD = true;
                                this.IsEnableEditProcessD = true;
                                break;
                            case "XSCE":
                                this.IsEnableEditCusCodeE = true;
                                this.IsEnableEditFrame = true;
                                break;
                            case "XSCF":
                                this.IsEnableEditCusCodeF = true;
                                this.IsEnableEditFrameSet = true;
                                break;
                        }
                    }
                    catch
                    {
                    }

                    break;
                case UBillState.Drop:
                    break;
                case UBillState.New:
                case UBillState.Edit:
                    break;
            }
        }

        protected override void New()
        {
            base.New();
            ComOpenWins.Open("", "Sale_ContractBill_ChooseByNew", is_Flag: false);
            Messenger.Default.Register<List<string>>(this, "Sale_ContractBill_ChooseByNew" + "_Return", new Action<List<string>>(ReturnNew));
        }

        private void ReturnNew(List<string> msg)
        {
            try
            {
                Messenger.Default.Unregister<List<string>>(this, ReturnNew);

                if (msg[0].ToString() != "True")
                {
                    this.ChangeBillSate(UBillState.Drop);
                    return;
                }
                if (string.IsNullOrEmpty(msg[1].ToString()))
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("Sale_ContractBill_Err_CustTypeNull"));
                    this.ChangeBillSate(UBillState.Drop);
                    return;
                }
                if (msg[2].ToString() != "XSCA"
                    && msg[2].ToString() != "XSCB"
                    && msg[2].ToString() != "XSCC"
                    && msg[2].ToString() != "XSCD"
                    && msg[2].ToString() != "XSCE"
                    && msg[2].ToString() != "XSCF")
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("Sale_ContractBill_Err_ContractTypeErr"));
                    this.ChangeBillSate(UBillState.Drop);
                    return;
                }

                this.DContextMain.GetType().GetProperty("CusType").SetValue(this.DContextMain, msg[1].ToString().Trim(), null);
                this.DContextMain.GetType().GetProperty("ContractType").SetValue(this.DContextMain, msg[2].ToString().ToUpper().Trim(), null);

                switch (msg[2].ToString())
                {
                    case "XSCA":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCA"), null);
                        break;
                    case "XSCB":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCB"), null);
                        break;
                    case "XSCC":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCC"), null);
                        break;
                    case "XSCD":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCD"), null);
                        break;
                    case "XSCE":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCE"), null);
                        break;
                    case "XSCF":
                        this.DContextMain.GetType().GetProperty("TypeName").SetValue(this.DContextMain, ErpUIText.Get("ERP_XSCF"), null);
                        break;
                }

                this.IsFocusMain = true;
            }
            catch { MessageErp.ErrorMessage(ErpUIText.ErrMsg); this.ChangeBillSate(UBillState.Drop); }
        }


        ////////////////////////////////////////
        #region editbutton

        private RelayCommand _CmdEditMnumberA;

        /// <summary>
        /// Gets the CmdEditMnumberA.
        /// </summary>
        public RelayCommand CmdEditMnumberA
        {
            get
            {
                return _CmdEditMnumberA ?? (_CmdEditMnumberA = new RelayCommand(ExecuteCmdEditMnumberA));
            }
        }

        private void ExecuteCmdEditMnumberA()
        {
            if (!CanExecuteCmdEditMnumberA())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Mnumber_List");
        }

        private bool CanExecuteCmdEditMnumberA()
        {
            return true;
        }

        private RelayCommand _CmdEditMnumberB;

        /// <summary>
        /// Gets the CmdEditMnumberB.
        /// </summary>
        public RelayCommand CmdEditMnumberB
        {
            get
            {
                return _CmdEditMnumberB ?? (_CmdEditMnumberB = new RelayCommand(ExecuteCmdEditMnumberB));
            }
        }

        private void ExecuteCmdEditMnumberB()
        {
            if (!CanExecuteCmdEditMnumberB())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Mnumber_List");
        }

        private bool CanExecuteCmdEditMnumberB()
        {
            return true;
        }

        private RelayCommand _CmdEditMnumberC;

        /// <summary>
        /// Gets the CmdEditMnumberC.
        /// </summary>
        public RelayCommand CmdEditMnumberC
        {
            get
            {
                return _CmdEditMnumberC ?? (_CmdEditMnumberC = new RelayCommand(ExecuteCmdEditMnumberC));
            }
        }

        private void ExecuteCmdEditMnumberC()
        {
            if (!CanExecuteCmdEditMnumberC())
            {
                return;
            }

        }

        private bool CanExecuteCmdEditMnumberC()
        {
            return true;
        }

        private RelayCommand _CmdEditMnumberD;

        /// <summary>
        /// Gets the CmdEditMnumberD.
        /// </summary>
        public RelayCommand CmdEditMnumberD
        {
            get
            {
                return _CmdEditMnumberD ?? (_CmdEditMnumberD = new RelayCommand(ExecuteCmdEditMnumberD));
            }
        }

        private void ExecuteCmdEditMnumberD()
        {
            if (!CanExecuteCmdEditMnumberD())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Mnumber_List");
        }

        private bool CanExecuteCmdEditMnumberD()
        {
            return true;
        }

        private RelayCommand _CmdEditProcessA;

        /// <summary>
        /// Gets the CmdEditProcessA.
        /// </summary>
        public RelayCommand CmdEditProcessA
        {
            get
            {
                return _CmdEditProcessA ?? (_CmdEditProcessA = new RelayCommand(ExecuteCmdEditProcessA));
            }
        }

        private void ExecuteCmdEditProcessA()
        {
            if (!CanExecuteCmdEditProcessA())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Process_List");
        }

        private bool CanExecuteCmdEditProcessA()
        {
            return true;
        }

        private RelayCommand _CmdEditProcessB;

        /// <summary>
        /// Gets the CmdEditProcessB.
        /// </summary>
        public RelayCommand CmdEditProcessB
        {
            get
            {
                return _CmdEditProcessB ?? (_CmdEditProcessB = new RelayCommand(ExecuteCmdEditProcessB));
            }
        }

        private void ExecuteCmdEditProcessB()
        {
            if (!CanExecuteCmdEditProcessB())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Process_List");
        }

        private bool CanExecuteCmdEditProcessB()
        {
            return true;
        }

        private RelayCommand _CmdEditProcessC;

        /// <summary>
        /// Gets the CmdEditProcessC.
        /// </summary>
        public RelayCommand CmdEditProcessC
        {
            get
            {
                return _CmdEditProcessC ?? (_CmdEditProcessC = new RelayCommand(ExecuteCmdEditProcessC));
            }
        }

        private void ExecuteCmdEditProcessC()
        {
            if (!CanExecuteCmdEditProcessC())
            {
                return;
            }

        }

        private bool CanExecuteCmdEditProcessC()
        {
            return true;
        }

        private RelayCommand _CmdEditProcessD;

        /// <summary>
        /// Gets the CmdEditProcessD.
        /// </summary>
        public RelayCommand CmdEditProcessD
        {
            get
            {
                return _CmdEditProcessD ?? (_CmdEditProcessD = new RelayCommand(ExecuteCmdEditProcessD));
            }
        }

        private void ExecuteCmdEditProcessD()
        {
            if (!CanExecuteCmdEditProcessD())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Process_List");
        }

        private bool CanExecuteCmdEditProcessD()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeA;

        /// <summary>
        /// Gets the CmdEditCusCodeA.
        /// </summary>
        public RelayCommand CmdEditCusCodeA
        {
            get
            {
                return _CmdEditCusCodeA ?? (_CmdEditCusCodeA = new RelayCommand(ExecuteCmdEditCusCodeA));
            }
        }

        private void ExecuteCmdEditCusCodeA()
        {
            if (!CanExecuteCmdEditCusCodeA())
            {
                return;
            }

            this.Assign();
        }

        private bool CanExecuteCmdEditCusCodeA()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeB;

        /// <summary>
        /// Gets the CmdEditCusCodeB.
        /// </summary>
        public RelayCommand CmdEditCusCodeB
        {
            get
            {
                return _CmdEditCusCodeB ?? (_CmdEditCusCodeB = new RelayCommand(ExecuteCmdEditCusCodeB));
            }
        }

        private void ExecuteCmdEditCusCodeB()
        {
            if (!CanExecuteCmdEditCusCodeB())
            {
                return;
            }

            this.Assign();
        }

        private bool CanExecuteCmdEditCusCodeB()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeC;

        /// <summary>
        /// Gets the CmdEditCusCodeC.
        /// </summary>
        public RelayCommand CmdEditCusCodeC
        {
            get
            {
                return _CmdEditCusCodeC ?? (_CmdEditCusCodeC = new RelayCommand(ExecuteCmdEditCusCodeC));
            }
        }

        private void ExecuteCmdEditCusCodeC()
        {
            if (!CanExecuteCmdEditCusCodeC())
            {
                return;
            }

        }

        private bool CanExecuteCmdEditCusCodeC()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeD;

        /// <summary>
        /// Gets the CmdEditCusCodeD.
        /// </summary>
        public RelayCommand CmdEditCusCodeD
        {
            get
            {
                return _CmdEditCusCodeD ?? (_CmdEditCusCodeD = new RelayCommand(ExecuteCmdEditCusCodeD));
            }
        }

        private void ExecuteCmdEditCusCodeD()
        {
            if (!CanExecuteCmdEditCusCodeD())
            {
                return;
            }

            this.Assign();
        }

        private bool CanExecuteCmdEditCusCodeD()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeE;

        /// <summary>
        /// Gets the CmdEditCusCodeE.
        /// </summary>
        public RelayCommand CmdEditCusCodeE
        {
            get
            {
                return _CmdEditCusCodeE ?? (_CmdEditCusCodeE = new RelayCommand(ExecuteCmdEditCusCodeE));
            }
        }

        private void ExecuteCmdEditCusCodeE()
        {
            if (!CanExecuteCmdEditCusCodeE())
            {
                return;
            }

            this.Assign();
        }

        private bool CanExecuteCmdEditCusCodeE()
        {
            return true;
        }

        private RelayCommand _CmdEditCusCodeF;

        /// <summary>
        /// Gets the CmdEditCusCodeF.
        /// </summary>
        public RelayCommand CmdEditCusCodeF
        {
            get
            {
                return _CmdEditCusCodeF ?? (_CmdEditCusCodeF = new RelayCommand(ExecuteCmdEditCusCodeF));
            }
        }

        private void ExecuteCmdEditCusCodeF()
        {
            if (!CanExecuteCmdEditCusCodeF())
            {
                return;
            }

            this.Assign();
        }

        private bool CanExecuteCmdEditCusCodeF()
        {
            return true;
        }

        private RelayCommand _CmdEditFrame;

        /// <summary>
        /// Gets the CmdEditFrame.
        /// </summary>
        public RelayCommand CmdEditFrame
        {
            get
            {
                return _CmdEditFrame ?? (_CmdEditFrame = new RelayCommand(ExecuteCmdEditFrame));
            }
        }

        private void ExecuteCmdEditFrame()
        {
            if (!CanExecuteCmdEditFrame())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_Frame_List");
        }

        private bool CanExecuteCmdEditFrame()
        {
            return true;
        }

        private RelayCommand _CmdEditFrameSet;

        /// <summary>
        /// Gets the CmdEditFrameSet.
        /// </summary>
        public RelayCommand CmdEditFrameSet
        {
            get
            {
                return _CmdEditFrameSet ?? (_CmdEditFrameSet = new RelayCommand(ExecuteCmdEditFrameSet));
            }
        }

        private void ExecuteCmdEditFrameSet()
        {
            if (!CanExecuteCmdEditFrameSet())
            {
                return;
            }

            this.Assign("Sale_ContractBill_Sub_FrameSet_List");
        }

        private bool CanExecuteCmdEditFrameSet()
        {
            return true;
        }



        private void Assign(string vname = "Sale_ContractBill_Sub_CusCode")
        {
            USysTemp.BillCodeMain = this.CurrentIDCode;
            ComOpenWins.Open("", vname, is_Flag: false);
            Messenger.Default.Send<string>(this.CurrentIDCode, vname + "_MsgBillCode");
        }


        #endregion


        #endregion

    }
}
