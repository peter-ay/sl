
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MPur_PriceContract_FrameSet
    {
        public string ID
        {
            get;
            set;
        }

        public string BID
        {
            get;
            set;
        }

        public string FrameCode
        {
            get;
            set;
        }

        public int FQty
        {
            get;
            set;
        }

        public string LensCode
        {
            get;
            set;
        }

        public int LQty
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal Price_ProCost
        {
            get;
            set;
        }

        public string InvTitle
        {
            get;
            set;
        }

    }
}