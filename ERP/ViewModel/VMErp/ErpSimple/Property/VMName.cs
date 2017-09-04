

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private string _VMName;
        public string VMName
        {
            get
            {
                return _VMName ?? this.GetType().Name;
            }
            set
            {
                _VMName = value;
                RaisePropertyChanged<string>(() => this.VMName);
            }
        }
    }
}
