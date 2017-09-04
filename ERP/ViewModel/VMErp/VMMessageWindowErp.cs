
namespace ERP.ViewModel
{
    public class VMMessageWindowErp : VMChildWindow
    {
        private string _Input;
        public string Input
        {
            get { return _Input; }
            set
            {
                _Input = value;
                RaisePropertyChanged<string>(() => this.Input);
            }
        }
    }
}
