using ERP.Common;
using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Web.Entity
{
    partial class V_Sale_Invoice_SD
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

        private decimal? _UpdateFreight;
        public decimal? UpdateFreight
        {
            get
            {
                return this._UpdateFreight;
            }
            set
            {
                this._UpdateFreight = value;
                this.RaisePropertyChanged("UpdateFreight");
            }
        }

        private string _UpdatePhone;
        public string UpdatePhone
        {
            get
            {
                return this._UpdatePhone;
            }
            set
            {
                this._UpdatePhone = value;
                this.RaisePropertyChanged("UpdatePhone");
            }
        }

        private string _UpdateAddress;
        public string UpdateAddress
        {
            get
            {
                return this._UpdateAddress;
            }
            set
            {
                this._UpdateAddress = value;
                this.RaisePropertyChanged("UpdateAddress");
            }
        }

        private string _UpdateBCodeSale;
        public string UpdateBCodeSale
        {
            get
            {
                return this._UpdateBCodeSale;
            }
            set
            {
                this._UpdateBCodeSale = value;
                this.RaisePropertyChanged("UpdateBCodeSale");
            }
        }

        private string _UpdateDN;
        public string UpdateDN
        {
            get
            {
                return this._UpdateDN;
            }
            set
            {
                this._UpdateDN = value;
                this.RaisePropertyChanged("UpdateDN");
            }
        }

    }
}
