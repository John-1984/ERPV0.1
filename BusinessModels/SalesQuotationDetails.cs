using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class SalesQuotationDetails
    {
        public SalesQuotationDetails()
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
       

        [ForeignKey("SalesQuotation")]
        public int SQID
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

       
        public SalesQuotation SalesQuotation
        { get; set; }

        [ForeignKey("PaymentType")]
        public Int32 PaymentTypeID
        {
            get;
            set;
        }
        [ForeignKey("PaymentMode")]
        public Int32 PaymentModeID
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