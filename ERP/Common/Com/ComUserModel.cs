using System.ComponentModel;

namespace ERP.Common
{
    public class ComUserModel : INotifyPropertyChanged
    {
        private static ComUserModel _Ins=null;

        private ComUserModel() { }

        public static ComUserModel GetInstance()
        {
            return _Ins ?? new ComUserModel();
        }

        private string _userCode = "";
        public string UserCode
        {
            get
            {
                return _userCode;
            }

            set
            {
                //_userCode = value.ToUpper().Trim();
                _userCode = value;
                NotifyPropertyChanged("UserCode");
            }
        }

        private string _password = "";
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private bool isRemember = true;
        public bool IsRemember
        {
            get
            {
                return isRemember;
            }

            set
            {
                isRemember = value;
                NotifyPropertyChanged("IsRemember");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
