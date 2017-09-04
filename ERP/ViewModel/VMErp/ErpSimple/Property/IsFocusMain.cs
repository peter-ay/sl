

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private bool _IsFocusMain;
        /// <summary>
        /// ////////////////////////
        /// </summary>
        public bool IsFocusMain
        {
            get { return _IsFocusMain; }
            set
            {
                _IsFocusMain = false;
                RaisePropertyChanged("IsFocusMain");
                _IsFocusMain = true;
                RaisePropertyChanged("IsFocusMain");
            }
        }
    }
}
