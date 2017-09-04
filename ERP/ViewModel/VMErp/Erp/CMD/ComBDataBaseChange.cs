using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand<Entity> _CmdComBDataBaseChange;

        /// <summary>
        /// Gets the CmdComBDataBaseChange.
        /// </summary>
        public RelayCommand<Entity> CmdComBDataBaseChange
        {
            get
            {
                return _CmdComBDataBaseChange
                    ?? (_CmdComBDataBaseChange = new RelayCommand<Entity>(ExecuteCmdComBDataBaseChange));
            }
        }

        protected virtual void ExecuteCmdComBDataBaseChange(Entity paramater)
        {

        }
    }
}
