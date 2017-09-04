
namespace ERP.View
{
    //ForeignCurrCode
    public class TBForeignCurrCode : TextBoxErp
    {
        public TBForeignCurrCode()
            : base("DContextMain.ForeignCurrCode")
        {
            this.MaxLength = 10;
            base.SetFocus("ForeignCurrCode");
        }
    }
    //ForeignCurrName
    public class TBForeignCurrName : TextBoxErp
    {
        public TBForeignCurrName()
            : base("DContextMain.ForeignCurrName")
        {
            this.MaxLength = 30;
        }
    }
    //ForeignCurrName
    public class TBForeignCurrNameRO : TextBoxErp
    {
        public TBForeignCurrNameRO()
            : base("DContextMain.ForeignCurrName")
        {
            this.ReSetRO();
        }
    }
}
