
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnablePrintToFactory = false;
        public bool IsEnablePrintToFactory
        {
            get { return isEnablePrintToFactory; }
            set { isEnablePrintToFactory = value; RaisePropertyChanged("IsEnablePrintToFactory"); }
        }
    }
}
