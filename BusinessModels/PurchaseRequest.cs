using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        [ForeignKey("CompanyType")]
        public int CompanyTypeID
        {
            get;
            set;
        }

        [ForeignKey("Status")]
        public int? POStatus
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

        [ForeignKey("PurchaseRequestType")]
        public int? PurchaseRequestTypeID
        {
            get;
            set;
        }

        
        public string Comments
        {
            get;
            set;
        }

        
        public string CaseNo
        {
            get;
            set;
        }
        
        public string SQCode
        {
            get;
            set;
        }
        public string POCode
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
        public int? OriginatorID
        {
            get;
            set;
        }
        public int? VerifiedBy
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
        public int? ApprovedBy
        {
            get;
            set;
        }

        [ForeignKey("EnquiryLevel")]
        public int? EnquiryLevelID
        { get; set; }

        public bool IsActive
        { get; set; }
        

        public bool IsVerified
        { get; set; }
        public bool IsApproved
        { get; set; }


        public Location Location
        {
            get;
            set;
        }
        public EnquiryLevel EnquiryLevel
        {
            get;
            set;
        }
        public Status Status
        {
            get;
            set;
        }

        public CompanyType CompanyType
        {
            get;
            set;
        }

        public PurchaseRequestType PurchaseRequestType
        {
            get;
            set;
        }
        public Employee Employee
        {
            get;
            set;
        }

        public ICollection<PurchaseRequestDetails> PurchaseRequestDetails { get; set; }
    }
}