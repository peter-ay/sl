
namespace ERP.ViewModel
{
    public class VMBase_Department : VMBill
    {
        public VMBase_Department()
            : base("DeptCode", "Base_Department")
        {
            this.IsChildWindow = true;
        }
    }
}
