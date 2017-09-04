using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;

namespace ERP.Common
{
    public class ComOpenWins
    {
        public static void Open(string functionID, string FunCode, string funName = "", string extend = "", bool f_CheckRight = true)
        {
            if (string.IsNullOrEmpty(funName))
                try
                {
                    funName = URight.Rights.Where(it => it.FunCode == FunCode).FirstOrDefault().FunName;
                }
                catch { }

            if (string.IsNullOrEmpty(funName))
                funName = ErpUIText.Get(FunCode);

            ComWinsInfo.FunID = functionID;
            ComWinsInfo.FunCode = FunCode;
            ComWinsInfo.FunName = funName.UIStr();
            ComWinsInfo.Extend = extend;
            ComWinsInfo.F_CheckRight = f_CheckRight;
            Messenger.Default.Send<string>((""), USysMessages.AddTab);
        }
    }
}
