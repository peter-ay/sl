using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand<KeyEventArgs> _CmdKeyDownNotes;

        /// <summary>
        /// Gets the CmdKeyDownNotes.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdKeyDownNotes
        {
            get
            {
                return _CmdKeyDownNotes
                    ?? (_CmdKeyDownNotes = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownNotes));
            }
        }

        private void ExecuteCmdKeyDownNotes(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                var _EditState = this.DContextMain.GetType().GetProperty("EditState").GetValue(this.DContextMain, null).ToString();
                if (_EditState != "1")
                    return;
            }
            catch { }

            this.IsFocusNotesAC = true;
        }
    }
}
