
namespace ERP.View
{
    //UpdateMoney
    public class TBUpdateMoney : TextBoxErp
    {
        public TBUpdateMoney()
            : base("DContextMain.UpdateMoney", validatesOnExceptions: true)
        {
            this.MaxLength = 6;
        }
    }
    //UpdateMoneyReason
    public class TBUpdateMoneyReason : TextBoxErp
    {
        public TBUpdateMoneyReason()
            : base("DContextMain.UpdateMoneyReason")
        {
            this.MaxLength = 50;
        }
    }
}
