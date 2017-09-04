
namespace ERP.View
{
    //TypeName
    public class TBTypeName : TextBoxErp
    {
        public TBTypeName()
            : base("DContextMain.TypeName")
        {
            this.MaxLength = 30;
        }
    }
    //TypeNameRO
    public class TBTypeNameRO : TextBoxErp
    {
        public TBTypeNameRO()
            : base("DContextMain.TypeName")
        {
            this.ReSetRO();
        }
    }
    //CusTypeNameRO
    public class TBCusTypeNameRO : TextBoxErp
    {
        public TBCusTypeNameRO()
            : base("DContextMain.CusTypeName")
        {
            this.ReSetRO();
        }
    }
    //TypeNameRO
    public class TBTypeNameROList : TextBoxErp
    {
        public TBTypeNameROList()
            : base("TypeName")
        {
            this.ReSetRO();
        }
    }
    //CusTypeNameROList
    public class TBCusTypeNameROList : TextBoxErp
    {
        public TBCusTypeNameROList()
            : base("CusTypeName")
        {
            this.ReSetRO();
        }
    }
    //TypeNameUI
    public class TBTypeNameUI : TextBoxErp
    {
        public TBTypeNameUI()
            : base("DContextMain.TypeNameUI")
        {
            this.ReSetRO();
        }
    } 
}
