using System;
using System.Collections.Generic;
using System.Runtime;
using System.Web.Mvc;

namespace ERP.Models.Workflow
{
    public class Workflow
    {
        public Workflow()
        {
            Identity = -1;
            Description = string.Empty;
            Name = string.Empty;
            CreatedDate = string.Empty;
           // CreatedBy = string.Empty;
           SQCode = string.Empty;

            StatusName = string.Empty;
         EnquiryLevelName = string.Empty;
        SQCreatedDate = string.Empty;
        InvoiceNo = string.Empty;
        PaymerMode = string.Empty;
            CheckNo = string.Empty;
        }

        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int LocationID { get; set; }
        public int CompanyTypeID { get; set; }
        public int CompanyID { get; set; }
        public int ItemType { get; set; }

        public Employee Employee
        { get; set; }


        public Location Location
        { get; set; }

        public CompanyType CompanyType
        { get; set; }

        public Company Company
        { get; set; }

        public Menu Menu
        { get; set; }

        public SelectList RegionList
        {
            get;
            set;
        }

        public SelectList CountryList
        {
            get;
            set;
        }

        public SelectList StateList
        {
            get;
            set;
        }

        public SelectList DistrictList
        {
            get;
            set;
        }

        public SelectList LocationList
        {
            get;
            set;
        }

        public SelectList CompanyList
        {
            get;
            set;
        }

        public SelectList CompanyTypeList
        {
            get;
            set;
        }

        public SelectList ModulesList
        {
            get;
            set;
        }

        public SelectList MenuList
        {
            get;
            set;
        }

        public ICollection<ProductEnquiryDetails> ProductEnquiryDetails { get; set; }

        public ICollection<PurchaseRequestDetails> PurchaseRequestDetails { get; set; }

        public string ItemTypeName { get; set; }
        public Decimal TotalCost { get; set; }

        public decimal TotalAdvanceAmount { get; set; }

        public SalesQuotationDetails SQDetails { get; set; }

        public PurchaseQuotationDetails PQDetails { get; set; }

        public ICollection<SQAdvanceDetails> SQAdvanceDetails { get; set; }
        public ICollection<PQAdvanceDetails> PQAdvanceDetails { get; set; }
        public string SQCode { get; set; }
        public string StatusName { get; set; }
        public string EnquiryLevelName { get; set; }
        public string SQCreatedDate { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymerMode { get; set; }

        public string CheckNo { get; set; }

        public string PQCode { get; set; }
        public string PQCreatedDate { get; set; }

        public string CreatedDateString { get; set; }

        public ICollection<StockOutExpenseDetails> StockOutExpenseDetails { get; set; }
        public Decimal TotalExpenseCost { get; set; }


        public string VehicleNo
        {
            get;
            set;
        }

        public string DisapatchTime
        {
            get;
            set;
        }

        public decimal ExpenseTypeAmount
        {
            get;
            set;
        }

        public string DriverName
        {
            get;
            set;
        }

        public string DriverLicenceNumber
        {
            get;
            set;
        }

        public decimal AdditionalAmountPaid
        {
            get;
            set;
        }
        public string ContainerNo
        {
            get;
            set;
        }

        public bool IsDispatchApproved
        {
            get;
            set;
        }

        public int? AssignedWHSupervisorID
        {
            get;
            set;
        }


    }
}
