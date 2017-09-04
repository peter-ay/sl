
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        public string VMNameAuthority
        {
            get { return this.VMName.Substring(2); }
        }
    }
}
