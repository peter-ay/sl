

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>
        private bool _IsFocusOnTabItemReturn;
        public bool IsFocusOnTabItemReturn
        {
            get { return _IsFocusOnTabItemReturn; }
            set
            {
                _IsFocusOnTabItemReturn = false;
                RaisePropertyChanged("IsFocusTabItemOnReturn");
                _IsFocusOnTabItemReturn = true;
                RaisePropertyChanged("IsFocusTabItemOnReturn");
            }
        }
    }
}
