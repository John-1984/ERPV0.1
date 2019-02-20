using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BusinessModels;
using X.PagedList;


namespace ERP.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        [Required(ErrorMessage ="Please enter name")]
        public string EmployeeName
        { get; set; }


        // [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Please enter valid email.")]

        [Required(ErrorMessage = "Please enter official email id")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string OfficialEmail
        { get; set; }

        //[DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter personal email id")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PersonalEmail
        { get; set; }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
       
        public string Address
        { get; set; }

        [Required(ErrorMessage = "Please enter contact number")]
        public string PersonalContactNo
        { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]

        [Required(ErrorMessage = "Please enter official contact number")]
        [Phone(ErrorMessage ="Please enter valid phone number.")]
        public string OfficialContactNo
        { get; set; }

        [Phone(ErrorMessage = "Please enter valid phone number.")]
        public string AlternateContactNo
        { get; set; }

        [Phone(ErrorMessage = "Please enter valid phone number.")]
        public string Qualification
        { get; set; }


        public int IdentificationID
        { get; set; }

        public string IdentificationValue
        { get; set; }

        public string Photo
        { get; set; }

        public int CompanyID
        { get; set; }

        public int ManagerID
        { get; set; }

        public string StaffCode
        { get; set; }

        public int RoleMasterID
        { get; set; }


        public int LocationID
        { get; set; }

        public int CompanyTypeID
        { get; set; }

        public string RoleName
        { get; set; }

        public string LocationName
        { get; set; }

        public string TypeName
        { get; set; }

        public string IdentificationName
        { get; set; }

        public string CompanyName
        { get; set; }

        public SelectList RoleList
        {
            get;
            set;
        }

        public SelectList ManagerList
        {
            get;
            set;
        }

        public SelectList ComapnyTypeList
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

        public SelectList IdentificationList
        {
            get;
            set;
        }
        public List<string> ErrorList
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
    }
}