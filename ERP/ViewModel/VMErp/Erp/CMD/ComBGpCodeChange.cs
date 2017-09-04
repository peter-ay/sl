using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand<Entity> _CmdComBGpCodeChange;

        /// <summary>
        /// Gets the CmdComBGroupChange.
        /// </summary>
        public RelayCommand<Entity> CmdComBGpCodeChange
        {
            get
            {
                return _CmdComBGpCodeChange
                    ?? (_CmdComBGpCodeChange = new RelayCommand<Entity>(ExecuteCmdComBGpCodeChange));
            }
        }

        protected virtual void ExecuteCmdComBGpCodeChange(Entity paramater)
        {

        }
    }
}
