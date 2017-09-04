using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ERP.View
{
    public class TextBoxErp : TextBox
    {
        public TextBoxErp()
            : base()
        {
            this.Style = App.Current.Resources["TBoxStyle"] as Style;
            base.GotFocus += (s, e) =>
            {
                base.SelectAll();
            };
            this.Height = 23;
            //this.TextAlignment = System.Windows.TextAlignment.Right;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.FontFamily = App.Current.Resources["FFV"] as FontFamily;
            this.FontSize = (double)App.Current.Resources["FSV"];
        }

        public TextBoxErp(string bingcode, bool isNotifyDataErrors = false, bool validatesOnExceptions = false, bool convertToDateshort = false, string bdIsReadOnly = "TB_Falg_RO")
            : this()
        {
            var binding = new Binding(bingcode)
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = isNotifyDataErrors,
                NotifyOnValidationError = true,
                //ValidatesOnDataErrors = true,
                ValidatesOnExceptions = validatesOnExceptions,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };

            if (convertToDateshort)
            {
                binding.Converter = new ERP.Converters.ToShortDataString();
                binding.TargetNullValue = "";
            }

            this.SetBinding(TextBox.TextProperty, binding);

            var bindingRO = new Binding("IsReadOnly")
            {
                ElementName = bdIsReadOnly
            };
            this.SetBinding(TextBox.IsReadOnlyProperty, bindingRO);
        }

        protected void SetFocus(string fcode)
        {
            var binding = new Binding("IsFocus" + fcode);
            this.SetBinding(ERP.Behavior.BhFocusTBox.IsFocusedProperty, binding);
        }

        protected void ReSetRO()
        {
            this.ClearValue(TextBox.IsReadOnlyProperty);
            this.IsReadOnly = true;
        }

        protected void SetKeyDown(string bindFunctionName)
        {
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "KeyDown" };
            var etc = new EventToCommand() { PassEventArgsToCommand = true };
            var binding =
                new Binding("CmdKeyDown" + bindFunctionName) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }

        protected void SetVisible(string bding = "IsShowTB")
        {
            var bd = new Binding(bding);
            this.SetBinding(TextBox.VisibilityProperty, bd);
        }
    }
}
