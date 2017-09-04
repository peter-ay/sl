using System.ServiceModel.DomainServices.Client;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _AssignItemCheckClick;

        /// <summary>
        /// Gets the AssignItemCheck.
        /// </summary>
        public RelayCommand<Entity> AssignItemCheckClick
        {
            get
            {
                return _AssignItemCheckClick
                    ?? (_AssignItemCheckClick = new RelayCommand<Entity>(ExecuteAssignItemCheck));
            }
        }

        protected virtual void ExecuteAssignItemCheck(Entity parameter)
        {

        }
    }
}
