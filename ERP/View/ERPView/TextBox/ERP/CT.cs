
namespace ERP.View
{
    //CT
    public class TBCT : TextBoxErp
    {
        public TBCT()
            : base("DContextMain.CT")
        {
            this.MaxLength = 5;
        }
    }
    //CTR
    public class TBCTR : TextBoxErp
    {
        public TBCTR()
            : base("DContextMain.CTR")
        {
            this.MaxLength = 5;
        }
    }
    //CTL
    public class TBCTL : TextBoxErp
    {
        public TBCTL()
            : base("DContextMain.CTL")
        {
            this.MaxLength = 5;
        }
    }
}
