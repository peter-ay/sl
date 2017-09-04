
namespace ERP.View
{
    //PD
    public class TBPD : TextBoxErp
    {
        public TBPD()
            : base("DContextMain.PD")
        {
            this.MaxLength = 20;
        }
    }
    //PDRO
    public class TBPDRO : TextBoxErp
    {
        public TBPDRO()
            : base("DContextMain.PD")
        {
            this.ReSetRO();
        }
    }
    //PH
    public class TBPH : TextBoxErp
    {
        public TBPH()
            : base("DContextMain.PH")
        {
            this.MaxLength = 20;
        }
    }
    //PHRO
    public class TBPHRO : TextBoxErp
    {
        public TBPHRO()
            : base("DContextMain.PH")
        {
            this.ReSetRO();
        }
    }
}
