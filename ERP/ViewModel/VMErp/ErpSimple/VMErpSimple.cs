using System;
using System.ComponentModel;
using ERP.Utility;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public abstract partial class VMErpSimple : ViewModelBase
    {
        public VMErpSimple()
            : base()
        {
            UIText = new ComUIText();
            this.InitMessages();
        }
         
        #region Methods

        private void InitMessages()
        {
            Messenger.Default.Register<bool>(this, USysMessages.MessageWindow, (msg) =>
            {
                this.IsFocusMain = true;
            });
            Messenger.Default.Register<string>(this, USysMessages.ReturnFoucus, (msg) =>
            {
                this.IsFocusMain = true;
            });
            Messenger.Default.Register<string>(this, USysMessages.FocusTabItem, (msg) =>
            {
                this.IsFocusTabItem = true;
            });
            Messenger.Default.Register<string>(this, USysMessages.ReturnTabItemFoucus, (msg) =>
            {
                this.IsFocusMain = true;
            });
            Messenger.Default.Register<string>(this, USysMessages.OnImportCompleted, (msg) =>
            {
                this.OnImportCompleted();
            });
        } 
         
        #endregion
    }

    public class ComUIText : INotifyPropertyChanged
    {
        public string this[string uIName]
        {
            get
            {
                return ERP.Resource.Languages.ResourceManager.GetString(uIName) ?? "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeLanguage()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));

            //日期格式化  
            ERP.Common.ComInitSystem.FormatDatePattern();

        }
    }

    public class ErpUIText
    {
        public static string Get(string str)
        {
            return ERP.Resource.Languages.ResourceManager.GetString(str) ?? "";
        }

        public static string ErrMsg
        {
            get
            {
                return ERP.Resource.Languages.ResourceManager.GetString("ERP_Err") ?? "";
            }
        }

        public static string ErpFont
        {
            get
            {
                return ERP.Resource.Languages.ResourceManager.GetString("ERP_Font") ?? "";
            }
        }

        public static double ErpFontSize
        {
            get
            {
                return Convert.ToDouble(ERP.Resource.Languages.ResourceManager.GetString("ERP_FontSize") ?? "12");
            }
        }
    }

}
