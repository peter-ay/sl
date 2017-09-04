
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private bool _BTypeAll = true;
        public bool BTypeAll
        {
            get { return _BTypeAll; }
            set { _BTypeAll = value; RaisePropertyChanged("BTypeAll"); }
        }
    }
}
