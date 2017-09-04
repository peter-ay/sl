

using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private bool _IsLoad = false;
        private RelayCommand _CmdViewOnLoad;
        /// <summary>
        /// Gets the CmdViewOnLoad.
        /// </summary>
        public RelayCommand CmdViewOnLoad
        {
            get
            {
                return _CmdViewOnLoad
                    ?? (_CmdViewOnLoad = new RelayCommand(ExecuteCmdViewOnLoad));
            }
        }

        private void ExecuteCmdViewOnLoad()
        {
            if (!_IsLoad)
            {
                _IsLoad = true;
                this.ViewOnLoad();
            }
        }

        protected virtual void ViewOnLoad() { }
    }
}
