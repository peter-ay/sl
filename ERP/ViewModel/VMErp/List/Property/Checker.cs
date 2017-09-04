
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _Checker;
        public string Checker
        {
            get { return _Checker; }
            set { _Checker = value; RaisePropertyChanged("Checker"); }
        }
    }
}
