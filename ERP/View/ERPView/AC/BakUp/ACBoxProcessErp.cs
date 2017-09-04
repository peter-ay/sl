using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace ERP.View
{
    public abstract class ACBoxProcess : ACBoxErp
    {
        public ACBoxProcess(string bingcode)
            : base("ProCode", "ACDataTemplateProcess", bingcode, true)
        {
            this.ClearValue(AutoCompleteBox.VisibilityProperty);
            base.SetInList();
        }
    }

    public abstract class ACBoxProcess_CF : ACBoxErp
    {
        public ACBoxProcess_CF(string bingcode)
            : base("ProCode", "ACDataTemplateProcess", bingcode)
        {
            this.InitMessages();
            this.ClearValue(AutoCompleteBox.VisibilityProperty);
            this.Visibility = Visibility.Visible;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<bool>(this, USysMessages.ACBoxProcess_CF_IsShow, (msg) =>
            {
                var t = msg ? Visibility.Visible : Visibility.Collapsed;
                this.Visibility = t;
            });
        }
    }

    public abstract class ACBoxProcess_KF : ACBoxErp
    {
        public ACBoxProcess_KF(string bingcode)
            : base("ProCode", "ACDataTemplateProcess", bingcode)
        {
            this.InitMessages();
            this.ClearValue(AutoCompleteBox.VisibilityProperty);
            this.Visibility = Visibility.Collapsed;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<bool>(this, USysMessages.ACBoxProcess_KF_IsShow, (msg) =>
            {
                var t = msg ? Visibility.Visible : Visibility.Collapsed;
                this.Visibility = t;
            });
        }
    }
}
