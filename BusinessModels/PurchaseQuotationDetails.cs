using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseQuotationDetails
    {
        public PurchaseQuotationDetails()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
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
       

        [ForeignKey("PurchaseQuotation")]
        public int PQID
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


        public bool IsActive
        {
            get;
            set;
        }

       
        public PurchaseQuotation PurchaseQuotation
        { get; set; }

        [ForeignKey("PaymentType")]
        public Int32? PaymentTypeID
        {
            get;
            set;
        }
        [ForeignKey("PaymentMode")]
        public Int32? PaymentModeID
        {
            get;
            set;
        }

        public PaymentMode PaymentMode
        { get; set; }

        public PaymentType PaymentType
        { get; set; }

    }
}