﻿
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class ACBoxCusFrameCode6 : ACBoxCusFrameCodeBill
    {
        public ACBoxCusFrameCode6()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.FrameCode6")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}