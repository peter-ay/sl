
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Threading;
namespace ERP.Common
{
    public class ComLanguageResourceManage
    {
        static CultureInfo currentCulture;
        public static CultureInfo CurrentCulture
        {
            get
            {
                if (currentCulture == null)
                {
                    try
                    {
                        IsolatedStorageSettings appSetting = IsolatedStorageSettings.ApplicationSettings;
                        if (appSetting.Contains("language"))
                        {
                            currentCulture = new CultureInfo((string)appSetting["language"]);
                        }
                    }
                    catch
                    {
                    }
                }
                if (currentCulture == null)
                {
                    currentCulture = new CultureInfo("zh-Hant");
                }
                return currentCulture;
            }
            set
            {
                currentCulture = value;
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentCulture;

                try
                {
                    IsolatedStorageSettings appSetting = IsolatedStorageSettings.ApplicationSettings;
                    if (appSetting.Contains("language"))
                    {
                        appSetting["language"] = currentCulture.Name;
                    }
                    else
                    {
                        appSetting.Add("language", currentCulture.Name);
                    }

                }
                catch
                {
                }
            }
        }
    }
}
