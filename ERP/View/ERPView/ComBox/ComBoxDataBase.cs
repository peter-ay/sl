using System.Windows.Media;
using ERP.Common;

namespace ERP.View
{
    public class ComBoxDataBase : ComBoxErp
    {
        public ComBoxDataBase()
            : base("Template_DataBase")
        {
            this.FontFamily = (FontFamily)App.Current.Resources["FFV"];
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.ItemsSource = ComHelpDBCode.UHV_S_DataBase;
        }
    }
}
