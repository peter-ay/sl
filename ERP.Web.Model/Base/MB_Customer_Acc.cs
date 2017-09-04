
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MB_Customer_Acc
    {
        public string AccCusCode
        {
            get;
            set;
        }

        public string AccCusName
        {
            get;
            set;
        }

        public int AccEndDate
        {
            get;
            set;
        }

        public decimal AccLimit
        {
            get;
            set;
        }

        public string PCode
        {
            get;
            set;
        }

    }
}