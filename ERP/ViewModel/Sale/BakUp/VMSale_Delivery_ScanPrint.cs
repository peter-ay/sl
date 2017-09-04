
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
    public class VMSale_Delivery_ScanPrint : VMBill
    {

        #region Properties

        private bool _IsCheckPPY = true;
        public bool IsCheckPPY
        {
            get { return _IsCheckPPY; }
            set { _IsCheckPPY = value; RaisePropertyChanged("IsCheckPPY"); }
        }

        private bool _IsCheckPBFY = true;
        public bool IsCheckPBFY
        {
            get { return _IsCheckPBFY; }
            set { _IsCheckPBFY = value; RaisePropertyChanged("IsCheckPBFY"); }
        }


        #endregion

        public VMSale_Delivery_ScanPrint()
            : base("ID", "Sale_Delivery_ScanPrint")
        {

        }

        #region Methods

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

        protected override void Print()
        {

        }




        #endregion

    }
}
