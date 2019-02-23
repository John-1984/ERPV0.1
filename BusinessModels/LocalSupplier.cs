using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class LocalSupplier
    {
        public LocalSupplier()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string SupplierName
        {
            get;
            set;
        }
        
        public string Email
        {
            get;
            set;
        }

        
        public string Address
        {
            get;
            set;
        }

        public String ContactNumber
        {
            get;
            set;
        }

        [ForeignKey("Location")]
        public int? LocationID
        {
            get;
            set;
        }

        [ForeignKey("ItemMaster")]
        public int? ItemID
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

        public Location Location
        {
            get;
            set;
        }

        public ItemMaster ItemMaster
        {
            get;
            set;
        }
    }
}