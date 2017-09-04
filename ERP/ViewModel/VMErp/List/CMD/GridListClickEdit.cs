using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClickEdit;
        /// <summary>
        /// Gets the CmdGridListClickEdit.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClickEdit
        {
            get
            {
                return _CmdGridListClickEdit
                    ?? (_CmdGridListClickEdit = new RelayCommand<Entity>(ExecuteCmdGridListClickEdit));
            }
        }

        private void ExecuteCmdGridListClickEdit(Entity parameter)
        {
            this.GridListClickEdit(parameter);
        }

        protected virtual void GridListClickEdit(Entity parameter)
        {
            var _vmCode = this.VMName.Replace("_List", "");
            var _funCode = _vmCode.Substring(2)+"Edit";
            ComOpenWins.Open("", _funCode);
            string _ID = "";
            try
            {
                _ID = parameter.GetType().GetProperty("ID").GetValue(parameter, null).ToString();
            }
            catch { _ID = ""; }
            Messenger.Default.Send<string>((_ID), _vmCode + "_ShowFromList");
        }
    }
}
