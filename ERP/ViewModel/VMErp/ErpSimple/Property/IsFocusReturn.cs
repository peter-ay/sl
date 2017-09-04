

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private bool _IsFocusReturn;
        /// <summary>
        /// /////////////移动焦点，为更新textbox////////////
        /// </summary>
        public bool IsFocusReturn
        {
            get { return _IsFocusReturn; }
            set
            {
                _IsFocusReturn = false;
                RaisePropertyChanged("IsFocusReturn");
                _IsFocusReturn = true;
                RaisePropertyChanged("IsFocusReturn");
            }
        }
    }
}
