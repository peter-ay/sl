
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
namespace ERP.View
{
    public class ACBoxFrameCodeBill : ACBoxFrameCodeErp
    {
        protected string _Text = "";

        public ACBoxFrameCodeBill()
            : base("DContextMain.FrameCode")
        {

        }

        public void SetGotFocus(string bdCode)
        {
            var bd = new Binding("CmdGotFocus" + bdCode) { Mode = BindingMode.OneWay };
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "GotFocus" };
            var etc = new EventToCommand();
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, bd);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
