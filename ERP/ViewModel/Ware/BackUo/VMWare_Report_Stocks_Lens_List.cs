
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMWare_Report_Stocks_Lens_List : VMList
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

        public VMWare_Report_Stocks_Lens_List()
            : base("WhCode", "Ware_Report_Stocks_Lens")
        {
            this.IsShowImportBool = false;
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

        }
    }
}
