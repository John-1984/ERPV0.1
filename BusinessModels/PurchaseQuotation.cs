using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseQuotation
    {
        public PurchaseQuotation()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string PQCode
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

        [ForeignKey("EnquiryLevel")]
        public int? EnquiryLevelID
        {
            get;
            set;
        }

        [ForeignKey("PurchaseRequest")]
        public int? PurchaseRequestID
        {
            get;
            set;
        }

        [ForeignKey("Location")]
        public int? LocationID
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

        public int? OriginatorID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsApproved
        {
            get;
            set;
        }

        public bool IsPOGenerated
        {
            get;
            set;
        }

        public bool IsAssigned
        {
            get;
            set;
        }

        [ForeignKey("CompanyType")]
        public int? CompanyTypeID
        { get; set; }
        public Employee Employee
        { get; set; }

        public EnquiryLevel EnquiryLevel
        { get; set; }

        public PurchaseRequest PurchaseRequest
        { get; set; }

        public Location Location
        { get; set; }

        public Status Status
        { get; set; }
        public CompanyType CompanyType
        { get; set; }


    }
}