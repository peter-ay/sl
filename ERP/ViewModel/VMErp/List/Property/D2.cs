
using System;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _D2 = DateTime.Now.ToShortDateString();
        public string D2
        {
            get { return _D2; }
            set { _D2 = value; RaisePropertyChanged("D2"); }
        }
    }
}
