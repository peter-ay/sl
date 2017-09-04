
using ERP.Web.Entity;
using ERP.Common;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMB_Supplier_Default_List : VMList
    {
        public VMB_Supplier_Default_List()
            : base("SpCode", "B_Supplier_Default", "spCode", "spName", isAutoRefresh: true)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<bool>(this, "B_Supplier_Default_CusCode" + "_Result", (msg) =>
            {
                this.Search();
            });
            Messenger.Default.Register<bool>(this, "B_Supplier_Default_Lens" + "_Result", (msg) =>
            {
                this.Search();
            });
            Messenger.Default.Register<bool>(this, "B_Supplier_Default_ProCode" + "_Result", (msg) =>
            {
                this.Search();
            });
        }


        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_B_Supplier_Default;
            var fCode = "B_Supplier_Default_CusCode";
            var vName = ErpUIText.Get(fCode);
            var _sCode = "" + "||" + _DC.SpCode + "||" + _DC.SpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick2(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_B_Supplier_Default;
            var fCode = "B_Supplier_Default_Lens";
            var vName = ErpUIText.Get(fCode);
            var _sCode = "" + "||" + _DC.SpCode + "||" + _DC.SpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

        protected override void GridListClick3(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            var _DC = parameter as V_B_Supplier_Default;
            var fCode = "B_Supplier_Default_ProCode";
            var vName = ErpUIText.Get(fCode);
            var _sCode = "" + "||" + _DC.SpCode + "||" + _DC.SpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }

    }
}
