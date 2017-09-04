
namespace ERP.View
{
    //DiaR
    public class TBDiaR : TextBoxErp
    {
        public TBDiaR()
            : base("DContextMain.DiaR", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }
    //DiaRRO
    public class TBDiaRRO : TextBoxErp
    {
        public TBDiaRRO()
            : base("DContextMain.DiaR")
        {
            this.ReSetRO();
        }
    }
    //DiaL
    public class TBDiaL : TextBoxErp
    {
        public TBDiaL()
            : base("DContextMain.DiaL", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }
    //DiaLRO
    public class TBDiaLRO : TextBoxErp
    {
        public TBDiaLRO()
            : base("DContextMain.DiaL")
        {
            this.ReSetRO();
        }
    }
    public class TBDia : TextBoxErp
    {
        public TBDia()
            : base("DContextMain.Dia", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }

    public class TBDiaList : TextBoxErp
    {
        public TBDiaList()
            : base("Dia", validatesOnExceptions: true)
        {
            this.MaxLength = 10;
        }
    }

}
