
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableLocate = false;
        public bool IsEnableLocate
        {
            get { return isEnableLocate; }
            set { isEnableLocate = value; RaisePropertyChanged("IsEnableLocate"); }
        }
    }
}
