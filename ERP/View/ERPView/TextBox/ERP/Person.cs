
namespace ERP.View
{
    //PersonCode
    public class TBPersonCode : TextBoxErp
    {
        public TBPersonCode()
            : base("DContextMain.PersonCode")
        {
            this.MaxLength = 10;
            base.SetFocus("PersonCode");
        }
    }
    //PersonCodeRO
    public class TBPersonCodeRO : TextBoxErp
    {
        public TBPersonCodeRO()
            : base("DContextMain.PersonCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    //PersonName
    public class TBPersonName : TextBoxErp
    {
        public TBPersonName()
            : base("DContextMain.PersonName")
        {
            this.MaxLength = 30;
        }
    }
    //PersonName
    public class TBPersonNameRO : TextBoxErp
    {
        public TBPersonNameRO()
            : base("DContextMain.PersonName")
        {
            this.ReSetRO();
        }
    }

    //PersonProperty
    public class TBPersonProperty : TextBoxErp
    {
        public TBPersonProperty()
            : base("DContextMain.PersonProperty")
        {
            this.MaxLength = 30;
        }
    }
}
