using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdNew;

        public RelayCommand CmdNew
        {
            get
            {
                return _CmdNew ?? (_CmdNew = new RelayCommand(ExecuteCmdNew));
            }
        }

        private void ExecuteCmdNew()
        {
            if (!CanExecuteCmdNew())
            {
                return;
            }

            this.New();
        }

        protected virtual void New()
        {
            this.IsFocusMain = true;
            this.PrepareDContextMain();
            this.ChangeBillSate(UBillState.New);
            this.IsReadOnlyID = false;
            this.IsFocusID = true;
        }
         
        /////////////////////////////////////////////////////////////////////////////////////////////
        private bool CanExecuteCmdNew()
        {
            return URight.Check(this.VMNameAuthority + "_New", false); ;
        }
    }
}
