
namespace ERP.View
{
    //TransferWayCode
    public class TBTransferWayCode : TextBoxErp
    {
        public TBTransferWayCode()
            : base("DContextMain.TransferWayCode")
        {
            this.MaxLength = 10;
            base.SetFocus("TransferWayCode");
        }
    }
    //TransferWayName
    public class TBTransferWayName : TextBoxErp
    {
        public TBTransferWayName()
            : base("DContextMain.TransferWayName")
        {
            this.MaxLength = 30;
        }
    }
    //TransferWayName
    public class TBTransferWayNameRO : TextBoxErp
    {
        public TBTransferWayNameRO()
            : base("DContextMain.TransferWayName")
        {
            this.ReSetRO();
        }
    }
}
