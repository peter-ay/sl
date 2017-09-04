using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdEdit;

        /// <summary>
        /// Gets the CmdEdit.
        /// </summary>
        public RelayCommand CmdEdit
        {
            get
            {
                return _CmdEdit ?? (_CmdEdit = new RelayCommand(ExecuteCmdEdit));
            }
        }

        private void ExecuteCmdEdit()
        {
            if (!CanExecuteCmdEdit())
            {
                return;
            }

            this.Edit();
        }

        private void Edit()
        {
            this.IsFocusMain = true;
            this.ChangeBillSate(UBillState.Edit);
            this.IsReadOnlyID = true;
        }

        private bool CanExecuteCmdEdit()
        {
            return URight.Check(this.VMNameAuthority + "_Edit", false);
        }
    }
}
