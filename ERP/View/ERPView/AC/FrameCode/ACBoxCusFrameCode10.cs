
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class ACBoxCusFrameCode10 : ACBoxCusFrameCodeBill
    {
        public ACBoxCusFrameCode10()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.FrameCode10")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
