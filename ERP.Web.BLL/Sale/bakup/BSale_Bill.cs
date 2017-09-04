using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BSale_Bill : BLLBase
    {
        private readonly DSale_Bill _dal = new DSale_Bill();
        public BSale_Bill()
        {
            this.Dal = _dal;
        }

        protected override bool VerifyModel<T>(T t)
        { 
            MSale_Bill _md = t as MSale_Bill;
            
            //var t =


            return true;
        }

        #region  ADD
        #endregion  ADD
    }
}
