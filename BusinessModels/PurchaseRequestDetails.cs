using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseRequestDetails
    {
        public PurchaseRequestDetails()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }       
        

        [ForeignKey("PurchaseRequest")]
        public int PurchaseRequestID
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

        
        public string Purpose
        {
            get;
            set;
        }

        public string Size
        {
            get;
            set;
        }

        public PurchaseRequest PurchaseRequest
        { get; set; }

        public ItemMaster ItemMaster
        { get; set; }


    }
}