
using System.Reflection;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private void CallKeyCodeEnter(string msg)
        {
            try
            {
                var cDX = this.DContextMain.GetType().GetProperty("EditState").GetValue(this.DContextMain, null).ToString();

                if (cDX != "1")
                    return;

                var keycode = msg.Replace("AC", "");

                this.GetType().InvokeMember("CallHelpWinDow" + keycode,
                           BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, this,
                           new object[] { });
            }
            catch { }
        }
    }
}
