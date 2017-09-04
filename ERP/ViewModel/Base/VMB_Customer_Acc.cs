
namespace ERP.ViewModel
{
    public class VMB_Customer_Acc : VMBill
    {
        public VMB_Customer_Acc()
            : base("AccCusCode", "B_Customer_Acc")
        {
            this.IsChildWindow = true;
        }
    }
}
