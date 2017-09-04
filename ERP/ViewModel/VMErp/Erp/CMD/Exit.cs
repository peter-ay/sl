using ERP.Common;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdExit;

        /// <summary>
        /// Gets the CmdExit.
        /// </summary>
        public RelayCommand CmdExit
        {
            get
            {
                return _CmdExit ?? (_CmdExit = new RelayCommand(ExecuteCmdExit));
            }
        }

        protected void ExecuteCmdExit()
        {
            if (!CanExecuteCmdExit())
            {
                return;
            }

            this.Exit();
        }

        protected virtual void Exit()
        {
            ComCloseWin.Close(IsChildWindow);
        }

        protected virtual bool CanExecuteCmdExit()
        {
            return true;
        }
    }
}
