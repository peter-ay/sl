
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMSale_PriceContract_List : VMList
    {
        #region SearchCondition

        private bool _IsPriAll = true;
        public bool IsPriAll
        {
            get { return _IsPriAll; }
            set { _IsPriAll = value; RaisePropertyChanged("IsPriAll"); }
        }

        private string _GpCode = "";
        public string GpCode
        {
            get { return _GpCode; }
            set { _GpCode = value; RaisePropertyChanged("GpCode"); }
        }

        private string _CusCode = "";
        public string CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        #endregion

        public VMSale_PriceContract_List()
            : base("ID", "Sale_PriceContract")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.F_SCTime = false;
            this.BCode = "";
            this.OBCode = "";
            this.IsPriAll = true;
            this.IsCheckAll = true;
            this.CusCode = "";
            this.GpCode = "";
            this.LensCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
            _SWhere += USptstr.Str1 + "GpCode" + USptstr.Str2 + this.GpCode;
            _SWhere += USptstr.Str1 + "Pri" + USptstr.Str2 + this._Pri;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "ConCheck" + USptstr.Str2 + this._ConCheck;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts(this.DDsInfoList.DefaultSortKey, true);
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Sale_PriceContract;
            var fCode = "Sale_PriceContract_CusCode";
            var vName = ErpUIText.Get(fCode);
            var _sCode = _DC.BCode + "||" + _DC.CusGroup + "||" + _DC.CusGpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick2(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            base.GridListClick2(parameter);
            var _DC = parameter as V_Sale_PriceContract;
            var fCode = "Sale_PriceContract_Lens_List";
            var vName = ErpUIText.Get(fCode);
            var _sCode = _DC.ID + "||" + _DC.BCode + "||" + _DC.CusGroup + "||" + _DC.CusGpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick3(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            base.GridListClick3(parameter);
            var _DC = parameter as V_Sale_PriceContract;
            var fCode = "Sale_PriceContract_Lens_ProCost_List";
            var vName = ErpUIText.Get(fCode);
            var _sCode = _DC.ID + "||" + _DC.BCode + "||" + _DC.CusGroup + "||" + _DC.CusGpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick4(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            base.GridListClick3(parameter);
            var _DC = parameter as V_Sale_PriceContract;
            var fCode = "Sale_PriceContract_Frame_List";
            var vName = ErpUIText.Get(fCode);
            var _sCode = _DC.ID + "||" + _DC.BCode + "||" + _DC.CusGroup + "||" + _DC.CusGpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick5(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            base.GridListClick3(parameter);
            var _DC = parameter as V_Sale_PriceContract;
            var fCode = "Sale_PriceContract_FrameSet_List";
            var vName = ErpUIText.Get(fCode);
            var _sCode = _DC.ID + "||" + _DC.BCode + "||" + _DC.CusGroup + "||" + _DC.CusGpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        #region Methods

        private RelayCommand<string> _CmdRBPCPriCheck;

        /// <summary>
        /// Gets the CmdRBPCPriCheck.
        /// </summary>
        public RelayCommand<string> CmdRBPCPriCheck
        {
            get
            {
                return _CmdRBPCPriCheck
                    ?? (_CmdRBPCPriCheck = new RelayCommand<string>(ExecuteCmdRBPCPriCheck));
            }
        }

        string _Pri = "";
        private void ExecuteCmdRBPCPriCheck(string parameter)
        {
            _Pri = parameter;
        }

        #endregion
    }
}
