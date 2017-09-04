
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_ADD
    {
        public string ID
        {
            get;
            set;
        }

        public string StCode
        {
            get;
            set;
        }

        public DateTime MDate
        {
            get;
            set;
        }

        public string Checker
        {
            get;
            set;
        }

        public string ChName
        {
            get;
            set;
        }

        public DateTime ChDate
        {
            get;
            set;
        }

        public string Deler
        {
            get;
            set;
        }

        public string DelName
        {
            get;
            set;
        }

        public DateTime DelDate
        {
            get;
            set;
        }

    }
}