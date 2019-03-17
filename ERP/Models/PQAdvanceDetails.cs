using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class PQAdvanceDetails
    {
        public PQAdvanceDetails()
        {
            Identity = -1;
        }
        [Key]
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
    
