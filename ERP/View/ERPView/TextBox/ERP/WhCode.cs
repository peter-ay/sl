
namespace ERP.View
{
    //WhCode
    public class TBWhCode : TextBoxErp
    {
        public TBWhCode()
            : base("DContextMain.WhCode")
        {
            this.MaxLength = 10;
            base.SetKeyDown("WhCode");
            this.SetFocus("WhCode");
        }
    }
    //WhCodeIn
    public class TBWhCodeIn : TextBoxErp
    {
        public TBWhCodeIn()
            : base("DContextMain.WhCodeIn")
        {
            this.MaxLength = 10;
            base.SetKeyDown("WhCodeIn");
            this.SetFocus("WhCodeIn");
        }
    }
    //WhCodeOut
    public class TBWhCodeOut : TextBoxErp
    {
        public TBWhCodeOut()
            : base("DContextMain.WhCodeOut")
        {
            this.MaxLength = 10;
            base.SetKeyDown("WhCodeOut");
            this.SetFocus("WhCodeOut");
        }
    }
    //WhCodeList
    public class TBWhCodeList : TextBoxErp
    {
        public TBWhCodeList()
            : base("WhCode")
        {
            this.MaxLength = 10;
        }
    }
    //WhCodeROList
    public class TBWhCodeROList : TextBoxErp
    {
        public TBWhCodeROList()
            : base("WhCode")
        {
            this.ReSetRO();
        }
    }
    //WhCodeROList
    public class TBWhCodeSelectedROList : TextBoxErp
    {
        public TBWhCodeSelectedROList()
            : base("WhCodeSelected")
        {
            this.ReSetRO();
        }
    }
    //WhCodeRO
    public class TBWhCodeRO1 : TextBoxErp
    {
        public TBWhCodeRO1()
            : base("DContextMain.WhCode")
        {
            this.ReSetRO();
        }
    }
    //WhCodeRO
    public class TBWhCodeRO : TextBoxErp
    {
        public TBWhCodeRO()
            : base("DContextMain.WhCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    //WhName
    public class TBWhName : TextBoxErp
    {
        public TBWhName()
            : base("DContextMain.WhName")
        {
            this.MaxLength = 50;
        }
    }
    //WhNameRO
    public class TBWhNameRO : TextBoxErp
    {
        public TBWhNameRO()
            : base("DContextMain.WhName")
        {
            this.ReSetRO();
        }
    }
    //WhNameInRO
    public class TBWhNameInRO : TextBoxErp
    {
        public TBWhNameInRO()
            : base("DContextMain.WhNameIn")
        {
            this.ReSetRO();
        }
    }
    //WhNameInRO
    public class TBWhNameOutRO : TextBoxErp
    {
        public TBWhNameOutRO()
            : base("DContextMain.WhNameOut")
        {
            this.ReSetRO();
        }
    }
}
