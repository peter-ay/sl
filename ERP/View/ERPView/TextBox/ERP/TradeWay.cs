
namespace ERP.View
{
    //TradeWayCode
    public class TBTradeWayCode : TextBoxErp
    {
        public TBTradeWayCode()
            : base("DContextMain.TradeWayCode")
        {
            this.MaxLength = 30;
            base.SetFocus("TradeWayCode");
        }
    }
    //TradeWayName
    public class TBTradeWayName : TextBoxErp
    {
        public TBTradeWayName()
            : base("DContextMain.TradeWayName")
        {
            this.MaxLength = 50;
        }
    }
    //TradeWayName
    public class TBTradeWayNameRO : TextBoxErp
    {
        public TBTradeWayNameRO()
            : base("DContextMain.TradeWayName")
        {
            this.ReSetRO();
        }
    }
}
