using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Data;

namespace ERP.Common
{
    public class ComAddViewMethods
    {
        public static void Add<T>(T t) where T : DependencyObject
        {
            AddOnLoad(t);
            AddKeyDown(t);
            AddBindingValidationError(t);
        }

        public static void AddChildWindowDefaultButtonMethod<T>(T t1, T t2) where T : DependencyObject
        {
            AddChildWindowOK(t1);
            AddChildWindowCancel(t2);
        }

        private static void AddChildWindowOK<T>(T t) where T : DependencyObject
        {
            if (t == null) return;
            var cmdMame = "CmdOK";
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand();
            var binding = new Binding(cmdMame) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(t).Add(trigger);
        }

        private static void AddChildWindowCancel<T>(T t) where T : DependencyObject
        {
            if (t == null) return;
            var cmdMame = "CmdCancel";
            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand();
            var binding = new Binding(cmdMame) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(t).Add(trigger);
        }

        private static void AddOnLoad<T>(T t) where T : DependencyObject
        {
            if (t == null) return;
            var cmdMame = "CmdViewOnLoad";
            var trigger = new System.Windows.Interactivity.EventTrigger { };
            var etc = new EventToCommand();
            var binding = new Binding(cmdMame) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(t).Add(trigger);
        }

        private static void AddKeyDown<T>(T t) where T : DependencyObject
        {
            if (t == null) return;
            var cmdMame = "CmdViewKeyDown";
            var trigger = new System.Windows.Interactivity.EventTrigger
            {
                EventName = "KeyDown"
            };
            var etc = new EventToCommand
                {
                    PassEventArgsToCommand = true,
                };
            var binding = new Binding(cmdMame) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(t).Add(trigger);
        }

        private static void AddBindingValidationError<T>(T t) where T : DependencyObject
        {
            if (t == null) return;
            var cmdMame = "CmdViewBindingValidationError";
            var trigger = new System.Windows.Interactivity.EventTrigger
            {
                EventName = "BindingValidationError"
            };
            var etc = new EventToCommand
            {
                PassEventArgsToCommand = true,
            };
            var binding = new Binding(cmdMame) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(t).Add(trigger);
        }
    }
}
