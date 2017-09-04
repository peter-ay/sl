
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
        protected void PrintCGSD(List<string> codes)
        {
            ComPrint.Print("CGSD", USysInfo.DBCode, codes);
            //var _RID = UID.ID;
            //DSErp ds = new DSErp();
            //var q = ds.GetV_Sale_Report_CGSDPrintQuery(USysInfo.DBCode, USysInfo.LgIndex, _RID, codes);
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
