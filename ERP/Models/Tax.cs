using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class Tax
    {
        public Tax()
        {
            Identity = -1;
        //    CountryName = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public decimal TaxValue 
        {
            get;
            set;
        }

        public int BrandID
        {
            get;
            set;
        }

        public int ItemID
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