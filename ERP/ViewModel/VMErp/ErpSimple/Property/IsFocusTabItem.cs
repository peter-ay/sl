

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    { 
        private bool _IsFocusTabItem;
        public bool IsFocusTabItem
        {
            get { return _IsFocusTabItem; }
            set
            {
                _IsFocusTabItem = false;
                RaisePropertyChanged("IsFocusTabItem");
                _IsFocusTabItem = true;
                RaisePropertyChanged("IsFocusTabItem");
            }
        }
    }
}
