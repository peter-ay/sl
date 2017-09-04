using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<bool> _CmdGridHeadCheck;

        /// <summary>
        /// Gets the CmdGridHeadCheck.
        /// </summary>
        public RelayCommand<bool> CmdGridHeadCheck
        {
            get
            {
                return _CmdGridHeadCheck
                    ?? (_CmdGridHeadCheck = new RelayCommand<bool>(ExecuteCmdGridHeadCheck));
            }
        }

        private void ExecuteCmdGridHeadCheck(bool parameter)
        {
            try
            {
                foreach (var item in this.DContextList)
                {
                    item.GetType().GetProperty("IsSelected").SetValue(item, parameter, null);
                }
            }
            catch { }
        }
    }
}
