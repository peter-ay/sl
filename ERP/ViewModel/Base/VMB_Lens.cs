
using GalaSoft.MvvmLight.Command;
using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMB_Lens : VMBill
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

        public VMB_Lens()
            : base("LensCode", "B_Lens")
        {
            this.IsChildWindow = true;
        }

        #region Methods
        private RelayCommand _CmdEditLensPrice;

        /// <summary>
        /// Gets the CmdEditLensPrice.
        /// </summary>
        public RelayCommand CmdEditLensPrice
        {
            get
            {
                return _CmdEditLensPrice
                    ?? (_CmdEditLensPrice = new RelayCommand(ExecuteCmdEditLensPrice));
            }
        }

        private void ExecuteCmdEditLensPrice()
        {
            try
            {
                var _DC = this.DContextMain as V_B_Lens;
                USysTemp.KeyCode = _DC.LensCode;
                USysTemp.KeyName = _DC.LensName;
            }
            catch
            {
                USysTemp.KeyCode = "";
                USysTemp.KeyName = "";
            }
            ComAssignWins.Assign(this.SIDCode, "B_Lens_Price_List");
        }
        /////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdEditLensProCost;

        /// <summary>
        /// Gets the CmdEditLensProCost.
        /// </summary>
        public RelayCommand CmdEditLensProCost
        {
            get
            {
                return _CmdEditLensProCost
                    ?? (_CmdEditLensProCost = new RelayCommand(ExecuteCmdEditLensProCost));
            }
        }

        private void ExecuteCmdEditLensProCost()
        {
            try
            {
                var _DC = this.DContextMain as V_B_Lens;
                USysTemp.KeyCode = _DC.LensCode;
                USysTemp.KeyName = _DC.LensName;
            }
            catch
            {
                USysTemp.KeyCode = "";
                USysTemp.KeyName = "";
            }
            ComAssignWins.Assign(this.SIDCode, "B_Lens_ProCost_List");
        }
        ///////////////////////////////////////////////////////////////////////
        private RelayCommand<string> _CmdRBCdiLensType;

        /// <summary>
        /// Gets the CmdRBCdiLensType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiLensType
        {
            get
            {
                return _CmdRBCdiLensType
                    ?? (_CmdRBCdiLensType = new RelayCommand<string>(ExecuteCmdRBCdiLensType));
            }
        }

        private void ExecuteCmdRBCdiLensType(string parameter)
        {
            try
            {
                var _DC = this.DContextMain as V_B_Lens;
                _DC.LensType = System.Convert.ToByte(parameter);
            }
            catch { }
        }

        /////////////////////////////////////////////////////////////////////////////
        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            try
            {
                var _DC = this.DContextMain as V_B_Lens;
                switch (_DC.LensType)
                {
                    case 0:
                        this.IsCheckLensTypeST = true;
                        break;
                    case 1:
                        this.IsCheckLensTypeRX = true;
                        break;
                    case 2:
                        this.IsCheckLensTypeOT = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
        ////////////////////////////////////////////////////////////////////////////
        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnableLensType = false;
            this.IsEnableEditLensPrice = false;
            this.IsEnableEditLensProCost = false;
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
