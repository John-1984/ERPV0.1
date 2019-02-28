using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BusinessModels;
using X.PagedList;

namespace ERP.Models
{
    public class Customer 
    {
        public Customer()
        {
            Identity = -1;
            CustomerName = string.Empty;
            Profession = string.Empty;
            EmailID = string.Empty;
            Quantity = string.Empty;
            CreatedDate = DateTime.Now;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter customer name")]
        public string CustomerName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please enter customer contact number")]
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
        public string Comments
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

        [Required(ErrorMessage = "Please enter customer email id")]
        public string EmailID
        {
            get;
            set;
        }

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
        public SelectList EmployeeList
        {
            get;
            set;
        }

        public SelectList EnquiryLevelList
        {
            get;
            set;
        }

        public Employee Employee
        {
            get;
            set;
        }

        public Purpose Purpose
        {
            get;
            set;
        }

        public SelectList StatusList
        {
            get;
            set;
        }

        public SelectList PurposeList
        {
            get;
            set;
        }

        public Boolean IsActive
        { get; set; }
    }
}
