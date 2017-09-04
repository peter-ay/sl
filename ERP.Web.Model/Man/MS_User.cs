
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MS_User
    {
        public string UserCode
        {
            get;
            set;
        }

        public DateTime LoginDate
        {
            get;
            set;
        }

        public string UserImage
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string UserExplain
        {
            get;
            set;
        }

        public string UserPassword
        {
            get;
            set;
        }

        public string UserRight
        {
            get;
            set;
        }

        public DateTime MakeDate
        {
            get;
            set;
        }

        public bool F_Admin
        {
            get;
            set;
        }

        public bool F_Stop
        {
            get;
            set;
        }

        public DateTime LastLoginDate
        {
            get;
            set;
        }

    }
}