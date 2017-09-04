
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableNext = false;
        public bool IsEnableNext
        {
            get { return isEnableNext; }
            set { isEnableNext = value; RaisePropertyChanged("IsEnableNext"); }
        }
    }
}
