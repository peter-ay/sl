using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BSale_Order : BLLBase
    {
        public BSale_Order()
            : base(new DSale_Order())
        {
        }
    }
}
