
namespace ERP.View
{
    //ContactPerson
    public class TBContactPerson : TextBoxErp
    {
        public TBContactPerson()
            : base("DContextMain.ContactPerson")
        {
            this.MaxLength = 30;
        }
    }
}
