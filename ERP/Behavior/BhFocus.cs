using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;


namespace ERP.Behavior
{
    public class BhFocusPBox : ControlFocusBehaviorBase<PasswordBox>
    { }

    public class BhFocusTBox : ControlFocusBehaviorBase<TextBox>
    { }

    public class BhFocusACBox : ControlFocusBehaviorBase<AutoCompleteBox>
    {
    }

    public class BhFocusButton : ControlFocusBehaviorBase<Button>
    {
    }

    public class ControlFocusBehaviorBase<T> : Behavior<FrameworkElement>
    where T : Control
    {
        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(
        "IsFocused", typeof(bool), typeof(ControlFocusBehaviorBase<T>),
        new PropertyMetadata(IsFocusedPropertyChanged));

        private static void IsFocusedPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var p = dependencyObject as T;
            if (p == null) return;
            if ((e.NewValue is bool ? (bool)e.NewValue : false))
            {
                p.Focus();
            }
        }

        public static bool GetIsFocused(T p)
        {
            return p.GetValue(IsFocusedProperty) is bool ? (bool)p.GetValue(IsFocusedProperty) : false;
        }

        public static void SetIsFocused(T p, bool value)
        {
            p.SetValue(IsFocusedProperty, value);
        }

    }

}
