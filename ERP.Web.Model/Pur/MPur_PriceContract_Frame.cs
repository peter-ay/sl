
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MPur_PriceContract_Frame
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

        public decimal Price
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