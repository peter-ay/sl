
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MS_Log
    {
        public string ID
        {
            get;
            set;
        }

        public DateTime LogTime
        {
            get;
            set;
        }

        public string UserCode
        {
            get;
            set;
        }

        public string DBCode
        {
            get;
            set;
        }

        public string FunCode
        {
            get;
            set;
        }

        public string IP
        {
            get;
            set;
        }

        public string ClientID
        {
            get;
            set;
        }
    }
}