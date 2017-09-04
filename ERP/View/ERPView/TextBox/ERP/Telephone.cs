
namespace ERP.View
{
    //Telephone
    public class TBTelephone : TextBoxErp
    {
        public TBTelephone()
            : base("DContextMain.Tel")
        {
            this.MaxLength = 30;
        }
    }
}
