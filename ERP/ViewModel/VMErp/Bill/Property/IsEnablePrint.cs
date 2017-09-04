
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnablePrint = false;
        public bool IsEnablePrint
        {
            get { return isEnablePrint; }
            set { isEnablePrint = value; RaisePropertyChanged("IsEnablePrint"); }
        }
    }
}
