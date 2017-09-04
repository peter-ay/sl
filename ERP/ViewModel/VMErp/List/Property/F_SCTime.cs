
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private bool _F_SCTime = true;
        public bool F_SCTime
        {
            get { return _F_SCTime; }
            set { _F_SCTime = value; RaisePropertyChanged("F_SCTime"); }
        }
    }
}
