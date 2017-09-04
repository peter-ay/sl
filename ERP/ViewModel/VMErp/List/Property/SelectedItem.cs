
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _SelectedItem;
        public string SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");
                this.GridSelectedItemToStringChanged(value);
            }
        }
    }
}
