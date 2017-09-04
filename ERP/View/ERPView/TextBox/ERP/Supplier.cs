
namespace ERP.View
{
    //Default_SpCode
    public class TBDf_SpCode : TextBoxErp
    {
        public TBDf_SpCode()
            : base("DContextMain.Df_SpCode")
        {
            this.MaxLength = 10;
        }
    }
    //SpCode
    public class TBSpCode : TextBoxErp
    {
        public TBSpCode()
            : base("DContextMain.SpCode")
        {
            this.MaxLength = 10;
            base.SetKeyDown("SpCode");
            this.SetFocus("SpCode");
        }
    }
    //SpCode
    public class TBSpCodeRO : TextBoxErp
    {
        public TBSpCodeRO()
            : base("DContextMain.SpCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //SpCodeList
    public class TBSpCodeList : TextBoxErp
    {
        public TBSpCodeList()
            : base("SpCode")
        {
            this.MaxLength = 10;
        }
    }

    //SpCodeListRO
    public class TBSpCodeListRO : TextBoxErp
    {
        public TBSpCodeListRO()
            : base("SpCode")
        {
            this.ReSetRO();
        }
    }
    #region CusGroup
    //SpGroup
    public class TBSpGroup : TextBoxErp
    {
        public TBSpGroup()
            : base("DContextMain.SpGroup")
        {
            this.MaxLength = 10;
            base.SetFocus("SpGroup");
        }
    }

    #endregion

    //SpName
    public class TBSpName : TextBoxErp
    {
        public TBSpName()
            : base("DContextMain.SpName")
        {
            this.MaxLength = 30;
        }
    }
    //SpNameRO
    public class TBSpNameRO : TextBoxErp
    {
        public TBSpNameRO()
            : base("DContextMain.SpName")
        {
            this.ReSetRO();
        }
    }
    //SpNameRO
    public class TBDf_SpNameRO : TextBoxErp
    {
        public TBDf_SpNameRO()
            : base("DContextMain.Df_SpName")
        {
            this.ReSetRO();
        }
    }
    //SpNameListRO
    public class TBSpNameListRO : TextBoxErp
    {
        public TBSpNameListRO()
            : base("SpName")
        {
            this.ReSetRO();
        }
    }
}
