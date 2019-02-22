using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class CompanyType
    {
        public CompanyType()
        {
            Identity = -1;
            TypeName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter company type name.")]
        public string TypeName
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string CompanyName
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

        public List<string> ErrorList
        {
            get;
            set;
        }

        public SelectList CompanyList
        {
            get;
            set;
        }
        public SelectList RegionList
        {
            get;
            set;
        }
        public SelectList CountryList
        {
            get;
            set;
        }
        public SelectList StateList
        {
            get;
            set;
        }

        public SelectList DistrictList
        {
            get;
            set;
        }
        public SelectList LocationList
        {
            get;
            set;
        }
        public Company Company
        {
            get;
            set;
        }
    }
}