using System;

namespace BusinessModels
{
    public class Discount
    {
        public Discount()
        {
          
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

       
        public decimal DiscountValue
        {
            get;
            set;
        }

        public int BrandID
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }


        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }


    }
}