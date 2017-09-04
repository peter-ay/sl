
using ERP.Common;
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private ComDDsInfo _DDsInfoList;
        public ComDDsInfo DDsInfoList
        {
            get { return _DDsInfoList; }
            set { _DDsInfoList = value; }
        }
    }
}
