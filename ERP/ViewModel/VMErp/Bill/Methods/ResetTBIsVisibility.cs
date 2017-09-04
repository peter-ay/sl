
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected void ResetTBIsVisibility(bool isVisibility)
        {
            var _isVisibility = isVisibility == true ? Visibility.Visible : Visibility.Collapsed;

            this.IsShowTB = _isVisibility;
        }
    }
}
