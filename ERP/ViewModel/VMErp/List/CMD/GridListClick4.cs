using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClick4;
        /// <summary>
        /// Gets the CmdGridListClick4.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClick4
        {
            get
            {
                return _CmdGridListClick4
                    ?? (_CmdGridListClick4 = new RelayCommand<Entity>(ExecuteCmdGridListClick4));
            }
        }

        private void ExecuteCmdGridListClick4(Entity parameter)
        {
            this.GridListClick4(parameter);
        }

        protected virtual void GridListClick4(Entity parameter)
        {
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
