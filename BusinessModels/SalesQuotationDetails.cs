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

       
        public string InvoiceNo
        {
            get;
            set;
        }       
        public int WareHouseID
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

       
        public SalesQuotation SalesQuotation
        { get; set; }

        

    }
}