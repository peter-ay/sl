using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ERP.View
{
    public abstract class ACBoxLensCodeErp : AutoCompleteBox
    {
        private int c1, c2 = 0;
        private int source = 0;
        private int sourceCount = 0;
        private string _text = "";

        public ACBoxLensCodeErp(string bingName, int source = 0)
            : this()
        {
            this.source = source;
            this.ValueMemberPath = "LensCode";
            this.Style = App.Current.Resources["ACTemplateLensCode"] as Style;
            this.FontFamily = App.Current.Resources["FFV"] as FontFamily;
            this.FontSize = (double)App.Current.Resources["FSV"];

            var binding = new Binding(bingName) { Mode = BindingMode.TwoWay, ValidatesOnNotifyDataErrors = false };
            this.SetBinding(AutoCompleteBox.TextProperty, binding);

            var bd = new Binding("IsShowAC");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bd);

            if (source == 1)
            {
                this.ItemsSource = ComHelpV_B_LensCode.UHV_B_LensCodeSmart;
            }
            this.InitSearch();
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !this.IsDropDownOpen)
                Messenger.Default.Send<string>((this.Name), USysMessages.KeyCodeEnter);

            base.OnKeyDown(e);
        }

        public ACBoxLensCodeErp()
            : base()
        {
            this.ItemsSource = ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart;
            this.InitMessages();
        }

        private void InitSearch()
        {
            this.FilterMode = AutoCompleteFilterMode.Custom;
            this.ItemFilter = (search, item) =>
            {
                if (this.ItemsSource == ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart)
                    sourceCount = ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart.Count;
                else
                    sourceCount = ComHelpV_B_LensCode.UHV_B_LensCodeSmart.Count;

                if (sourceCount == 0)
                {
                    c1 = 0; c2 = 0;
                    return false;
                }

                if (c1 == sourceCount)
                {
                    c1 = 0; c2 = 0;
                }

                c1++;

                if (c2 >= 20)
                {
                    return false;
                }

                var selectedItem = item as V_B_LensSmart;
                if (selectedItem != null)
                {
                    string filter = search.ToUpper().Trim();
                    if ((selectedItem.LensCode.ToUpper().Contains(filter) || selectedItem.LensName.ToUpper().Contains(filter)))
                    {
                        c2++;
                        return true;
                    }
                }
                return false;
            };
        }

        private void InitMessages()
        {
            Messenger.Default.Register<int>(this, USysMessages.ACBoxMinPrefixLengthChange, (msg) =>
            {
                this.MinimumPrefixLength = msg;
            });

            Messenger.Default.Register<string>(this, USysMessages.ACBoxTextUpdate, (msg) =>
            {
                this.Text = " " + this.Text.Trim();
            });

            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeTextUpdateBegin, (msg) =>
            {
                //if (this.ItemsSource == ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart)
                this._text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeTextUpdateEnd, (msg) =>
            {
                //if (this.ItemsSource == ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart)
                this.Text = this._text;
            });
        }

        protected void SetFocus(string code)
        {
            var binding = new Binding("IsFocus" + code);
            this.SetBinding(ERP.Behavior.BhFocusACBox.IsFocusedProperty, binding);
        }

        public void SetGotFocus(string bingcode)
        {
            var binding = new Binding("CmdGotFocus" + bingcode) { Mode = BindingMode.OneWay };
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "GotFocus" };
            var etc = new EventToCommand();
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
