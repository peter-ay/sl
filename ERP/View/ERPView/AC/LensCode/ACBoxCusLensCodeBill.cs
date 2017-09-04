using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ACBoxCusLensCodeBill : ACBoxLensCodeBill
    {
        public ACBoxCusLensCodeBill()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.LensCode")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            this.InitMessages();
            base.SetGotFocus("LensCode");

            this.ClearValue(ACBoxErp.VisibilityProperty);
            var bdSAC = new Binding("IsShowACCusLensCode");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bdSAC);

            this.ClearValue(ACBoxErp.MinimumPrefixLengthProperty);
            var bdMP = new Binding("MPLPCusLensCode");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bdMP);
            /////////////////////////////////////////////////////////////////////////////////////////////////
            this.ItemsSource = ComHelpLensCode.UHV_B_CusLensCodeSmartPD;
            this.ItemsourceCount = ComHelpLensCode.UHV_B_CusLensCodeSmartPD.Count;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodePDTextUpdateBegin, (msg) =>
            {
                if (this.Text != null)
                    this._Text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodePDTextUpdateEnd, (msg) =>
            {
                if (this.Text != null)
                    this.Text = this._Text;
                this.ItemsSource = ComHelpLensCode.UHV_B_CusLensCodeSmartPD;
                this.ItemsourceCount = ComHelpLensCode.UHV_B_CusLensCodeSmartPD.Count;
            });
        }
    }
}
