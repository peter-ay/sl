
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_Extend
    {
        public string ID
        {
            get;
            set;
        }

        public int CYLL
        {
            get;
            set;
        }

        public int X_ADDR
        {
            get;
            set;
        }

        public int X_ADDL
        {
            get;
            set;
        }

        public int QtyR
        {
            get;
            set;
        }

        public int QtyL
        {
            get;
            set;
        }

        public decimal PriceR
        {
            get;
            set;
        }

        public decimal PriceL
        {
            get;
            set;
        }

        public decimal ProCostR
        {
            get;
            set;
        }

        public decimal ProCostL
        {
            get;
            set;
        }

        public string SCode
        {
            get;
            set;
        }

        public int SumQty
        {
            get;
            set;
        }

        public decimal SumMoney
        {
            get;
            set;
        }

        public string LensCodeR
        {
            get;
            set;
        }

        public string LensCodeL
        {
            get;
            set;
        }

        public int SPHR
        {
            get;
            set;
        }

        public int SPHL
        {
            get;
            set;
        }

        public int CYLR
        {
            get;
            set;
        }
    }
}