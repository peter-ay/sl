
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMSale_PriceContract_CusGroup_List : VMList
    {
        #region SearchCondition

        private string _CusCode = "";
        public string CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; RaisePropertyChanged("CusCode"); }
        }

        #endregion

        public VMSale_PriceContract_CusGroup_List()
            : base("GpCode", "Sale_PriceContract_CusGroup", "gpCode", "gpName", isAutoRefresh: true)
        {

        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.CusCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            _SWhere += USptstr.Str1 + "cusCode" + USptstr.Str2 + this.CusCode;
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Sale_PriceContract_CusGroup;
            var fCode = "Sale_PriceContract_CusCode";
            var vName = ErpUIText.Get(fCode);
            var _sCode = "" + "||" + _DC.GpCode + "||" + _DC.GpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }
    }
}
