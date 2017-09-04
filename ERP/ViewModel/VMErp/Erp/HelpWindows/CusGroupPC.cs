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
        private bool _IsFocusCusGroup = false;
        public bool IsFocusCusGroup
        {
            get { return _IsFocusCusGroup; }
            set
            {
                _IsFocusCusGroup = false;
                RaisePropertyChanged("IsFocusCusGroup");
                _IsFocusCusGroup = true;
                RaisePropertyChanged("IsFocusCusGroup");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdHelpCusGroupPC;

        public RelayCommand CmdHelpCusGroupPC
        {
            get
            {
                return _CmdHelpCusGroupPC
                    ?? (_CmdHelpCusGroupPC = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowCusGroupPC();
                    }));
            }
        }

        private RelayCommand _CmdHelpCusGroupPCList;

        public RelayCommand CmdHelpCusGroupPCList
        {
            get
            {
                return _CmdHelpCusGroupPCList
                    ?? (_CmdHelpCusGroupPCList = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowCusGroupPC(true);
                    }));
            }
        }

        protected void CallHelpWinDowCusGroupPC(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_CusGroupPC";
            this.HKeyCode = "CusGroup";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
