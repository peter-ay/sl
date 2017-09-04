
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableCancel = false;
        public bool IsEnableCancel
        {
            get { return isEnableCancel; }
            set { isEnableCancel = value; RaisePropertyChanged("IsEnableCancel"); }
        }
    }
}
