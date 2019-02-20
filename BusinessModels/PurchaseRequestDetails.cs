using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseRequestDetails
    {
        public PurchaseRequestDetails()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string ItemSize
        {
            get;
            set;
        }

        public int PurchaseRequestID
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        
        public decimal ItemPrice
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