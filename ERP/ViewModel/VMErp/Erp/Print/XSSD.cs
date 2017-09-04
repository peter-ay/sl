
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Erp;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        protected void PrintXSSD(List<string> codes, bool f_IsShowMoney = true, bool f_IsBigFormat = false)
        {
            ComPrint.Print("XSSD", USysInfo.DBCode, codes, f_IsShowMoney, f_IsBigFormat);
            //var _RID = UID.ID;
            //DSErp ds = new DSErp();
            //var q = ds.GetV_Sale_Report_XSSDPrintQuery(USysInfo.DBCode, USysInfo.LgIndex, _RID, codes, "CN", "PDF", f_IsShowMoney, f_IsBigFormat);
            //Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            //ds.Load(q, geted =>
            //{
            //    Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
            //    if (geted.HasError)
            //    {
            //        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
            //        geted.MarkErrorAsHandled();
            //        return;
            //    }
            //    ComPrint.OpenReport(_RID + ".pdf");
            //    //ComOpenURL.Open(_id + ".pdf", @"Report/Reports");
            //}, null);
        }
    }
}
