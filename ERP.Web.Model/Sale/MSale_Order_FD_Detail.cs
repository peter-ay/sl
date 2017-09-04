
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MSale_Order_FD_Detail
    {
        public string ID
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string DeliveryName
        {
            get;
            set;
        }

        public int SubID
        {
            get;
            set;
        }

        public string FrameCode
        {
            get;
            set;
        }

        public int Qty
        {
            get;
            set;
        }

        public int QtyPur
        {
            get;
            set;
        }

        public int QtyRec
        {
            get;
            set;
        }

        public int QtySO
        {
            get;
            set;
        }

        public int QtyCs
        {
            get;
            set;
        }

        public int QtyRt
        {
            get;
            set;
        }        
    }
}

