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
    public abstract class ACBoxLensCodeErp : ACBoxErp
    {
        private int c1, c2 = 0;
        private int _ItemsourceCount = ComHelpLensCode.UHV_B_Material_LensSmart.Count;
        protected int ItemsourceCount
        {
            get { return this._ItemsourceCount; }
            set
            {
                this._ItemsourceCount = value;
                this.c1 = 0;
                this.c2 = 0;
            }
        }

        //private string _text = "";

        public ACBoxLensCodeErp(string bindDContextName)
            : base("LensCode", "", bindDContextName)
        {
            this.Style = App.Current.Resources["ACTemplateLensCode"] as Style;
            this.ItemsSource = ComHelpLensCode.UHV_B_Material_LensSmart;
            this.InitSearch();
            this.SetFocus("LensCode");
            this.GotFocus -= new RoutedEventHandler(ACBoxErp_GotFocus);
        }

        private void InitSearch()
        {
            this.FilterMode = AutoCompleteFilterMode.Custom;
            this.ItemFilter = (search, item) =>
            {
                if (string.IsNullOrEmpty(search) || search.Trim() == "" || ItemsourceCount == 0)
                    return false;

                if (c1 == ItemsourceCount)
                {
                    c1 = 0; c2 = 0;
                }

                c1++;

                if (c2 >= 20) return false;

                var selectedItem = item as V_B_Material_LensSmart;
                if (selectedItem != null)
                {
                    string filter = search.ToUpper().Trim();
                    if ((selectedItem.LensCode.ToUpper().Contains(filter)
                        || selectedItem.LensName.ToUpper().Contains(filter)))
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

        //    Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeTextUpdateBegin, (msg) =>
        //    {
        //        //if (this.ItemsSource == ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart)
        //        this._text = this.Text.Trim();
        //    });
        //    Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeTextUpdateEnd, (msg) =>
        //    {
        //        //if (this.ItemsSource == ComHelpV_B_LensCode.UHV_B_CusLensCodeSmart)
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
