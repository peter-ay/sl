using System;
using System.IO.IsolatedStorage;

namespace ERP.Common
{
    public class ComUserLogiinInfoManage
    {
        static ComUserModel currentModel;
        public static ComUserModel CurrentModel
        {
            get
            {
                currentModel = currentModel ?? ComUserModel.GetInstance();
                try
                {
                    IsolatedStorageSettings appSetting = IsolatedStorageSettings.ApplicationSettings;
                    if (appSetting.Contains("ErpUser"))
                    {
                        currentModel.UserCode = appSetting["ErpUser"].ToString();
                    }
                    if (appSetting.Contains("ErpUserPassword"))
                    {
                        currentModel.Password = appSetting["ErpUserPassword"].ToString();
                    }
                    if (appSetting.Contains("ErpIsRemember"))
                    {
                        currentModel.IsRemember = Convert.ToBoolean(appSetting["ErpIsRemember"].ToString());
                    }
                }
                catch { }
                if (!currentModel.IsRemember)
                {
                    currentModel.UserCode = "";
                    currentModel.Password = "";
                }
                return currentModel;
            }
            set
            {
                try
                {
                    IsolatedStorageSettings appSetting = IsolatedStorageSettings.ApplicationSettings;
                    if (appSetting.Contains("ErpUser"))
                        appSetting["ErpUser"] = currentModel.UserCode;
                    else
                        appSetting.Add("ErpUser", currentModel.UserCode);

                    if (appSetting.Contains("ErpUserPassword"))
                        appSetting["ErpUserPassword"] = currentModel.Password;
                    else
                        appSetting.Add("ErpUserPassword", currentModel.Password);

                    if (appSetting.Contains("ErpIsRemember"))
                        appSetting["ErpIsRemember"] = currentModel.IsRemember;
                    else
                        appSetting.Add("ErpIsRemember", currentModel.IsRemember);
                }
                catch { }
            }
        }
    }
}
