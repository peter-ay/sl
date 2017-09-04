using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ERP.View
{
    public class ACBoxCusCode : AutoCompleteBox
    {
        private int c1, c2 = 0;

        public ACBoxCusCode()
            : base()
        {
            this.Name = "CusCodeAC";
            this.ValueMemberPath = "CusCode";
            this.Style = App.Current.Resources["ACTemplateCusCode"] as Style;
            this.FontFamily = App.Current.Resources["FFV"] as FontFamily;
            this.FontSize = (double)App.Current.Resources["FSV"];
            var binding = new Binding("DContextMain.CusCode")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false,
            };
            this.SetBinding(AutoCompleteBox.TextProperty, binding);

            var bd = new Binding("IsShowAC");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bd);

            this.ItemsSource = ComHelpV_B_Customer.UHV_B_CustomerSmartBrowseRight;
            this.InitSearch();
            this.InitMessages();
            this.SetFocus();
        }

        private void SetFocus()
        {
            var binding = new Binding("IsFocus" + "CusCode");
            this.SetBinding(ERP.Behavior.BhFocusACBox.IsFocusedProperty, binding);
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !this.IsDropDownOpen)
                Messenger.Default.Send<string>((this.Name), USysMessages.KeyCodeEnter);

            base.OnKeyDown(e);
        }

        private void InitSearch()
        {
            this.FilterMode = AutoCompleteFilterMode.Custom;
            this.ItemFilter = (search, item) =>
            {
                if (c1 == ComHelpV_B_Customer.UHV_B_CustomerSmartBrowseRight.Count)
                {
                    c1 = 0; c2 = 0;
                }

                c1++;

                if (c2 >= 20)
                {
                    return false;
                }

                var selectedItem = item as V_B_CustomerSmartBrowseRight;
                if (selectedItem != null)
                {
                    string filter = search.MyStr();
                    if ((selectedItem.CusCode.ToUpper().Contains(filter)
                            || selectedItem.CusName.ToUpper().Contains(filter)))
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
        }
    }
}
