
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableCheck = false;
        public bool IsEnableCheck
        {
            get { return isEnableCheck; }
            set { isEnableCheck = value; RaisePropertyChanged("IsEnableCheck"); }
        }
    }
}
