
namespace ERP.View
{
    //Apply
    public class TBAccCode : TextBoxErp
    {
        public TBAccCode()
            : base("DContextMain.AccCode")
        {
            this.MaxLength = 10;
            this.SetFocus("AccCode");
        }
    }
}
