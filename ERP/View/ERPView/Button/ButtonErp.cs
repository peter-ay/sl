using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ButtonErp : Button
    {
        public ButtonErp()
            : base()
        {
            this.Style = App.Current.Resources["ButtonStyle"] as Style;
            this.Height = 23;
            this.MinWidth = 60;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            var binding = new Binding("UIText[ERP_Font]");
            this.SetBinding(Button.FontFamilyProperty, binding);
            var bdsz = new Binding("UIText[ERP_FontSize]");
            this.SetBinding(Button.FontSizeProperty, bdsz);

            this.FontWeight = FontWeights.Bold;
        }

        public void SetIsShow(string bingIsShow = "IsShowHB")
        {
            var bindingis = new Binding(bingIsShow);
            this.SetBinding(DatePicker.VisibilityProperty, bindingis);
        }
    }
}
