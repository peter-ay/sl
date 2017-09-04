using ERP.Common;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ERP.View
{
    public abstract class ButtonFun : ButtonErp
    {
        private StackPanel sp = new StackPanel();
        private Image image = new Image();
        private TextBlock tb = new TextBlock();

        private string bindIsEnableName = "";
        private string imagePath = "";
        private string contendtext = "";
        private string bindFunctionName = "";
        private string bingIsShowName = "";

        public ButtonFun()
            : base()
        {
        }

        public ButtonFun(string bindIsEnableName, string imagePath, string contendtext, string bindFunctionName, string bingIsShowName = "")
            : this()
        {
            this.bindIsEnableName = bindIsEnableName;
            this.imagePath = imagePath;
            this.contendtext = contendtext;
            this.bindFunctionName = bindFunctionName;

            this.Padding = new Thickness(0);
            this.Margin = new Thickness(2,0,2,0);
            //this.Height = 23;
            //if (ComLanguageResourceManage.CurrentCulture.Name == "en-US")
            //    this.Width = 75;
            //else
            //    this.Width = 60;
            //this.Width = 60;
            var bindingie = new Binding(this.bindIsEnableName);
            this.SetBinding(Button.IsEnabledProperty, bindingie);

            this.bingIsShowName = bingIsShowName;
            if (!string.IsNullOrEmpty(this.bingIsShowName))
            {
                var bindingis = new Binding(this.bingIsShowName);
                this.SetBinding(Button.VisibilityProperty, bindingis);
            }

            sp.Orientation = Orientation.Horizontal;
            sp.HorizontalAlignment = HorizontalAlignment.Left;
            //Image 
            //if (!string.IsNullOrEmpty(this.imagePath))
            //{
            //    image.Source = new BitmapImage(new Uri("/ERP;component/Images/" + this.imagePath, UriKind.Relative));
            //    image.Height = 16;
            //    image.Width = 16;
            //    image.Margin = new Thickness(0, 0, 1, 0);
            //}
            //if (image.Width > 0)
            //{
            //    sp.Children.Add(image);
            //}
            //text
            tb.Text = this.contendtext;
            tb.Margin = new Thickness(0, 0, 0, 0);
            tb.Padding = new Thickness(0);
            tb.FontWeight = FontWeights.Bold;

            sp.Children.Add(tb);

            this.Content = sp;

            var trigger = new System.Windows.Interactivity.EventTrigger { EventName = "Click" };
            var etc = new EventToCommand();
            var binding =
                new Binding(this.bindFunctionName) { Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(etc, EventToCommand.CommandProperty, binding);
            trigger.Actions.Add(etc);
            System.Windows.Interactivity.Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
