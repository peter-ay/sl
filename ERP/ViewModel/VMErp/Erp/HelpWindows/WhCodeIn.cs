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
        private bool isFocusWhCodeIn = false;
        public bool IsFocusWhCodeIn
        {
            get { return isFocusWhCodeIn; }
            set
            {
                isFocusWhCodeIn = false;
                RaisePropertyChanged("IsFocusWhCodeIn");
                isFocusWhCodeIn = true;
                RaisePropertyChanged("IsFocusWhCodeIn");
            }
        }

        private RelayCommand _CmdWhCodeIn;

        /// <summary>
        /// Gets the CmdWhCodeIn.
        /// </summary>
        public RelayCommand CmdWhCodeIn
        {
            get
            {
                return _CmdWhCodeIn
                    ?? (_CmdWhCodeIn = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWindowWhCodeIn();
                    }));
            }
        }

        protected void CallHelpWindowWhCodeIn(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_WhCodeIn";
            this.HKeyCode = "WhCodeIn";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
