using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdLoad;

        /// <summary>
        /// Gets the ComLoad.
        /// </summary>
        public RelayCommand CmdLoad
        {
            get
            {
                return _CmdLoad ?? (_CmdLoad = new RelayCommand(ExecuteCmdLoad));
            }
        }

        protected void ExecuteCmdLoad()
        {
            if (!CanExecuteCmdLoad())
            {
                return;
            }
            this.Load();
        }

        protected virtual void Load()
        {
            this.Search();
        }

        protected virtual bool CanExecuteCmdLoad()
        {
            return true;
        }
    }
}
