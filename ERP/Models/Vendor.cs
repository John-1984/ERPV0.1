using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class Vendor
    {
        public Vendor()
        {
            Identity = -1;
            VendorName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter vendor name")]
        public string VendorName
        {
            get;
            set;
        }  
        
        public int ProductMasterID
        { get; set; }

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

        public SelectList ProductMasterList
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