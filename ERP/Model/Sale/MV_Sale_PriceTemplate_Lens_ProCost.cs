using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Web.Entity
{
    partial class V_Sale_PriceTemplate_Lens_ProCost
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
       SelectedBillCode = this.ID,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        }

    }
}
