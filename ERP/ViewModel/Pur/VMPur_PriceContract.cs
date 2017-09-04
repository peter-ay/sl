
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
    public class VMPur_PriceContract : VMBill
    {
        #region property

        private V_Pur_PriceContract _DC
        {
            get
            {
                return this.DContextMain as V_Pur_PriceContract;
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

        private bool _IsEnableEditPriceContractSpCode = false;
        public bool IsEnableEditPriceContractSpCode
        {
            get { return _IsEnableEditPriceContractSpCode; }
            set
            {
                _IsEnableEditPriceContractSpCode = value;
                RaisePropertyChanged("IsEnableEditPriceContractSpCode");
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

        public VMPur_PriceContract()
            : base("ID", "Pur_PriceContract")
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
            this.IsEnableEditPriceContractSpCode = false;
            this.IsEnableEditPriceContractLens = false;
            this.IsEnableEditPriceContractFrame = false;
            this.IsEnableEditPriceContractFrameSet = false;
            this.IsEnableEditPriceContractProCost = false;
            //
            IsShowNewGroup = System.Windows.Visibility.Collapsed;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableEditPriceContractSpCode = true;
                    this.IsEnableEditPriceContractLens = true;
                    this.IsEnableEditPriceContractFrame = true;
                    this.IsEnableEditPriceContractFrameSet = true;
                    this.IsEnableEditPriceContractProCost = true;
                    //if (!string.IsNullOrEmpty(this._DC.Checker))
                    //{
                    //    this.IsEnableEditPriceContractSpCode = true;
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
            if (string.IsNullOrEmpty(_DC.SpGroup.Trim()) && this.GpCodeNew.Trim() == "")
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_SpGroupNull"));
                return false;
            }

            if (string.IsNullOrEmpty(GpCodeNew.Trim()) && this._DC.GpNameNew.Trim() != "" && this._DC.SpGroup.Trim() == "")
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_SpGroupNull"));
                return false;
            }

            if (!string.IsNullOrEmpty(this.GpCodeNew))
            {
                this._DC.SpGroup = this.GpCodeNew;
            }

            return true;
        }
        ////////////////////////////////////////
        #region editbutton

        private RelayCommand _CmdEditPriceContractSpCode;
        /// <summary>
        /// Gets the CmdEditPriceContractSpCode.
        /// </summary>
        public RelayCommand CmdEditPriceContractSpCode
        {
            get
            {
                return _CmdEditPriceContractSpCode ?? (_CmdEditPriceContractSpCode = new RelayCommand(ExecuteCmdEditPriceContractSpCode));
            }
        }

        private void ExecuteCmdEditPriceContractSpCode()
        {
            if (!CanExecuteCmdEditPriceContractSpCode())
            {
                return;
            }

            this.AssignNewWin();
        }

        private bool CanExecuteCmdEditPriceContractSpCode()
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

            this.AssignNewWin("Pur_PriceContract_Lens_List");
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

            this.AssignNewWin("Pur_PriceContract_Lens_ProCost_List");
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

            this.AssignNewWin("Pur_PriceContract_Frame_List");
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

            this.AssignNewWin("Pur_PriceContract_FrameSet_List");
        }

        private bool CanExecuteCmdEditPriceContractFrameSet()
        {
            return true;
        }



        private void AssignNewWin(string fCode = "Pur_PriceContract_SpCode", string vName = "")
        {
            if (vName == "")
            {
                vName = ErpUIText.Get(fCode);
            }
            var _sCode = "";
            if (fCode == "Pur_PriceContract_SpCode")
            {
                _sCode = this._DC.BCode + "||" + this._DC.SpGroup + "||" + this._DC.SpGpName;
            }
            else
            {
                _sCode = this._DC.ID + "||" + this._DC.BCode + "||" + this._DC.SpGroup + "||" + this._DC.SpGpName;
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
