
namespace ERP.View
{
    //AccLimit
    public class TBAccLimit : TextBoxErp
    {
        public TBAccLimit()
            : base("DContextMain.AccLimit", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }
}
