using ERP.Common;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ERP.View
{
    public abstract class ButtonHome : ButtonErp
    {
        private StackPanel sp = new StackPanel();
        private StackPanel sp2 = new StackPanel();
        private Image image = new Image();
        private TextBlock tb = new TextBlock();

        private string imagePath = "";
        private string contendtext = "";
        public ButtonHome()
            : base()
        {
        }

        public ButtonHome(string contendtext, string functionCode, string imagePath, int foreground = 0)
            : this()
        {

            this.imagePath = imagePath;
            this.contendtext = contendtext;

            this.Padding = new Thickness(1, 0, 1, 1);
            this.Height = 22;
            this.Width = 120;

            sp.Orientation = Orientation.Horizontal;

            image.Source = new BitmapImage(new Uri("/ERP;component/Images/" + this.imagePath, UriKind.Relative));
            image.Height = 16;
            image.Width = 16;
            image.Margin = new Thickness(0, 0, 2, 0);

            sp2.Width = 92;
            sp2.Orientation = Orientation.Horizontal;
            sp.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Text = this.contendtext; tb.FontSize = 13;
            tb.Margin = new Thickness(0, 4, 0, 0);
            //tb.FontFamily = new FontFamily("NSimSun");
            tb.Padding = new Thickness(0);
            //tb.FontWeight = FontWeights.Bold;
            if (foreground == 1)
            {
                tb.Foreground = new SolidColorBrush(ComColorConstants.DarkRed);
            }
            sp2.Children.Add(tb);

            sp.Children.Add(image);
            sp.Children.Add(sp2);

            this.Content = sp;

            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand();
            var binding =
                new Binding("CmdOpenWins") { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            etc.CommandParameter = functionCode;
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
