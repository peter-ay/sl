using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdPrint;

        /// <summary>
        /// Gets the CmdPrint.
        /// </summary>
        public RelayCommand CmdPrint
        {
            get
            {
                return _CmdPrint ?? (_CmdPrint = new RelayCommand(ExecuteCmdPrint));
            }
        }

        private void ExecuteCmdPrint()
        {
            if (!CanExecuteCmdPrint())
            {
                return;
            }

            this.Print();
        }

        protected virtual void Print()
        {

        }

        protected virtual bool CanExecuteCmdPrint()
        {
            return URight.Check(this.VMNameAuthority + "_Print",false);
        }

    }
}
