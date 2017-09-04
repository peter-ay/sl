using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class BusyIndicatorErp : BusyIndicator
    {
        public BusyIndicatorErp()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle1"] as Style;

            var bindingis = new Binding("IsBusy");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);

            var bindingis2 = new Binding("UIText[ERP_BusyContend]");
            this.SetBinding(BusyIndicator.BusyContentProperty, bindingis2);

            var binding = new Binding("UIText[ERP_Font]");
            this.SetBinding(Button.FontFamilyProperty, binding);
            var bdsz = new Binding("UIText[ERP_FontSize]");
            this.SetBinding(Button.FontSizeProperty, bdsz);
        }
    }

    public class BusyIndicatorMain : BusyIndicator
    {
        public BusyIndicatorMain()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle1"] as Style;

            var bindingis = new Binding("IsBusyMain");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
        }
    }

    public class BusyIndicatorSub : BusyIndicator
    {
        public BusyIndicatorSub()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle1"] as Style;

            var bindingis = new Binding("IsBusySub");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
        }
    }

    public class BusyIndicatorList2 : BusyIndicator
    {
        public BusyIndicatorList2()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle1"] as Style;

            var bindingis = new Binding("IsBusyList2");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
        }
    }

    public class BusyIndicatorProgress : BusyIndicator
    {
        public BusyIndicatorProgress()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle2"] as Style;

            var bindingis = new Binding("IsBusyProgress");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
            var bdBIValue = new Binding("BIProgressValue");
            Style style = new Style(typeof(ProgressBar));
            style.Setters.Add(new Setter(ProgressBar.ValueProperty, bdBIValue));
            style.Setters.Add(new Setter(ProgressBar.IsIndeterminateProperty, false));
            style.Setters.Add(new Setter(ProgressBar.HeightProperty, 15));
            style.Setters.Add(new Setter(ProgressBar.MarginProperty, new Thickness(8, 0, 8, 8)));
            this.ProgressBarStyle = style;
        }
    }

    public class BusyIndicatorProgressMain : BusyIndicator
    {
        public BusyIndicatorProgressMain()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle2"] as Style;

            var bindingis = new Binding("IsBusyProgressMain");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
            var bdBIValue = new Binding("BIProgressValueMain");
            Style style = new Style(typeof(ProgressBar));
            style.Setters.Add(new Setter(ProgressBar.ValueProperty, bdBIValue));
            style.Setters.Add(new Setter(ProgressBar.IsIndeterminateProperty, false));
            style.Setters.Add(new Setter(ProgressBar.HeightProperty, 15));
            style.Setters.Add(new Setter(ProgressBar.MarginProperty, new Thickness(8, 0, 8, 8)));
            this.ProgressBarStyle = style;
        }
    }

    public class BusyIndicatorCW : BusyIndicator
    {
        public BusyIndicatorCW()
        {
            this.Style = App.Current.Resources["BusyIndicatorStyle1"] as Style;

            var bindingis = new Binding("IsBusyCW");
            this.SetBinding(BusyIndicator.IsBusyProperty, bindingis);
        }
    }

}
