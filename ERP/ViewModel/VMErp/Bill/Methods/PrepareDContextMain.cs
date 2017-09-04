
using System.Reflection;
using System.ServiceModel.DomainServices.Client;
using System;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected virtual void PrepareDContextMain()
        {
            try
            {
                var dname = "V_" + this.ModelName;
                this.DContextMain = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.Entity." + dname) as Entity;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("[PrepareDContextMain]" + ex.Message);
            }
        }
    }
}
