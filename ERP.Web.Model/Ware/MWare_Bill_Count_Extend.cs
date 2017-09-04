
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_Count_Extend
    {
        public string ID
        {
            get;
            set;
        }

        public int SumQty1
        {
            get;
            set;
        }

        public int SumQty2
        {
            get;
            set;
        }

        public int SumQty
        {
            get;
            set;
        }

    }
}