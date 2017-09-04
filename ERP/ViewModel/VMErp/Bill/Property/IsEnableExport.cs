
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableExport = false;
        public bool IsEnableExport
        {
            get { return isEnableExport; }
            set { isEnableExport = value; RaisePropertyChanged("IsEnableExport"); }
        }
    }
}
