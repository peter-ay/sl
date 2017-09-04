using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Mnumber_Focus
    {
        private readonly DBase_Mnumber_Focus dal = new DBase_Mnumber_Focus();
        public BBase_Mnumber_Focus()
        { }
        #region  ADD

        public string Add(MBase_Mnumber_Focus model)
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
