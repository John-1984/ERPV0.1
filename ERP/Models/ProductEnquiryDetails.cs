using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ERP.Models
{
    public class ProductEnquiryDetails
    {
        public ProductEnquiryDetails()
        {
            Identity = -1;
            Size = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        public int ProductEnquiryID
        {
            get;
            set;
        }
        public int itemID
        {
            get;
            set;
        }
        public int Quantitiy
        {
            get;
            set;
        }
        [DefaultValue("")]
        public string Size
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






    }
}