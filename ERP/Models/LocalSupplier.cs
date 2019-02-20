﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class LocalSupplier
    {
        public LocalSupplier()
        {
            Identity = -1;
            SupplierName = string.Empty;
            Email = String.Empty;
            Address = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter supplier name")]
        public string SupplierName
        {
            get;
            set;
        }
        [DefaultValue("")]
        public string Email
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Address
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage = "Please enter contact number")]
        public int ContactNumber
        {
            get;
            set;
        }

        public int LocationID
        {
            get;
            set;
        }

        public string LocationName
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


        public SelectList LocationList
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