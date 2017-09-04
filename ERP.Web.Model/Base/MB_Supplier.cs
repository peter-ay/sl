
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MB_Supplier
    {
        public string SpCode
        {
            get;
            set;
        }

        public bool F_Garages
        {
            get;
            set;
        }

        public bool F_Cutting_Type
        {
            get;
            set;
        }

        public bool F_Stock
        {
            get;
            set;
        }

        public bool F_Comprehensive
        {
            get;
            set;
        }

        public int Default_Priority
        {
            get;
            set;
        }

        public bool F_Stop
        {
            get;
            set;
        }

        public string BrowseRight
        {
            get;
            set;
        }

        public string SpName
        {
            get;
            set;
        }

        public string SpAddress
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Fax
        {
            get;
            set;
        }

        public string ContactPerson
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string AreaCode
        {
            get;
            set;
        }

        public bool F_Semifinished
        {
            get;
            set;
        }        
    }
}