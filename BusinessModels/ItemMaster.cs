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

        [ForeignKey("Brand")]
        public int BrandID
        {
            get;
            set;
        }
        

        [ForeignKey("UOMMaster")]
        public int UOMID
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


        public DateTime? CreatedDate
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public int? CreatedBy
        {
            get;
            set;
        }

        public Brand Brand
        {
            get;
            set;
        }

        public UOMMaster UOMMaster
        {
            get;
            set;
        }
    }
}