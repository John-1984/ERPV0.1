using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class ItemMaster
    {
        public ItemMaster()
        {
            Identity = -1;
            ItemName = string.Empty;
            Description = String.Empty;
            ItemSize = String.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please enter item name")]
        public string ItemName
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Description
        {
            get;
            set;
        }
        public int BrandID
        {
            get;
            set;
        }
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
        public string VendorName
        {
            get;
            set;
        }
        public int UOMID
        {
            get;
            set;
        }

        public int UOMName
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public decimal  ItemWeight
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public decimal RetailPrice
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public decimal PurchacePrice
        {
            get;
            set;
        }

        [DefaultValue("")]
        public String ItemSize
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

        public SelectList UOMList
        {
            get;
            set;
        }

        public SelectList BrandList
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