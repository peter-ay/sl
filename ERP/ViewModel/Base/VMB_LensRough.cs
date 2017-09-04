
using GalaSoft.MvvmLight.Command;
using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMB_LensRough : VMBill
    {
        #region Property
        //IsEnableLensType
        private bool _IsEnableLensType = false;
        public bool IsEnableLensType
        {
            get { return _IsEnableLensType; }
            set
            {
                _IsEnableLensType = value;
                RaisePropertyChanged("IsEnableLensType");
            }
        }

        //IsEnableEditLensPrice
        private bool _IsEnableEditLensPrice = false;
        public bool IsEnableEditLensPrice
        {
            get { return _IsEnableEditLensPrice; }
            set
            {
                _IsEnableEditLensPrice = value;
                RaisePropertyChanged("IsEnableEditLensPrice");
            }
        }

        //IsEnableEditLensProCost
        private bool _IsEnableEditLensProCost = false;
        public bool IsEnableEditLensProCost
        {
            get { return _IsEnableEditLensProCost; }
            set
            {
                _IsEnableEditLensProCost = value;
                RaisePropertyChanged("IsEnableEditLensProCost");
            }
        }


        #region IsCheckLensType
        private bool _IsCheckLensTypeST = true;
        public bool IsCheckLensTypeST
        {
            get { return _IsCheckLensTypeST; }
            set
            {
                _IsCheckLensTypeST = value;
                RaisePropertyChanged("IsCheckLensTypeST");
            }
        }

        private bool _IsCheckLensTypeRX = false;
        public bool IsCheckLensTypeRX
        {
            get { return _IsCheckLensTypeRX; }
            set
            {
                _IsCheckLensTypeRX = value;
                RaisePropertyChanged("IsCheckLensTypeRX");
            }
        }

        private bool _IsCheckLensTypeOT = false;
        public bool IsCheckLensTypeOT
        {
            get { return _IsCheckLensTypeOT; }
            set
            {
                _IsCheckLensTypeOT = value;
                RaisePropertyChanged("IsCheckLensTypeOT");
            }
        }
        #endregion



        #endregion

        public VMB_LensRough()
            : base("RCode", "B_LensRough")
        {
            this.IsChildWindow = true;
        }

        #region Methods


        /////////////////////////////////////////////////////////////////////////////
        protected override void OnLoadMainEnd()
        {
            //base.OnLoadMainEnd();
            //try
            //{
            //    var _DC = this.DContextMain as V_B_LensRough;
            //    switch (_DC.LensType)
            //    {
            //        case 0:
            //            this.IsCheckLensTypeST = true;
            //            break;
            //        case 1:
            //            this.IsCheckLensTypeRX = true;
            //            break;
            //        case 2:
            //            this.IsCheckLensTypeOT = true;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch { }
        }
        ////////////////////////////////////////////////////////////////////////////
        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);


            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableEditLensPrice = true;
                    this.IsEnableEditLensProCost = true;
                    break;
                case UBillState.Edit:
                    this.IsEnableLensType = true;
                    break;
                case UBillState.Drop:
                    break;
                case UBillState.New:
                    this.IsEnableLensType = true;
                    break;
            }
        }
        #endregion
    }
}
