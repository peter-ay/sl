using ERP.Utility;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
namespace ERP.Common
{
    public class ComWinFactory
    {
        public static Control GetInstance(string functionCode)
        {
            var myitem = USysControls.Items.Where(item => item.Name == functionCode).FirstOrDefault();
            if (myitem != null)
                return myitem as Control;
            try
            {
                Assembly assem = Assembly.GetExecutingAssembly();
                Control c = assem.CreateInstance("ERP.View." + functionCode.ToString()) as Control;
                c.Name = functionCode;
                USysControls.Items.Add(c);
                return c;
            }
            catch
            {
                return null;
            }
        }
    }
}
