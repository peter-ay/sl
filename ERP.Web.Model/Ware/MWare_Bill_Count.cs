
using System;
using System.Collections.Generic;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill_Count
    {
        public string ID
        {
            get;
            set;
        }

        public int KJYear
        {
            get;
            set;
        }

        public int Period
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

        public string Starter
        {
            get;
            set;
        }

        public string StartName
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public string Ender
        {
            get;
            set;
        }

        public string EndName
        {
            get;
            set;
        }

        public string BCode
        {
            get;
            set;
        }

        public DateTime EndTime
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

        public string WhCode
        {
            get;
            set;
        }

        public string FBCode
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

        public List<MWare_Bill_Count_PD_Detail1> Sub_PD_Detail1
        {
            get;
            set;
        }

        public List<MWare_Bill_Count_PD_Detail2> Sub_PD_Detail2
        {
            get;
            set;
        }

        public MWare_Bill_Count_Extend Sub_Extend
        {
            get;
            set;
        }

    }
}