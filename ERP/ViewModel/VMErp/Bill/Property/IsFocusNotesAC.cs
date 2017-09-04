
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool isFocusNotesAC = false;
        public bool IsFocusNotesAC
        {
            get { return isFocusNotesAC; }
            set
            {
                isFocusNotesAC = false;
                RaisePropertyChanged("IsFocusNotesAC");
                isFocusNotesAC = true;
                RaisePropertyChanged("IsFocusNotesAC");
            }
        }
    }
}
