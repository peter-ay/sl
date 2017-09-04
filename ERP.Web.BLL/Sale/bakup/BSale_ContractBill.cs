using ERP.Web.DAL;

namespace ERP.Web.BLL
{
    public partial class BSale_ContractBill : BLLBase
    {
        private readonly DSale_ContractBill dal = new DSale_ContractBill();
        public BSale_ContractBill()
        {
            this.Dal = dal;
        }

        #region  ADD
        #endregion  ADD
    }
}
