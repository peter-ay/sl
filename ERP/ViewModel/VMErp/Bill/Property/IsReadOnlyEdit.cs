
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool _IsReadOnlyEdit = true;
        public bool IsReadOnlyEdit
        {
            get { return _IsReadOnlyEdit; }
            set { _IsReadOnlyEdit = value; RaisePropertyChanged("IsReadOnlyEdit"); }
        }
    }
}
