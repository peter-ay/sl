using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdExportList;

        /// <summary>
        /// Gets the CmdExportList.
        /// </summary>
        public RelayCommand CmdExportList
        {
            get
            {
                return _CmdExportList ?? (_CmdExportList = new RelayCommand(ExecuteCmdExportList));
            }
        }

        protected void ExecuteCmdExportList()
        {
            if (!CanExecuteCmdExportList())
            {
                return;
            }
            this.ExportList();
        }

        protected virtual void ExportList()
        {
            //ComExport.Export(this.VMNameAuthority.Replace("_List", ""));
        }

        protected virtual bool CanExecuteCmdExportList()
        {
            return URight.Check(this.VMNameAuthority + "_ExportList");
        }

    }
}
