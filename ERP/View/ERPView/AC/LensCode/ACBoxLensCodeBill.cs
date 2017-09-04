
using System.Windows.Data;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
namespace ERP.View
{
    public class ACBoxLensCodeBill : ACBoxLensCodeErp
    {
        protected string _Text = "";

        public ACBoxLensCodeBill()
            : base("DContextMain.LensCode")
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

        public void SetLostFocus(string bdCode)
        {
            var bd = new Binding("CmdLostFocus" + bdCode) { Mode = BindingMode.OneWay };
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "LostFocus" };
            var etc = new EventToCommand();
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, bd);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
