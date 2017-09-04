
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableReOrder = false;
        public bool IsEnableReOrder
        {
            get { return isEnableReOrder; }
            set { isEnableReOrder = value; RaisePropertyChanged("IsEnableReOrder"); }
        }
    }
}
