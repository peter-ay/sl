using System;
using System.Collections.Generic;
namespace ERP.Web.Model
{
    [Serializable]
    public class MSale_Order
    {
        public string ID
        {
            get;
            set;
        }

        public bool F_SD
        {
            get;
            set;
        }

        public bool F_FS
        {
            get;
            set;
        }
         
        public string CusCode
        {
            get;
            set;
        }

        public int OGType
        {
            get;
            set;
        }

        public string WhCode
        {
            get;
            set;
        }

        public string SpCode
        {
            get;
            set;
        }

        public string DpCodeWG
        {
            get;
            set;
        }

        public string BCode
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public decimal Freight
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
         
        public DateTime BDate
        {
            get;
            set;
        }

        public string BarCodePre
        {
            get;
            set;
        }

        public string OBCode
        {
            get;
            set;
        }

        public string FBCode
        {
            get;
            set;
        }

        public int UD
        {
            get;
            set;
        }

        public DateTime CsDate
        {
            get;
            set;
        }

        public string BType
        {
            get;
            set;
        }

        public string MType
        {
            get;
            set;
        }

        public List<MSale_Order_SD> Sub_SD
        {
            get;
            set;
        }

        public MSale_Order_SD_Process Sub_SD_Process
        {
            get;
            set;
        }

        public MSale_Order_PD Sub_PD
        {
            get;
            set;
        }

        public List<MSale_Order_PD_Detail> Sub_PD_Detail
        {
            get;
            set;
        }

        public List<MSale_Order_FD_Detail> Sub_FD_Detail
        {
            get;
            set;
        }

        public MSale_Order_ADD Sub_ADD
        {
            get;
            set;
        }

        public MSale_Order_Extend Sub_Extend
        {
            get;
            set;
        }
    }
}

