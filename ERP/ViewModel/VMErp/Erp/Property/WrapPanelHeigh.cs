
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private double wrapPanelHeigh = 0;
        public double WrapPanelHeigh
        {
            get { return wrapPanelHeigh; }
            set { wrapPanelHeigh = value; RaisePropertyChanged("WrapPanelHeigh"); }
        }
    }
}
