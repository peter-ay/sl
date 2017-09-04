
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _Maker;
        public string Maker
        {
            get { return _Maker; }
            set { _Maker = value; RaisePropertyChanged("Maker"); }
        }
    }
}
