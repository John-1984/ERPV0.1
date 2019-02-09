using System;

namespace BusinessModels
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        public int WarehouseId
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }

        public int PurchaseRequestType
        {
            get;
            set;
        }

        
        public string Comments
        {
            get;
            set;
        }

        
        public string CaseNo
        {
            get;
            set;
        }
        
        public string SOCode
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
    }
}