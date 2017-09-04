
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isEnableNew = true;
        public bool IsEnableNew
        {
            get { return isEnableNew; }
            set { isEnableNew = value; RaisePropertyChanged("IsEnableNew"); }
        }
    }
}
