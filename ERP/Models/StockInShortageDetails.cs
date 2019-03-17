using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{ 
    public class StockInShortageDetails
    {
        public StockInShortageDetails()
        {
            Identity = -1;
        }

        [Key]
        public Int32 Identity
        {
            get;
            set;
        }


        public int POID
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

        public decimal itemprice
        {
            get;
            set;
        }

        public PurchaseOrder PurchaseOrder
        { get; set; }

        public ItemMaster ItemMaster
        { get; set; }

        public SelectList ProductMasterList
        { get; set; }

        public SelectList VendorList
        { get; set; }

        public SelectList BrandList
        { get; set; }

        public SelectList ItemList
        { get; set; }


    }
}