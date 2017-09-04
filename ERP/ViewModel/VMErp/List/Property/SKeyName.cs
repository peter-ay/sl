
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _SKeyName = "";
        public string SKeyName
        {
            get { return _SKeyName; }
            set
            {
                _SKeyName = value;
                RaisePropertyChanged("SKeyName");
            }
        }

        private string _SKeyName2 = "";
        public string SKeyName2
        {
            get { return _SKeyName2; }
            set
            {
                _SKeyName2 = value;
                RaisePropertyChanged("SKeyName2");
            }
        }
    }
}
