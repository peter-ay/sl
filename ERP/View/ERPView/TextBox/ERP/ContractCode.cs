
namespace ERP.View
{
    //ContractCode
    public class TBContractCode : TextBoxErp
    {
        public TBContractCode()
            : base("DContextMain.ContractCode")
        {
            this.MaxLength = 50;
        }
    }
    //ContractCodeRO
    public class TBContractCodeRO : TextBoxErp
    {
        public TBContractCodeRO()
            : base("DContextMain.ContractCode")
        {
            this.ReSetRO();
        }
    }
    //ContractCodeList
    public class TBContractCodeList : TextBoxErp
    {
        public TBContractCodeList()
            : base("ContractCode")
        {
            this.MaxLength = 50;
        }
    }
    //ContractCode1List
    public class TBContractCodeList1 : TextBoxErp
    {
        public TBContractCodeList1()
            : base("ContractCode1")
        {
            this.MaxLength = 50;
        }
    }
    //ContractCode2
    public class TBContractCodeList2 : TextBoxErp
    {
        public TBContractCodeList2()
            : base("ContractCode2")
        {
            this.MaxLength = 50;
        }
    }
    //OContractCode
    public class TBOContractCode : TextBoxErp
    {
        public TBOContractCode()
            : base("DContextMain.OContractCode")
        {
            this.MaxLength = 50;
        }
    }
    //OContractCode
    public class TBOContractCodeList : TextBoxErp
    {
        public TBOContractCodeList()
            : base("OContractCode")
        {
            this.MaxLength = 50;
        }
    }
}
