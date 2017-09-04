using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ACBoxCusLensCodeBillSDRR : ACBoxLensCodeBill
    {
        public ACBoxCusLensCodeBillSDRR()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.LensCodeRR")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
