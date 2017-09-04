using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdImport;

        /// <summary>
        /// Gets the CmdImport.
        /// </summary>
        public RelayCommand CmdImport
        {
            get
            {
                return _CmdImport ?? (_CmdImport = new RelayCommand(ExecuteCmdImport));
            }
        }

        protected void ExecuteCmdImport()
        {
            if (!CanExecuteCmdImport())
            {
                return;
            }
            this.Import();
        }

        protected virtual void Import()
        {
            ComImport.Import(this.VMNameAuthority.Replace("_List", ""));
        }

        protected virtual bool CanExecuteCmdImport()
        {
            return URight.Check(this.VMNameAuthority + "_Import", false);
        }

    }
}
