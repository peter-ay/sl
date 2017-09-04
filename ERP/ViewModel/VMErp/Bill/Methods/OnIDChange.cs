
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected override void OnIDChange(string msg)
        {
            this.LoadBill(msg);
        }
    }
}
