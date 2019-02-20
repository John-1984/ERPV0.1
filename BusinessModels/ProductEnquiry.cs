using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class ProductEnquiry
    {
        public ProductEnquiry()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public String Comments
        {
            get;
            set;
        }

        public int CustomerInfoId
        {
            get;
            set;
        }

        public int EnquiryLevel
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }


        public int LocationId
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