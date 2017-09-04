using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand<KeyEventArgs> _CmdKeyDownWhCode;

        public RelayCommand<KeyEventArgs> CmdKeyDownWhCode
        {
            get
            {
                return _CmdKeyDownWhCode
                    ?? (_CmdKeyDownWhCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownWhCode));
            }
        }

        private void ExecuteCmdKeyDownWhCode(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                var _EditState = this.DContextMain.GetType().GetProperty("EditState").GetValue(this.DContextMain, null).ToString();
                if (_EditState != "1")
                    return;

                this.CallHelpWinDowWhCodeBrowse();
            }
            catch { }
        }
    }
}
