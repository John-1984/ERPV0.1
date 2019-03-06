using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class SalesQuotation
    {
        public SalesQuotation()
        {
            Identity = -1;
            SQCode = string.Empty;           
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        public int? CompanyTypeID
        { get; set; }
        public string SQCode
        {
            get;
            set;
        }

        public int? AssignedTo
        {
            get;
            set;
        }

        public int? EnquiryLevelID
        {
            get;
            set;
        }

        public int? ProductEnquiryID
        {
            get;
            set;
        }

        public int? LocationID
        {
            get;
            set;
        }

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

        public Employee Employee
        { get; set; }

        public EnquiryLevel EnquiryLevel
        { get; set; }

        public ProductEnquiry ProductEnquiry
        { get; set; }

        public Location Location
        { get; set; }

        public Status Status
        { get; set; }
        public CompanyType CompanyType
        { get; set; }

    }
}