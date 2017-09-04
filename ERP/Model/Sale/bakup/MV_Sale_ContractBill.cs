using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Web.Entity
{
    partial class V_Sale_ContractBill
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
                        SelectedBillCode = this.ContractCode,
                        VMName = this.GetType().Name.Substring(2)
                    }, USysMessages.UpdateSelectedCode);
            }
        }


        public string TypeNameUI
        {
            get
            {
                return this.TypeName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("TypeNameUI");
            }
        }

        public string StateNameUI
        {
            get
            {
                return this.StateName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("StateNameUI");
            }
        }

        partial void OnTypeNameChanged()
        {
            this.TypeNameUI = "";
        }

        partial void OnStateNameChanged()
        {
            this.StateNameUI = "";
        }

        partial void OnCreated()
        {
            this.BeginDate = DateTime.Now;
            this.Checker = "";
            this.ContractCode = "";
            this.ContractDate = DateTime.Now;
            this.ContractState = "DSH";
            this.ContractType = "";
            this.CusType = "";
            this.EndDate = DateTime.Now.AddYears(2);
            this.Maker = USysInfo.UserCode;
            this.Remark = "";
            this.StateName = ErpUIText.Get("ERP_New");
            this.TypeName = "";
        }

    }
}
