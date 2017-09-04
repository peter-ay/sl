
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
namespace ERP.ViewModel
{
    public class VMMainPage : VMErpSimple
    {
        private GridLength columnWith = GridLength.Auto;
        public GridLength ColumnWith
        {
            get
            {
                return this.columnWith;
            }
            set
            {
                this.columnWith = value;
                RaisePropertyChanged("ColumnWith");
            }
        }

        public VMMainPage()
        {
            this.InitMessages();
            this.IsBusy = USysInfo.LoginMode == 0 ? true : false;
        }


        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.LoginTab, (msg) =>
            {
                ColumnWith = ColumnWith.Value == 0 ? GridLength.Auto : new GridLength(0);
            });

            Messenger.Default.Register<bool>(this, USysMessages.MainBI, (msg) =>
            {
                if (!USysFlag.IsReady)
                    return;
                this.IsBusy = msg;
            });

            Messenger.Default.Register<string>(this, USysMessages.FunLoadEnd, (msg) =>
            {
                this.IsBusy = false;
            });

            Messenger.Default.Register<string>(this, USysMessages.FunLoadBegin, (msg) =>
            {
                this.IsBusy = true;
            });

            Messenger.Default.Register<bool>(this, USysMessages.FunProgressBIMain, (msg) =>
            {
                this.IsBusyProgressMain = msg;
            });


            Messenger.Default.Register<int>(this, USysMessages.FunProgressValueMain, (msg) =>
            {
                this.BIProgressValueMain = msg;
            });
        }
    }
}