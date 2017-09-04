using System.Windows;
using DevExpress.AgMenu;
namespace ERP.View
{
    public class MenuErp : AgMenu
    {
        public MenuErp()
            : base()
        {
            this.InitMenu();
        }

        private void InitMenu()
        {
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.Margin = new Thickness(1, 0, 1, 0);
            this.FontSize = 12;
            this.FontWeight = FontWeights.Bold;
        }
    }
}
