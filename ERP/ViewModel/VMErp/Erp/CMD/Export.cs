using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdExport;

        /// <summary>
        /// Gets the CmdExport.
        /// </summary>
        public RelayCommand CmdExport
        {
            get
            {
                return _CmdExport ?? (_CmdExport = new RelayCommand(ExecuteCmdExport));
            }
        }

        protected void ExecuteCmdExport()
        {
            if (!CanExecuteCmdExport())
            {
                return;
            }
            this.Export();
        }

        protected virtual void Export()
        {
            ComExport.Export(this.VMNameAuthority.Replace("_List", ""));
        }

        protected virtual bool CanExecuteCmdExport()
        {
            return URight.Check(this.VMNameAuthority + "_Export");
        }

    }
}
