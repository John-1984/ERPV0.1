using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class OfficeExpense
    {
        public OfficeExpense()
        {
            Identity = -1;
        }

       [Key]
        public Int32 Identity
        {
            get;
            set;
        }
        public string Comments
        { get; set; }
        public decimal Amount
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }

        public int CompanyTypeID
        {
            get;
            set;
        }

        public int ExpenseID
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
        
        public SelectList ExpenseTypeList
        { get; set; }

        public Location Location
        {
            get;
            set;
        }

        public CompanyType CompanyType
        {
            get;
            set;
        }
        public Boolean IsActive
        { get; set; }

        public int AssignedTo
        { get; set; }

        public int VerifiedBy
        {
            get;
            set;
        }
        public int OriginatorID
        { get; set; }
        public int ApprovedBy
        {
            get;
            set;
        }
        public ExpenseType ExpenseType
        {
            get;
            set;
        }

        public Employee Employee
        {
            get;
            set;
        }
        public int StatusID
        { get; set; }

        public Status Status
        {
            get;
            set;
        }

    }
}