using System;
using ERP.Common;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public class VMSale_ContractBill_List : VMList
    {
        #region property

        private string cusType;
        public string CusType
        {
            get { return cusType; }
            set { cusType = value; RaisePropertyChanged("CusType"); }
        }

        private string cusCode;
        public string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string contractCode1;
        public string ContractCode1
        {
            get { return contractCode1; }
            set { contractCode1 = value; RaisePropertyChanged("ContractCode1"); }
        }

        private string contractCode2;
        public string ContractCode2
        {
            get { return contractCode2; }
            set { contractCode2 = value; RaisePropertyChanged("ContractCode2"); }
        }

        private string oContractCode;
        public string OContractCode
        {
            get { return oContractCode; }
            set { oContractCode = value; RaisePropertyChanged("OContractCode"); }
        }

        #endregion

        public VMSale_ContractBill_List()
            : base("ContractCode", "Sale_ContractBill")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            this.D1 = DateTime.Now.AddYears(-2).ToShortDateString();
            this.CusType = "";
            this.Checker = "";
            this.Maker = "";
            this.CusCode = "";
            this.ContractCode1 = "";
            this.ContractCode2 = "";
            this.OContractCode = "";
            this.IsCheckAll = true;
            _cdiCheck = -1;
            this.IsTypeAll = true;
            conType = "";
        }

        protected override void PrepareDDsInfoMainParameters()
        {
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "d1", Value = D1 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "d2", Value = D2 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cusType", Value = this.CusType.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cusCode", Value = this.CusCode.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "code1", Value = this.ContractCode1.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "code2", Value = this.ContractCode2.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "ocode", Value = this.OContractCode.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "maker", Value = this.Maker.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "checker", Value = this.Checker.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdicheck", Value = _cdiCheck });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "conType", Value = conType.MyStr() });
        }

        #region methods

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

        string conType = "";
        private void ExecuteCmdRBCdiType(string parameter)
        {
            conType = parameter;
        }


        #endregion

    }
}
