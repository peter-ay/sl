
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isFocusNotes = false;
        public bool IsFocusNotes
        {
            get { return isFocusNotes; }
            set
            {
                isFocusNotes = false;
                RaisePropertyChanged("IsFocusNotes");
                isFocusNotes = true;
                RaisePropertyChanged("IsFocusNotes");
            }
        }
    }
}
