using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Mnumber_Technology
    {
        private readonly DBase_Mnumber_Technology dal = new DBase_Mnumber_Technology();
        public BBase_Mnumber_Technology()
        { }
        #region  ADD

        public string Add(MBase_Mnumber_Technology model)
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
