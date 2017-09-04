
namespace ERP.View
{
    public class TBBDateRO : TextBoxErp
    {
        public TBBDateRO()
            : base("DContextMain.BDate", convertToDateshort: true)
        {
            this.ReSetRO();
        }
    }

    public class TBCsDate : TextBoxErp
    {
        public TBCsDate()
            : base("DContextMain.CsDate", convertToDateshort: true)
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    public class TBBegDateRO : TextBoxErp
    {
        public TBBegDateRO()
            : base("DContextMain.BegDate", convertToDateshort: true)
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    public class TBEndDateRO : TextBoxErp
    {
        public TBEndDateRO()
            : base("DContextMain.EndDate", convertToDateshort: true)
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }

    public class TBDDateRO : TextBoxErp
    {
        public TBDDateRO()
            : base("DContextMain.DDate", convertToDateshort: true)
        {
            this.ReSetRO();
        }
    }
    //BDateSale
    public class TBBDateSaleRO : TextBoxErp
    {
        public TBBDateSaleRO()
            : base("DContextMain.BDateSale", convertToDateshort: true)
        {
            this.ReSetRO();
        }
    }
    //CsDateSale
    public class TBCsDateSaleRO : TextBoxErp
    {
        public TBCsDateSaleRO()
            : base("DContextMain.CsDateSale", convertToDateshort: true)
        {
            this.ReSetRO();
        }
    }
}
