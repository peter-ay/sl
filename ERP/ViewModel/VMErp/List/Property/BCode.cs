
using System;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private string _BCode = "";
        public string BCode
        {
            get { return _BCode; }
            set { _BCode = value; RaisePropertyChanged("BCode"); }
        }

        private string _OBCode = "";
        public string OBCode
        {
            get { return _OBCode; }
            set { _OBCode = value; RaisePropertyChanged("OBCode"); }
        }
    }
}
