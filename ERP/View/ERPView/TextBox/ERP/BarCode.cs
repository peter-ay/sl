
namespace ERP.View
{
    //BarCode
    public class TBBarCode : TextBoxErp
    {
        public TBBarCode()
            : base("DContextMain.BarCode")
        {
            this.MaxLength = 30;
        }
    }

    //BarCodePre
    public class TBBarCodePre : TextBoxErp
    {
        public TBBarCodePre()
            : base("DContextMain.BarCodePre")
        {
            this.MaxLength = 50;
        }
    }
}
