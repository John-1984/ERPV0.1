﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace ERP.Models
{
    public class District
    {
        public District()
        {
            Identity = -1;
            DistrictName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter district Name")]
        public string DistrictName
        {
            get;
            set;
        }

        public int StateID
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
        public int RegionID
        {
            get;
            set;
        }
        public int CountryID
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

        public List<string> ErrorList
        {
            get;
            set;
        }

        public State State
        {
            get;
            set;
        }

    }
}