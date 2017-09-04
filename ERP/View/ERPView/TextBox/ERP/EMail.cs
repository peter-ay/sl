
namespace ERP.View
{
    //EMail
    public class TBEmail : TextBoxErp
    {
        public TBEmail()
            : base("DContextMain.Email")
        {
            this.MaxLength = 20;
        }
    }
}
