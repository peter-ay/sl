
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected void RefreshMain()
        {
            var cDC = this.DContextMain;
            this.DContextMain = null;
            this.DContextMain = cDC;
        }
    }
}
