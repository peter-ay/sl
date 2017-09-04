using System.Windows;
using System.Windows.Controls;
using ERP.Common;
using ERP.Web.Entity;

namespace ERP.View
{
    public abstract class ACBoxFrameCodeErp : ACBoxErp
    {
        private int c1, c2 = 0;
        protected int _ItemsourceCount = ComHelpFrameCode.UHV_B_Material_Frame.Count;
        //private string _text = "";

        public ACBoxFrameCodeErp(string bindDContextName)
            : base("FrameCode", "", bindDContextName)
        {
            this.Style = App.Current.Resources["ACTemplateFrameCode"] as Style;
            this.ItemsSource = ComHelpFrameCode.UHV_B_Material_Frame;
            this.InitSearch();
            this.SetFocus("FrameCode");
            this.GotFocus -= new RoutedEventHandler(ACBoxErp_GotFocus);
        }

        private void InitSearch()
        {
            this.FilterMode = AutoCompleteFilterMode.Custom;
            this.ItemFilter = (search, item) =>
            {
                if (c1 == _ItemsourceCount)
                {
                    c1 = 0; c2 = 0;
                }

                c1++;

                if (c2 >= 20) return false;

                var selectedItem = item as V_B_Material_Frame;
                if (selectedItem != null)
                {
                    string filter = search.ToUpper().Trim();
                    if ((selectedItem.FrameCode.ToUpper().Contains(filter)
                        || selectedItem.FrameName.ToUpper().Contains(filter)))
                    {
                        c2++;
                        return true;
                    }
                }
                return false;
            };
        }

        //private void InitMessages()
        //{
        //    Messenger.Default.Register<int>(this, USysMessages.ACBoxMinPrefixLengthChange, (msg) =>
        //    {
        //        this.MinimumPrefixLength = msg;
        //    });

        //    Messenger.Default.Register<string>(this, USysMessages.ACBoxTextUpdate, (msg) =>
        //    {
        //        this.Text = " " + this.Text.Trim();
        //    });

        //    Messenger.Default.Register<string>(this, USysMessages.ACBoxFrameCodeTextUpdateBegin, (msg) =>
        //    {
        //        //if (this.ItemsSource == ComHelpV_B_FrameCode.UHV_B_CusFrameCodeSmart)
        //        this._text = this.Text.Trim();
        //    });
        //    Messenger.Default.Register<string>(this, USysMessages.ACBoxFrameCodeTextUpdateEnd, (msg) =>
        //    {
        //        //if (this.ItemsSource == ComHelpV_B_FrameCode.UHV_B_CusFrameCodeSmart)
        //        this.Text = this._text;
        //    });
        //}

        //protected void SetFocus(string code)
        //{
        //    var binding = new Binding("IsFocus" + code);
        //    this.SetBinding(ERP.Behavior.BhFocusACBox.IsFocusedProperty, binding);
        //}

        //public void SetGotFocus(string bingcode)
        //{
        //    var binding = new Binding("CmdGotFocus" + bingcode) { Mode = BindingMode.OneWay };
        //    var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "GotFocus" };
        //    var etc = new EventToCommand();
        //    BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
        //    trigger.Actions.Add(etc);
        //    System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        //}
    }
}
