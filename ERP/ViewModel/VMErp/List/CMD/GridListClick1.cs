using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClick1;
        /// <summary>
        /// Gets the CmdGridListClick1.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClick1
        {
            get
            {
                return _CmdGridListClick1
                    ?? (_CmdGridListClick1 = new RelayCommand<Entity>(ExecuteCmdGridListClick1));
            }
        }

        private void ExecuteCmdGridListClick1(Entity parameter)
        {
            this.GridListClick1(parameter);
        }

        protected virtual void GridListClick1(Entity parameter)
        {
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
