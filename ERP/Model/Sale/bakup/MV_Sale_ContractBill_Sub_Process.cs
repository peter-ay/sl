using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Web.Entity
{
    partial class V_Sale_ContractBill_Sub_Process
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
                Messenger.Default.Send<USelectedBillCodes>(
                   new USelectedBillCodes()
                   {
                       IsAdd = value,
                       SelectedBillCode = this.SubID.ToString(),
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

    }
}
