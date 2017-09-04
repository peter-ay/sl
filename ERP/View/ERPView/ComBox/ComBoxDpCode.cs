using System.Windows.Media;
using ERP.Common;

namespace ERP.View
{
    public class ComBoxDpCode : ComBoxErp
    {
        public ComBoxDpCode()
            : base("Template_DpCode")
        {
            this.FontFamily = (FontFamily)App.Current.Resources["FFV"];
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.ItemsSource = ComHelpDpCode.UHV_B_Department;
        }
    }
}
