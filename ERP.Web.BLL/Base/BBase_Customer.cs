using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Customer
    {
        private readonly DBase_Customer dal = new DBase_Customer();
        public BBase_Customer()
        { }
        #region  ADD

        public string Add(MBase_Customer model)
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
