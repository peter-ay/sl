
using System.Collections.Generic;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private List<string> _GridListSelectedCodes = new List<string>();

        public List<string> GridListSelectedCodes
        {
            get { return _GridListSelectedCodes; }
            set { _GridListSelectedCodes = value; }
        }
    }
}
