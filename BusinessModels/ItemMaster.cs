using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class ItemMaster
    {
        public ItemMaster()
        {
           
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

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

        public decimal ItemWeight
        {
            get;
            set;
        }

        public decimal RetailPrice
        {
            get;
            set;
        }

        public decimal PurchacePrice
        {
            get;
            set;
        }

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