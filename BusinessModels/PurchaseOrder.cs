using System;


namespace BusinessModels
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
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
        
        public string POCode
        {
            get;
            set;
        }
        public int SupplierQuotationID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public int WarehouseID
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