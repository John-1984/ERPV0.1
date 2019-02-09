using System;

namespace BusinessModels
{
    public class LocalSupplier
    {
        public LocalSupplier()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string SupplierName
        {
            get;
            set;
        }
        
        public string Email
        {
            get;
            set;
        }

        
        public string Address
        {
            get;
            set;
        }

        public int ContactNumber
        {
            get;
            set;
        }

        public int LocationID
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