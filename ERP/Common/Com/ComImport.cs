using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using ERP.Web.DomainService.Common;
using GalaSoft.MvvmLight.Messaging;
using System.IO;
using System.Windows.Controls;
using System;
using System.ServiceModel.DomainServices.Client;

namespace ERP.Common
{
    public class ComImport
    {
        static DSImport _DS = new DSImport();
        static Stream _FileStream; static bool _LastBlock = false; static string _OpenFileName = string.Empty; static long _FileLength; static long _FileLengthVs;
        static string _TableName = string.Empty; static string _BID = string.Empty; static string _OpenFileExtension = string.Empty;
        static string _ID = string.Empty;
        public static void Import(string tableName, string bID = "")
        {
            _TableName = tableName;
            _BID = bID;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Excel Files |*.xls";
                if ((bool)dialog.ShowDialog())
                {
                    _ID = DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length == 2 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + DateTime.Now.Day + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                    InitUploadPara();
                    _OpenFileName = dialog.File.Name;
                    _OpenFileExtension = dialog.File.Extension;
                    _FileStream = dialog.File.OpenRead();
                    _FileLength = dialog.File.Length;
                    _FileLengthVs = _FileLength;

                    if (_FileLength > (100 * 1024 * 1024))
                    {
                        MessageErp.ErrorMessage(ErpUIText.Get("Err_LargeThan100M"));
                        try { _FileStream.Close(); }
                        catch { }
                        return;
                    }
                    SentFileStream(true);
                }
            }

            catch (IOException)
            {
                try { _FileStream.Close(); }
                catch { }
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_FileInUse"));
            }
        }

        private static void InitUploadPara()
        {
            _LastBlock = false;
            Messenger.Default.Send<bool>(false, USysMessages.FunProgressBIMain);
            Messenger.Default.Send<int>(0, USysMessages.FunProgressValueMain);
            try { _FileStream.Close(); }
            catch { }
        }

        private static void SentFileStream(bool firstBlock)
        {
            byte[] _Buffer = new byte[4 * 4 * 1024];
            int _BytesRead = _FileStream.Read(_Buffer, 0, _Buffer.Length);
            _FileLengthVs = _FileLengthVs - _BytesRead;
            if (_FileLengthVs <= 0) _FileLengthVs = 0;
            double V1 = Convert.ToDouble(_FileLength - _FileLengthVs);
            double V2 = Convert.ToDouble(_FileLength);
            Messenger.Default.Send<bool>(true, USysMessages.FunProgressBIMain);
            Messenger.Default.Send<int>(Convert.ToInt32((V1 / V2) * 100), USysMessages.FunProgressValueMain);

            if (_BytesRead <= 0)
            {
                _LastBlock = true;
            }

            _DS.Import(USysInfo.DBCode, USysInfo.LgIndex, _ID, USysInfo.UserCode, _TableName, _OpenFileName, _OpenFileExtension, _Buffer, firstBlock, _LastBlock, OnSendCompleted, null);
        }

        private static void OnSendCompleted(InvokeOperation geted)
        {
            if (geted.HasError)
            {
                Messenger.Default.Send<bool>(false, USysMessages.FunProgressBIMain);
                Messenger.Default.Send<int>(0, USysMessages.FunProgressValueMain);
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                try { _FileStream.Close(); }
                catch { }
                return;
            }

            if (_LastBlock)
            {
                InitUploadPara();
                OnFuntionCompleted(geted.Value.ToString());
            }
            else
            {
                SentFileStream(false);
            }
        }

        private static void OnFuntionCompleted(string fileName)
        {
            Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            _DS.ImportCompleted(USysInfo.DBCode, USysInfo.LgIndex, fileName, _TableName, _BID, geted =>
                                {
                                    Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                                    if (geted.HasError)
                                    {
                                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                                        geted.MarkErrorAsHandled();
                                        return;
                                    }
                                    MessageErp.InfoMessage(ErpUIText.Get("ERP_ImportSucceed") + "[" + geted.Value.ToString() + "]");
                                    Messenger.Default.Send<string>("", USysMessages.OnImportCompleted);
                                }, null);
        }

    }
}
