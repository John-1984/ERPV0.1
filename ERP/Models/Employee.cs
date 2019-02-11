using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessModels;
using X.PagedList;


namespace ERP.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        [Required]
        public string EmployeeName
        { get; set; }


        // [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Please enter valid email.")]

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string officialemail
        { get; set; }

        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PersonalEmail
        { get; set; }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        public int RoleMasterID
        { get; set; }


        public int LocationID
        { get; set; }

        public string Address
        { get; set; }

        public string PersonalContactNo
        { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]

        [Phone(ErrorMessage ="Please enter valid phone number.")]
        public string OfficialContactNo
        { get; set; }

        [Phone(ErrorMessage = "Please enter valid phone number.")]
        public string AlternateContactNo
        { get; set; }

        [Phone(ErrorMessage = "Please enter valid phone number.")]
        public string Qualification
        { get; set; }


        public string IdentificationID
        { get; set; }

        public string IdentificationValue
        { get; set; }

        public string Photo
        { get; set; }

        public string CompanyID
        { get; set; }

        public int managerID
        { get; set; }

        public string StaffID
        { get; set; }

    }
}