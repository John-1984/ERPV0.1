using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class StockOutExpenseDetails
    {
        public StockOutExpenseDetails()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }


        [ForeignKey("SalesQuotation")]
        public int? SQID
        {
            get;
            set;
        }

        [ForeignKey("ExpenseType")]
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