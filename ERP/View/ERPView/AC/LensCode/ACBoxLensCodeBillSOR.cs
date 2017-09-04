using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ACBoxLensCodeBillSOR : ACBoxLensCodeBill
    {
        public ACBoxLensCodeBillSOR()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.LensCodeR")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
