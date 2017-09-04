
namespace ERP.View
{
    //Checker
    public class TBChecker : TextBoxErp
    {
        public TBChecker()
            : base("DContextMain.Checker")
        {
            this.MaxLength = 10;
        }
    }
    //CheckerRO
    public class TBCheckerRO : TextBoxErp
    {
        public TBCheckerRO()
            : base("DContextMain.Checker")
        {
            this.ReSetRO();
        }
    }
    //CheckerRO
    public class TBCheckerInRO : TextBoxErp
    {
        public TBCheckerInRO()
            : base("DContextMain.CheckerIn")
        {
            this.ReSetRO();
        }
    }
    //CheckerRO
    public class TBCheckerOutRO : TextBoxErp
    {
        public TBCheckerOutRO()
            : base("DContextMain.CheckerOut")
        {
            this.ReSetRO();
        }
    }
    //CheckerList
    public class TBCheckerList : TextBoxErp
    {
        public TBCheckerList()
            : base("Checker")
        {
            this.MaxLength = 10;
        }
    }
}
