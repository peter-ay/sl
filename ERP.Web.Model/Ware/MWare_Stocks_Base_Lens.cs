
using System;
using System.Collections.Generic;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Stocks_Base_Lens
    {
        public string ID
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

        public string StCode
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public int SumQty
        {
            get;
            set;
        }

        public bool F_Del
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

        public string BCode
        {
            get;
            set;
        }

        public DateTime DelDate
        {
            get;
            set;
        }

        public string WhCode
        {
            get;
            set;
        }

        public string LensCode
        {
            get;
            set;
        }

        public string F_LR
        {
            get;
            set;
        }

        public DateTime BDate
        {
            get;
            set;
        }

        public string BType
        {
            get;
            set;
        }

        public string Maker
        {
            get;
            set;
        }

        public string MName
        {
            get;
            set;
        }        

        public List<MWare_Stocks_Base_Lens_Detail> Sub_Detail
        {
            get;
            set;
        }
    }
}