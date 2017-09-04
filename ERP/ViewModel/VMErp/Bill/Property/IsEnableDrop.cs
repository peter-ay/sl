
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableDrop = false;
        public bool IsEnableDrop
        {
            get { return isEnableDrop; }
            set { isEnableDrop = value; RaisePropertyChanged("IsEnableDrop"); }
        }
    }
}
