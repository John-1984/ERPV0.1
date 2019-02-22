using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class Brand
    {
        public Brand()
        {
            Identity = -1;
            BrandName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter brand name")]
        public string BrandName
        {
            get;
            set;
        }

        
        public int VendorID
        {
            get;
            set;
        }
        public int VendorName
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
        public SelectList VendorList
        {
            get;
            set;
        }
        public List<string> ErrorList
        {
            get;
            set;
        }


        public Vendor Vendor
        {
            get;
            set;
        }
    }
}