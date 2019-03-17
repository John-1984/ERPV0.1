using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class PurchaseQuotationDetails
    {
        public PurchaseQuotationDetails()
        {
            Identity = -1;
            InvoiceNo = string.Empty;
            PaymentTypeID = 0;
            PaymentModeID = 0;
        }
        

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        public int PQID
        {
            get;
            set;
        }

        public string CheckNo
        { get; set; }

        public string InvoiceNo
        {
            get;
            set;
        }
        public Int32 PaymentTypeID
        {
            get;
            set;
        }
        public Int32 PaymentModeID
        {
            get;
            set;
        }

        public PaymentMode PaymentMode
        { get; set; }

        public PaymentType PaymentType
        { get; set; }

        
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
        public bool IsActive
        {
            get;
            set;
        }
        public PurchaseQuotation PurchaseQuotation
        { get; set; }
    }
}