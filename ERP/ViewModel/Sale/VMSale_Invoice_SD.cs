
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMSale_Invoice_SD : VMBill
    {
        #region property

        //private V_Sale_Invoice_SD _DC
        //{
        //    get
        //    {
        //        return this.DContextMain as V_Sale_Invoice_SD;
        //    }
        //}

        #region enableButton

        //private bool _IsEnableEditPriceContractLens = false;
        //public bool IsEnableEditPriceContractLens
        //{
        //    get { return _IsEnableEditPriceContractLens; }
        //    set
        //    {
        //        _IsEnableEditPriceContractLens = value;
        //        RaisePropertyChanged("IsEnableEditPriceContractLens");
        //    }
        //} 

        #endregion


        #endregion

        public VMSale_Invoice_SD()
            : base("ID", "Sale_Invoice_SD", true)
        {
        }

        protected override void OnLoadMainEndRetSetDContextMain(System.ServiceModel.DomainServices.Client.Entity item)
        {
            //base.OnLoadMainEndRetSetDContextMain(item);
            //this._DC.UpdateFreight = this._DC.Freight;
            //this._DC.UpdatePhone = this._DC.DPhone;
            //this._DC.UpdateAddress = this._DC.DAddress;
            //this._DC.UpdateBCodeSale = this._DC.BCodeSale;
            //this._DC.UpdateDN = this._DC.DN;
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsEnablePrint = true;
            switch (uBillState)
            {
                case UBillState.View:

                    break;
                case UBillState.Drop:

                    break;
                case UBillState.New:

                    break;
                case UBillState.Edit:

                    break;
            }
        }

        ////////////////////////////////////////
        #region Methods


        #endregion

    }
}
