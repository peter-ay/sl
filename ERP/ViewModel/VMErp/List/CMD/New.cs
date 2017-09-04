using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public partial class VMList
    {

        private RelayCommand _CmdNew;
        /// <summary>
        /// Gets the CmdNew.
        /// </summary>
        public RelayCommand CmdNew
        {
            get
            {
                return _CmdNew ?? (_CmdNew = new RelayCommand(ExecuteCmdNew));
            }
        }

        private void ExecuteCmdNew()
        {
            if (!CanExecuteCmdNew())
            {
                return;
            }
            this.New();
        }

        protected virtual void New()
        {
            var fcode = this.VMNameAuthority.Replace("_List", "");
            ComOpenWins.Open("", fcode);
            Messenger.Default.Send<string>((""), this.VMName.Replace("_List", "_NewFromList"));
        }

        private bool CanExecuteCmdNew()
        {
            return URight.Check(this.VMNameAuthority + "_New", false);
        }
    }
}
