using System;
using ERP.Common;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Utility;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private bool _IsFocusLensCode = false;
        public bool IsFocusLensCode
        {
            get { return _IsFocusLensCode; }
            set
            {
                _IsFocusLensCode = false;
                RaisePropertyChanged("IsFocusLensCode");
                _IsFocusLensCode = true;
                RaisePropertyChanged("IsFocusLensCode");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdHelpLensCode;

        public RelayCommand CmdHelpLensCode
        {
            get
            {
                return _CmdHelpLensCode
                    ?? (_CmdHelpLensCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCode();
                    }));
            }
        }

        private RelayCommand _CmdHelpLensCodeList;

        public RelayCommand CmdHelpLensCodeList
        {
            get
            {
                return _CmdHelpLensCodeList
                    ?? (_CmdHelpLensCodeList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCode(true);
                    }));
            }
        }

        private RelayCommand _CmdHelpLensCodeSale;
        private RelayCommand _CmdHelpLensCodeSaleList;
        private RelayCommand _CmdHelpLensCodePur;
        private RelayCommand _CmdHelpLensCodePurList;

        public RelayCommand CmdHelpLensCodeSale
        {
            get
            {
                return _CmdHelpLensCodeSale
                    ?? (_CmdHelpLensCodeSale = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodeSale(false);
                    }));
            }
        }

        public RelayCommand CmdHelpLensCodeSaleList
        {
            get
            {
                return _CmdHelpLensCodeSaleList
                    ?? (_CmdHelpLensCodeSaleList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodeSale(true);
                    }));
            }
        }

        public RelayCommand CmdHelpLensCodePur
        {
            get
            {
                return _CmdHelpLensCodePur
                    ?? (_CmdHelpLensCodePur = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodePur(false);
                    }));
            }
        }

        public RelayCommand CmdHelpLensCodePurList
        {
            get
            {
                return _CmdHelpLensCodePurList
                    ?? (_CmdHelpLensCodePurList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowLensCodePur(true);
                    }));
            }
        }

        protected void CallHelpWinDowLensCode(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_LensCode";
            this.HKeyCode = "LensCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

        protected void CallHelpWinDowLensCodeSale(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_LensCodeSale";
            this.HKeyCode = "LensCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

        protected void CallHelpWinDowLensCodePur(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_LensCodePur";
            this.HKeyCode = "LensCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }
    }
}
