using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class OfficeExpense
    {
        public OfficeExpense()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }       

        [ForeignKey("Location")]
        public int LocationID
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

        [ForeignKey("ExpenseType")]
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
        public decimal Amount
        {
            get;
            set;
        }
        public string Comments
        { get; set; }

        [ForeignKey("Status")]
        public int StatusID
        { get; set; }


        public Boolean IsActive
        { get; set; }
        public int VerifiedBy
        {
            get;
            set;
        }
        public int ApprovedBy
        {
            get;
            set;
        }

        public int OriginatorID
        { get; set; }
        [ForeignKey("Employee")]
        public int AssignedTo
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

        public ExpenseType ExpenseType
        {
            get;
            set;
        }
        public Status Status
        {
            get;
            set;
        }

        public Employee Employee
        {
            get;
            set;
        }



    }
}