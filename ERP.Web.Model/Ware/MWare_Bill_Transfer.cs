
using System;
using System.Collections.Generic;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_Transfer
    {
        public string ID
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

        public DateTime MDate
        {
            get;
            set;
        }

        public bool F_Chk
        {
            get;
            set;
        }

        public string CheckerIn
        {
            get;
            set;
        }

        public string ChNameIn
        {
            get;
            set;
        }

        public DateTime ChDateIn
        {
            get;
            set;
        }

        public string CheckerOut
        {
            get;
            set;
        }

        public string ChNameOut
        {
            get;
            set;
        }

        public DateTime ChDateOut
        {
            get;
            set;
        }

        public string BCode
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

        public DateTime DelDate
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

        public string MType
        {
            get;
            set;
        }

        public string StCode
        {
            get;
            set;
        }

        public string WhCodeIn
        {
            get;
            set;
        }

        public string WhCodeOut
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public MWare_Bill_PD Sub_PD
        {
            get;
            set;
        }

        public List<MWare_Bill_PD_Detail> Sub_PD_Detail
        {
            get;
            set;
        }

        public MWare_Bill_Extend Sub_Extend
        {
            get;
            set;
        }

    }
}