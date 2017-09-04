
namespace ERP.View
{
    #region PCode

    //PCode
    public class TBPCode : TextBoxErp
    {
        public TBPCode()
            : base("DContextMain.PCode")
        {
            this.MaxLength = 50;
        }
    }
    //PCodeRO
    public class TBPCodeRO : TextBoxErp
    {
        public TBPCodeRO()
            : base("DContextMain.PCode")
        {
            this.ReSetRO();
            this.TextAlignment = System.Windows.TextAlignment.Center;
            this.Foreground = new System.Windows.Media.SolidColorBrush(ERP.Common.ComColorConstants.DarkBlue);
        }
    }

    //PCodeListRO
    public class TBPCodeListRO : TextBoxErp
    {
        public TBPCodeListRO()
            : base("PCode")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region PCodeName

    //RName
    public class TBRName : TextBoxErp
    {
        public TBRName()
            : base("DContextMain.RName")
        {
            this.MaxLength = 100;
        }

    }
    #endregion

    //ParentCode
    public class TBParentCode : TextBoxErp
    {
        public TBParentCode()
            : base("DContextMain.ParentCode")
        {
            this.MaxLength = 10;
        }
    }
}
