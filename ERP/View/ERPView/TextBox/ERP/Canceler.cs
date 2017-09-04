
namespace ERP.View
{
    //Canceler
    public class TBCanceler : TextBoxErp
    {
        public TBCanceler()
            : base("DContextMain.Canceler")
        {
            this.MaxLength = 10;
        }
    }
    //CancelerRO
    public class TBCancelerRO : TextBoxErp
    {
        public TBCancelerRO()
            : base("DContextMain.Canceler")
        {
            this.ReSetRO();
        }
    }
    //CancelerList
    public class TBCancelerList : TextBoxErp
    {
        public TBCancelerList()
            : base("Canceler")
        {
            this.MaxLength = 10;
        }
    }
}
