using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdAssign;

        /// <summary>
        /// Gets the CmdAssign.
        /// </summary>
        public RelayCommand CmdAssign
        {
            get
            {
                return _CmdAssign ?? (_CmdAssign = new RelayCommand(ExecuteCmdAssign));
            }
        }

        protected void ExecuteCmdAssign()
        {
            if (!CanExecuteCmdAssign())
            {
                return;
            }
            this.Assign();
        }

        protected virtual void Assign() { }

        protected virtual bool CanExecuteCmdAssign()
        {
            return URight.Check(this.VMNameAuthority + "_Assign", false);
        }

    }
}
