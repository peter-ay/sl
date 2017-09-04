using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdPrintToFactory;

        /// <summary>
        /// Gets the CmdPrintToFactory.
        /// </summary>
        public RelayCommand CmdPrintToFactory
        {
            get
            {
                return _CmdPrintToFactory ?? (_CmdPrintToFactory = new RelayCommand(ExecuteCmdPrintToFactory));
            }
        }

        private void ExecuteCmdPrintToFactory()
        {
            if (!CanExecuteCmdPrintToFactory())
            {
                return;
            }

            this.PrintToFactory();
        }

        protected virtual void PrintToFactory()
        {

        }

        private bool CanExecuteCmdPrintToFactory()
        {
            return URight.Check(this.VMNameAuthority + "_PrintToFactory", false);
        }

    }
}
