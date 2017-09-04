
namespace ERP.View
{
    #region DpCode

    //DpCode
    public class TBDpCode : TextBoxErp
    {
        public TBDpCode()
            : base("DContextMain.DpCode")
        {
            this.MaxLength = 10;
            base.SetFocus("DpCode");
        }
    }

    //DpCodeCX
    public class TBDpCodeCX : TextBoxErp
    {
        public TBDpCodeCX()
            : base("DContextMain.DpCodeCX")
        {
            this.MaxLength = 10;
        }
    }

    //DpCodeRO
    public class TBDpCodeRO : TextBoxErp
    {
        public TBDpCodeRO()
            : base("DContextMain.DpCode")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //DpCodeCXRO
    public class TBDpCodeCXRO : TextBoxErp
    {
        public TBDpCodeCXRO()
            : base("DContextMain.DpCodeCX")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //DpCodeSelectedItem
    public class TBDpCodeSelectedItem : TextBoxErp
    {
        public TBDpCodeSelectedItem()
            : base("SelectedItem.DpCode")
        {
            this.MaxLength = 10;
            base.SetFocus("DpCode");
        }
    }

    //TempDpCode
    public class TBTempDpCode : TextBoxErp
    {
        public TBTempDpCode()
            : base("DContextMain.TempDpCode")
        {
            this.MaxLength = 10;
            base.SetKeyDown("TempDpCode");
            this.SetFocus("TempDpCode");
        }
    }

    //DpCodeList
    public class TBDpCodeList : TextBoxErp
    {
        public TBDpCodeList()
            : base("DpCode")
        {
            this.MaxLength = 30;
        }
    }

    //DpCodeListRO
    public class TBDpCodeListRO : TextBoxErp
    {
        public TBDpCodeListRO()
            : base("DpCode")
        {
            this.ReSetRO();
        }
    }

    //DpCodeWG
    public class TBDpCodeWGRO : TextBoxErp
    {
        public TBDpCodeWGRO()
            : base("DContextMain.DpCodeWG")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    //DpCodeJG
    public class TBDpCodeJGRO : TextBoxErp
    {
        public TBDpCodeJGRO()
            : base("DContextMain.DpCodeJG")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    #endregion

    #region DpName

    //DpName
    public class TBDpName : TextBoxErp
    {
        public TBDpName()
            : base("DContextMain.DpName")
        {
            this.MaxLength = 30;
        }
    }
    //DpNameRO
    public class TBDpNameRO : TextBoxErp
    {
        public TBDpNameRO()
            : base("DContextMain.DpName")
        {
            this.ReSetRO();
        }
    }
    //DpNameCXRO
    public class TBDpNameCXRO : TextBoxErp
    {
        public TBDpNameCXRO()
            : base("DContextMain.DpNameCX")
        {
            this.ReSetRO();
        }
    }
    //DpNameListRO
    public class TBDpNameListRO : TextBoxErp
    {
        public TBDpNameListRO()
            : base("DpName")
        {
            this.ReSetRO();
        }
    }
    //DpNameJGRO
    public class TBDpNameJGRO : TextBoxErp
    {
        public TBDpNameJGRO()
            : base("DContextMain.DpNameJG")
        {
            this.ReSetRO();
        }
    }
    //DpNameWGRO
    public class TBDpNameWGRO : TextBoxErp
    {
        public TBDpNameWGRO()
            : base("DContextMain.DpNameWG")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region Ex

    //DeptProperty
    public class TBDeptProperty : TextBoxErp
    {
        public TBDeptProperty()
            : base("DContextMain.DpProperty")
        {
            this.MaxLength = 20;
        }
    }

    #endregion
}
