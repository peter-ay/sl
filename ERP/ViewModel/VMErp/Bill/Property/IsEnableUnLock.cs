
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableUnLock = false;
        public bool IsEnableUnLock
        {
            get { return isEnableUnLock; }
            set { isEnableUnLock = value; RaisePropertyChanged("IsEnableUnLock"); }
        }
    }
}
