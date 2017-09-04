
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnablePrevious = false;
        public bool IsEnablePrevious
        {
            get { return isEnablePrevious; }
            set { isEnablePrevious = value; RaisePropertyChanged("IsEnablePrevious"); }
        }
    }
}
