
namespace ERP.View
{
    //BCode
    public class TBBCode : TextBoxErp
    {
        public TBBCode()
            : base("DContextMain.BCode")
        {
            this.MaxLength = 50;
        }
    }
    //BCodeRO
    public class TBBCodeRO : TextBoxErp
    {
        public TBBCodeRO()
            : base("DContextMain.BCode")
        {
            this.ReSetRO();
        }
    }
    //BCodePCRO
    public class TBBCodePCRO : TextBoxErp
    {
        public TBBCodePCRO()
            : base("DContextMain.BCodePC")
        {
            this.ReSetRO();
        }
    }
    //BCodeList
    public class TBBCodeList : TextBoxErp
    {
        public TBBCodeList()
            : base("BCode")
        {
            this.MaxLength = 50;
        }
    }
    //BCodeList
    public class TBBCodeROList : TextBoxErp
    {
        public TBBCodeROList()
            : base("BCode")
        {
            this.ReSetRO();
        }
    }
    //BCode1List
    public class TBBCodeList1 : TextBoxErp
    {
        public TBBCodeList1()
            : base("BCode1")
        {
            this.MaxLength = 50;
        }
    }
    //BCode2
    public class TBBCodeList2 : TextBoxErp
    {
        public TBBCodeList2()
            : base("BCode2")
        {
            this.MaxLength = 50;
        }
    }
    //OBCode
    public class TBOBCode : TextBoxErp
    {
        public TBOBCode()
            : base("DContextMain.OBCode", bdIsReadOnly: "TB_Falg_ROEdit")
        {
            this.MaxLength = 50;
        }
    }
    //OBCodeRO
    public class TBOBCodeRO : TextBoxErp
    {
        public TBOBCodeRO()
            : base("DContextMain.OBCode")
        {
            this.ReSetRO();
        }
    }
    //OBCodeList
    public class TBOBCodeList : TextBoxErp
    {
        public TBOBCodeList()
            : base("OBCode")
        {
            this.MaxLength = 50;
        }
    }
    //FromBCode
    public class TBFBCodeRO : TextBoxErp
    {
        public TBFBCodeRO()
            : base("DContextMain.FBCode")
        {
            this.ReSetRO();
        }
    }
    //FromBCodeList
    public class TBFBCodeList : TextBoxErp
    {
        public TBFBCodeList()
            : base("FBCode")
        {
            this.MaxLength = 50;
        }
    }
    //DNCode
    public class TBDNCodeRO : TextBoxErp
    {
        public TBDNCodeRO()
            : base("DContextMain.DNCode")
        {
            this.ReSetRO();
        }
    }
    //ERP_BCodeSale
    public class TBBCodeSaleRO : TextBoxErp
    {
        public TBBCodeSaleRO()
            : base("DContextMain.BCodeSale")
        {
            this.ReSetRO();
        }
    }
    //OBCodeSaleRO
    public class TBOBCodeSaleRO : TextBoxErp
    {
        public TBOBCodeSaleRO()
            : base("DContextMain.OBCodeSale")
        {
            this.ReSetRO();
        }
    }
    //ERP_BCodeSaleList
    public class TBBCodeSaleList : TextBoxErp
    {
        public TBBCodeSaleList()
            : base("BCodeSale")
        {
            this.MaxLength = 30;
        }
    }
    //ERP_OBCodeSaleList
    public class TBOBCodeSaleList : TextBoxErp
    {
        public TBOBCodeSaleList()
            : base("OBCodeSale")
        {
            this.MaxLength = 30;
        }
    }
    //ERP_BCodeSale
    public class TBBCodeSale : TextBoxErp
    {
        public TBBCodeSale()
            : base("DContextMain.BCodeSale")
        {
            this.MaxLength = 30;
        }
    }
    //ERP_UpdateBCodeSale
    public class TBUpdateBCodeSale : TextBoxErp
    {
        public TBUpdateBCodeSale()
            : base("DContextMain.UpdateBCodeSale")
        {
            this.MaxLength = 30;
        }
    }
}
