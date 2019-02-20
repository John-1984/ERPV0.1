using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class SupplierQuotation
    {
        public SupplierQuotation()
        {
           
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        
        public string SOCOde
        {
            get;
            set;
        }

        public string InvoiceNo
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

        public int Priority
        {
            get;
            set;
        }
        public int locationId
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