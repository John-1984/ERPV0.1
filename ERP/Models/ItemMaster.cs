using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
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

        public int UOMID
        {
            get;
            set;
        }

        public int WarrantyID
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


    }
}