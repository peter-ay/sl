
namespace ERP.View
{
    //SerialNum
    public class TBSerialNum : TextBoxErp
    {
        public TBSerialNum()
            : base("DContextMain.SerialNum")
        {
            this.MaxLength = 50;
        }
    }
    //SerialNumRO
    public class TBSerialNumRO : TextBoxErp
    {
        public TBSerialNumRO()
            : base("DContextMain.SerialNum")
        {
            this.ReSetRO();
        }
    }
    //SerialNum
    public class TBSerialNumList : TextBoxErp
    {
        public TBSerialNumList()
            : base("SerialNum")
        {
            this.MaxLength = 50;
        }
    }
}
