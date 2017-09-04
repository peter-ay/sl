
namespace ERP.View
{
    //Freight
    public class TBFreight : TextBoxErp
    {
        public TBFreight()
            : base("DContextMain.Freight", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }
    //UpdateFreight
    public class TBUpdateFreight : TextBoxErp
    {
        public TBUpdateFreight()
            : base("DContextMain.UpdateFreight", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }
}
