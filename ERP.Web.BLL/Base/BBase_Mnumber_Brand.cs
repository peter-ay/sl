using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Mnumber_Brand
    {
        private readonly DBase_Mnumber_Brand dal = new DBase_Mnumber_Brand();
        public BBase_Mnumber_Brand()
        { }
        #region  ADD

        public string Add(MBase_Mnumber_Brand model)
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
