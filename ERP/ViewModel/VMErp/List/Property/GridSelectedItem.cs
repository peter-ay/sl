
using System.ServiceModel.DomainServices.Client;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private Entity _gridselectedItem;
        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
        public Entity GridSelectedItem
        {
            get { return _gridselectedItem; }
            set
            {
                _gridselectedItem = value;
                this.InitSelectItem(_gridselectedItem);
                this.GridSelectedItemChanged(_gridselectedItem);
                RaisePropertyChanged("GridSelectedItem");
            }
        }

        protected virtual void GridSelectedItemChanged(Entity item)
        {

        }

        protected virtual void InitSelectItem(Entity item)
        {
            if (item == null) return;
            try
            {
                this.SelectedItem = item.GetType().GetProperty(this.IDCode).GetValue(item, null).ToString();
            }
            catch { }
        }
    }
}
