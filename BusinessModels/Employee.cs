using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class Employee
    {
        public Employee()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }
        public string EmployeeName
        { get; set; }



        public string OfficialEmail
        { get; set; }

        public string PersonalEmail
        { get; set; }

       

        public string Address
        { get; set; }

        public string PersonalContactNo
        { get; set; }


        public string OfficialContactNo
        { get; set; }

        public string AlternateContactNo
        { get; set; }

        public string Qualification
        { get; set; }


        public int IdentificationID
        { get; set; }

        public string IdentificationValue
        { get; set; }

        public string Photo
        { get; set; }

        public string CompanyID
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