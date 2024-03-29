﻿
using System;
namespace ERP.Web.Model
{
    [Serializable]
    public class MPur_Quote
    {
        public string ID
        {
            get;
            set;
        }

        public string BType
        {
            get;
            set;
        }

        public string SpCode
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

        public string BCodePC
        {
            get;
            set;
        }        

        public MPur_Quote_SD Sub_SD
        {
            get;
            set;
        }

        public MPur_Quote_SD_Process Sub_SD_Process
        {
            get;
            set;
        }
    }
}