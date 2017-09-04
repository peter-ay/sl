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
        private bool isFocusCusCode = false;
        public bool IsFocusCusCode
        {
            get { return isFocusCusCode; }
            set
            {
                isFocusCusCode = false;
                RaisePropertyChanged("IsFocusCusCode");
                isFocusCusCode = true;
                RaisePropertyChanged("IsFocusCusCode");
            }
        }

        private RelayCommand _CmdCusCode;

        /// <summary>
        /// Gets the CmdCusCode.
        /// </summary>
        public RelayCommand CmdCusCode
        {
            get
            {
                return _CmdCusCode
                    ?? (_CmdCusCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowCusCode();
                    }));
            }
        }

        protected void CallHelpWinDowCusCode(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_CusCode";
            this.HKeyCode = "CusCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
