using System;

namespace BusinessModels
{
    public class CallCenter
    {
        public CallCenter()
        {
           
        }

       
        public Int32 Identity
        {
            get;
            set;
        }

       
        public int CustomerID
        {
            get;
            set;
        }

        public int ProductEnquriyID
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public int AssignedTo
        {
            get;
            set;
        }
        public int VerifiedBy
        {
            get;
            set;
        }
        public int ApprovedBy
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