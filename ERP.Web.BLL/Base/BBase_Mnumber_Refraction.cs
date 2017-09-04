using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Mnumber_Refraction
    {
        private readonly DBase_Mnumber_Refraction dal = new DBase_Mnumber_Refraction();
        public BBase_Mnumber_Refraction()
        { }
        #region  ADD

        public string Add(MBase_Mnumber_Refraction model)
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
