
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private ObservableCollection<Entity> _DContextSub;
        public ObservableCollection<Entity> DContextSub
        {
            get
            {
                return _DContextSub;
            }
            set
            {
                _DContextSub = value;
                RaisePropertyChanged("DContextSub");
            }
        }
    }
}
 