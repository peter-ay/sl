using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdDrop;

        public RelayCommand CmdDrop
        {
            get
            {
                return _CmdDrop
                    ?? (_CmdDrop = new RelayCommand(ExecuteCmdDrop));
            }
        }

        private void ExecuteCmdDrop()
        {
            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_Drop"), MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.Drop();
            };
            u.Show();
        }

        protected virtual void Drop()
        {
            this.DContextMain = null;
            this.ChangeBillSate(UBillState.Drop);
            this.IsReadOnlyID = true;
        }
    }
}
