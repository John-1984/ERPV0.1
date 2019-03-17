using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Identity = -1;
            POCode = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        public string CheckNo
        { get; set; }


        public int? CompanyTypeID
        { get; set; }
        public string POCode
        {
            get;
            set;
        }

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

        public int? PurchaseQuotationID
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

        
        public Decimal AdvanceAmount
        {
            get;
            set;
        }

        public Employee Employee
        { get; set; }

        public EnquiryLevel EnquiryLevel
        { get; set; }

        public PurchaseQuotation PurchaseQuotation
        { get; set; }

        public Location Location
        { get; set; }

        public Status Status
        { get; set; }
        public CompanyType CompanyType
        { get; set; }

        //public ICollection<PurchaseRequestDetails> PurchaseRequestDetails { get; set; }
        public Decimal TotalCost { get; set; }

        public SelectList EmployeeList
        { get; set; }
        public bool IsAssigned
        {
            get;
            set;
        }
        public bool IsWarehouseAssigned
        { get; set; }
        public string InvoiceNo
        {
            get;
            set;
        }
        public string CreatedDateString
        {
            get;
            set;
        }
        public int PaymentType
        {
            get;
            set;
        }

        public int PaymentMode
        {
            get;
            set;
        }
        public Decimal TotalAdvanceAmount
        {
            get;
            set;
        }

        //public bool IsPOGenerated
        //{
        //    get;
        //    set;
        //}

        public SelectList PaymentTypeList
        { get; set; }

        public SelectList PaymentModeList
        { get; set; }

        public SelectList LocationList
        { get; set; }

       

        public PurchaseQuotationDetails PurchaseQuotationDetails { get; set; }
        public ICollection<PQAdvanceDetails> PQAdvanceDetails { get; set; }
        public ICollection<PurchaseRequestDetails> PurchaseRequestDetails { get; set; }

        public SelectList ItemList
        { get; set; }
        public int Quantity
        {
            get;
            set;
        }

        public string size
        {
            get;
            set;
        }

        public decimal itemprice
        {
            get;
            set;
        }

        public ICollection<StockInExcessDetails> StockInExcessDetails { get; set; }
        public ICollection<StockInDamagedDetails> StockInDamagedDetails { get; set; }
        public ICollection<StockInShortageDetails> StockInShortageDetails { get; set; }

        public int TotalExcessItems
        {
            get;
            set;
        }

        public int TotalDamagedItems
        {
            get;
            set;
        }

        public int TotalShortageItems
        {
            get;
            set;
        }

    }
}