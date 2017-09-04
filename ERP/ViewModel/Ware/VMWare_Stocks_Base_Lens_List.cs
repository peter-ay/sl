
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.DomainService.Erp;
using ERP.View;
using System;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public class VMWare_Stocks_Base_Lens_List : VMList
    {
        #region SearchCondition

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        #endregion

        public VMWare_Stocks_Base_Lens_List()
            : base("ID", "Ware_Stocks_Base_Lens")
        {
            this.IsShowImportBool = false;
            this.IsShowExportBool = true;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.WhCode = "";
            this.LensCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("WhCode");
            this.DDsInfoList.AddDefaultSorts("LensCode");
        }

        protected override void Export()
        {
            if (this.GridListSelectedCodes.Count == 0)
                return;

            DSErp _DS = new DSErp();
            this.IsBusy = true;
            var _ID = UReportID.ExcelFileName;
            var p = _DS.GetV_Ware_Stocks_Base_LensForExportQuery(USysInfo.DBCode, USysInfo.LgIndex, _ID, this.GridListSelectedCodes);
            _DS.Load(p, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                ComOpenURL.Open(_ID);
            }, null);
        }

        protected override void Check()
        {
            if (this.GridListSelectedCodes.Count == 0)
                return;


        }
    }
}
