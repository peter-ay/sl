
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMSale_Rec_Lens_List : VMList
    {
        #region SearchCondition

        private bool _BillTypeALL = true;
        public bool BillTypeALL
        {
            get { return _BillTypeALL; }
            set { _BillTypeALL = value; RaisePropertyChanged("BillTypeALL"); }
        }

        private string _CusCode = "";
        public string CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string _BCodeSale = "";
        public string BCodeSale
        {
            get { return _BCodeSale; }
            set { _BCodeSale = value; RaisePropertyChanged("BCodeSale"); }
        }

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private string _BTypeSale = "";
        public string BTypeSale
        {
            get { return _BTypeSale; }
            set { _BTypeSale = value; RaisePropertyChanged("BTypeSale"); }
        }

        //private bool _IsCheckUnCheck = false;
        //public bool IsCheckUnCheck
        //{
        //    get { return _IsCheckUnCheck; }
        //    set { _IsCheckUnCheck = value; RaisePropertyChanged("IsCheckUnCheck"); }
        //}

        #endregion

        public VMSale_Rec_Lens_List()
            : base("ID", "Ware_Bill_SO_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.BillTypeALL = true;
            this.CusCode = "";
            this.WhCode = "";
            this.BTypeSale = "";
            this.BCodeSale = "";
            this.IsCheckAll = true;
        }

        protected override void OnIDChange(string msg)
        {
            this.InitSearchCondition();
            this.F_SCTime = false;
            this.BCodeSale = msg;
            this.Load();
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();

            _SWhere += USptstr.Str1 + "F_WhCode" + USptstr.Str2 + "0";
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "BTypeSale" + USptstr.Str2 + this.BTypeSale;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "BCodeSale" + USptstr.Str2 + this.BCodeSale;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BDate");
            this.DDsInfoList.AddDefaultSorts("BCode");
        }

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Ware_Bill_SO_Lens;
            var _ID = _DC.ID;
            string _FunCode = "Sale_Rec_PD";
            if (_DC.BType == "KFSOPDWG")
            {
                _FunCode = "Sale_Rec_PD";
            }
            var _VName = ErpUIText.Get(_FunCode);
            ComAssignWins.Assign(_ID, _FunCode, _VName);
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Ware_Bill_SO_Lens;
            var _FCode = "Sale_Order_SD";
            if (_DC.BType == "KFSOPD")
            {
                _FCode = "Sale_Order_PD";
            }
            var _VName = ErpUIText.Get(_FCode);
            var _IDCode = _DC.FBCode;
            ComAssignWins.Assign(_IDCode, _FCode, _VName);
        }

        #region Cdi

        private RelayCommand<string> _CmdRBCdiBillType;

        /// <summary>
        /// Gets the CmdRBCdiBillType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiBillType
        {
            get
            {
                return _CmdRBCdiBillType
                    ?? (_CmdRBCdiBillType = new RelayCommand<string>(
                    p =>
                    {
                        this.BTypeSale = p;
                    }));
            }
        }
        ///////////////////////////// 

        #endregion

        #region Methods

        #endregion
    }
}
