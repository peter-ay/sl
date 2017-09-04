using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand _CmdSearch;

        /// <summary>
        /// Gets the ComSearch.
        /// </summary>
        public RelayCommand CmdSearch
        {
            get
            {
                return _CmdSearch ?? (_CmdSearch = new RelayCommand(ExecuteCmdSearch));
            }
        }

        protected void ExecuteCmdSearch()
        {
            if (!CanExecuteCmdSearch())
            {
                return;
            }
            this.Search();
        }

        protected virtual void Search()
        {
            this.PrepareLoadList();
        }

        protected virtual void PrepareLoadList() { }

        protected virtual bool CanExecuteCmdSearch()
        {
            return URight.Check(this.VMNameAuthority + "_Search", false);
        }
    }
}
