
namespace ERP.View
{
    //Maker
    public class TBMaker : TextBoxErp
    {
        public TBMaker()
            : base("DContextMain.Maker")
        {
            this.MaxLength = 10;
        }
    }
    //MakerRO
    public class TBMakerRO : TextBoxErp
    {
        public TBMakerRO()
            : base("DContextMain.Maker")
        {
            this.ReSetRO();
        }
    }
    //MakerList
    public class TBMakerList : TextBoxErp
    {
        public TBMakerList()
            : base("Maker")
        {
            this.MaxLength = 10;
        }
    }
}
