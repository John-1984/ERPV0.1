using System;

namespace BusinessModels
{
    public class ProductEnquiryDetails
    {
        public ProductEnquiryDetails()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }
        public int ProductEnquiryID
        {
            get;
            set;
        }
        public int itemID
        {
            get;
            set;
        }
        public int Quantitiy
        {
            get;
            set;
        }
        
        public string Size
        {
            get;
            set;
        }

        
        public decimal ItemPrice
        {
            get;
            set;
        }






    }
}