
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int _ACMinimumPrefixLength = 0;
        public int ACMinimumPrefixLength
        {
            get { return _ACMinimumPrefixLength; }
            set { _ACMinimumPrefixLength = value; RaisePropertyChanged("ACMinimumPrefixLength"); }
        }
    }
}
