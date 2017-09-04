using System;

namespace ERP.Web.Entity
{
    partial class V_Sale_ContractBill_Sub_FrameSet
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

    }
}
