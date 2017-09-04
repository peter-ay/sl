using GalaSoft.MvvmLight.Command;
using ERP.Utility;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand _CmdCheck;

        /// <summary>
        /// Gets the CmdCheck.
        /// </summary>
        public RelayCommand CmdCheck
        {
            get
            {
                return _CmdCheck
                    ?? (_CmdCheck = new RelayCommand(ExecuteCmdCheck));
            }
        }

        private void ExecuteCmdCheck()
        {
            if (!CanExecuteCmdCheck())
            {
                return;
            }
            this.Check();
        }

        protected virtual bool CanExecuteCmdCheck()
        {
            return URight.Check(this.VMNameAuthority + "_Check");
        }

        protected virtual void Check()
        {

        }
    }
}
