using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public class VMLoginUserLogined : VMErpSimple
    {
        #region Property
        private string _IPAddress = "";
        public string IPAddress
        {
            set
            {
                _IPAddress = "IP:" + value;
                RaisePropertyChanged("IPAddress");
            }
            get
            {
                return _IPAddress;
            }
        }

        public string UserInfo
        {
            get
            {
                return USysInfo.UserCode + " " + USysInfo.UserName.UIStr();
            }
        }

        public string DBInfo
        {
            get
            {
                return USysInfo.DBName.UIStr();
            }
        }

        private string msgDate;
        /// <summary>
        /// /////////////////////////////////
        /// </summary>
        public string MsgDate
        {
            get { return msgDate; }
            set { msgDate = value; RaisePropertyChanged("MsgDate"); }
        }

        private string msgTime;
        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
        public string MsgTime
        {
            get { return msgTime; }
            set { msgTime = value; RaisePropertyChanged("MsgTime"); }
        }

        #endregion

        public VMLoginUserLogined()
        {
            this.InitDateTime();
            this.InitMessages();
        }

        private void GetIP()
        {
            new DSGetIP().GetIP4Address(geted =>
            {
                if (geted.HasError)
                {
                    geted.MarkErrorAsHandled();
                    return;
                }
                var rs = geted.Value.ToString();
                USysInfo.IP = rs.Split(';')[0];
                this.IPAddress = USysInfo.IP;
                USysInfo.ClientID = rs.Split(';')[1];
            }, null);
        }

        private void InitDateTime()
        {
            Storyboard s = new Storyboard();
            s.Duration = new Duration(TimeSpan.FromSeconds(1));
            s.Completed += (s1, e1) =>
            {
                this.MsgDate = DateTime.Now.Year
                    + ErpUIText.Get("ERP_Year")
                    + DateTime.Now.Month
                    + ErpUIText.Get("ERP_Month")
                    + DateTime.Now.Day
                    + ErpUIText.Get("ERP_Day");
                string dayofweek = "";
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        dayofweek = ErpUIText.Get("ERP_Friday"); break;
                    case DayOfWeek.Monday:
                        dayofweek = ErpUIText.Get("ERP_Monday"); break;
                    case DayOfWeek.Saturday:
                        dayofweek = ErpUIText.Get("ERP_Saturday"); break;
                    case DayOfWeek.Sunday:
                        dayofweek = ErpUIText.Get("ERP_Sunday"); break;
                    case DayOfWeek.Thursday:
                        dayofweek = ErpUIText.Get("ERP_Thursday"); break;
                    case DayOfWeek.Tuesday:
                        dayofweek = ErpUIText.Get("ERP_Tuesday"); break;
                    case DayOfWeek.Wednesday:
                        dayofweek = ErpUIText.Get("ERP_Wednesday"); break;
                }
                this.MsgTime = " " + dayofweek + " " + DateTime.Now.ToShortTimeString();
                s.Begin();
            };
            s.Begin();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.UserLoginedTree, (msg) =>
            {
                this.LoadFunctionTree();
                this.GetIP();
            });
        }

        private ObservableCollection<V_S_Function> _TreeDateSource = new ObservableCollection<V_S_Function>();
        public ObservableCollection<V_S_Function> TreeDateSource
        {
            get
            {
                return _TreeDateSource;
            }
            set
            {
                _TreeDateSource = value;
                RaisePropertyChanged("TreeDateSource");
            }
        }

        private void LoadFunctionTree()
        {
            TreeDateSource.Clear();
            TreeDateSource.Add(new V_S_Function() { FunName = ErpUIText.Get("ERP_Loading") });
            switch (USysInfo.LoginMode)
            {
                case 0:
                    this.LoadFunctionTree0();
                    break;
                case 1:
                    this.LoadFunctionTree1();
                    break;
            }
        }
        /////////////////////////////////////////////////////////////////////////////// 
        private void LoadFunctionTree0()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_FunctionTreeErpList, dds_LoadedData);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager ? -99 : USysInfo.GpID });
            dds.Load();
        }
        ///////////////////////////////////////////////////////////////////////////// 
        private void LoadFunctionTree1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_FunctionTreeManList, dds_LoadedData);
            dds.Load();
        }
        /////////////////////////////////////////////////////////////////////////////// 
        void dds_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            if (geted.HasError)
            {
                TreeDateSource.Clear();
                TreeDateSource.Add(new V_S_Function() { FunName = ErpUIText.ErrMsg });
                geted.MarkErrorAsHandled();
                return;
            }
            if (geted.Entities.Count() == 0)
            {
                TreeDateSource.Clear();
                return;
            }
            var items = geted.Entities;
            this.InitTree(items);
        }
        /////////////////////////////////////////////////////////////////////////////// 
        bool _F_Explan = USysInfo.LoginMode == 1;
        private void InitTree(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items)
        {
            TreeDateSource.Clear();
            foreach (V_S_Function item in items)
            {
                if (string.IsNullOrEmpty(item.FunPID))
                {
                    item.F_Explan = _F_Explan;
                    item.Children = GetTreeChildren(items, item.FunID);
                    TreeDateSource.Add(item);
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////// 
        private List<V_S_Function> GetTreeChildren(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items, string parentID)
        {
            List<V_S_Function> t = new List<V_S_Function>();
            foreach (V_S_Function item in items)
            {
                if (item.FunPID == parentID)
                {
                    item.F_Explan = _F_Explan;
                    item.Children = GetTreeChildren(items, item.FunID);
                    t.Add(item);
                }
            }
            return t;
        }
        /////////////////////////////////////////////////////////////////////////////// 
        private RelayCommand _CmdLogout;

        /// <summary>
        /// Gets the CmdLogout.
        /// </summary>
        public RelayCommand CmdLogout
        {
            get
            {
                return _CmdLogout
                    ?? (_CmdLogout = new RelayCommand(
                    () =>
                    {
                        MessageWindowErp c = new MessageWindowErp(ErpUIText.Get("LoginUserLogined_LogoutAsk"), MessageWindowErp.MessageType.Confirm);
                        c.Closed += (s1, e1) =>
                        {
                            if (c.DialogResult == true)
                                HtmlPage.Window.Eval("window.location.reload();");
                        };
                        c.Show();
                    }));
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand<V_S_Function> _CmdOpenFuns;

        /// <summary>
        /// Gets the CmdOpenFuns.
        /// </summary>
        public RelayCommand<V_S_Function> CmdOpenFuns
        {
            get
            {
                return _CmdOpenFuns
                    ?? (_CmdOpenFuns = new RelayCommand<V_S_Function>(
                    (obj) =>
                    {
                        if (obj.F_Open.Value)
                        {
                            ComOpenWins.Open(obj.FunID, obj.FunCode, obj.FunName);
                        }
                        else
                        {
                            try
                            {
                                obj.F_Explan = !obj.F_Explan;
                            }
                            catch { }
                        }
                    }));
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdUserInfo;

        /// <summary>
        /// Gets the CmdUserInfo.
        /// </summary>
        public RelayCommand CmdUserInfo
        {
            get
            {
                return _CmdUserInfo
                    ?? (_CmdUserInfo = new RelayCommand(
                    () =>
                    {
                        ComOpenWins.Open("", "LoginUserInfo", f_CheckRight: false);
                    }));
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdSysInfo;

        /// <summary>
        /// Gets the CmdSysInfo.
        /// </summary>
        public RelayCommand CmdSysInfo
        {
            get
            {
                return _CmdSysInfo
                    ?? (_CmdSysInfo = new RelayCommand(
                    () =>
                    {

                    }));
            }
        }
    }
}