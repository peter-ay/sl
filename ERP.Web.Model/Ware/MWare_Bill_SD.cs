
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_SD
    {
        public string ID
        {
            get;
            set;
        }

        public string F_LR
        {
            get;
            set;
        }

        public string LensCode
        {
            get;
            set;
        }

        public int SPH
        {
            get;
            set;
        }

        public int CYL
        {
            get;
            set;
        }

        public int X_ADD
        {
            get;
            set;
        }

        public int Qty
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal ProCost
        {
            get;
            set;
        }
    }
}