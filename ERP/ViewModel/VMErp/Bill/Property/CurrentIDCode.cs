
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected string CurrentIDCode
        {
            get
            {
                try
                {
                    return this.DContextMain.GetType().GetProperty(this.IDCode).GetValue(this.DContextMain, null).ToString();
                }
                catch { return ""; }
            }
        }
    }
}
