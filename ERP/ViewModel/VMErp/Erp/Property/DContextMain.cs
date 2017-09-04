
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private Entity _DContextMain;
        public Entity DContextMain
        {
            get { return _DContextMain; }
            set
            {
                _DContextMain = value;
                RaisePropertyChanged("DContextMain");
            }
        }
    }
}
 