using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ERP.Common;
using ERP.View;
using ERP.ViewModel;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;
using ERP.Web.Model;

namespace ERP.Utility
{
    public class URight
    {
        private static DSM_Log DS_Bill = new DSM_Log();

        private static List<V_S_Function> _Rights = new List<V_S_Function>();

        public static List<V_S_Function> Rights
        {
            get { return URight._Rights; }
            set { URight._Rights = value; }
        }

        public static void Read()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_FunctionRightList, dds_LoadedData);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager ? -99 : USysInfo.GpID });
            dds.Load();
        }

        private static void dds_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            if (geted.HasError)
            {
                USysFlag.IsReadyRight = true;
                geted.MarkErrorAsHandled();
                return;
            }
            Rights.Clear();
            V_S_Function t = null;
            foreach (V_S_Function item in geted.Entities)
            {
                t = new V_S_Function()
                {
                    F_Open = item.F_Open,
                    FunCode = item.FunCode,
                    FunID = item.FunID,
                    FunName = item.FunName,
                    FunPID = item.FunPID,
                    ImageURL = item.ImageURL,
                    F_Explan = item.F_Explan,
                    F_ShowInMenu = item.F_ShowInMenu,
                    FunRight = item.FunRight,
                };
                Rights.Add(t);
            }
            USysFlag.IsReadyRight = true;
        }

        public static bool Check(string funCode, bool f_IsCheck = true)
        {
            if (!USysInfo.F_Manager && f_IsCheck)
            {
                var items = Rights.Where(it => it.FunCode == funCode).Count();
                if (items == 0)
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("ERP_RightErr"));
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(funCode))
            {
                var _log = new MS_Log()
                  {
                      DBCode = USysInfo.DBCode,
                      UserCode = USysInfo.UserCode,
                      ClientID = USysInfo.ClientID,
                      FunCode = funCode,
                      IP = USysInfo.IP
                  };

                DS_Bill.Add(USysInfo.DBERP, USysInfo.LgIndex, _log, geted =>
                {
                    if (geted.HasError)
                    {
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
            }

            return true;
        }
    }
}
