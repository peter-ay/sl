
using System;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using ERP.View;
using ERP.Utility;
using ERP.Web.Model;
using ERP.Web.DomainService.Bill;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMSale_PriceContract_Lens_List : VMList
    {
        #region Property


        //////////////////////////////////////////////

        #region ListShowDetail
        //private string _BCode = "";
        //public string BCode
        //{
        //    get { return _BCode; }
        //    set { _BCode = value; RaisePropertyChanged("BCode"); }
        //}

        private string _GpCode = "";
        public string GpCode
        {
            get { return _GpCode; }
            set { _GpCode = value; RaisePropertyChanged("GpCode"); }
        }

        private string _GpName = "";
        public string GpName
        {
            get { return _GpName; }
            set { _GpName = value; RaisePropertyChanged("GpName"); }
        }

        #endregion

        #region SearchCondition

        private string _BID = "";
        public string BID
        {
            get { return _BID; }
            set { _BID = value; RaisePropertyChanged("BID"); }
        }

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _LensName = "";
        public string LensName
        {
            get { return _LensName; }
            set { _LensName = value; RaisePropertyChanged("LensName"); }
        }

        #endregion


        #endregion

        public VMSale_PriceContract_Lens_List()
            : base("LensCode", "Sale_PriceContract_Lens", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "BID" + USptstr.Str2 + this.BID;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "LensName" + USptstr.Str2 + this.LensName;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.LensCode = "";
            this.LensName = "";
        }

        protected override void OnIDChange(string msg)
        {
            this.InitSearchCondition();
            var _Str = msg.Split(new string[] { "||" }, StringSplitOptions.None);
            this.BID = _Str[0].ToString();
            this.BCode = _Str[1].ToString();
            this.GpCode = _Str[2].ToString();
            this.GpName = _Str[3].ToString();
            this.Load();
        }

        protected override void New()
        {
            base.New();
            var _Msg = this.BID + "||" + this.BCode + "||" + this.GpCode + "||" + this.GpName;
            Messenger.Default.Send<string>((_Msg), this.VMName.Replace("_List", "_RefreshID"));
        }

        //////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            ERP.Common.ComExport.Export(this.VMNameAuthority.Replace("_List", ""), @" BID='" + this.BID + "'", " LensCode", " LensCode,SPH1,SPH2,CYL1,CYL2,X_ADD1,X_ADD2,Dia,P1,P2,P1JM,P2JM,InvTitle ");
        }

        protected override void Import()
        {
            ERP.Common.ComImport.Import(this.VMNameAuthority.Replace("_List", ""), this.BID);
        }

        protected override void OnImportCompleted()
        {
            this.Load();
        }

    }
}
