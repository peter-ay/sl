using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdAllUnAssign;

        /// <summary>
        /// Gets the CmdAllUnAssign.
        /// </summary>
        public RelayCommand CmdAllUnAssign
        {
            get
            {
                return _CmdAllUnAssign
                    ?? (_CmdAllUnAssign = new RelayCommand(ExecuteCmdAllUnAssign));
            }
        }

        protected virtual void ExecuteCmdAllUnAssign()
        {
 
        }
    }
}
