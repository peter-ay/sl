using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Utility;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdCancel;

        /// <summary>
        /// Gets the CmdCancel.
        /// </summary>
        public RelayCommand CmdCancel
        {
            get
            {
                return _CmdCancel ?? (_CmdCancel = new RelayCommand(ExecuteCmdCancel));
            }
        }

        protected void ExecuteCmdCancel()
        {
            if (!CanExecuteCmdCancel())
            {
                return;
            }
            this.Cancel();
        }

        protected virtual void Cancel()
        {
            Messenger.Default.Send<bool>(false, this.VMName.Substring(2) + "_Result");
        }

        protected virtual bool CanExecuteCmdCancel()
        {
            return URight.Check(this.VMNameAuthority + "_Cancel", false);
        }
    }
}
