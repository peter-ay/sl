
using System;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _D1 = DateTime.Now.ToShortDateString();
        public string D1
        {
            get { return _D1; }
            set { _D1 = value; RaisePropertyChanged("D1"); }
        }
    }
}
