
namespace ERP.View
{
    #region CusCode

    //CusCode
    public class TBCusCode : TextBoxErp
    {
        public TBCusCode()
            : base("DContextMain.CusCode")
        {
            this.MaxLength = 10;
            this.SetFocus("CusCode");
        }
    }
    //AccCusCode
    public class TBAccCusCode : TextBoxErp
    {
        public TBAccCusCode()
            : base("DContextMain.AccCusCode")
        {
            this.MaxLength = 10;
            this.SetFocus("AccCusCode");
        }
    }
    //MainCusCode
    public class TBMainCusCode : TextBoxErp
    {
        public TBMainCusCode()
            : base("DContextMain.MainCusCode")
        {
            this.MaxLength = 10;
            this.SetFocus("MainCusCode");
        }
    }
    //CusCodeRO
    public class TBCusCodeRO : TextBoxErp
    {
        public TBCusCodeRO()
            : base("DContextMain.CusCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //AccCusCodeRO
    public class TBAccCusCodeRO : TextBoxErp
    {
        public TBAccCusCodeRO()
            : base("DContextMain.AccCusCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //MainCusCodeRO
    public class TBMainCusCodeRO : TextBoxErp
    {
        public TBMainCusCodeRO()
            : base("DContextMain.MainCusCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //CusCodeRO1
    public class TBCusCodeRO1 : TextBoxErp
    {
        public TBCusCodeRO1()
            : base("DContextMain.CusCode")
        {
            this.ReSetRO();
        }
    }
    //CusCodeList
    public class TBCusCodeList : TextBoxErp
    {
        public TBCusCodeList()
            : base("CusCode")
        {
            this.MaxLength = 10;
        }
    }
    //AccCusCodeList
    public class TBAccCusCodeList : TextBoxErp
    {
        public TBAccCusCodeList()
            : base("AccCusCode")
        {
            this.MaxLength = 10;
        }
    }
    //AccCusCodeListRO
    public class TBAccCusCodeListRO : TextBoxErp
    {
        public TBAccCusCodeListRO()
            : base("AccCusCode")
        {
            this.ReSetRO();
        }
    }
    //MainCusCodeListRO
    public class TBMainCusCodeListRO : TextBoxErp
    {
        public TBMainCusCodeListRO()
            : base("MainCusCode")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region CusName

    //CusName
    public class TBCusName : TextBoxErp
    {
        public TBCusName()
            : base("DContextMain.CusName")
        {
            this.MaxLength = 100;
        }
    }
    //AccCusName
    public class TBAccCusName : TextBoxErp
    {
        public TBAccCusName()
            : base("DContextMain.AccCusName")
        {
            this.MaxLength = 100;
        }
    }
    //MainCusName
    public class TBMainCusName : TextBoxErp
    {
        public TBMainCusName()
            : base("DContextMain.MainCusName")
        {
            this.MaxLength = 100;
        }
    }
    //CusNameRO
    public class TBCusNameRO : TextBoxErp
    {
        public TBCusNameRO()
            : base("DContextMain.CusName")
        {
            this.ReSetRO();
        }
    }
    //AccCusNameRO
    public class TBAccCusNameRO : TextBoxErp
    {
        public TBAccCusNameRO()
            : base("DContextMain.AccCusName")
        {
            this.ReSetRO();
        }
    }
    //MainCusNameRO
    public class TBMainCusNameRO : TextBoxErp
    {
        public TBMainCusNameRO()
            : base("DContextMain.MainCusName")
        {
            this.ReSetRO();
        }
    }
    //CusNameList
    public class TBCusNameList : TextBoxErp
    {
        public TBCusNameList()
            : base("CusName")
        {
            this.MaxLength = 30;
        }
    }
    //AccCusNameList
    public class TBAccCusNameList : TextBoxErp
    {
        public TBAccCusNameList()
            : base("AccCusName")
        {
            this.MaxLength = 30;
        }
    }
    //AccCusNameListRO
    public class TBAccCusNameListRO : TextBoxErp
    {
        public TBAccCusNameListRO()
            : base("AccCusName")
        {
            this.ReSetRO();
        }
    }
    //MainCusNameListRO
    public class TBMainCusNameListRO : TextBoxErp
    {
        public TBMainCusNameListRO()
            : base("MainCusName")
        {
            this.ReSetRO();
        }
    }
    #endregion

    #region CusGroup
    //CusGroup
    public class TBCusGroup : TextBoxErp
    {
        public TBCusGroup()
            : base("DContextMain.CusGroup")
        {
            this.MaxLength = 10;
            base.SetFocus("CusGroup");
        }
    }

    #endregion

    #region CusType

    //CusTypeRO
    public class TBCusTypeRO : TextBoxErp
    {
        public TBCusTypeRO()
            : base("DContextMain.CusType")
        {
            this.ReSetRO();
        }
    }
    //CusTypeROList
    public class TBCusTypeROList : TextBoxErp
    {
        public TBCusTypeROList()
            : base("CusType")
        {
            this.ReSetRO();
        }
    }
    //CusTypeList
    public class TBCusTypeList : TextBoxErp
    {
        public TBCusTypeList()
            : base("CusType")
        {
            this.MaxLength = 10;
        }
    }

    #endregion
}
