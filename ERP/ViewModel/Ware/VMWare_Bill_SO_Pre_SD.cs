
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
using ERP.Web.Model;
using System.Windows;
namespace ERP.ViewModel
{
    public class VMWare_Bill_SO_Pre_SD : VMBill
    {
        #region property

        private V_Ware_Bill_SO_Pre_SD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_SO_Pre_SD;
            }
        }


        #endregion

        public VMWare_Bill_SO_Pre_SD()
            : base("ID", "Ware_Bill_SO_Pre_SD")
        {
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);


            switch (uBillState)
            {
                case UBillState.View:

                    break;
                case UBillState.Drop:

                    break;

                case UBillState.New:

                    break;

                case UBillState.Edit:

                    //if (string.IsNullOrEmpty(_DC.Checker))
                    //{
                    //    this.FixEditACBug();
                    //}

                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.LensCodeR = " " + this._DC.LensCodeR;
            this._DC.LensCodeR = this._DC.LensCodeR.Trim();
            this._DC.LensCodeL = " " + this._DC.LensCodeL;
            this._DC.LensCodeL = this._DC.LensCodeL.Trim();
            ///////////////////////////////////////////////
            this._DC.WhCode = " " + this._DC.WhCode;
            this._DC.WhCode = this._DC.WhCode.Trim();
            /////////////////////////////////////////////// 
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            //
            _CM.Sub_SD = new List<MWare_Bill_SD>();
            MWare_Bill_SD sub_SD = null;
            for (int i = 0; i <= 1; i++)
            {
                sub_SD = new MWare_Bill_SD()
                {
                    ID = _CM.ID,
                    CYL = i == 0 ? _DC.CYLR.Value : _DC.CYLL.Value,
                    Qty = i == 0 ? _DC.QtyR.Value : _DC.QtyL.Value,
                    SPH = i == 0 ? _DC.SPHR.Value : _DC.SPHL.Value,
                    LensCode = i == 0 ? _DC.LensCodeR.Trim() : _DC.LensCodeL.Trim(),
                    X_ADD = i == 0 ? _DC.X_ADDR.Value : _DC.X_ADDL.Value,
                    Price = 0,
                    F_LR = i == 0 ? "R" : "L",
                };
                _CM.Sub_SD.Add(sub_SD);
            }
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill";
        }
    }
}
