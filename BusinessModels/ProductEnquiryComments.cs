using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class ProductEnquiryComments
    {
        public ProductEnquiryComments()
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
       
        
        public string Comments
        {
            get;
            set;
        }
        
       

        public ProductEnquiry ProductEnquiry
        { get; set; }

    }
}