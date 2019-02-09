using System;

namespace BusinessModels
{
    public class PurchaseRequestType
    {
        public PurchaseRequestType()
        {
            Identity = -1;
            Name = string.Empty;
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string Name
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