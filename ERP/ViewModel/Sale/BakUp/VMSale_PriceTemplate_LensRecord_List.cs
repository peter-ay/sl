
using System.ServiceModel.DomainServices.Client;
using ERP.Common;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMSale_PriceTemplate_LensRecord_List : VMList
    {
        public VMSale_PriceTemplate_LensRecord_List()
            : base("LensCode", "Sale_PriceTemplate_LensRecord", "lensCode", "lensName")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void GridListClick2(Entity parameter)
        {
            var _RS = parameter as V_Sale_PriceTemplate_LensRecord;
            var _KeyCode = _RS.LensCode;
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
            var funcode = "Sale_PriceTemplate_Lens_List";
            ComOpenWins.Open("", funcode, f_CheckRight: false);
            Messenger.Default.Send<string>((_KeyCode), funcode + "_ShowFromList2");
        }

        protected override void GridListClick3(Entity parameter)
        {
            var _RS = parameter as V_Sale_PriceTemplate_LensRecord;
            var _KeyCode = _RS.LensCode;
            var funcode = "Sale_PriceTemplate_Lens_ProCost_List";
            ComOpenWins.Open("", funcode, f_CheckRight: false);
            Messenger.Default.Send<string>((_KeyCode), funcode + "_ShowFromList2");
        }
    }
}
