using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ERP.View
{
    public abstract class ACBoxErp : AutoCompleteBox
    {
        public ACBoxErp(string valueMemberPath, string itemTemplate, string bindname, bool f_InList = false)
        {
            this.Height = 23;
            this.FontFamily = App.Current.Resources["FFV"] as FontFamily;
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.MinimumPrefixLength = -1;
            this.MinimumPopulateDelay = 0;
            this.IsTextCompletionEnabled = false;
            this.FilterMode = AutoCompleteFilterMode.None;
            this.Padding = new Thickness(1, 4, 1, 1);

            var bd = new Binding("IsShowAC");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bd);

            if (!string.IsNullOrEmpty(valueMemberPath))
                this.ValueMemberPath = valueMemberPath;
            if (!string.IsNullOrEmpty(itemTemplate))
                this.ItemTemplate = App.Current.Resources[itemTemplate] as DataTemplate;

            var binding = new Binding(bindname)
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, binding);

            if (!f_InList)
            {
                this.InitMessages();
            }
            //this.InitTextStyle();
        }

        private void InitTextStyle()
        {
            Style style = new Style(typeof(TextBox));
            style.Setters.Add(new Setter(TextBox.TextAlignmentProperty, "Right"));
            this.TextBoxStyle = style;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<int>(this, USysMessages.ACBoxMinPrefixLengthChange, (msg) =>
            {
                this.MinimumPrefixLength = msg;
                if (msg == 0)
                    this.GotFocus += new RoutedEventHandler(ACBox_GotFocus);
                else
                    this.GotFocus -= new RoutedEventHandler(ACBox_GotFocus);
            });

            Messenger.Default.Register<string>(this, USysMessages.ACBoxTextUpdate, (msg) =>
            {
                this.Text = " " + this.Text.Trim();
                this.Text = this.Text.Trim();
            });
        }

        private void ACBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsDropDownOpen = true;
        }

        protected void SetFocus(string fcode)
        {
            var binding = new Binding("IsFocus" + fcode);
            this.SetBinding(ERP.Behavior.BhFocusACBox.IsFocusedProperty, binding);
        }

        protected void SetDropDownClosed(string bindFunctionName)
        {
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "DropDownClosed" };
            var etc = new EventToCommand();
            var binding =
                new Binding("CmdDropDownClosed" + bindFunctionName) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }

        protected void SetInList()
        {
            this.MinimumPrefixLength = 0;
            this.GotFocus += new RoutedEventHandler(ACBox_GotFocus);
        }
    }
}
