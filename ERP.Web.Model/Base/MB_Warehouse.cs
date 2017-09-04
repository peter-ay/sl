
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MB_Warehouse
    {
        public string WhCode
        {
            get;
            set;
        }

        public string BrowseRight
        {
            get;
            set;
        }

        public string UseRight
        {
            get;
            set;
        }

        public string WhName
        {
            get;
            set;
        }

        public string WhAddress
        {
            get;
            set;
        }

        public string DpCode
        {
            get;
            set;
        }

        public string Tel
        {
            get;
            set;
        }

        public string ManageMan
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public int Priority
        {
            get;
            set;
        }

        public bool F_Stop
        {
            get;
            set;
        }

    }
}