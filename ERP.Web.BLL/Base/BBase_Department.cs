using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Department
    {
        private readonly DBase_Department dal = new DBase_Department();
        public BBase_Department()
        { }
        #region  ADD

        public string Add(MBase_Department model)
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
