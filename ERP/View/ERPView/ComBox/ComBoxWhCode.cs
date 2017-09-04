using System.Windows.Media;
using ERP.Common;

namespace ERP.View
{
    public class ComBoxWhCode : ComBoxErp
    {
        public ComBoxWhCode()
            : base("Template_WhCode")
        {
            this.FontFamily = (FontFamily)App.Current.Resources["FFV"];
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.ItemsSource = ComHelpWhCode.UHV_B_Warehouse_Browse;
        }
    }
}
