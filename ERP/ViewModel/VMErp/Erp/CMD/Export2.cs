using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdExport2;

        /// <summary>
        /// Gets the CmdExport2.
        /// </summary>
        public RelayCommand CmdExport2
        {
            get
            {
                return _CmdExport2 ?? (_CmdExport2 = new RelayCommand(ExecuteCmdExport2));
            }
        }

        protected void ExecuteCmdExport2()
        {
            if (!CanExecuteCmdExport2())
            {
                return;
            }
            this.Export2();
        }

        protected virtual void Export2()
        {
            //ComExport.Export(this.VMNameAuthority.Replace("_List", ""));
        }

        protected virtual bool CanExecuteCmdExport2()
        {
            return URight.Check(this.VMNameAuthority + "_Export2");
        }

    }
}
