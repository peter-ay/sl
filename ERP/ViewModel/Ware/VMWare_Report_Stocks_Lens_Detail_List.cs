
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMWare_Report_Stocks_Lens_Detail_List : VMList
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

        private string _SPH = "";
        public string SPH
        {
            get { return _SPH; }
            set { _SPH = value; RaisePropertyChanged("SPH"); }
        }

        private string _CYL = "";
        public string CYL
        {
            get { return _CYL; }
            set { _CYL = value; RaisePropertyChanged("CYL"); }
        }

        private string _X_ADD = "";
        public string X_ADD
        {
            get { return _X_ADD; }
            set { _X_ADD = value; RaisePropertyChanged("X_ADD"); }
        }

        #endregion

        public VMWare_Report_Stocks_Lens_Detail_List()
            : base("WhCode", "Ware_Report_Stocks_Lens_Detail", isAutoLoad: false)
        {
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.WhCode = "";
            this.LensCode = "";
            this.SPH = "";
            this.CYL = "";
            this.X_ADD = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "SPH" + USptstr.Str2 + this.SPH;
            _SWhere += USptstr.Str1 + "CYL" + USptstr.Str2 + this.CYL;
            _SWhere += USptstr.Str1 + "X_ADD" + USptstr.Str2 + this.X_ADD;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("WhCode");
            this.DDsInfoList.AddDefaultSorts("LensCode");
            this.DDsInfoList.AddDefaultSorts("SPH");
        }

        protected override void Export()
        {

        }
    }
}
