
using ERP.Common;
using ERP.Utility;
using System.Windows.Controls;
using System.Linq;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMLoginUserInfo : VMChildWindow
    {
        public VMLoginUserInfo()
        {
        }

        protected override void ViewOnLoad()
        {
            this.GetUserInfo();
        }

        public string UserCode
        {
            get
            {
                return USysInfo.UserCode;
            }
        }

        private string userName = "";
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        private string remark = "";
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
                RaisePropertyChanged("Remark");
            }
        }

        private string createDate = "";
        public string CreateDate
        {
            get
            {
                return createDate;
            }
            set
            {
                createDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }

        private void GetUserInfo()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, "GetV_S_UserQuery", dds_LoadedData);
            FilterDescriptor fd = new FilterDescriptor() { PropertyPath = "UserCode", Operator = FilterOperator.IsEqualTo, Value = USysInfo.UserCode };
            dds.FilterDescriptors.Add(fd);
            dds.Load();
        }

        void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            if (e.Entities.Count() == 0)
            {
                return;
            }

            var item = e.Entities.FirstOrDefault() as V_S_User;
            if (item == null) return;

            this.UserName = item.UserName;
            this.Remark = item.UserExplain;
            this.CreateDate = item.MakeDate.Value.ToShortDateString();
        }
        ///////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdUpdateCache;

        /// <summary>
        /// Gets the CmdUpdateCache.
        /// </summary>
        public RelayCommand CmdUpdateCache
        {
            get
            {
                return _CmdUpdateCache
                    ?? (_CmdUpdateCache = new RelayCommand(ExecuteCmdUpdateCache));
            }
        }

        private void ExecuteCmdUpdateCache()
        {
            ComHelp.Load();
            MessageErp.InfoMessage(ErpUIText.Get("ERP_UpdateSucceed"));
        }


    }
}