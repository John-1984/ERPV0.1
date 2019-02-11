using System;
using System.Collections.Generic;
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

        public string EmployeeName
        { get; set; }              

        public string officialemail
        { get; set; }

        public string PersonalEmail
        { get; set; }

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


        public string OfficialContactNo
        { get; set; }

        public string AlternateContactNo
        { get; set; }

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