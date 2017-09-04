
namespace ERP.View
{
    //Remark 
    public class TBRemark : TextBoxErp
    {
        public TBRemark()
            : base("DContextMain.Remark", bdIsReadOnly: "TB_Falg_ROEdit")
        {
            this.MaxLength = 100;
        }
    }
    //Remark 
    public class TBRemark1 : TextBoxErp
    {
        public TBRemark1()
            : base("DContextMain.Remark")
        {
            this.MaxLength = 100;
        }
    }
    //RemarkSale 
    public class TBRemarkSaleRO : TextBoxErp
    {
        public TBRemarkSaleRO()
            : base("DContextMain.RemarkSale")
        {
            this.ReSetRO();
        }
    }
}
