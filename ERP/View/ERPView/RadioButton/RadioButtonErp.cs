

using ERP.ViewModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
namespace ERP.View
{
    public class RadioButtonErp : RadioButton
    {
        public RadioButtonErp(string bindIsEnableName, string groupName, string contendtext, string bindFunctionName, string commandParameterValue)
            : base()
        {
            this.Style = App.Current.Resources["RadioButtonStyleERP"] as Style;
            this.Padding = new Thickness(1, 2, 0, 2);
            this.Margin = new Thickness(1, 3, 0, 0);
            this.FontWeight = FontWeights.Bold;
            this.FontFamily = new FontFamily(ErpUIText.ErpFont);
            this.FontSize = ErpUIText.ErpFontSize;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.Content = contendtext;
            this.GroupName = groupName;

            if (!string.IsNullOrEmpty(bindIsEnableName))
            {
                var bd = new Binding(bindIsEnableName);
                this.SetBinding(RadioButton.IsEnabledProperty, bd);
            } 

            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand() { CommandParameterValue = commandParameterValue };
            var binding =
                new Binding(bindFunctionName) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }

        public void SetIsCheck(string bingIsCheckName = "")
        {
            var bd = new Binding(bingIsCheckName);
            bd.Mode = BindingMode.TwoWay;
            this.SetBinding(RadioButton.IsCheckedProperty, bd);
        }
    }
}
