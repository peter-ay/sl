
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected void ResetHBIsVisibility(bool isVisibility)
        {
            var _isVisibility = isVisibility == true ? Visibility.Visible : Visibility.Collapsed;

            this.IsShowHB = _isVisibility;
        }
    }
}
