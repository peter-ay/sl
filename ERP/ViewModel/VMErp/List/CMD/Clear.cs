using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand _CmdClear;

        /// <summary>
        /// Gets the CmdClear.
        /// </summary>
        public RelayCommand CmdClear
        {
            get
            {
                return _CmdClear
                    ?? (_CmdClear = new RelayCommand(ExecuteCmdClear));
            }
        }

        private void ExecuteCmdClear()
        {
            this.InitSearchCondition();
        }
    }
}
