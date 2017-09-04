using ERP.Utility;
using ERP.ViewModel;

namespace System
{
    public static class ExHanldeErrMsg
    {
        public static String GetErrMsg(this String errmsg)
        {
            var str = errmsg.ToDBC();
            str = ErpUIText.ErrMsg + str.Substring(str.IndexOf('.') + 1);
            return str.Trim();
        }
    }
}
