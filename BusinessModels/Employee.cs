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

        [ForeignKey("IdentificationsType")]
        public int? IdentificationID
        { get; set; }

        public string IdentificationValue
        { get; set; }

        public string Photo
        { get; set; }

        [ForeignKey("Company")]
        public int? CompanyID
        { get; set; }

        public int? ManagerID
        { get; set; }

        public string StaffCode
        { get; set; }

        [ForeignKey("RoleMaster")]
        public int? RoleMasterID
        { get; set; }

        [ForeignKey("Location")]
        public int? LocationID
        { get; set; }

        [ForeignKey("CompanyType")]
        public int? CompanyTypeID
        { get; set; }

        [ForeignKey("FloorMaster")]
        public int? FloorMasterID
        { get; set; }

        [ForeignKey("Login")]
        public int? LoginID
        { get; set; }


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

        public RoleMaster RoleMaster
        { get; set; }

        public Location Location
        { get; set; }

        public CompanyType CompanyType
        { get; set; }

        public FloorMaster FloorMaster
        { get; set; }

        public IdentificationsType IdentificationsType
        { get; set; }

        public Company Company
        { get; set; }

        public Login Login
        { get; set; }

        public Boolean IsActive
        { get; set; }
    }
}