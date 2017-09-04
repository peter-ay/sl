using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClick5;
        /// <summary>
        /// Gets the CmdGridListClick5.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClick5
        {
            get
            {
                return _CmdGridListClick5
                    ?? (_CmdGridListClick5 = new RelayCommand<Entity>(ExecuteCmdGridListClick5));
            }
        }

        private void ExecuteCmdGridListClick5(Entity parameter)
        {
            this.GridListClick5(parameter);
        }

        protected virtual void GridListClick5(Entity parameter)
        {
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
