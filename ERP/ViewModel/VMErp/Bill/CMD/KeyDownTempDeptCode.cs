using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand<KeyEventArgs> _CmdKeyDownTempDpCode;

        public RelayCommand<KeyEventArgs> CmdKeyDownTempDpCode
        {
            get
            {
                return _CmdKeyDownTempDpCode
                    ?? (_CmdKeyDownTempDpCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownTempDpCode));
            }
        }

        private void ExecuteCmdKeyDownTempDpCode(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                var _EditState = this.DContextMain.GetType().GetProperty("EditState").GetValue(this.DContextMain, null).ToString();
                if (_EditState != "1")
                    return;
                this.CallHelpWinDowTempDpCode();
            }
            catch { }
        }
    }
}
