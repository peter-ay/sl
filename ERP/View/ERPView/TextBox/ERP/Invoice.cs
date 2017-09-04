
namespace ERP.View
{
    //InvoiceTitle
    public class TBInvoiceTitle : TextBoxErp
    {
        public TBInvoiceTitle()
            : base("DContextMain.InvoiceTitle")
        {
            this.MaxLength = 50;
        }
    }

    //InvTitle
    public class TBInvTitle : TextBoxErp
    {
        public TBInvTitle()
            : base("DContextMain.InvTitle")
        {
            this.MaxLength = 50;
        }
    }

    public class TBInvTitleList : TextBoxErp
    {
        public TBInvTitleList()
            : base("InvTitle")
        {
            this.MaxLength = 50;
        }
    }

    //public class TBInvCodeRO : TextBoxErp
    //{
    //    public TBInvCodeRO()
    //        : base("InvTitle")
    //    {
    //        this.ReSetRO();
    //    }
    //}
}
