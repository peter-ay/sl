using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Web.Entity
{
    partial class V_Pur_PriceContract_SpGroup
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
                        SelectedBillCode = this.GpCode,
                        VMName = this.GetType().Name.Substring(2)
                    }, USysMessages.UpdateSelectedCode);
            }
        }

        partial void OnCreated()
        {
            this.GpCode = "";
            this.GpName = "";
        }
    }
}
