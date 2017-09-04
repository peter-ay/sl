
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            if (!this.IsChildWindow)
            {
                this.New();
            }
        }
    }
}
