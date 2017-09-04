using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using ERP.Common;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdReOrder;

        /// <summary>
        /// Gets the CmdReOrder.
        /// </summary>
        public RelayCommand CmdReOrder
        {
            get
            {
                return _CmdReOrder ?? (_CmdReOrder = new RelayCommand(ExecuteCmdReOrder));
            }
        }

        private void ExecuteCmdReOrder()
        {
            if (!CanExecuteCmdReOrder())
            {
                return;
            }

            this.ReOrder();
        }

        protected virtual void ReOrder()
        {
            ComAssignWins.Assign("", "Sale_Order_SD_ReOrder");
        }

        private bool CanExecuteCmdReOrder()
        {
            return URight.Check(this.VMNameAuthority + "_ReOrder");
        }
    }
}
