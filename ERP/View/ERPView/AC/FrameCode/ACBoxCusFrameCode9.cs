
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class ACBoxCusFrameCode9 : ACBoxCusFrameCodeBill
    {
        public ACBoxCusFrameCode9()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.FrameCode9")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
