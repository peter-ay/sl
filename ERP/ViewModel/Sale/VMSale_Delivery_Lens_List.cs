
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using System;
namespace ERP.ViewModel
{
    public class VMSale_Delivery_Lens_List : VMList
    {
        #region SearchCondition

        private bool _IsCheckDeliveryAll = true;
        public bool IsCheckDeliveryAll
        {
            get { return _IsCheckDeliveryAll; }
            set { _IsCheckDeliveryAll = value; RaisePropertyChanged("IsCheckDeliveryAll"); }
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

        private string _OBCodeSale = "";
        public string OBCodeSale
        {
            get { return _OBCodeSale; }
            set { _OBCodeSale = value; RaisePropertyChanged("OBCodeSale"); }
        }

        private string _DN = "";
        public string DN
        {
            get { return _DN; }
            set { _DN = value; RaisePropertyChanged("DN"); }
        }

        private int _SCDelivery = -1;

        #endregion

        public VMSale_Delivery_Lens_List()
            : base("ID", "Sale_Delivery_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            //this.D1 = System.DateTime.Now.AddYears(-2).ToShortDateString();
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.IsCheckDeliveryAll = true;
            this._SCDelivery = -1;
            this.BCodeSale = "";
            this.OBCodeSale = "";
            this.DN = "";
            this.CusCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCodeSale" + USptstr.Str2 + this.BCodeSale;
            _SWhere += USptstr.Str1 + "DN" + USptstr.Str2 + this.DN;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "SCDelivery" + USptstr.Str2 + this._SCDelivery;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BCode");
        }

        protected override void OnIDChange(string msg)
        {
            this.InitSearchCondition();
            this.F_SCTime = false;
            this.BCodeSale = msg;
            this.Load();
        }

        #region Methods

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            //var _DC = parameter as V_Sale_Delivery_Lens;
            //var _ID = _DC.ID;
            //string _FunCode = "Sale_Delivery_SD";
            //if (_DC.BType.Contains("PD"))
            //{
            //    _FunCode = "Sale_Delivery_PD";
            //}
            //var _VName = ErpUIText.Get(_FunCode);
            //ComAssignWins.Assign(_ID, _FunCode, _VName);
        }

        #region RBCon

        private RelayCommand<string> _CmdRBCdiDelivery;

        public RelayCommand<string> CmdRBCdiDelivery
        {
            get
            {
                return _CmdRBCdiDelivery
                    ?? (_CmdRBCdiDelivery = new RelayCommand<string>(
                    p =>
                    {
                        this._SCDelivery = Convert.ToInt32(p);
                    }));
            }
        }

        #endregion

        #endregion
    }
}
