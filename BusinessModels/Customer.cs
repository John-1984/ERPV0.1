using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Customer
    {
        public Customer()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

       

        public string CustomerName
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string ContactNumber
        {
            get;
            set;
        }

        public string Profession
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

        [ForeignKey("Status")]
        public int? StatusID
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

        public string Address
        {
            get;
            set;
        }

        public string EmailID
        {
            get;
            set;
        }

        [ForeignKey("Purpose")]
        public int? PurposeID
        {
            get;
            set;
        }

        public string Quantity
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

        [ForeignKey("EnquiryLevel")]
        public int? EnquiryLevelID
        { get; set; }

        public EnquiryLevel EnquiryLevel
        { get; set; }

        public Location Location
        {
            get;
            set;
        }

        public Status Status
        {
            get;
            set;
        }

        public Purpose Purpose
        {
            get;
            set;
        }

        public Employee Employee
        {
            get;
            set;
        }

        public Boolean IsActive
        { get; set; }

    }
}
