using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class StockInShortageDetails
    {
        public StockInShortageDetails()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }


        [ForeignKey("PurchaseOrder")]
        public int POID
        {
            get;
            set;
        }

        [ForeignKey("ItemMaster")]
        public int ItemID
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }


       

        public string Size
        {
            get;
            set;
        }

        public decimal itemprice
        {
            get;
            set;
        }

        public PurchaseOrder PurchaseOrder
        { get; set; }

        public ItemMaster ItemMaster
        { get; set; }


    }
}