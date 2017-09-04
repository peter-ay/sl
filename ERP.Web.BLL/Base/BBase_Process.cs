using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Process
    {
        private readonly DBase_Process dal = new DBase_Process();
        public BBase_Process()
        { }
        #region  ADD

        public string Add(MBase_Process model)
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
