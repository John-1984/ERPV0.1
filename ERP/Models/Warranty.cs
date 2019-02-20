using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class Warranty
    {
        public Warranty()
        {
            Identity = -1;
           // CountryName = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue(0)]
        [Required(ErrorMessage ="Please enter warranty value")]
        public int WarrantyValue
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }

        public string ItemName
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

        public SelectList ItemList
        {
            get;
            set;
        }

        public List<string> ErrorList
        {
            get;
            set;
        }

    }
}