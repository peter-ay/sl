using ERP.Utility;
using Microsoft.VisualBasic;
using System;
using System.Windows.Browser;

namespace ERP.Common
{
    public class ComOpenURL
    {
        public static void Open(string fileName, string path = "Export")
        {
            string strBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
            int PositionOfClientBin =
                App.Current.Host.Source.AbsoluteUri.ToLower().IndexOf(@"/clientbin");
            strBaseWebAddress = Strings.Left(strBaseWebAddress, PositionOfClientBin);

            Uri UriWebService = new Uri(String.Format(@"{0}/" +
                path + "/{1}",
                strBaseWebAddress, fileName));

            string PopupURL = String.Format("{0}", UriWebService);
            System.Text.StringBuilder codeToRun = new System.Text.StringBuilder();
            codeToRun.Append("window.open(");
            codeToRun.Append("\"");
            codeToRun.Append(string.Format("{0}", PopupURL));
            codeToRun.Append("\");");

            HtmlPage.Window.Eval(codeToRun.ToString());
        }

        public static void OpenByFullURL(string url)
        {
            string PopupURL = String.Format("{0}", url);
            System.Text.StringBuilder codeToRun = new System.Text.StringBuilder();
            codeToRun.Append("window.open(");
            codeToRun.Append("\"");
            codeToRun.Append(string.Format("{0}", PopupURL));
            codeToRun.Append("\");");
            HtmlPage.Window.Eval(codeToRun.ToString());
        }

        public static string GetRootURL()
        {
            string strBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
            int PositionOfClientBin =
                App.Current.Host.Source.AbsoluteUri.ToLower().IndexOf(@"/clientbin");
            strBaseWebAddress = Strings.Left(strBaseWebAddress, PositionOfClientBin);
            return strBaseWebAddress + "/";
        }
    }
}
