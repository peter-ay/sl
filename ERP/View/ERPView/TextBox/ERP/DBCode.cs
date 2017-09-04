
namespace ERP.View
{
    #region DBCode

    //DBCode
    public class TBDBCode : TextBoxErp
    {
        public TBDBCode()
            : base("DContextMain.DBCode")
        {
            this.MaxLength = 30;
            this.SetFocus("DBCode");
        }
    }

    //DBCodeListSelected
    public class TBDBCodeListSelected : TextBoxErp
    {
        public TBDBCodeListSelected()
            : base("DBCodeListSelected")
        {
            this.MaxLength = 30;
        }
    }

    //DBCodeList
    public class TBDBCodeList : TextBoxErp
    {
        public TBDBCodeList()
            : base("DBCode")
        {
            this.MaxLength = 30;
        }
    }

    #endregion

    #region DBName

    //DBName
    public class TBDBName : TextBoxErp
    {
        public TBDBName()
            : base("DContextMain.DBName")
        {
            this.ReSetRO();
        }
    }
    //DBNameList
    public class TBDBNameList : TextBoxErp
    {
        public TBDBNameList()
            : base("DBName")
        {
            this.MaxLength = 100;
        }
    }
    //DBNameUI
    public class TBDBNameUI : TextBoxErp
    {
        public TBDBNameUI()
            : base("DContextMain.DBNameUI")
        {
            this.ReSetRO();
        }
    }

    #endregion
}
