using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERP.Common
{
    public class ComLogin
    {
        public static Lazy<ObservableCollection<ComLogin>> _ll = new Lazy<ObservableCollection<ComLogin>>();

        public string LoginMode
        {
            get;
            set;
        }

        public ComLogin(string login)
        {
            this.LoginMode = login;
        }

        public static ObservableCollection<ComLogin> LoginList(List<string> list)
        {
            _ll.Value.Clear();
            list.ForEach(it=>{_ll.Value.Add(new ComLogin(it));});
            return _ll.Value;
        }
    }
}
