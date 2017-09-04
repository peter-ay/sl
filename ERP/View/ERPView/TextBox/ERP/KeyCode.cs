
namespace ERP.View
{
    #region KeyCode

    //KeyCode
    public class TBKeyCode : TextBoxErp
    {
        public TBKeyCode()
            : base("DContextMain.KeyCode")
        {
            this.MaxLength = 10;
        }
    }
    //KeyCodeRO
    public class TBKeyCodeRO : TextBoxErp
    {
        public TBKeyCodeRO()
            : base("DContextMain.KeyCode")
        {
            this.ReSetRO();
            this.TextAlignment = System.Windows.TextAlignment.Center;
            this.Foreground = new System.Windows.Media.SolidColorBrush(ERP.Common.ComColorConstants.DarkBlue);
        }
    }

    //KeyCodeListRO
    public class TBKeyCodeListRO : TextBoxErp
    {
        public TBKeyCodeListRO()
            : base("KeyCode")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region KeyName

    //KeyName
    public class TBKeyName : TextBoxErp
    {
        public TBKeyName()
            : base("DContextMain.KeyName")
        {
            this.MaxLength = 50;
        }

    }
    #endregion


    #region SN

    //SN
    public class TBSN : TextBoxErp
    {
        public TBSN()
            : base("DContextMain.SN")
        {
            this.MaxLength = 3;
        }

    }
    #endregion

}
