using System.Windows.Input;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public abstract partial class VMErp : VMErpSimple
    {
        public VMErp()
        {
            this.InitMessages();
        }

        #region methods

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, this.VMNameAuthority + "_MsgIDChange", (msg) =>
            {
                this.OnIDChange(msg);
            });

            Messenger.Default.Register<string>(this, this.VMNameAuthority + "_MsgCusCode", (msg) =>
            {
                this.OnCusCodeChange(msg);
            });
             
            Messenger.Default.Register<string>(this, USysMessages.ExportToExcelSuccessed, (msg) =>
            {
                try
                {
                    var serialNum = this.DContextMain.GetType().GetProperty("SerialNum").GetValue(this.DContextMain, null).ToString();
                    if (string.IsNullOrEmpty(serialNum))
                    {
                        this.Search();
                    }
                }
                catch { }
            });

            Messenger.Default.Register<double>(this, this.VMName + "_ActualHeight", (msg) =>
            {
                if (msg == 0)
                {
                    this.WrapPanelHeigh = 450;
                }
                else
                {
                    switch (this.VMName)
                    {
                        case "VMM_Group_Rights_List":
                        case "VMM_User_List":
                        case "VMM_Group_List":
                            this.WrapPanelHeigh = msg - 135;
                            break;

                        default:
                            this.WrapPanelHeigh = msg - 105;
                            break;
                    }
                }
            });
        }

        protected virtual void OnIDChange(string msg) { }

        protected virtual void OnCusCodeChange(string msg) { }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void ViewKeyDown(KeyEventArgs parameter)
        {
            switch (parameter.Key)
            {
                case Key.Escape:
                    this.ExecuteCmdExit();
                    parameter.Handled = true;
                    break;
            }
        }

        #endregion


    }
}