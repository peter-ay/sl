
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool _IsReadOnlyMain = true;
        public bool IsReadOnlyMain
        {
            get { return _IsReadOnlyMain; }
            set { _IsReadOnlyMain = value; RaisePropertyChanged("IsReadOnlyMain"); }
        }
    }
}
