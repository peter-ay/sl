using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdOK;

        public RelayCommand CmdOK
        {
            get
            {
                return _CmdOK ?? (_CmdOK = new RelayCommand(ExecuteCmdOK));
            }
        }

        protected void ExecuteCmdOK()
        {
            if (!CanExecuteCmdOK())
            {
                return;
            }
            this.OK();
        }

        protected virtual void OK()
        {
            Messenger.Default.Send<bool>(true, this.VMName.Substring(2) + "_Result");
        }

        protected virtual bool CanExecuteCmdOK()
        {
            return true;
        }
    }
}
