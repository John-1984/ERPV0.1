using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Discount
    {
        public Discount()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

       
        public decimal DiscountValue
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

        public ItemMaster ItemMaster
        {
            get;set;
        }
    }
}