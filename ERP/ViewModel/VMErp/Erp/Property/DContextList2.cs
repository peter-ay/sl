
using System.ServiceModel.DomainServices.Client;
using System.Collections;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private IEnumerable _DContextList2;
        public IEnumerable DContextList2
        {
            get { return _DContextList2; }
            set
            {
                _DContextList2 = value;
                RaisePropertyChanged("DContextList2");
            }
        }
    }
}
