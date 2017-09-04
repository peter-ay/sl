

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>
        private bool _IsFocusTabItemReturn;
        public bool IsFocusTabItemReturn
        {
            get { return _IsFocusTabItemReturn; }
            set
            {
                _IsFocusTabItemReturn = false;
                RaisePropertyChanged("IsFocusTabItemReturn");
                _IsFocusTabItemReturn = true;
                RaisePropertyChanged("IsFocusTabItemReturn");
            }
        }
    }
}
