

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private bool _IsFocusID;
        /// <summary>
        /// ////////////////////////////////
        /// </summary>
        public bool IsFocusID
        {
            get { return _IsFocusID; }
            set
            {
                _IsFocusID = false;
                RaisePropertyChanged("IsFocusID");
                _IsFocusID = true;
                RaisePropertyChanged("IsFocusID");
            }
        }
    }
}
