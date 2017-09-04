
namespace ERP.View
{
    //Bridge
    public class TBBridge : TextBoxErp
    {
        public TBBridge()
            : base("DContextMain.Bridge")
        {
            this.MaxLength = 10;
        }
    }
}
