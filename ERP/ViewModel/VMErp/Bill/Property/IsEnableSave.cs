
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableSave = false;
        public bool IsEnableSave
        {
            get { return isEnableSave; }
            set { isEnableSave = value; RaisePropertyChanged("IsEnableSave"); }
        }
    }
}
