
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMSale_PriceContract : VMBill
    {
        #region property

        private V_Sale_PriceContract _DC
        {
            get
            {
                return this.DContextMain as V_Sale_PriceContract;
            }
        }

        #region PriID

        private bool _IsEnablePCP = true;
        public bool IsEnablePCP
        {
            get { return _IsEnablePCP; }
            set
            {
                _IsEnablePCP = value;
                RaisePropertyChanged("IsEnablePCP");
            }
        }

        private bool _IsCheckPCP1 = true;
        public bool IsCheckPCP1
        {
            get { return _IsCheckPCP1; }
            set
            {
                _IsCheckPCP1 = value;
                RaisePropertyChanged("IsCheckPCP1");
            }
        }

        private bool _IsCheckPCP2 = false;
        public bool IsCheckPCP2
        {
            get { return _IsCheckPCP2; }
            set
            {
                _IsCheckPCP2 = value;
                RaisePropertyChanged("IsCheckPCP2");
            }
        }

        private bool _IsCheckPCP3 = false;
        public bool IsCheckPCP3
        {
            get { return _IsCheckPCP3; }
            set
            {
                _IsCheckPCP3 = value;
                RaisePropertyChanged("IsCheckPCP3");
            }
        }

        private bool _IsCheckPCP4 = false;
        public bool IsCheckPCP4
        {
            get { return _IsCheckPCP4; }
            set
            {
                _IsCheckPCP4 = value;
                RaisePropertyChanged("IsCheckPCP4");
            }
        }

        #endregion

        #region ContactType

        private bool _IsCheckPCTLens = true;
        public bool IsCheckPCTLens
        {
            get { return _IsCheckPCTLens; }
            set
            {
                _IsCheckPCTLens = value;
                RaisePropertyChanged("IsCheckPCTLens");
            }
        }

        private bool _IsCheckPCTFrame = false;
        public bool IsCheckPCTFrame
        {
            get { return _IsCheckPCTFrame; }
            set
            {
                _IsCheckPCTFrame = value;
                RaisePropertyChanged("IsCheckPCTFrame");
            }
        }

        #endregion

        #region enableButton

        private bool _IsEnableEditPriceContractLens = false;
        public bool IsEnableEditPriceContractLens
        {
            get { return _IsEnableEditPriceContractLens; }
            set
            {
                _IsEnableEditPriceContractLens = value;
                RaisePropertyChanged("IsEnableEditPriceContractLens");
            }
        }

        private bool _IsEnableEditPriceContractFrame = false;
        public bool IsEnableEditPriceContractFrame
        {
            get { return _IsEnableEditPriceContractFrame; }
            set
            {
                _IsEnableEditPriceContractFrame = value;
                RaisePropertyChanged("IsEnableEditPriceContractFrame");
            }
        }

        private bool _IsEnableEditPriceContractFrameSet = false;
        public bool IsEnableEditPriceContractFrameSet
        {
            get { return _IsEnableEditPriceContractFrameSet; }
            set
            {
                _IsEnableEditPriceContractFrameSet = value;
                RaisePropertyChanged("IsEnableEditPriceContractFrameSet");
            }
        }

        private bool _IsEnableEditPriceContractProCost = false;
        public bool IsEnableEditPriceContractProCost
        {
            get { return _IsEnableEditPriceContractProCost; }
            set
            {
                _IsEnableEditPriceContractProCost = value;
                RaisePropertyChanged("IsEnableEditPriceContractProCost");
            }
        }

        private bool _IsEnableEditPriceContractCusCode = false;
        public bool IsEnableEditPriceContractCusCode
        {
            get { return _IsEnableEditPriceContractCusCode; }
            set
            {
                _IsEnableEditPriceContractCusCode = value;
                RaisePropertyChanged("IsEnableEditPriceContractCusCode");
            }
        }

        #endregion

        private System.Windows.Visibility _IsShowNewGroup = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsShowNewGroup
        {
            get { return _IsShowNewGroup; }
            set { _IsShowNewGroup = value; RaisePropertyChanged("IsShowNewGroup"); }
        }

        private string _GpCodeNew = "";
        public string GpCodeNew
        {
            get { return _GpCodeNew; }
            set { _GpCodeNew = value; RaisePropertyChanged("GpCodeNew"); }
        }

        #endregion

        public VMSale_PriceContract()
            : base("ID", "Sale_PriceContract")
        {
        }

        #region methods
        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            this.ReSetPriID();
        }

        private void ReSetPriID()
        {
            try
            {
                switch (_DC.PriCode)
                {
                    case 1:
                        this.IsCheckPCP1 = true;
                        break;
                    case 2:
                        this.IsCheckPCP2 = true;
                        break;
                    case 3:
                        this.IsCheckPCP3 = true;
                        break;
                    case 4:
                        this.IsCheckPCP4 = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        protected override void ChangeBillSate(Utility.UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnablePCP = false;
            //
            this.IsEnableEditPriceContractCusCode = false;
            this.IsEnableEditPriceContractLens = false;
            this.IsEnableEditPriceContractFrame = false;
            this.IsEnableEditPriceContractFrameSet = false;
            this.IsEnableEditPriceContractProCost = false;
            //
            IsShowNewGroup = System.Windows.Visibility.Collapsed;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableEditPriceContractCusCode = true;
                    this.IsEnableEditPriceContractLens = true;
                    this.IsEnableEditPriceContractFrame = true;
                    this.IsEnableEditPriceContractFrameSet = true;
                    this.IsEnableEditPriceContractProCost = true;
                    //if (!string.IsNullOrEmpty(this._DC.Checker))
                    //{
                    //    this.IsEnableEditPriceContractCusCode = true;
                    //    this.IsEnableEditPriceContractLens = true;
                    //    this.IsEnableEditPriceContractFrame = true;
                    //    this.IsEnableEditPriceContractFrameSet = true;
                    //    this.IsEnableEditPriceContractProCost = true;
                    //}
                    break;
                case UBillState.Drop:

                    break;
                case UBillState.New:
                    IsShowNewGroup = System.Windows.Visibility.Visible;

                    break;
                case UBillState.Edit:
                    this.IsEnablePCP = true;

                    break;
            }
        }

        protected override void New()
        {
            base.New();
            this.ReSetPriID();
        }

        protected override bool VerifySave()
        {
            if (string.IsNullOrEmpty(_DC.CusGroup.Trim()) && this.GpCodeNew.Trim() == "")
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusGroupNull"));
                return false;
            }

            if (string.IsNullOrEmpty(GpCodeNew.Trim()) && this._DC.GpNameNew.Trim() != "" && this._DC.CusGroup.Trim() == "")
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusGroupNull"));
                return false;
            }

            if (!string.IsNullOrEmpty(this.GpCodeNew))
            {
                this._DC.CusGroup = this.GpCodeNew;
            }

            return true;
        }
        ////////////////////////////////////////
        #region editbutton

        private RelayCommand _CmdEditPriceContractCusCode;
        /// <summary>
        /// Gets the CmdEditPriceContractCusCode.
        /// </summary>
        public RelayCommand CmdEditPriceContractCusCode
        {
            get
            {
                return _CmdEditPriceContractCusCode ?? (_CmdEditPriceContractCusCode = new RelayCommand(ExecuteCmdEditPriceContractCusCode));
            }
        }

        private void ExecuteCmdEditPriceContractCusCode()
        {
            if (!CanExecuteCmdEditPriceContractCusCode())
            {
                return;
            }

            this.AssignNewWin();
        }

        private bool CanExecuteCmdEditPriceContractCusCode()
        {
            return true;
        }

        private RelayCommand _CmdEditPriceContractLens;

        /// <summary>
        /// Gets the CmdEditPriceContractLens.
        /// </summary>
        public RelayCommand CmdEditPriceContractLens
        {
            get
            {
                return _CmdEditPriceContractLens ?? (_CmdEditPriceContractLens = new RelayCommand(ExecuteCmdEditPriceContractLens));
            }
        }

        private void ExecuteCmdEditPriceContractLens()
        {
            if (!CanExecuteCmdEditPriceContractLens())
            {
                return;
            }

            this.AssignNewWin("Sale_PriceContract_Lens_List");
        }

        private bool CanExecuteCmdEditPriceContractLens()
        {
            return true;
        }

        private RelayCommand _CmdEditPriceContractProCost;

        /// <summary>
        /// Gets the CmdEditPriceContractProCost.
        /// </summary>
        public RelayCommand CmdEditPriceContractProCost
        {
            get
            {
                return _CmdEditPriceContractProCost ?? (_CmdEditPriceContractProCost = new RelayCommand(ExecuteCmdEditPriceContractProCost));
            }
        }

        private void ExecuteCmdEditPriceContractProCost()
        {
            if (!CanExecuteCmdEditPriceContractProCost())
            {
                return;
            }

            this.AssignNewWin("Sale_PriceContract_Lens_ProCost_List");
        }

        private bool CanExecuteCmdEditPriceContractProCost()
        {
            return true;
        }

        private RelayCommand _CmdEditPriceContractFrame;

        /// <summary>
        /// Gets the CmdEditFrame.
        /// </summary>
        public RelayCommand CmdEditPriceContractFrame
        {
            get
            {
                return _CmdEditPriceContractFrame ?? (_CmdEditPriceContractFrame = new RelayCommand(ExecuteCmdEditPriceContractFrame));
            }
        }

        private void ExecuteCmdEditPriceContractFrame()
        {
            if (!CanExecuteCmdEditPriceContractFrame())
            {
                return;
            }

            this.AssignNewWin("Sale_PriceContract_Frame_List");
        }

        private bool CanExecuteCmdEditPriceContractFrame()
        {
            return true;
        }

        private RelayCommand _CmdEditPriceContractFrameSet;

        /// <summary>
        /// Gets the CmdEditFrameSet.
        /// </summary>
        public RelayCommand CmdEditPriceContractFrameSet
        {
            get
            {
                return _CmdEditPriceContractFrameSet ?? (_CmdEditPriceContractFrameSet = new RelayCommand(ExecuteCmdEditPriceContractFrameSet));
            }
        }

        private void ExecuteCmdEditPriceContractFrameSet()
        {
            if (!CanExecuteCmdEditPriceContractFrameSet())
            {
                return;
            }

            this.AssignNewWin("Sale_PriceContract_FrameSet_List");
        }

        private bool CanExecuteCmdEditPriceContractFrameSet()
        {
            return true;
        }



        private void AssignNewWin(string fCode = "Sale_PriceContract_CusCode", string vName = "")
        {
            if (vName == "")
            {
                vName = ErpUIText.Get(fCode);
            }
            var _sCode = "";
            if (fCode == "Sale_PriceContract_CusCode")
            {
                _sCode = this._DC.BCode + "||" + this._DC.CusGroup + "||" + this._DC.CusGpName;
            }
            else
            {
                _sCode = this._DC.ID + "||" + this._DC.BCode + "||" + this._DC.CusGroup + "||" + this._DC.CusGpName;
            }
            ComAssignWins.Assign(_sCode, fCode, vName);
        }


        #endregion

        private RelayCommand<string> _CmdRBPCPCheck;

        /// <summary>
        /// Gets the CmdRBPCPCheck.
        /// </summary>
        public RelayCommand<string> CmdRBPCPCheck
        {
            get
            {
                return _CmdRBPCPCheck
                    ?? (_CmdRBPCPCheck = new RelayCommand<string>(ExecuteCmdRBPCPCheck));
            }
        }

        private void ExecuteCmdRBPCPCheck(string parameter)
        {
            try
            {
                _DC.PriCode = Convert.ToByte(parameter);
            }
            catch
            {
                if (_DC != null)
                {
                    _DC.PriCode = 1;
                }
            }
        }

        #endregion

    }
}
