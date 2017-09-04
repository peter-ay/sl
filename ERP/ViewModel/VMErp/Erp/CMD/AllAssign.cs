using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdAllAssign;

        /// <summary>
        /// Gets the CmdAllAssign.
        /// </summary>
        public RelayCommand CmdAllAssign
        {
            get
            {
                return _CmdAllAssign
                    ?? (_CmdAllAssign = new RelayCommand(ExecuteCmdAllAssign));
            }
        }

        protected virtual void ExecuteCmdAllAssign()
        {
         
        }
    }
}
