
namespace ERP.View
{
    #region AreaCode

    //AreaCode
    public class TBAreaCode : TextBoxErp
    {
        public TBAreaCode()
            : base("DContextMain.AreaCode")
        {
            this.MaxLength = 10;
            base.SetFocus("AreaCode");
        }
    }

    //AreaCodeRO
    public class TBAreaCodeRO : TextBoxErp
    {
        public TBAreaCodeRO()
            : base("DContextMain.AreaCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    #endregion

    #region AreaName

    //AreaName
    public class TBAreaName : TextBoxErp
    {
        public TBAreaName()
            : base("DContextMain.AreaName")
        {
            this.MaxLength = 30;
        }
    }
    //AreaName
    public class TBAreaNameRO : TextBoxErp
    {
        public TBAreaNameRO()
            : base("DContextMain.AreaName")
        {
            this.ReSetRO();
        }
    }

    #endregion

}
