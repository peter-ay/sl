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
        private RelayCommand _CmdWhCodeBrowse;

        private bool _IsFocusWhCode = false;
        public bool IsFocusWhCode
        {
            get { return _IsFocusWhCode; }
            set
            {
                _IsFocusWhCode = false;
                RaisePropertyChanged("IsFocusWhCode");
                _IsFocusWhCode = true;
                RaisePropertyChanged("IsFocusWhCode");
            }
        }

        public RelayCommand CmdWhCodeBrowse
        {
            get
            {
                return _CmdWhCodeBrowse
                    ?? (_CmdWhCodeBrowse = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowWhCodeBrowse();
                    }));
            }
        }

        public RelayCommand CmdWhCodeBrowseList
        {
            get
            {
                return _CmdWhCodeBrowse
                    ?? (_CmdWhCodeBrowse = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowWhCodeBrowse(true);
                    }));
            }
        }

        protected void CallHelpWinDowWhCodeBrowse(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_WhCodeBrowse";
            this.HKeyCode = "WhCode";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
