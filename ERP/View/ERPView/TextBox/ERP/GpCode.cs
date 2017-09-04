
namespace ERP.View
{
    #region GpCode
    //GpCode
    public class TBGpCode : TextBoxErp
    {
        public TBGpCode()
            : base("DContextMain.GpCode")
        {
            this.MaxLength = 10;
            base.SetFocus("GpCode");
        }
    }
    //GpCode
    public class TBGpCodeList : TextBoxErp
    {
        public TBGpCodeList()
            : base("GpCode")
        {
            this.MaxLength = 10;
        }
    }
    //GpCodeRO
    public class TBGpCodeRO : TextBoxErp
    {
        public TBGpCodeRO()
            : base("DContextMain.GpCode")
        {
            this.ReSetRO();
        }
    }
    //GpCode
    public class TBGpCodeListRO : TextBoxErp
    {
        public TBGpCodeListRO()
            : base("GpCode")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region GpName

    //GpName
    public class TBGpName : TextBoxErp
    {
        public TBGpName()
            : base("DContextMain.GpName")
        {
            this.MaxLength = 10;
            base.SetFocus("GpName");
        }
    }
    //GpNameRO
    public class TBGpNameRO : TextBoxErp
    {
        public TBGpNameRO()
            : base("DContextMain.GpName")
        {
            this.ReSetRO();
        }
    }
    //CusGpNameRO
    public class TBCusGpNameRO : TextBoxErp
    {
        public TBCusGpNameRO()
            : base("DContextMain.CusGpName")
        {
            this.ReSetRO();
        }
    }
    //SpGpNameRO
    public class TBSpGpNameRO : TextBoxErp
    {
        public TBSpGpNameRO()
            : base("DContextMain.SpGpName")
        {
            this.ReSetRO();
        }
    }
    //GpNameListRO
    public class TBGpNameListRO : TextBoxErp
    {
        public TBGpNameListRO()
            : base("GpName")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region GroupExplain

    //GroupExplain
    public class TBGpExplain : TextBoxErp
    {
        public TBGpExplain()
            : base("DContextMain.GpExplain")
        {
            this.MaxLength = 30;
        }
    }

    #endregion
}
