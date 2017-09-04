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
    public abstract class ACBoxCusCodeBrowseErp : ACBoxErp
    {
        private int c1, c2 = 0;
        private int _ItemsourceCount = ComHelpCusCode.UHV_B_CustomerRightBrowse.Count;

        public ACBoxCusCodeBrowseErp(string bindDContextName)
            : base("CusCode", "", bindDContextName)
        {
            this.Style = App.Current.Resources["ACTemplateCusCode"] as Style;
            this.ItemsSource = ComHelpCusCode.UHV_B_CustomerRightBrowse;
            this.InitSearch();
            this.SetFocus("CusCode");
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

                var selectedItem = item as V_B_Customer;
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

    }
}
