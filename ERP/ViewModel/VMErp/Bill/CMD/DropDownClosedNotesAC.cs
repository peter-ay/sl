using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdDropDownClosedNotesAC;

        public RelayCommand CmdDropDownClosedNotesAC
        {
            get
            {
                return _CmdDropDownClosedNotesAC
                    ?? (_CmdDropDownClosedNotesAC = new RelayCommand(ExecuteCmdDropDownClosedNotesAC));
            }
        }

        private bool _IsSetNotes = false;
        private string _MyNotesCom = "";
        private void ExecuteCmdDropDownClosedNotesAC()
        {
            if (_IsSetNotes)
            {
                _IsSetNotes = !_IsSetNotes;
                return;
            }
            try
            {
                var _MyNotes = this.DContextMain.GetType().GetProperty("MyNotes").GetValue(this.DContextMain, null).ToString().Trim();

                if (_MyNotesCom == _MyNotes)
                {
                    _IsSetNotes = !_IsSetNotes;
                    return;
                }

                _MyNotesCom = _MyNotes;

                var _Notes = this.DContextMain.GetType().GetProperty("Notes").GetValue(this.DContextMain, null).ToString().Trim();
                if (_Notes.Length >= 200)
                    return;
                if (_Notes.Trim() == "")
                {
                    _Notes = _MyNotes;
                }
                else
                {
                    _Notes += "," + _MyNotes;
                }
                this.DContextMain.GetType().GetProperty("Notes").SetValue(this.DContextMain, _Notes, null);
                _IsSetNotes = !_IsSetNotes;
            }
            catch { }
            finally
            {
                this.IsFocusNotes = true;
            }
        }
    }
}
