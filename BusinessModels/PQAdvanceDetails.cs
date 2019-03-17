using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PQAdvanceDetails
    {
        public PQAdvanceDetails()
        {                  
        }
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }
        public Decimal Amount
        {
            get;
            set;
        }
        public string CheckNo
        { get; set; }

        [ForeignKey("PurchaseQuotation")]
        public Int32? PQID
        {
            get;
            set;
        }
        public DateTime? CreatedDate
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public int? CreatedBy
        {
            get;
            set;
        }  
        
        public PurchaseQuotation PurchaseQuotation
        { get; set; }

    }
}
    
