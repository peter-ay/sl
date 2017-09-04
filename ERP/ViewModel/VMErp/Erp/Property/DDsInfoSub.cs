
using ERP.Common;
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private ComDDsInfo _DDsInfoSub;
        public ComDDsInfo DDsInfoSub
        {
            get { return _DDsInfoSub; }
            set { _DDsInfoSub = value; }
        }
    }
}
