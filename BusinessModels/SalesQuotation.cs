using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class SalesQuotation
    {
        public SalesQuotation()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string SOCode
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
        public int priority
        {
            get;
            set;
        }
        
        public string Comments
        {
            get;
            set;
        }
        
        public string InvoiceNo
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public int LocationID
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