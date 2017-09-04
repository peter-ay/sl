
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableEdit = false;
        public bool IsEnableEdit
        {
            get { return isEnableEdit; }
            set { isEnableEdit = value; RaisePropertyChanged("IsEnableEdit"); }
        }
    }
}
