using System;
using System.Collections.Generic;
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

     
        [ForeignKey("Customer")]
        public int? CustomerID
        {
            get;
            set;
        }

        [ForeignKey("EnquiryLevel")]
        public int? EnquiryLevelID
        {
            get;
            set;
        }

        [ForeignKey("Status")]
        public int? StatusID
        {
            get;
            set;
        }

        [ForeignKey("Location")]
        public int? LocationId
        {
            get;
            set;
        }

        [ForeignKey("Employee")]
        public int? AssignedTo
        {
            get;
            set;
        }

        public int? VerifiedBy
        {
            get;
            set;
        }

        public int? ApprovedBy
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

        public int? OriginatorID
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

        
        public Location Location
        { get; set; }

        public Customer Customer
        { get; set; }

        public Status Status
        { get; set; }

        public EnquiryLevel EnquiryLevel
        { get; set; }

        public Employee Employee
        { get; set; }
        

        public Boolean IsActive
        { get; set; }

        public Boolean IsVerified
        { get; set; }

        public ICollection<ProductEnquiryDetails> ProductEnquiryDetails { get; set; }

    }
}