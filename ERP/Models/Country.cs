﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace ERP.Models
{
    public class Country
    {

        public Country()
        {
            Identity = -1;
            CountryName = string.Empty;
            RegionList = null;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter country name")]
        public string CountryName
        {
            get;
            set;
        }
        
        public int RegionID
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
        public List<string> ErrorList
        {
            get;
            set;
        }

        public SelectList RegionList
        {
            get;
            set;
        }

        public string PageInfo
        {
            get;
            set;
        }
    }
}