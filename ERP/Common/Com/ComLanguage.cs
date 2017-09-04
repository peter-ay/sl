
using System.Collections.ObjectModel;
namespace ERP.Common
{
    public class ComLanguage
    {
        static ObservableCollection<ComLanguage> _ll;
        public string LanguageName { get; set; }
        public string ImagePath { get; set; }
        public string CultureName { get; set; }

        public ComLanguage(string cultureName, string languageName, string imagePath)
        {
            this.CultureName = cultureName;
            this.LanguageName = languageName;
            this.ImagePath = imagePath;
        }

        public static ObservableCollection<ComLanguage> LanguageList
        {
            get
            {
                if (_ll == null)
                {
                    _ll = new ObservableCollection<ComLanguage>();
                    //_ll.Add(new ComLanguage("zh-Hans", "中文简体", "/ERP;component/Images/chs.png"));
                    //_ll.Add(new ComLanguage("zh-Hant", "中文繁體", "/ERP;component/Images/chs.png"));
                    //_ll.Add(new ComLanguage("en-US", "English", "/ERP;component/Images/eng.png"));
                    _ll.Add(new ComLanguage("zh-Hans", "chs|中文简体", ""));
                    _ll.Add(new ComLanguage("zh-Hant", "cht|中文繁體", ""));
                    _ll.Add(new ComLanguage("en-US", "eng|English", ""));
                }
                return _ll;
            }
        }

        public static int LanguageIndex
        {
            get
            {
                int i = 2;
                var crr = ComLanguageResourceManage.CurrentCulture;
                if (crr != null)
                {
                    switch (crr.Name)
                    {
                        case "en-US":
                            i = 3;
                            break;
                        case "zh-Hans":
                            i = 1;
                            break;
                        default:
                            i = 2;
                            break;
                    }
                }
                return i;
            }
        }
    }
}
