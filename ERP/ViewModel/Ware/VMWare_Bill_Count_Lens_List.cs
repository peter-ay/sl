
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMWare_Bill_Count_Lens_List : VMList
    {
        #region SearchCondition

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private bool _IsCheckUnCheck = false;
        public bool IsCheckUnCheck
        {
            get { return _IsCheckUnCheck; }
            set { _IsCheckUnCheck = value; RaisePropertyChanged("IsCheckUnCheck"); }
        }

        #endregion

        public VMWare_Bill_Count_Lens_List()
            : base("ID", "Ware_Bill_Count_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.LensCode = "";
            this.WhCode = "";
            this.IsCheckAll = true;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            //return base.PrepareDDsInfoListQueryName();
            return "GetV_Ware_Bill_Count_LensList";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "BType" + USptstr.Str2 + "KFOIPD";
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BCode");
        }

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Ware_Bill_Count_Lens;
            var _ID = _DC.ID;
            string _FunCode = "Ware_Bill_Count_Lens";
            var _VName = ErpUIText.Get(_FunCode);
            ComAssignWins.Assign(_ID, _FunCode, _VName);
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            //var _DC = parameter as V_Ware_Bill_Lens;
            //var _FCode = "Sale_Order_SD";
            //if (_DC.BType == "KFSOPD")
            //{
            //    _FCode = "Sale_Order_PD";
            //}
            //var _VName = ErpUIText.Get(_FCode);
            //var _IDCode = _DC.FBCode;
            //ComAssignWins.Assign(_IDCode, _FCode, _VName);
        }

        #region Cdi

        #endregion

        #region Methods

        #endregion
    }
}
