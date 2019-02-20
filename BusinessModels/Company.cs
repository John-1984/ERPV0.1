﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Company
    {
        public Company()
        {
            Identity = -1;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

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
    }
}