
namespace ERP.View
{
    //PayWayCode
    public class TBPayWayCode : TextBoxErp
    {
        public TBPayWayCode()
            : base("DContextMain.PayWayCode")
        {
            this.MaxLength = 10;
            base.SetFocus("PayWayCode");
        }
    }
    //PayWayName
    public class TBPayWayName : TextBoxErp
    {
        public TBPayWayName()
            : base("DContextMain.PayWayName")
        {
            this.MaxLength = 30;
        }
    }
    //PayWayName
    public class TBPayWayNameRO : TextBoxErp
    {
        public TBPayWayNameRO()
            : base("DContextMain.PayWayName")
        {
            this.ReSetRO();
        }
    }
}
