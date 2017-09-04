
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected void ResetDPIsVisibility(bool isVisibility)
        {
            var _isVisibility = isVisibility == true ? Visibility.Visible : Visibility.Collapsed;

            this.IsShowDP = _isVisibility;
        }
    }
}
