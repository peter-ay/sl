
using System.ServiceModel.DomainServices.Client;
using System.Collections;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private IEnumerable _DContextList;
        public IEnumerable DContextList
        {
            get { return _DContextList; }
            set
            {
                _DContextList = value;
                RaisePropertyChanged("DContextList");
            }
        }
    }
}
