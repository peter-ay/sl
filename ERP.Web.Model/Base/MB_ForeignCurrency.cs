  
using System;
namespace ERP.Web.Model  
{	
	[Serializable]
	public class MB_ForeignCurrency
	{	
        public string ForeignCurrCode
        {
            get;
            set;
        }        
			
        public string ForeignCurrName
        {
            get;
            set;
        }        
			
        public bool ConvertFlag
        {
            get;
            set;
        }        
			
        public decimal Acc_Rate
        {
            get;
            set;
        }        
			
        public decimal Adjust_Rate
        {
            get;
            set;
        }        
			
        public int Decimal_Digtal
        {
            get;
            set;
        }        
			
        public bool StandardFlag
        {
            get;
            set;
        }        
		   
	}
}

