using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public class VMLoginUserLogin : VMChildWindow
    {
        #region SourceMain

        public ObservableCollection<ComLanguage> LanguageList { get; private set; }
        public ObservableCollection<ComLogin> LoginList { get; private set; }

        private ComLanguage _LanguageSelected;
        /// <summary>
        /// /////////////
        /// </summary>
        public ComLanguage LanguageSelected
        {
            get { return _LanguageSelected; }
            set { _LanguageSelected = value; }
        }

        private int _LanguageIndex = 0;
        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        public int LanguageIndex
        {
            get { return _LanguageIndex; }
            set
            {
                _LanguageIndex = value;
                RaisePropertyChanged("LanguageIndex");
            }
        }

        private int _LoginIndex = 0;
        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        public int LoginIndex
        {
            get { return _LoginIndex; }
            set
            {
                _LoginIndex = value;
                RaisePropertyChanged("LoginIndex");
            }
        }


        private ComUserModel _DSource;
        /// <summary>
        /// ////////////////////////////////
        /// </summary>
        public ComUserModel DSource
        {
            get { return _DSource; }
            set
            {
                _DSource = value;
                RaisePropertyChanged<ComUserModel>(() => this.DSource);
            }
        }


        #endregion

        public VMLoginUserLogin()
        {
            this.InitLanguageList();
            this.InitLoginList();
            _DSource = ComUserLogiinInfoManage.CurrentModel;
        }

        private void InitLoginList()
        {
            List<string> _li = new List<string>();
            _li.Add(ERP.Resource.Languages.ResourceManager.GetString("ComLogin1"));
            _li.Add(ERP.Resource.Languages.ResourceManager.GetString("ComLogin2"));
            LoginList = ComLogin.LoginList(_li);
            this.LoginIndex = 0;
        }

        private void InitLanguageList()
        {
            LanguageList = ComLanguage.LanguageList;
            this.LanguageIndex = ComLanguage.LanguageIndex - 1;
        }

        #region Methods

        private RelayCommand _ChangLanguage;

        /// <summary>
        /// Gets the ChangLanguage.
        /// </summary>
        public RelayCommand RcdChangLanguage
        {
            get
            {
                return _ChangLanguage
                    ?? (_ChangLanguage = new RelayCommand(ExecuteChangLanguage));
            }
        }

        private void ExecuteChangLanguage()
        {
            ComLanguageResourceManage.CurrentCulture = new System.Globalization.CultureInfo(LanguageSelected.CultureName);
            this.UIText.ChangeLanguage();
            this.InitLoginList();
        }

        /////////////////////////////////////////////////
        protected override void OK()
        {
            this.VerifyUser();
        }
        ////////////////////////////////////////////////
        protected override bool CanExecuteCmdOK()
        {
            if (string.IsNullOrEmpty(DSource.UserCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("LoginUserLogin_Err_UserEmpty"));
                return false;
            }
            return true;
        }
        /// <summary>
        /// //////////////////验证用户
        /// </summary>
        /// <returns></returns>
        /// 
        private void VerifyUser()
        {
            this.DDsInfoMain = new ComDDsInfo()
            {
                Domaincontext = ComDSFactory.Man,
                QueryName = UDSMethods.V_S_UserBill
            };
            DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = DSource.UserCode.MyStr() });
            var dds = ComDDSFactory.Get(DDsInfoMain, null, dds_LoadedData);
            this.IsBusy = true;
            dds.Load();
        }

        private void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            this.IsBusy = false;
            if (e.HasError)
            {
                MessageErp.ErrorMessage(e.Error.Message.GetErrMsg());
                e.MarkErrorAsHandled();
                return;
            }

            if (e.TotalEntityCount <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("LoginUserLogin_Err_UserNone") + DSource.UserCode);
                return;
            }

            var it = e.Entities.FirstOrDefault();
            var pw = it.GetType().GetProperty("UserPassword").GetValue(it, null).ToString();

            if (ComPassword.Get(DSource.Password) != pw)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("LoginUserLogin_Err_Password"));
                return;
            }

            bool f_stop = false;
            try
            {
                f_stop = Convert.ToBoolean(it.GetType().GetProperty("F_Stop").GetValue(it, null).ToString());
            }
            catch { f_stop = false; }
            if (f_stop)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("LoginUserLogin_Err_UserStop"));
                return;
            }


            if (LoginIndex == 1)
            {
                var man = it.GetType().GetProperty("F_Admin").GetValue(it, null).ToString();
                var mf = false;
                try
                {
                    mf = Convert.ToBoolean(man);
                }
                catch { mf = false; }

                if (!mf)
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("LoginUserLogin_Err_NotManager"));
                    return;
                }
            }

            ComUserLogiinInfoManage.CurrentModel = DSource;
            USysInfo.UserCode = DSource.UserCode;
            USysInfo.UserName = it.GetType().GetProperty("UserName").GetValue(it, null).ToString();

            try
            {
                USysInfo.F_Manager = Convert.ToBoolean(it.GetType().GetProperty("F_Admin").GetValue(it, null).ToString());
            }
            catch { USysInfo.F_Manager = false; }

            USysInfo.LoginMode = LoginIndex;
            USysInfo.LgIndex = LanguageIndex+1;
            Messenger.Default.Send<bool>(true, this.VMName.Substring(2) + "_Result");
        }
        ///////////////////////////
        /// <summary>
        /// ////////////////////////屏蔽Esc
        /// </summary>
        /// <returns></returns>
        protected override bool CanExecuteCmdCancel()
        {
            return false;
        }
        /////////////////////////////
        #endregion
    }
}