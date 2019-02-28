using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class Stocks
    {
        public Stocks()
        {
            Identity = -1;
            Size = "";
            Quantity = 0;
        }

        [Key]
        public Int32 Identity
        {
            get;
            set;
        }


        public int ItemID
        {
            get;
            set;
        }



        public int? LocationId
        {
            get;
            set;
        }



        public string Size
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public int CompanyTypeID
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

        public CompanyType CompanyType
        {
            get;
            set;
        }

        public Boolean IsActive
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
