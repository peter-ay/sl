
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.Common
{
    public class ComAssignWins
    {
        public static void Assign(string idCode, string fCode, string vName = "")
        {
            USysTemp.BillCodeMain = idCode;
            ComOpenWins.Open("", fCode, funName: vName, f_CheckRight: false);
            Messenger.Default.Send<string>(idCode, fCode + "_MsgIDChange");
        }
    }
}
