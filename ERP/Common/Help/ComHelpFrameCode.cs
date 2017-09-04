using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Linq;

namespace ERP.Common
{
    public class ComHelpFrameCode
    {
        private static ObservableCollection<V_B_Material_Frame> _UHV_B_Material_Frame = new ObservableCollection<V_B_Material_Frame>();
        public static ObservableCollection<V_B_Material_Frame> UHV_B_Material_Frame
        {
            get
            {
                return _UHV_B_Material_Frame;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_Material_FrameHelpList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_Frame.Clear();
            foreach (V_B_Material_Frame t in e.Entities)
            {
                _UHV_B_Material_Frame.Add(t);
            }
        }

        #region FrameCode
        //private static string _CusCodeFrameCode = "";

        private static ObservableCollection<V_B_Material_Frame> _UHV_B_CusFrameCode = new ObservableCollection<V_B_Material_Frame>();
        public static ObservableCollection<V_B_Material_Frame> UHV_B_CusFrameCode
        {
            get
            {
                return _UHV_B_CusFrameCode;
            }
        }

        public static void LoadCusFrameCode(string cusCode)
        {
            //cusCode = cusCode.MyStr();
            //if (string.IsNullOrEmpty(cusCode) || _CusCodeFrameCode == cusCode) return;
            //_CusCodeFrameCode = cusCode;

            //var _rs = ComHelpCusCode.UHV_B_CustomerSmartBrowseRight.Where(item => item.CusCode.MyStr() == _CusCodeFrameCode).FirstOrDefault();
            //if (_rs == null)
            //{
            //    Messenger.Default.Send<string>((""), USysMessages.ACBoxFrameCodeTextUpdateBegin);
            //    _UHV_B_CusFrameCode.Clear();
            //    Messenger.Default.Send<string>((""), USysMessages.ACBoxFrameCodeTextUpdateEnd);
            //    return;
            //}
            //var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_CusFrameHelpListQuery", LoadCusFrameCode_LoadedData, true);
            //dds.QueryParameters.Add(new Parameter() { ParameterName = "cusCode", Value = _CusCodeFrameCode });
            //dds.Load();
        }

        private static void LoadCusFrameCode_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxFrameCodeTextUpdateBegin);
            _UHV_B_CusFrameCode.Clear();

            if (e.TotalEntityCount == 0) return;

            foreach (V_B_Material_Frame t in e.Entities)
            {
                _UHV_B_CusFrameCode.Add(t);
            }
            Messenger.Default.Send<string>((""), USysMessages.ACBoxFrameCodeTextUpdateEnd);
        }

        #endregion


    }

}
