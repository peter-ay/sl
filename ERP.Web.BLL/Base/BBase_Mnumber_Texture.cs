using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BBase_Mnumber_Texture
    {
        private readonly DBase_Mnumber_Texture dal = new DBase_Mnumber_Texture();
        public BBase_Mnumber_Texture()
        { }
        #region  ADD

        public string Add(MBase_Mnumber_Texture model)
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
