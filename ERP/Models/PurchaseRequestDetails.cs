using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class PurchaseRequestDetails
    {
        public PurchaseRequestDetails()
        {
            Identity = -1;
            ItemSize = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string ItemSize
        {
            get;
            set;
        }

        public int PurchaseRequestID
        {
            get;
            set;
        }

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

        [DefaultValue(0)]
        public decimal ItemPrice
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