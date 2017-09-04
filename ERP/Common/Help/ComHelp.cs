
using ERP.Utility;
namespace ERP.Common
{
    public class ComHelp
    {
        public static void Load()
        {
            ComHelpDBCode.Load();
            ComHelpGpCode.Load();

            if (USysInfo.LoginMode == 0)
            {
                ComHelpCusCode.Load();
                ComHelpSale_Base_Note.Load();
                ComHelpLensCode.Load();
                ComHelpProCode.Load();
                ComHelpDpCode.Load();
                ComHelpAreaCode.Load();
                ComHelpPersonCode.Load();
                ComHelpSpCode.Load();
                ComHelpWhCode.Load();
                ComHelpLensClass.Load();
                ComHelpFrameCode.Load();
                ComHelpCusGroup.Load();
                ComHelpSpGroup.Load();
            }
        }
    }
}
