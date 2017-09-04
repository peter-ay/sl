
namespace ERP.View
{
    public class TBOdDate : TextBoxErp
    {
        public TBOdDate()
            : base("DContextMain.OdDate",convertToDateshort:true)
        {
            this.ReSetRO();
            //this.SetVisible();

        }
    }
}
