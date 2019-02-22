using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class Company
    {
        public Company()
        {
            Identity = -1;
            CompanyName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string CompanyName
        {
            get;
            set;
        }

        public int CompanytypeID
        {
            get;
            set;
        }

        public int LocationID
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
        public string RegionName
        {
            get;
            set;
        }
        public string CountryName
        {
            get;
            set;
        }
        public string StateName
        {
            get;
            set;
        }
        public string DistrictName
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public string RegionID
        {
            get;
            set;
        }
        public string CountryID
        {
            get;
            set;
        }
        public string StateID
        {
            get;
            set;
        }
        public string DistrictID
        {
            get;
            set;
        }
        public string CompanyTypeName
        {
            get;
            set;
        }
        public List<string> ErrorList
        {
            get;
            set;
        }

        public SelectList CompanyTypeList
        {
            get;
            set;
        }

        public SelectList LocationList
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

        public Location Location
        {
            get;
            set;
        }
    }
}