using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class StockOutExpenseDetails
    {
        public StockOutExpenseDetails()
        {
            Identity = -1;
            Amount = 0;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        public int? SQID
        {
            get;
            set;
        }

        public int? ExpenseTypeID
        {
            get;
            set;
        }
        
        public decimal Amount
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


        public bool IsActive
        {
            get;
            set;
        }

        public SalesQuotation SalesQuotation
        { get; set; }

        public ExpenseType ExpenseType
        { get; set; }

    }
}