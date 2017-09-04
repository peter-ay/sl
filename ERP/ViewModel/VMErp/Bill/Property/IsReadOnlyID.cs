
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool _IsReadOnlyID = true;
        public bool IsReadOnlyID
        {
            get { return _IsReadOnlyID; }
            set { _IsReadOnlyID = value; RaisePropertyChanged("IsReadOnlyID"); }
        }
    }
}
