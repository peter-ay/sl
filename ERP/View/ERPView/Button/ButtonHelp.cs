using ERP.Converters;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ERP.View
{
    public class ButtonHelp
        : ButtonErp
    {
        public ButtonHelp()
        {
            this.MinWidth = 0;
            this.Height = 23;
            this.Width = 20;
            this.Content = "?";
            this.FontSize = 14;
            this.FontFamily = App.Current.Resources["FFN"] as FontFamily;
            this.Padding = new Thickness(2, 3, 2, 1);
            this.VerticalAlignment = VerticalAlignment.Bottom;
            var bindingie = new Binding("IsReadOnly") { ElementName = "TB_Falg_RO", Converter = new ReadOnlyToEnable() };
            this.SetBinding(Button.IsEnabledProperty, bindingie);
            this.SetIsShow();
        }

        public ButtonHelp(string commandname)
            : this()
        {
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand();
            var binding =
                new Binding(commandname) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
