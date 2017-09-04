
namespace ERP.View
{
    //PrintCode
    public class TBPrintCode : TextBoxErp
    {
        public TBPrintCode()
            : base("DContextMain.PrintCode")
        {
            this.MaxLength = 10;
        }
    }
    //PrintCodeList
    public class TBPrintCodeList : TextBoxErp
    {
        public TBPrintCodeList()
            : base("PrintCode")
        {
            this.MaxLength = 10;
        }
    }
}
