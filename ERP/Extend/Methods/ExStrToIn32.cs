using ERP.Utility;
using ERP.ViewModel;

namespace System
{
    public static class ExStrToInt32
    {
        public static int ToInt32FromStr(this String str)
        {
            var _rs = 0;
            try { _rs = Convert.ToInt32(str); }
            catch { _rs = 0; }
            return _rs;
        }
    }
}
