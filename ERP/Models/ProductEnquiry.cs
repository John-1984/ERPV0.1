using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class ProductEnquiry
    {
        public ProductEnquiry()
        {
            Identity = -1;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }


        public int? CustomerID
        {
            get;
            set;
        }

        public int? EnquiryLevelID
        {
            get;
            set;
        }

        public int? StatusID
        {
            get;
            set;
        }

        public int? LocationId
        {
            get;
            set;
        }

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

        public int? ModifiedBy
        {
            get;
            set;
        }
        public int? OriginatorID
        {
            get;
            set;
        }
        public int? CreatedBy
        {
            get;
            set;
        }

        public SelectList ProdvctMasterList
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

        public Boolean IsActive
        { get; set; }

        public string Size
        {
            get;
            set;
        }

        public Boolean IsVerified
        { get; set; }

        public decimal ItemPrice
        {
            get;
            set;
        }

        public ICollection<ProductEnquiryDetails> ProductEnquiryDetails { get; set; }
        

        public SelectList ProductMasterList
        { get; set; }

        public SelectList VendorList
        { get; set; }

        public SelectList BrandList
        { get; set; }

        public SelectList ItemList
        { get; set; }

        public ItemMaster ItemMaster
        { get; set; }
    }
}