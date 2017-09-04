using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using System.Collections.Generic;

namespace ERP.Common
{
    public class ComSubGridColumnUpdate
    {
        public string GridName
        {
            get;
            set;
        }

        public ObservableCollection<Entity> Source
        {
            get;
            set;
        }
    }
}
