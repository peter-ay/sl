
namespace ERP.View
{
    //Address
    public class TBAddress : TextBoxErp
    {
        public TBAddress()
            : base("DContextMain.Address")
        {
            this.MaxLength = 50;
        }
    }
    //CusAddress
    public class TBCusAddress : TextBoxErp
    {
        public TBCusAddress()
            : base("DContextMain.CusAddress")
        {
            this.MaxLength = 50;
        }
    }
    //DeliveryAddress
    public class TBTempAddress : TextBoxErp
    {
        public TBTempAddress()
            : base("DContextMain.TempAddress")
        {
            this.MaxLength = 50;
        }
    }
    //DpAddress
    public class TBDeptAddress : TextBoxErp
    {
        public TBDeptAddress()
            : base("DContextMain.DpAddress")
        {
            this.MaxLength = 50;
        }
    }
    //SpAddress
    public class TBSpAddress : TextBoxErp
    {
        public TBSpAddress()
            : base("DContextMain.SpAddress")
        {
            this.MaxLength = 50;
        }
    }
    //WhAddress
    public class TBWhAddress : TextBoxErp
    {
        public TBWhAddress()
            : base("DContextMain.WhAddress")
        {
            this.MaxLength = 50;
        }
    }
    //UpdateAddress
    public class TBUpdateAddress : TextBoxErp
    {
        public TBUpdateAddress()
            : base("DContextMain.UpdateAddress")
        {
            this.MaxLength = 100;
        }
    }
    //DAddress
    public class TBDAddress : TextBoxErp
    {
        public TBDAddress()
            : base("DContextMain.DAddress")
        {
            this.MaxLength = 100;
        }
    }
}
