
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MS_UserGroup
    {
        public string GpCode
        {
            get;
            set;
        }

        public bool F_RBSpCode
        {
            get;
            set;
        }

        public string GpName
        {
            get;
            set;
        }

        public string GpExplain
        {
            get;
            set;
        }

        public int GpID
        {
            get;
            set;
        }

        public string DBCode
        {
            get;
            set;
        }

        public bool F_RBCusCode
        {
            get;
            set;
        }

        public bool F_RBWhCode
        {
            get;
            set;
        }

        public bool F_RUWhCode
        {
            get;
            set;
        }

        public bool F_RBDpCode
        {
            get;
            set;
        }    
    }
}