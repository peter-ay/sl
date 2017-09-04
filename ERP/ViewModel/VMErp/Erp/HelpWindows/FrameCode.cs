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
        private bool _IsFocusFrameCode = false;
        public bool IsFocusFrameCode
        {
            get { return _IsFocusFrameCode; }
            set
            {
                _IsFocusFrameCode = false;
                RaisePropertyChanged("IsFocusFrameCode");
                _IsFocusFrameCode = true;
                RaisePropertyChanged("IsFocusFrameCode");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdHelpFrameCode;

        public RelayCommand CmdHelpFrameCode
        {
            get
            {
                return _CmdHelpFrameCode
                    ?? (_CmdHelpFrameCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowFrameCode();
                    }));
            }
        }

        private RelayCommand _CmdHelpFrameCodeList;

        public RelayCommand CmdHelpFrameCodeList
        {
            get
            {
                return _CmdHelpFrameCodeList
                    ?? (_CmdHelpFrameCodeList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowFrameCode(true);
                    }));
            }
        }

        protected void CallHelpWinDowFrameCode(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_FrameCode";
            this.HKeyCode = "FrameCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
