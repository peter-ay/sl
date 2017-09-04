using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdCopyRights;

        /// <summary>
        /// Gets the CmdCopyRights.
        /// </summary>
        public RelayCommand CmdCopyRights
        {
            get
            {
                return _CmdCopyRights ?? (_CmdCopyRights = new RelayCommand(ExecuteCmdCopyRights));
            }
        }

        protected void ExecuteCmdCopyRights()
        {
            if (!CanExecuteCmdCopyRights())
            {
                return;
            }
            this.CopyRights();
        }

        protected virtual void CopyRights() { }

        protected virtual bool CanExecuteCmdCopyRights()
        {
            return URight.Check(this.VMNameAuthority + "_CopyRights", false);
            //return true;
        }

    }
}
