
namespace ERP.View
{
    //AccEndDate
    public class TBAccEndDate : TextBoxErp
    {
        public TBAccEndDate()
            : base("DContextMain.AccEndDate", validatesOnExceptions: true)
        {
            this.MaxLength = 2;
        }
    }
}
