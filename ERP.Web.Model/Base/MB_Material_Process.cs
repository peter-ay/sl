
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MB_Material_Process
    {
        public string ProCode
        {
            get;
            set;
        }

        public string ProName
        {
            get;
            set;
        }

        public string ProClass
        {
            get;
            set;
        }

        public bool F_RX
        {
            get;
            set;
        }

        public bool F_ST
        {
            get;
            set;
        }

    }
}