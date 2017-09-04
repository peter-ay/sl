
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private string _Title = "";
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_Title))
                {
                    _Title = ErpUIText.Get(this.VMNameAuthority + "_Title");
                }
                return _Title;
            }
            set
            {
                _Title = value;
                RaisePropertyChanged("Title");
            }
        }
    }
}
