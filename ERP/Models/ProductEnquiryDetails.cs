using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class ProductEnquiryDetails
    {
        public ProductEnquiryDetails()
        {
            Identity = -1;
            Size = string.Empty;
        }

        [Key]
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

        public decimal ItemPrice
        {
            get;
            set;
        }

        public SelectList ProductMasterList
        { get; set; }

        public SelectList VendorList
        { get; set; }

        public SelectList BrandList
        { get; set; }

        public SelectList ItemList
        { get; set; }

        public ItemMaster ItemMaster
        { get; set; }



    }
}