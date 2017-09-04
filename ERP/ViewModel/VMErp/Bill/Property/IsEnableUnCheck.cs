
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableUnCheck = false;
        public bool IsEnableUnCheck
        {
            get { return isEnableUnCheck; }
            set { isEnableUnCheck = value; RaisePropertyChanged("IsEnableUnCheck"); }
        }
    }
}
