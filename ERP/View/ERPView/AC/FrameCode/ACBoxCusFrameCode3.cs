
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class ACBoxCusFrameCode3 : ACBoxCusFrameCodeBill
    {
        public ACBoxCusFrameCode3()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.FrameCode3")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
