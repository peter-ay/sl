
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private bool _IsCheckAll = true;
        public bool IsCheckAll
        {
            get { return _IsCheckAll; }
            set { _IsCheckAll = value; RaisePropertyChanged("IsCheckAll"); }
        }
    }
}
