using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdRefresh2;

        /// <summary>
        /// Gets the ComSearch.
        /// </summary>
        public RelayCommand CmdRefresh2
        {
            get
            {
                return _CmdRefresh2 ?? (_CmdRefresh2 = new RelayCommand(ExecuteCmdRefresh2));
            }
        }

        protected void ExecuteCmdRefresh2()
        {
            if (!CanExecuteCmdRefresh2())
            {
                return;
            }
            this.Refresh2();
        }

        protected virtual void Refresh2()
        {

        }

        //protected virtual void PrepareLoadList() { }

        protected virtual bool CanExecuteCmdRefresh2()
        {
            return true;
        }
    }
}
