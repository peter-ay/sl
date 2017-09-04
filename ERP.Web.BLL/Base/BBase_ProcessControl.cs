using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_ProcessControl
    {
        private readonly DBase_ProcessControl dal = new DBase_ProcessControl();
        public BBase_ProcessControl()
        { }
        #region  ADD

        public string Add(MBase_ProcessControl model)
        {
            return dal.Add(model);
        }

        public void Delete(string code)
        {
            dal.Delete(code);
        }
         
        #endregion  ADD
    }
}
