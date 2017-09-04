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
    public abstract class ACBoxSpCodeBrowseErp : ACBoxErp
    {
        private int c1, c2 = 0;
        private int _ItemsourceCount = ComHelpSpCode.UHV_B_SupplierRightBrowse.Count;

        public ACBoxSpCodeBrowseErp(string bindDContextName)
            : base("SpCode", "", bindDContextName)
        {
            this.Style = App.Current.Resources["ACTemplateSpCode"] as Style;
            this.ItemsSource = ComHelpSpCode.UHV_B_SupplierRightBrowse;
            this.InitSearch();
            this.SetFocus("SpCode");
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

                var selectedItem = item as V_B_Supplier;
                if (selectedItem != null)
                {
                    string filter = search.MyStr();
                    if ((selectedItem.SpCode.ToUpper().Contains(filter)
                            || selectedItem.SpName.ToUpper().Contains(filter)))
                    {
                        c2++;
                        return true;
                    }
                }
                return false;
            };
        }

    }
}
