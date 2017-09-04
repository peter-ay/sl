
using System;
using System.Collections.Generic;
namespace ERP.Web.Model
{
    [Serializable]
    public class MWare_Bill
    {
        public string ID
        {
            get;
            set;
        }

        public string CusCode
        {
            get;
            set;
        }

        public string SpCode
        {
            get;
            set;
        }

        public string Remark
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

        public string BarCodeSOPre
        {
            get;
            set;
        }

        public string BarCodeR
        {
            get;
            set;
        }

        public string BarCodeL
        {
            get;
            set;
        }

        public string BCode
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

        public string FBCode
        {
            get;
            set;
        }

        public bool F_IO
        {
            get;
            set;
        }

        public string MType
        {
            get;
            set;
        }

        public bool F_SD
        {
            get;
            set;
        }

        public string WhCode
        {
            get;
            set;
        }

        public List<MWare_Bill_SD> Sub_SD
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

        public MWare_Bill_ADD Sub_ADD
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