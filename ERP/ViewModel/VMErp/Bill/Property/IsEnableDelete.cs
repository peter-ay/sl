
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableDelete = false;
        public bool IsEnableDelete
        {
            get { return isEnableDelete; }
            set { isEnableDelete = value; RaisePropertyChanged("IsEnableDelete"); }
        }
    }
}
