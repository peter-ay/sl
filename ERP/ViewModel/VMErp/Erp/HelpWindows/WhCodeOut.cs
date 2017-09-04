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
        private bool isFocusWhCodeOut = false;
        public bool IsFocusWhCodeOut
        {
            get { return isFocusWhCodeOut; }
            set
            {
                isFocusWhCodeOut = false;
                RaisePropertyChanged("IsFocusWhCodeOut");
                isFocusWhCodeOut = true;
                RaisePropertyChanged("IsFocusWhCodeOut");
            }
        }

        private RelayCommand _CmdWhCodeOut;

        /// <summary>
        /// Gets the CmdWhCodeOut.
        /// </summary>
        public RelayCommand CmdWhCodeOut
        {
            get
            {
                return _CmdWhCodeOut
                    ?? (_CmdWhCodeOut = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWindowWhCodeOut();
                    }));
            }
        }

        protected void CallHelpWindowWhCodeOut(bool f_InList = false)
        {
            this.HCWKeyCode = "CH_WhCodeOut";
            this.HKeyCode = "WhCodeOut";
            this.HF_InList = f_InList;
            this.CallHelpWindow();
        }

    }
}
