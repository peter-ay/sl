
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _SKeyCode = "";
        public string SKeyCode
        {
            get { return _SKeyCode; }
            set
            {
                _SKeyCode = value;
                RaisePropertyChanged("SKeyCode");
            }
        }

        private string _SKeyCode2 = "";
        public string SKeyCode2
        {
            get { return _SKeyCode2; }
            set
            {
                _SKeyCode2 = value;
                RaisePropertyChanged("SKeyCode2");
            }
        }
    }
}
