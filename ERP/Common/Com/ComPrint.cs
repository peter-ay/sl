using ERP.Utility;
using Microsoft.VisualBasic;
using System;
using System.Windows.Browser;
using ERP.View;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.DomainService.Common;
using System.Collections.Generic;

namespace ERP.Common
{
    public class ComPrint
    {
        //public static void Print(string billCodes, string billType, bool isShowMoney, bool isBigFormat, string printCode)
        //{
        //    if (string.IsNullOrEmpty(printCode)) printCode = USysInfo.DBPrefix;

        //    string _isShowMoney = "0";
        //    if (isShowMoney) _isShowMoney = "1";

        //    string _isBigFormat = "0";
        //    if (isBigFormat) _isBigFormat = "1";

        //    string strBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
        //    int PositionOfClientBin =
        //        App.Current.Host.Source.AbsoluteUri.ToLower().IndexOf(@"/clientbin");
        //    strBaseWebAddress = Strings.Left(strBaseWebAddress, PositionOfClientBin);

        //    Uri UriWebService = new Uri(String.Format(@"{0}/" +
        //        "Report/Main.aspx?BC={1}&BT={2}&PC={3}&DB={4}&BF={5}&SM={6}",
        //        strBaseWebAddress, billCodes, billType, printCode, USysInfo.DBCode, _isBigFormat, _isShowMoney));

        //    string PopupURL = String.Format("{0}", UriWebService);
        //    System.Text.StringBuilder codeToRun = new System.Text.StringBuilder();
        //    codeToRun.Append("window.open(");
        //    codeToRun.Append("\"");
        //    codeToRun.Append(string.Format("{0}", PopupURL));
        //    codeToRun.Append("\");");

        //    HtmlPage.Window.Eval(codeToRun.ToString());
        //}

        public static void Print(string rType, string pCode, List<string> codes, bool f_IsShowMoney = true, bool f_IsBigFormat = false, string rFormat = "PDF")
        {
            DSReport ds = new DSReport();
            string _RID = UReportID.ID;
            Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            ds.GetReport(USysInfo.DBCode, USysInfo.LgIndex, USysInfo.UserCode,USysInfo.UserName,_RID, pCode, rType, rFormat, codes, f_IsShowMoney, f_IsBigFormat, geted =>
                {
                    Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    OpenReport(geted.Value);
                }, null);
        }

        public static void OpenReport(string fileName)
        {
            string _StrBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
            int _PositionOfClientBin =
                App.Current.Host.Source.AbsoluteUri.ToLower().IndexOf(@"/clientbin");
            _StrBaseWebAddress = Strings.Left(_StrBaseWebAddress, _PositionOfClientBin);
            Uri _UriWebService = new Uri(String.Format(@"{0}/" + "Report/Reports/" + fileName, _StrBaseWebAddress));

            string _PopupURL = String.Format("{0}", _UriWebService);
            System.Text.StringBuilder codeToRun = new System.Text.StringBuilder();
            codeToRun.Append("window.open(");
            codeToRun.Append("\"");
            codeToRun.Append(string.Format("{0}", _PopupURL));
            codeToRun.Append("\");");
            HtmlPage.Window.Eval(codeToRun.ToString());
        }
    }
}
