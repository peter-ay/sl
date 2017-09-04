using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ERP.View
{
    public class ComBoxErp : ComboBox
    {
        public ComBoxErp()
            : base()
        {
            this.Style = App.Current.Resources["ComBoxStyle"] as Style;
            this.Height = 23;
            this.Padding = new Thickness(5, 0, 0, 0);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        }

        public ComBoxErp(string itemTemplate)
            : this()
        {
            this.ItemTemplate = App.Current.Resources[itemTemplate] as DataTemplate;

            //var b2 = new Binding("ComboBoxSelectedItem") { Mode = BindingMode.TwoWay };
            //BindingOperations.SetBinding(this, ComboBox.SelectedItemProperty, b2);

            //var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "SelectionChanged" };
            //var etc = new EventToCommand();
            //var b1 = new Binding(bindFunctionName) { Mode = BindingMode.OneWay };
            //BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, b1);
            //trigger.Actions.Add(etc);
            //            var trigger = (System.Windows.Interactivity.EventTrigger)
            //                            XamlReader.Load(@"
            //
            //                <i:Interaction.Triggers xmlns='http://schemas.microsoft.com/client/2007'  xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity' xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras'>
            //                    <i:EventTrigger EventName='SelectionChanged'>
            //                        <Command:EventToCommand Command='{Binding CmdDataBaseChange, Mode=OneWay}' CommandParameter='{Binding SelectedItem, ElementName=CB_DataBase}'/>
            //                    </i:EventTrigger>
            //                </i:Interaction.Triggers>");

            //            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
