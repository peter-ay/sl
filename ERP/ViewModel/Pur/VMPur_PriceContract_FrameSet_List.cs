
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
    public class VMPur_PriceContract_FrameSet_List : VMList
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

        private string _CusType = "";
        public string CusType
        {
            get { return _CusType; }
            set { _CusType = value; RaisePropertyChanged("CusType"); }
        }

        private string _CusTypeName = "";
        public string CusTypeName
        {
            get { return _CusTypeName; }
            set { _CusTypeName = value; RaisePropertyChanged("CusTypeName"); }
        }

        #endregion

        #region SearchCondition

        private string _BID = "";
        public string BID
        {
            get { return _BID; }
            set { _BID = value; RaisePropertyChanged("BID"); }
        }

        private string _FrameCode = "";
        public string FrameCode
        {
            get { return _FrameCode; }
            set { _FrameCode = value; RaisePropertyChanged("FrameCode"); }
        }

        private string _FrameName = "";
        public string FrameName
        {
            get { return _FrameName; }
            set { _FrameName = value; RaisePropertyChanged("FrameName"); }
        }

        #endregion


        #endregion

        public VMPur_PriceContract_FrameSet_List()
            : base("FrameCode", "Pur_PriceContract_FrameSet", isAutoRefresh: true)
        {

        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "BID" + USptstr.Str2 + this.BID;
            _SWhere += USptstr.Str1 + "FrameCode" + USptstr.Str2 + this.FrameCode;
            _SWhere += USptstr.Str1 + "FrameName" + USptstr.Str2 + this.FrameName;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.FrameCode = "";
            this.FrameName = "";
        }

        protected override void OnIDChange(string msg)
        {
            this.InitSearchCondition();
            var _Str = msg.Split(new string[] { "||" }, StringSplitOptions.None);
            this.BID = _Str[0].ToString();
            this.BCode = _Str[1].ToString();
            this.CusType = _Str[2].ToString();
            this.CusTypeName = _Str[3].ToString();
            this.Load();
        }

        protected override void New()
        {
            base.New();
            var _Msg = this.BID + "||" + this.BCode + "||" + this.CusType + "||" + this.CusTypeName;
            Messenger.Default.Send<string>((_Msg), this.VMName.Replace("_List", "_RefreshID"));
        }

        //////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            ERP.Common.ComExport.Export(this.VMNameAuthority.Replace("_List", ""), @" BID='" + this.BID + "'", " FrameCode", " FrameCode,FQty,LensCode,LQty,Price,PriceJM,Price_ProCost,Price_ProCostJM,InvTitle ");
        }

        protected override void Import()
        {
            ERP.Common.ComImport.Import(this.VMNameAuthority.Replace("_List", ""), this.BID);
        }

    }
}
