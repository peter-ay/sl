
namespace ERP.View
{
    //Phone
    public class TBPhone : TextBoxErp
    {
        public TBPhone()
            : base("DContextMain.Phone")
        {
            this.MaxLength = 30;
        }
    }
    //UpdatePhone
    public class TBUpdatePhone : TextBoxErp
    {
        public TBUpdatePhone()
            : base("DContextMain.UpdatePhone")
        {
            this.MaxLength = 30;
        }
    }
    //DPhone
    public class TBDPhone : TextBoxErp
    {
        public TBDPhone()
            : base("DContextMain.DPhone")
        {
            this.MaxLength = 30;
        }
    }
}
