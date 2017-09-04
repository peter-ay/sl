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
        private bool _IsFocusSpGroup = false;
        public bool IsFocusSpGroup
        {
            get { return _IsFocusSpGroup; }
            set
            {
                _IsFocusSpGroup = false;
                RaisePropertyChanged("IsFocusSpGroup");
                _IsFocusSpGroup = true;
                RaisePropertyChanged("IsFocusSpGroup");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdHelpSpGroupPC;

        public RelayCommand CmdHelpSpGroupPC
        {
            get
            {
                return _CmdHelpSpGroupPC
                    ?? (_CmdHelpSpGroupPC = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowSpGroupPC();
                    }));
            }
        }

        private RelayCommand _CmdHelpSpGroupPCList;

        public RelayCommand CmdHelpSpGroupPCList
        {
            get
            {
                return _CmdHelpSpGroupPCList
                    ?? (_CmdHelpSpGroupPCList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowSpGroupPC(true);
                    }));
            }
        }

        protected void CallHelpWinDowSpGroupPC(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_SpGroupPC";
            this.HKeyCode = "SpGroup";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
