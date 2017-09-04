
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
namespace ERP.ViewModel
{
    public class VMWare_Bill_SO_Pending_PD_List : VMList
    {
        #region SearchCondition

        private string _CusCode = "";
        public string CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        #endregion

        public VMWare_Bill_SO_Pending_PD_List()
            : base("ID", "Ware_Bill_SO_Pending_PD")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.F_SCTime = false;
            this.CusCode = "";
            this.WhCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "OGType" + USptstr.Str2 + "1";
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BCode");
        }

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Ware_Bill_SO_Pending_PD;
            var _ID = _DC.ID;
            var _VMCode = "VMWare_Bill_SO_PD";
            var _FunCode = "Ware_Bill_SO_PD";
            var _VName = ErpUIText.Get(_FunCode);
            ComOpenWins.Open("", _FunCode, _VName);
            Messenger.Default.Send<string>((_ID), _VMCode + "_NewSOFromList");
        }

        #region Cdi

        #endregion

        #region Methods

        #endregion
    }
}
