using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using ERP.Web.DomainService.Common;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.IO;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComExport
    {
        //public static void Export(string tableName, string where = " 1=1", string orderby = " ", string selectItems = "*")
        //{
        //    DSExport DS_Bill = new DSExport();
        //    var dialog = new SaveFileDialog();

        //    dialog.DefaultExt = ".xls";
        //    dialog.Filter = "Excel Files|*.xls|All Files|*.*";
        //    dialog.FilterIndex = 1;
        //    //dialog.DefaultFileName = tableName + "_" + DateTime.Now.ToShortDateString();

        //    bool? dialogResult = dialog.ShowDialog();
        //    if (dialogResult == true)
        //    {
        //        try
        //        {
        //            Messenger.Default.Send<string>("", USysMessages.FunctionLoadBegin);
        //            byte[] fileBytes = null;
        //            DS_Bill.Export(USysInfo.DBCode,USysInfo.LgIndex,USysInfo.UserCode, tableName, where, orderby, selectItems, geted =>
        //            {
        //                Messenger.Default.Send<string>("", USysMessages.FunctionLoadend);
        //                if (geted.HasError)
        //                {
        //                    //USysInfo.ErrMsg = ErpUIText.Get("ERP_ExportFail") + geted.Error.Message.Substring(geted.Error.Message.IndexOf('.') + 1);
        //                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
        //                    geted.MarkErrorAsHandled();
        //                    return;
        //                }
        //                fileBytes = geted.Value;
        //                using (Stream fs = dialog.OpenFile())
        //                {
        //                    fs.Write(fileBytes, 0, fileBytes.Length);
        //                    fs.Close();
        //                }
        //                MessageErp.InfoMessage(ErpUIText.Get("ERP_ExportSuccecced"));
        //            }, null);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageErp.ErrorMessage(ErpUIText.Get("ERP_ExportFail") + ex.Message);
        //        }
        //    }
        //}

        public static void Export(string tableName, string where = " 1=1", string orderby = " ", string selectItems = "*")
        {
            DSExport _DS = new DSExport();
            Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            _DS.Export(USysInfo.DBCode, USysInfo.LgIndex, USysInfo.UserCode, tableName, where, orderby, selectItems, geted =>
            {
                Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                var _FileName = geted.Value;
                ComOpenURL.Open(_FileName);
            }, null);
        }

    }
}
