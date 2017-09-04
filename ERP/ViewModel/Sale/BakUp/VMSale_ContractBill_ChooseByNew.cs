
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMSale_ContractBill_ChooseByNew : VMChildWindow
    {
        #region property

        private string _CustType = "";
        public string CustType
        {
            get
            {
                return _CustType;
            }
            set
            {
                _CustType = value;
                RaisePropertyChanged("CustType");
            }
        }

        private string cType = "XSCA";
        public string CType
        {
            get
            {
                return cType;
            }
            set
            {
                cType = value;
                RaisePropertyChanged("CType");
            }
        }

        #endregion

        public VMSale_ContractBill_ChooseByNew()
        {

        }

        private RelayCommand<string> _CmdRBCdiType;

        /// <summary>
        /// Gets the CmdRBCdiType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiType
        {
            get
            {
                return _CmdRBCdiType
                    ?? (_CmdRBCdiType = new RelayCommand<string>(ExecuteCmdRBCdiType));
            }
        }

        private void ExecuteCmdRBCdiType(string parameter)
        {
            this.CType = parameter;
        }
    }
}
