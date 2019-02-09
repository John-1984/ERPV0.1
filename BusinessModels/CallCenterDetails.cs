using System;

namespace BusinessModels
{
    public class CallCenterDetails
    {
        public CallCenterDetails()
        {
           
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string Comments
        {
            get;
            set;
        }

        public decimal Time
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