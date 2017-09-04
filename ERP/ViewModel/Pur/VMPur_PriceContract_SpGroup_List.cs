
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMPur_PriceContract_SpGroup_List : VMList
    {
        #region SearchCondition

        private string _SpCode = "";
        public string SpCode
        {
            get { return _SpCode; }
            set { _SpCode = value; RaisePropertyChanged("SpCode"); }
        }

        #endregion

        public VMPur_PriceContract_SpGroup_List()
            : base("GpCode", "Pur_PriceContract_SpGroup", "gpCode", "gpName", isAutoRefresh: true)
        {

        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.SpCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            _SWhere += USptstr.Str1 + "spCode" + USptstr.Str2 + this.SpCode;
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_Pur_PriceContract_SpGroup;
            var fCode = "Pur_PriceContract_SpCode";
            var vName = ErpUIText.Get(fCode);
            var _sCode = "" + "||" + _DC.GpCode + "||" + _DC.GpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }
    }
}
