
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private string _Xmlpath;
        public string XMLPath
        {
            get
            {
                _Xmlpath = _Xmlpath ?? this.VMName.Substring(0, this.VMName.IndexOf('_')).Remove(0, 2);
                return _Xmlpath;
            }
            set { _Xmlpath = value; }
        }
    }
}
