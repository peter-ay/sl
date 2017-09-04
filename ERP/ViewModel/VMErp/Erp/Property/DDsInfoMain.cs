
using ERP.Common;
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private ComDDsInfo _DDsInfoMain;
        public ComDDsInfo DDsInfoMain
        {
            get { return _DDsInfoMain; }
            set { _DDsInfoMain = value; }
        }
    }
}
