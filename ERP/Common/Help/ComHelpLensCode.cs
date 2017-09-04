using ERP.Utility;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComHelpLensCode
    {
        // 
        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_Material_LensSmart = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_Material_LensSmart
        {
            get
            {
                return _UHV_B_Material_LensSmart;
            }
        }

        public static void Load()
        {
            Load1();
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensSmartHelpListQuery", dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensSmart.Clear();
            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_Material_LensSmart.Add(t);
            }
        }

        #region Quote
        private static string _CusCodeQuote = "";

        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_CusLensCodeSmartQuote = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_CusLensCodeSmartQuote
        {
            get
            {
                return _UHV_B_CusLensCodeSmartQuote;
            }
        }

        public static void LoadCusLensCodeSmartQupte(string cusCode)
        {
            cusCode = cusCode.MyStr();
            if (string.IsNullOrEmpty(cusCode) || _CusCodeQuote == cusCode) return;
            _CusCodeQuote = cusCode;

            var _Rs = ComHelpCusCode.UHV_B_CustomerRightBrowse.Where(item => item.CusCode.MyStr() == _CusCodeQuote).FirstOrDefault();
            if (_Rs == null)
            {
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateBegin);
                _UHV_B_CusLensCodeSmartQuote.Clear();
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateEnd);
                return;
            }
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensByCusCodeListQuery", ddsCusLensCodeQuote_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "cusCode", Value = _CusCodeQuote });
            dds.Load();
        }

        private static void ddsCusLensCodeQuote_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateBegin);
            _UHV_B_CusLensCodeSmartQuote.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_CusLensCodeSmartQuote.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateEnd);
        }

        //Pur

        private static string _SpCodeQuote = "";

        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_SpLensCodeSmartQuote = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_SpLensCodeSmartQuote
        {
            get
            {
                return _UHV_B_SpLensCodeSmartQuote;
            }
        }

        public static void LoadSpLensCodeSmartQupte(string spCode)
        {
            spCode = spCode.MyStr();
            if (string.IsNullOrEmpty(spCode) || _SpCodeQuote == spCode) return;
            _SpCodeQuote = spCode;

            var _Rs = ComHelpSpCode.UHV_B_Supplier.Where(item => item.SpCode.MyStr() == _SpCodeQuote).FirstOrDefault();
            if (_Rs == null)
            {
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateBegin);
                _UHV_B_SpLensCodeSmartQuote.Clear();
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateEnd);
                return;
            }
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensBySpCodeListQuery", ddsSpLensCodeQuote_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "spCode", Value = _SpCodeQuote });
            dds.Load();
        }

        private static void ddsSpLensCodeQuote_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateBegin);
            _UHV_B_SpLensCodeSmartQuote.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_SpLensCodeSmartQuote.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeQuoteTextUpdateEnd);
        }




        #endregion

        #region SDR
        private static string _CusCodeSDR = "";

        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_CusLensCodeSmartSDR = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_CusLensCodeSmartSDR
        {
            get
            {
                return _UHV_B_CusLensCodeSmartSDR;
            }
        }

        public static void LoadCusLensCodeSmartSDR(string cusCode)
        {
            cusCode = cusCode.MyStr();
            if (string.IsNullOrEmpty(cusCode) || _CusCodeSDR == cusCode) return;
            _CusCodeSDR = cusCode;

            var _rs = ComHelpCusCode.UHV_B_CustomerRightBrowse.Where(item => item.CusCode.MyStr() == _CusCodeSDR).FirstOrDefault();
            if (_rs == null)
            {
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDRTextUpdateBegin);
                _UHV_B_CusLensCodeSmartSDR.Clear();
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDRTextUpdateEnd);
                return;
            }
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensByCusCodeListQuery", ddsCusLensCodeSDR_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "cusCode", Value = _CusCodeSDR });
            dds.Load();
        }

        private static void ddsCusLensCodeSDR_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDRTextUpdateBegin);
            _UHV_B_CusLensCodeSmartSDR.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_CusLensCodeSmartSDR.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDRTextUpdateEnd);
        }

        #endregion

        #region SDL
        private static string _CusCodeSDL = "";

        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_CusLensCodeSmartSDL = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_CusLensCodeSmartSDL
        {
            get
            {
                return _UHV_B_CusLensCodeSmartSDL;
            }
        }

        public static void LoadCusLensCodeSmartSDL(string cusCode)
        {
            cusCode = cusCode.MyStr();
            if (string.IsNullOrEmpty(cusCode) || _CusCodeSDL == cusCode) return;
            _CusCodeSDL = cusCode;

            var _rs = ComHelpCusCode.UHV_B_CustomerRightBrowse.Where(item => item.CusCode.MyStr() == _CusCodeSDL).FirstOrDefault();
            if (_rs == null)
            {
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDLTextUpdateBegin);
                _UHV_B_CusLensCodeSmartSDL.Clear();
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDLTextUpdateEnd);
                return;
            }
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensByCusCodeListQuery", ddsCusLensCodeSDL_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "cusCode", Value = _CusCodeSDL });
            dds.Load();
        }

        private static void ddsCusLensCodeSDL_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDLTextUpdateBegin);
            _UHV_B_CusLensCodeSmartSDL.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_CusLensCodeSmartSDL.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodeSDLTextUpdateEnd);
        }

        #endregion

        #region PD
        private static string _CusCodePD = "";

        private static ObservableCollection<V_B_Material_LensSmart> _UHV_B_CusLensCodeSmartPD = new ObservableCollection<V_B_Material_LensSmart>();
        public static ObservableCollection<V_B_Material_LensSmart> UHV_B_CusLensCodeSmartPD
        {
            get
            {
                return _UHV_B_CusLensCodeSmartPD;
            }
        }

        public static void LoadCusLensCodeSmartPD(string cusCode)
        {
            cusCode = cusCode.MyStr();
            if (string.IsNullOrEmpty(cusCode) || _CusCodePD == cusCode) return;
            _CusCodePD = cusCode;

            var _rs = ComHelpCusCode.UHV_B_CustomerRightBrowse.Where(item => item.CusCode.MyStr() == _CusCodePD).FirstOrDefault();
            if (_rs == null)
            {
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodePDTextUpdateBegin);
                _UHV_B_CusLensCodeSmartPD.Clear();
                Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodePDTextUpdateEnd);
                return;
            }
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensByCusCodeListQuery", ddsCusLensCodePD_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "cusCode", Value = _CusCodePD });
            dds.Load();
        }

        private static void ddsCusLensCodePD_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodePDTextUpdateBegin);
            _UHV_B_CusLensCodeSmartPD.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_LensSmart t in e.Entities)
            {
                _UHV_B_CusLensCodeSmartPD.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxLensCodePDTextUpdateEnd);
        }

        #endregion
    }
}
