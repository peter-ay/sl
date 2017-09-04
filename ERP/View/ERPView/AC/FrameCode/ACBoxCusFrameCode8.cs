
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class ACBoxCusFrameCode8 : ACBoxCusFrameCodeBill
    {  
        public ACBoxCusFrameCode8()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.FrameCode8")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
        }
    }
}
