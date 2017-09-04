
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private void LoadBill(string msg)
        {
            this.SIDCode = msg; 
            this.LoadBillMain();
        } 
    }
}
