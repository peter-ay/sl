using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using ERP.Web.DomainService.Common;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComExportToFactory
    {
        private static byte[] fileBytes = null;
        private static SaveFileDialog dialog = null;
        public static void Export(List<string> billcodes, bool is_cx)
        {
            if (billcodes.Count > 100)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg + ErpUIText.Get("MoreThan100"));
                return;
            }

            dialog = new SaveFileDialog();
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel Files|*.xls|All Files|*.*";
            dialog.FilterIndex = 1;
            //dialog.DefaultFileName = "MDExcel_" + DateTime.Now.ToShortDateString();

            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult != true) return;
            try
            {
                Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
                DSExportToFactory ds = new DSExportToFactory();
                ds.ExportExcelToFactory(billcodes, is_cx, USysInfo.UserCode, OnExportToFactoryCompleted, null);
            }
            catch
            {
                Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                MessageErp.ErrorMessage(ErpUIText.ErrMsg);
            }
        }

        private static void OnExportToFactoryCompleted(InvokeOperation geted)
        {
            Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
            if (geted.HasError)
            {

                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            fileBytes = geted.Value as byte[];
            using (Stream fs = dialog.OpenFile())
            {
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Close();
            }
            MessageErp.InfoMessage(ErpUIText.Get("ERP_ExportSuccecced"));
            Messenger.Default.Send<string>("", USysMessages.ExportToExcelSuccessed);
        }
    }
}
