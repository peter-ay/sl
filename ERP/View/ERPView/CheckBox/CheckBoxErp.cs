using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace ERP.View
{
    public class CheckBoxErp : CheckBox
    {

        public CheckBoxErp()
            : base()
        {
            this.Style = App.Current.Resources["CBStyle"] as Style;
            this.Padding = new System.Windows.Thickness(0);
            this.Margin = new System.Windows.Thickness(0);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
        }

        public CheckBoxErp(string bingcode)
            : this()
        {
            var binding = new Binding(bingcode)
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false,
                NotifyOnValidationError = true,
                //ValidatesOnDataErrors = true,
                ValidatesOnExceptions = false,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            this.SetBinding(CheckBox.IsCheckedProperty, binding);

            this.SetIsEnabled();
        }

        private void SetIsEnabled()
        {
            var binding = new Binding("IsReadOnly")
                {
                    ElementName = "TB_Falg_RO",
                    Converter = new ERP.Converters.ReadOnlyToEnable()
                };
            this.SetBinding(CheckBox.IsEnabledProperty, binding);
        }

        public void SetIsEnabledFalse()
        {
            this.ClearValue(CheckBox.IsEnabledProperty);
            this.IsEnabled = false;
        }
    }
}
