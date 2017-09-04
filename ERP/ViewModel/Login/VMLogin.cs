
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Browser;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.Entity;
namespace ERP.ViewModel
{
    public class VMLogin : VMErpSimple
    {
        public VMLogin()
        {
        }

        protected override void ViewOnLoad()
        {
            ERP.View.LoginUserLogin u = new View.LoginUserLogin();
            u.Closed += (s1, e1) =>
                {
                    if (u.DialogResult != true) return;
                    this.PrepareLogin();
                };
            u.Show();
        }

        private void PrepareLogin()
        {
            switch (USysInfo.LoginMode)
            {
                case 0://普通登录
                    this.Login0();
                    break;

                case 1://後臺登陸
                    this.Login1();
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// /////////////后台
        /// </summary>
        private void Login1()
        {
            USysInfo.DBCode = "HKOERP";
            USysInfo.DBName = ErpUIText.Get("ERP_DBName");
            USysFlag.IsLogin2 = true;
        }
        /// <summary>
        /// /////////////普通登陆//////////
        /// </summary>
        private void Login0()
        {
            var ddsInfo = new ComDDsInfo()
            {
                Domaincontext = ComDSFactory.Man,
                QueryName = UDSMethods.V_S_User_GroupDataBaseBill,
                PageSize = 0
            };
            ddsInfo.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
            var dds = ComDDSFactory.Get(ddsInfo, null, dds_LoadedData);
            this.IsBusy = true;
            dds.Load();
        }

        private void dds_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            var items = geted.Entities;
            if (items.Count() == 0)
            {
                MessageWindowErp u = new MessageWindowErp(USysInfo.UserCode + ErpUIText.Get("ERP_Err_NotDataBase"), MessageWindowErp.MessageType.Error);
                u.Closed += (s1, e1) =>
                {
                    HtmlPage.Window.Eval("window.location.reload();");
                    return;
                };
                u.Show();
            }

            if (geted.Entities.Count() == 1)
            {
                var item = geted.Entities.First() as V_S_User_GroupDataBase;
                this.InitUserInfo(item);
                return;
            }
            ////////////////////////////////////
            if (items.Count() > 1)
            {
                List<string> lists = new List<string>();
                foreach (V_S_User_GroupDataBase item in items)
                {
                    lists.Add(item.DBName.UIStr());
                }
                String[] comboOptions = lists.ToArray();

                MessageWindowErp cmw = new MessageWindowErp(ErpUIText.Get("ERP_SelectDataBase"),
                                                                 MessageWindowErp.MessageType.ComboInput,
                                                                 comboOptions);
                cmw.Btn_OK.Click += (obj, args) =>
                {
                    if (cmw.InputComboBox.SelectedIndex != -1)
                    {
                        var name = cmw.InputComboBox.SelectedItem.ToString();
                        foreach (V_S_User_GroupDataBase item in items)
                        {
                            if (item.DBName.UIStr() == name)
                            {
                                this.InitUserInfo(item);
                                break;
                            }
                        }
                    }
                };
                cmw.Show();
            }
        }

        private void InitUserInfo(V_S_User_GroupDataBase item)
        {
            USysInfo.DBCode = item.DBCode;
            USysInfo.DBName = item.DBName.UIStr();
            USysInfo.GpID = item.GpID;
            USysInfo.GroupCode = item.GpCode;
            USysInfo.GroupName = item.GpName.UIStr();
            USysInfo.F_CusCodeBrowse = item.F_RBCusCode ?? false;
            USysInfo.F_WhCodeBrowse = item.F_RBWhCode ?? false;
            USysInfo.F_WhCodeUse = item.F_RUWhCode ?? false;
            USysFlag.IsLogin1 = true;
        }
    }
}