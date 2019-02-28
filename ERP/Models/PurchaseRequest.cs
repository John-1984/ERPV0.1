using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            Identity = -1;
            //Comments = string.Empty;
            //CaseNo = string.Empty;
            //SQCode = String.Empty;
            //POCode = String.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        public int CompanyTypeID
        {
            get;
            set;
        }

        public int? POStatus
        {
            get;
            set;
        }

        public int? LocationID
        {
            get;
            set;
        }

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

        public int? EnquiryLevelID
        { get; set; }
        public bool IsActive
        { get; set; }

        public bool IsVerified
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

        public SelectList ProductMasterList
        { get; set; }

        public SelectList VendorList
        { get; set; }

        public SelectList BrandList
        { get; set; }

        public SelectList ItemList
        { get; set; }

        public SelectList EnquiryLevelList
        { get; set; }

        public SelectList PurchaseRequestTypeList
        { get; set; }
        public bool IsApproved
        { get; set; }
        public virtual ICollection<PurchaseRequestDetails> PurchaseRequestDetails { get; set; }
    }
}