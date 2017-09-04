
namespace ERP.View
{
    //UserCode
    public class TBUserCode : TextBoxErp
    {
        public TBUserCode()
            : base("DContextMain.UserCode")
        {
            this.MaxLength = 7;
        }
    }

    public class TBUserCodeListRO : TextBoxErp
    {
        public TBUserCodeListRO()
            : base("UserCode")
        {
            this.ReSetRO();
        }
    }

    //UserName
    public class TBUserName : TextBoxErp
    {
        public TBUserName()
            : base("DContextMain.UserName")
        {
            this.MaxLength = 20;
        }
    }

    public class TBUserNameListRO : TextBoxErp
    {
        public TBUserNameListRO()
            : base("UserName")
        {
            this.ReSetRO();
        }
    }

    //UserExplain
    public class TBUserExplain : TextBoxErp
    {
        public TBUserExplain()
            : base("DContextMain.UserExplain")
        {
            this.MaxLength = 20;
        }
    }

}
