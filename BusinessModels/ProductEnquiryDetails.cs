using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class ProductEnquiryDetails
    {
        public ProductEnquiryDetails()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        [ForeignKey("ProductEnquiry")]
        public int ProductEnquiryID
        {
            get;
            set;
        }

        [ForeignKey("ItemMaster")]
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
        
        public string Size
        {
            get;
            set;
        }
        
        public decimal ItemPrice
        {
            get;
            set;
        }

        public ProductEnquiry ProductEnquiry
        { get; set; }


        public ItemMaster ItemMaster
        { get; set; }

    }
}